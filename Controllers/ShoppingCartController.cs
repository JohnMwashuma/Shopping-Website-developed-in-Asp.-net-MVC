using GrandLabFixers.Models;
using GrandLabFixers.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace GrandLabFixers.Controllers
{
    [SelectedTab("ShoppingCart")]
    public class ShoppingCartController : Controller
    {
        public ApplicationDbContext Context;

        public ShoppingCartController()
        {
            Context = new ApplicationDbContext();
        }
        // GET: ShoppingCart

        [AllowAnonymous]
        public ActionResult Index(ShoppingCart model, string Page)
        {
            string shoppingCartId = model.GetCardId();
            var allCarts = Context.Carts.Include(c => c.Product).Count(c => c.CartId == shoppingCartId);

            IEnumerable<Cart> viewModel = Context.Carts.Include(c => c.Product).Where(c => c.CartId == shoppingCartId).ToList();
            ViewBag.TotalPages = Math.Ceiling(allCarts / 2.0);
            int page = int.Parse(Page ?? "1");
            ViewBag.Page = page;
            viewModel = viewModel.Skip((page - 1) * 2).Take(2);
            ViewBag.GetTotal = model.GetTotal();

            return View(viewModel);
        }

        [Authorize]
        public ActionResult RequestQuote()
        {

            var viewModel = new RequestQuoteForm()
            {
                Countries = Context.Countries.ToList(),
                Salutations = Context.Salutations.ToList(),

            };

            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQoute(RequestQuoteForm form, ShoppingCart viewModel, string cartId)
        {

            if (!ModelState.IsValid)
            {
                var viewmodel = new RequestQuoteForm()
                {
                    Countries = Context.Countries.ToList(),
                    Salutations = Context.Salutations.ToList()

                };
                return View("RequestQuote", viewmodel);
            }

            var country = Context.Countries.Single(c => c.Id == form.Country);
            var salutation = Context.Salutations.Single(c => c.Id == form.Salutation);

            using (ShoppingCart usersShoppingCart = new ShoppingCart())
            {
                List<Cart> myOrderList = usersShoppingCart.GetCartItems();

                for (int i = 0; i < myOrderList.Count; i++)
                {
                    var productid = myOrderList[i].ProductId;
                    var product = Context.Products.Single(c => c.Id == productid);
                    var orderDetail = new RequestQuote();
                    orderDetail.Id = myOrderList[i].ProductId;
                    orderDetail.ProductName = product.Name;
                    orderDetail.FirstName = form.FirstName;
                    orderDetail.LastName = form.LastName;
                    orderDetail.Email = form.Email;
                    orderDetail.Company = form.Company;
                    orderDetail.Department = form.Department;
                    orderDetail.Quantity = myOrderList[i].Quantity;
                    orderDetail.Message = form.Message;
                    orderDetail.Salutation = salutation;
                    orderDetail.City = form.City;
                    orderDetail.Country = country;
                    orderDetail.PhoneNumber = form.PhoneNumber;
                    orderDetail.PostalCode = form.PostalCode;
                    orderDetail.Address = form.Address;
                    orderDetail.OrderDate = DateTime.Now;


                    Context.RequestQuotes.Add(orderDetail);
                }
            }

            Context.SaveChanges();
            viewModel.EmptyCart(cartId);

            return RedirectToAction("index", "Home");
        }


        public ActionResult QuotationView(int id)
        {
            var quote = Context.RequestQuotes.Include(c => c.Product).Include(c => c.Country).SingleOrDefault(c => c.QuoteId == id);
            var countryId = quote.Country.Id;
            var countryName = Context.Countries.Single(c => c.Id == countryId);

            var viewModel = new RequestQuoteForm()
            {
                Heading = "Quotation Details",
                ProductName = quote.Product.Name,
                Image = quote.Product.Image,
                Quantity = quote.Quantity,
                Institution = quote.Company,
                LastName = quote.LastName,
                Email = quote.Email,
                CountryName = countryName,
                RequestDate = quote.OrderDate,
                Message = quote.Message

            };

            return View(viewModel);
        }


        [AllowAnonymous]
        public ActionResult RequestService(int id)
        {
            var viewModel = new RequestServiceForm()
            {
                Countries = Context.Countries.ToList(),
                Salutations = Context.Salutations.ToList(),
                ServiceTypes = Context.ServiceTypes.ToList()

            };

            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateService(RequestServiceForm form, int id)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new RequestServiceForm()
                {
                    Countries = Context.Countries.ToList(),
                    Salutations = Context.Salutations.ToList(),
                    ServiceTypes = Context.ServiceTypes.ToList()

                };
                return View("RequestService", viewmodel);
            }


            var country = Context.Countries.Single(c => c.Id == form.Country);
            var salutation = Context.Salutations.Single(c => c.Id == form.Salutation);
            var services = Context.Serviceses.SingleOrDefault(c => c.ServiceId == id);

            //StringBuilder sb = new StringBuilder();
            //sb.Append("").AppendLine();
            //foreach (var item in form.ServiceTypes)
            //{
            //    if (item.IsSelected == true)
            //    {
            //        sb.Append(item.Name + "").AppendLine();
            //    }
            //}


            var serviceRequest = new RequestService()
            {
                //ServiceId = id,
                Services = services,
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Company = form.Company,
                Department = form.Department,
                Message = form.Message,
                Salutation = salutation,
                City = form.City,
                Country = country,
                PhoneNumber = form.PhoneNumber,
                PostalCode = form.PostalCode,
                Address = form.Address,
                ServiceName = services.Name,
                //OtherServiceType = form.OtherServiceType,
                //ServiceType = sb.ToString(),
                RequestDate = DateTime.Now
            };

            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("jmwashuma@live.com"));  // replace with valid value 
            message.From = new MailAddress("jmwashuma@live.com");  // replace with valid value
            message.Subject = "Request for " + services.Name + " Service";
            message.Body = string.Format(body, form.FirstName, form.LastName, form.Email, form.Message);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "jmwashuma@live.com",  // replace with valid value
                    Password = "6927yoloo"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(message);
                Context.RequestServices.Add(serviceRequest);
                Context.SaveChanges();
                return RedirectToAction("index", "Home");
            }




        }

        public ActionResult ServiceView(int id)
        {
            var service = Context.RequestServices.Include(c => c.Services).Include(c => c.Product).Include(c => c.Country).SingleOrDefault(c => c.ServiceId == id);
            var countryId = service.Country.Id;
            var countryName = Context.Countries.Single(c => c.Id == countryId);

            var viewModel = new RequestServiceForm()
            {
                Heading = "Service Details",
                Image = service.Services.Image,
                LastName = service.LastName,
                Email = service.Email,
                CountryName = countryName,
                ServiceName = service.ServiceName,
                RequestDate = service.RequestDate,
                Message = service.Message,
                PhoneNumber = service.PhoneNumber

            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Checkout()
        {
            var viewModel = new OrderForm()
            {
                Countries = Context.Countries.ToList()
            };
            return View(viewModel);
        }



        [Authorize]
        [HttpPost]
        public ActionResult CreateOrder(Order order, ShoppingCart viewModel, OrderForm form, string cartId, Product product)
        {
            var country = Context.Countries.Single(c => c.Id == form.Country);
            //decimal orderTotal = 0;

            using (ShoppingCart usersShoppingCart = new ShoppingCart())
            {
                List<Cart> myOrderList = usersShoppingCart.GetCartItems();

                for (int i = 0; i < myOrderList.Count; i++)
                {
                    var orderDetail = new Order();
                    orderDetail.Quantity = myOrderList[i].Quantity;
                    orderDetail.ProductId = myOrderList[i].ProductId;
                    orderDetail.ClientName = User.Identity.Name;
                    orderDetail.FirstName = form.FirstName;
                    orderDetail.LastName = form.LastName;
                    orderDetail.Company = form.Company;
                    orderDetail.City = form.City;
                    orderDetail.Country = country;
                    orderDetail.Phone = form.Phone;
                    orderDetail.AdditionalPhone = form.AdditionalPhone;
                    orderDetail.Address = form.Address;
                    orderDetail.OrderDate = DateTime.Now;


                    Context.Orders.Add(orderDetail);
                }
            }

            Context.SaveChanges();
            viewModel.EmptyCart(cartId);


            return RedirectToAction("SalesDashboard", "Products");
        }

        [AllowAnonymous]
        public ActionResult EmptyCart(ShoppingCart viewModel)
        {
            string cartId = viewModel.GetCardId();
            if (cartId != null)
            {
                viewModel.EmptyCart(cartId);
            }

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult RemoveCartItem(ShoppingCart viewModel, int id)
        {

            viewModel.RemoveFromCart(id);

            return RedirectToAction("Index");
        }


    }
}