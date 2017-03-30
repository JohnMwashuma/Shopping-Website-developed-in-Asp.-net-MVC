using GrandLabFixers.Models;
using GrandLabFixers.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandLabFixers.Controllers
{
    [Authorize(Roles = RoleName.CanManageProducts)]
    public class ProductsController : Controller
    {

        public ApplicationDbContext _Context;
        private ApplicationUserManager _userManager;

        public ProductsController()
        {
            _Context = new ApplicationDbContext();
        }

        public ProductsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Create()
        {
            var viewModel = new ProductsForm
            {
                Heading = "Add a Product",
                Categories = _Context.Categories.ToList(),
                Product = _Context.Products.ToList()
            };
            return View("ProductForm", viewModel);
        }
        public ActionResult CreateService()
        {
            var viewModel = new ServiceViewModel()
            {
                Heading = "Add a Service",
                ServiceCategories = _Context.ServiceCategories.ToList(),
            };
            return View("ServiceForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateService([Bind(Exclude = "Image")] ServiceViewModel viewModel)
        {
            byte[] imagedata = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase image = Request.Files["Image"];
                if (image != null)
                    using (BinaryReader binary = new BinaryReader(image.InputStream))
                    {
                        imagedata = binary.ReadBytes(image.ContentLength);

                    }

            }

            var servicecategory = _Context.ServiceCategories.Single(c => c.ServiceCategoryId == viewModel.ServiceCategory);


            var service = new Services()
            {
                Name = viewModel.Name,
                ServiceCategory = servicecategory,
                Details = viewModel.Details,
                Price = viewModel.Price,
                Image = imagedata,

            };
            _Context.Serviceses.Add(service);
            //try
            //{
            //     _Context.SaveChanges();
            // }
            //catch (DbEntityValidationException e)
            //{

            //    Console.WriteLine(e);
            //}
            _Context.SaveChanges();
            return RedirectToAction("AllServices");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Image")] ProductsForm viewModel)
        {


            byte[] imagedata = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase image = Request.Files["Image"];
                if (image != null)
                    using (BinaryReader binary = new BinaryReader(image.InputStream))
                    {
                        imagedata = binary.ReadBytes(image.ContentLength);

                    }

            }
            var category = _Context.Categories.Single(c => c.Id == viewModel.Category);

            var product = new Product()
            {
                Name = viewModel.Name,
                Details = viewModel.Details,
                Price = viewModel.Price,
                Category = category,
                IsFeatured = viewModel.IsFeatured,
                Image = imagedata,
                Quantity = viewModel.Quantity
            };
            _Context.Products.Add(product);
            //try
            //{
            //     _Context.SaveChanges();
            // }
            //catch (DbEntityValidationException e)
            //{

            //    Console.WriteLine(e);
            //}
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Exclude = "Image")] ProductsForm viewModel)
        {
            var category = _Context.Categories.Single(c => c.Id == viewModel.Category);

            var product = _Context.Products.SingleOrDefault(c => c.Id == viewModel.Id);

            var imagevalue = _Context.Products.Single(c => c.Id == viewModel.Id);

            //var productImage = _Context.Products.Single(c => c.Image == imagevalue.Image);


            byte[] imagedata = null;
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                HttpPostedFileBase image = Request.Files["Image"];
                if (image != null)
                {
                    using (BinaryReader binary = new BinaryReader(image.InputStream))
                    {
                        imagedata = binary.ReadBytes(image.ContentLength);

                    }
                    product.Image = imagedata;
                }

            }
            else
            {
                //HttpPostedFileBase Image = Request.Files[Convert.ToString(imagevalue.Image)];

                //if (Image != null)
                //    using (BinaryReader binary = new BinaryReader(Image.InputStream))
                //    {
                //        imagedata = binary.ReadBytes(Image.ContentLength);

                //    }
                product.Image = imagevalue.Image;


            }


            product.Name = viewModel.Name;
            product.Details = viewModel.Details;
            product.Price = viewModel.Price;
            product.Category = category;
            product.IsFeatured = viewModel.IsFeatured;

            product.Quantity = viewModel.Quantity;
            //try
            //{
            //     _Context.SaveChanges();
            // }
            //catch (DbEntityValidationException e)
            //{

            //    Console.WriteLine(e);
            //}
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateService([Bind(Exclude = "Image")] ServiceViewModel viewModel)
        {


            var servicecategory = _Context.ServiceCategories.Single(c => c.ServiceCategoryId == viewModel.ServiceCategory);

            var service = _Context.Serviceses.SingleOrDefault(c => c.ServiceId == viewModel.Id);

            var imagevalue = _Context.Serviceses.Single(c => c.ServiceId == viewModel.Id);


            byte[] imagedata = null;
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                HttpPostedFileBase image = Request.Files["Image"];
                if (image != null)
                {
                    using (BinaryReader binary = new BinaryReader(image.InputStream))
                    {
                        imagedata = binary.ReadBytes(image.ContentLength);

                    }
                    service.Image = imagedata;
                }

            }
            else
            {
                //HttpPostedFileBase Image = Request.Files[Convert.ToString(imagevalue.Image)];

                //if (Image != null)
                //    using (BinaryReader binary = new BinaryReader(Image.InputStream))
                //    {
                //        imagedata = binary.ReadBytes(Image.ContentLength);

                //    }
                service.Image = imagevalue.Image;


            }

            service.Name = viewModel.Name;
            service.ServiceCategory = servicecategory;
            service.Details = viewModel.Details;
            service.Price = viewModel.Price;
            //try
            //{
            //     _Context.SaveChanges();
            // }
            //catch (DbEntityValidationException e)
            //{

            //    Console.WriteLine(e);
            //}
            _Context.SaveChanges();
            return RedirectToAction("AllServices");
        }

        [AllowAnonymous]
        public ActionResult BiologyLab(string Page, string search)
        {

            var allProducts = _Context.Products.Count(c => c.Category.Name == "Ring Stands, Clamps and Supports");

            //var viewModel = new ShoppingCart()
            //{
            //   Product = _Context.Products.Where(c => c.Category.Name == "Biology").ToList()
            //};

            IEnumerable<Product> viewModel = _Context.Products.Where(c => c.Category.Name == "Ring Stands, Clamps and Supports").ToList();
            if (!String.IsNullOrEmpty(search))
            {
                viewModel = viewModel.Where(c => c.Name.ToLower().StartsWith(search.ToLower()));
                //products = (from N in products where N.Name.StartsWith(searchString) select new { N.Name });
            }
            ViewBag.TotalPages = Math.Ceiling(allProducts / 2.0);
            int page = int.Parse(Page ?? "1");
            ViewBag.Page = page;
            viewModel = viewModel.Skip((page - 1) * 2).Take(2);
            return View(viewModel);

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddCart(int id, string cartId, ShoppingCart viewModel)
        {
            cartId = viewModel.GetCardId();

            var addedproduct = _Context.Carts.FirstOrDefault(c => c.CartId == cartId && c.ProductId == id);

            if (addedproduct == null)
            {
                addedproduct = new Cart()
                {
                    CartId = cartId,
                    ProductId = id,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                _Context.Carts.Add(addedproduct);
            }
            else
            {
                addedproduct.Quantity++;
            }

            _Context.SaveChanges();
            return RedirectToAction("Index", "ShoppingCart");
        }

        [SelectedTab("SalesDashboard")]
        public ActionResult SalesDashboard()
        {
            var model = new IndexViewModel
            {
                FirstName = FirstName(),
                LastName = LastName()

            };
            return View(model);
        }

        private string FirstName()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());

            return user.FirstName;

        }

        private string LastName()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());

            return user.LastName;

        }

        [SelectedTab("Index")]
        public ActionResult Index(string Page)
        {
            //var allProducts = _Context.Products.Count();

            IEnumerable<Product> viewModel = _Context.Products.ToList();
            //ViewBag.TotalPages = Math.Ceiling(allProducts / 3.0);
            //int page = int.Parse(Page ?? "1");
            //ViewBag.Page = page;
            //viewModel = viewModel.Skip((page - 1) * 3).Take(3);

            //var viewModel = new ProductsForm
            //{
            //   Products = _Context.Products.ToList()
            //};
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Productdetails(int id)
        {
            var products = _Context.Products.SingleOrDefault(c => c.Id == id);
            var product = new Product()
            {
                Id = id,
                Name = products.Name,
                Details = products.Details,
                Image = products.Image,
            };
            return View(product);
        }

        [AllowAnonymous]
        public ActionResult ServiceDetails(int id)
        {
            var services = _Context.Serviceses.SingleOrDefault(c => c.ServiceId == id);
            var service = new Product()
            {
                Id = id,
                Name = services.Name,
                Details = services.Details,
                Image = services.Image,
            };
            return View("productdetails", service);
        }

        public ActionResult Orders()
        {
            var viewModel = new OrderForm()
            {
                Orders = _Context.Orders
               .Include(c => c.Product).Include(c => c.OrderDetail)
               .Include(c => c.Country).ToList()
            };
            return View(viewModel);
        }

        [SelectedTab("ProductQuotes")]
        public ActionResult ProductQuotes(string Page)
        {
            //var allQuotes = _Context.RequestQuotes
            //    .Include(c => c.Product).Include(c => c.Salutation)
            //    .Include(c => c.Country).Count();

            IEnumerable<RequestQuote> viewModel = _Context.RequestQuotes
                .Include(c => c.Product).Include(c => c.Salutation)
                .Include(c => c.Country).ToList();
            //ViewBag.TotalPages = Math.Ceiling(allQuotes / 3.0);
            //int page = int.Parse(Page ?? "1");
            //ViewBag.Page = page;
            //viewModel = viewModel.Skip((page - 1) * 3).Take(3);

            return View(viewModel);
        }

        [SelectedTab("ServiceRequests")]
        public ActionResult ServiceRequests(string Page)
        {

            //var allQuotes = _Context.RequestServices
            //    .Include(c => c.Product)
            //    //.Include(c => c.Services)
            //    .Include(c => c.Salutation)
            //    .Include(c => c.Country).Count();

            IEnumerable<RequestService> viewModel = _Context.RequestServices
                .Include(c => c.Product)
                //.Include(c => c.Services)
                .Include(c => c.Salutation)
                .Include(c => c.Country).ToList();
            //ViewBag.TotalPages = Math.Ceiling(allQuotes / 3.0);
            //int page = int.Parse(Page ?? "1");
            //ViewBag.Page = page;
            //viewModel = viewModel.Skip((page - 1) * 3).Take(3);

            return View(viewModel);
        }
        [AllowAnonymous]
        [SelectedTab("MyServiceRequests")]
        public ActionResult MyServiceRequests(string Page)
        {
            var customerEmail = User.Identity.GetUserName();
            var allServices = _Context.RequestServices.Include(c => c.Product)
               .Include(c => c.Salutation).Include(c => c.Country).Count(c => c.Email == customerEmail);

            IEnumerable<RequestService> viewModel = _Context.RequestServices
                .Include(c => c.Product).Include(c => c.Salutation)
                .Include(c => c.Country).Where(c => c.Email == customerEmail).ToList();
            ViewBag.TotalPages = Math.Ceiling(allServices / 3.0);
            int page = int.Parse(Page ?? "1");
            ViewBag.Page = page;
            viewModel = viewModel.Skip((page - 1) * 3).Take(3);

            return View(viewModel);
        }

        [AllowAnonymous]
        [SelectedTab("MyQuotations")]
        public ActionResult MyQuotations(string Page)
        {
            var customerEmail = User.Identity.GetUserName();
            var allQuotes = _Context.RequestQuotes.Include(c => c.Product)
             .Include(c => c.Salutation).Include(c => c.Country).Count(c => c.Email == customerEmail);

            IEnumerable<RequestQuote> viewModel = _Context.RequestQuotes
                .Include(c => c.Product).Include(c => c.Salutation)
                .Include(c => c.Country).Where(c => c.Email == customerEmail).ToList();
            ViewBag.TotalPages = Math.Ceiling(allQuotes / 3.0);
            int page = int.Parse(Page ?? "1");
            ViewBag.Page = page;
            viewModel = viewModel.Skip((page - 1) * 3).Take(3);


            return View(viewModel);
        }


        public ActionResult RemoveServiceItem(RequestServiceForm viewModel, int id)
        {

            viewModel.RemoveServiceItem(id);

            return RedirectToAction("Index");
        }


        public ActionResult RemoveQuoteItem(RequestQuoteForm viewModel, int id)
        {

            viewModel.RemoveQuoteItem(id);

            return RedirectToAction("Index");
        }


        public ActionResult RemoveProductItem(ProductsForm viewModel, int id)
        {

            viewModel.RemoveFromProduct(id);

            return RedirectToAction("Index");
        }


        public ActionResult RemoveOrder(OrderForm viewModel, int id)
        {
            viewModel.RemoveFromOrder(id);

            return RedirectToAction("Orders");
        }


        public ActionResult Edit([Bind(Exclude = "Image")] int id)
        {
            var product = _Context.Products.SingleOrDefault(c => c.Id == id);

            //byte[] imagedata = null;
            //if (Request.Files.Count > 0)
            //{
            //    HttpPostedFileBase image = Request.Files["Image"];
            //    if (image != null)
            //        using (BinaryReader binary = new BinaryReader(image.InputStream))
            //        {
            //            if (product != null) product.Image = binary.ReadBytes(image.ContentLength);
            //        }

            //}


            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductsForm
            {
                Heading = "Edit a Product",
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = (int)product.Quantity,
                Image = product.Image,
                Categories = _Context.Categories.ToList(),
                Category = product.Category.Id,
                IsFeatured = product.IsFeatured,
                Details = product.Details

            };

            return View("ProductForm", viewModel);
        }

        public ActionResult Editservice([Bind(Exclude = "Image")] int id)
        {
            var service = _Context.Serviceses.SingleOrDefault(c => c.ServiceId == id);

            //byte[] imagedata = null;
            //if (Request.Files.Count > 0)
            //{
            //    HttpPostedFileBase image = Request.Files["Image"];
            //    if (image != null)
            //        using (BinaryReader binary = new BinaryReader(image.InputStream))
            //        {
            //            if (product != null) product.Image = binary.ReadBytes(image.ContentLength);
            //        }

            //}


            if (service == null)
                return HttpNotFound();

            var viewModel = new ServiceViewModel()
            {
                Heading = "Edit a Service",
                Id = service.ServiceId,
                Name = service.Name,
                ServiceCategories = _Context.ServiceCategories.ToList(),
                ServiceCategory = service.ServiceCategory.ServiceCategoryId,
                Price = service.Price,
                Image = service.Image,
                Details = service.Details

            };

            return View("ServiceForm", viewModel);
        }

        public ActionResult ProductView([Bind(Exclude = "Image")] int id)
        {
            var product = _Context.Products.Include(c => c.Category).SingleOrDefault(c => c.Id == id);
            var categoryId = product.Category.Id;
            var categoryName = _Context.Categories.Single(c => c.Id == categoryId);

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductsForm
            {
                Heading = "Product Details",
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                Quantity = (int)product.Quantity,
                Categories = _Context.Categories.ToList(),
                CategoryName = categoryName,
                IsFeatured = product.IsFeatured,
                Details = product.Details

            };

            return View(viewModel);
        }

        public ActionResult ServiceView([Bind(Exclude = "Image")] int id)
        {
            var service = _Context.Serviceses.Include(c => c.ServiceCategory).SingleOrDefault(c => c.ServiceId == id);
            var categoryId = service.ServiceCategory.ServiceCategoryId;
            var categoryName = _Context.ServiceCategories.Single(c => c.ServiceCategoryId == categoryId);


            if (service == null)
                return HttpNotFound();

            var viewModel = new ServiceViewModel();
            viewModel.Heading = "Sevice Details";
            viewModel.Id = service.ServiceId;
            viewModel.Name = service.Name;
            viewModel.ServiceCategories = _Context.ServiceCategories.ToList();
            viewModel.ServiceCategoryName = categoryName;
            viewModel.Price = service.Price;
            viewModel.Image = service.Image;
            viewModel.Details = service.Details;



            return View(viewModel);
        }

        public ActionResult ExportAllProducts(string reporttype)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/SupportReports/SupportReports/GrandLabProducts.rdl");

            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DBM3JBC; Initial Catalog=GrandLabFixers; User ID=sa; Password=6927mwashi;");
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = string.Format("SELECT Products.Name, Products.Details, Products.Price, Products.Quantity, Categories.Name AS Expr1 FROM Products INNER JOIN Categories ON Products.Category_Id = Categories.Id");
            ////cmd.CommandText = string.Format("SELECT        tickets.title, tickets.[content], tickets.created_at, status.name FROM tickets INNER JOIN ticket_status ON tickets.id = ticket_status.[ticket_id ] INNER JOIN status ON ticket_status.status_id = status.id");
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //con.Close();

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            //reportDataSource.Value = dt;
            reportDataSource.Value = _Context.Products.ToList();

            localReport.DataSources.Add(reportDataSource);

            string reportType = reporttype;
            string mimeType;
            string encoding;
            string fileNameExtention = (reporttype == "Excel") ? "xlsx" : "doc";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtention,
                out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename=All Products." + fileNameExtention);

            return File(renderedBytes, fileNameExtention);
        }
        public ActionResult ExportTo(string reporttype, int id)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/SupportReports/SupportReports/GrandLabProducts.rdl");

            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DBM3JBC; Initial Catalog=GrandLabFixers; User ID=sa; Password=6927mwashi;");
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = string.Format("SELECT Products.Name, Products.Details, Products.Price, Products.Quantity, Categories.Name AS Expr1 FROM Products INNER JOIN Categories ON Products.Category_Id = Categories.Id");
            ////cmd.CommandText = string.Format("SELECT        tickets.title, tickets.[content], tickets.created_at, status.name FROM tickets INNER JOIN ticket_status ON tickets.id = ticket_status.[ticket_id ] INNER JOIN status ON ticket_status.status_id = status.id");
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //con.Close();

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            //reportDataSource.Value = dt;
            reportDataSource.Value = _Context.Products.Include(c => c.Category).Where(c => c.Id == id).ToList();

            localReport.DataSources.Add(reportDataSource);

            string reportType = reporttype;
            string mimeType;
            string encoding;
            string fileNameExtention = (reporttype == "Excel") ? "xlsx" : "pdf";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtention,
                out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename=All Products." + fileNameExtention);

            return File(renderedBytes, fileNameExtention);
        }
        public ActionResult AllPrintQuotes(string reporttype)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/SupportReports/SupportReports/PriceQuotations.rdl");

            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DBM3JBC; Initial Catalog=GrandLabFixers; User ID=sa; Password=6927mwashi;");
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = string.Format("SELECT Products.Name, Products.Details, Products.Price, Products.Quantity, Categories.Name AS Expr1 FROM Products INNER JOIN Categories ON Products.Category_Id = Categories.Id");
            ////cmd.CommandText = string.Format("SELECT        tickets.title, tickets.[content], tickets.created_at, status.name FROM tickets INNER JOIN ticket_status ON tickets.id = ticket_status.[ticket_id ] INNER JOIN status ON ticket_status.status_id = status.id");
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //con.Close();

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            //reportDataSource.Value = dt;
            reportDataSource.Value = _Context.RequestQuotes.ToList();

            localReport.DataSources.Add(reportDataSource);

            string reportType = reporttype;
            string mimeType;
            string encoding;
            string fileNameExtention = (reporttype == "Excel") ? "xlsx" : "pdf";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtention,
                out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename=Price Quotation Request." + fileNameExtention);

            return File(renderedBytes, fileNameExtention);
        }
        public ActionResult PrintQuotes(string reporttype, int id, int productId)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/SupportReports/SupportReports/PriceQuotations.rdl");

            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DBM3JBC; Initial Catalog=GrandLabFixers; User ID=sa; Password=6927mwashi;");
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = string.Format("SELECT Products.Name, Products.Details, Products.Price, Products.Quantity, Categories.Name AS Expr1 FROM Products INNER JOIN Categories ON Products.Category_Id = Categories.Id");
            ////cmd.CommandText = string.Format("SELECT        tickets.title, tickets.[content], tickets.created_at, status.name FROM tickets INNER JOIN ticket_status ON tickets.id = ticket_status.[ticket_id ] INNER JOIN status ON ticket_status.status_id = status.id");
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //con.Close();

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            //reportDataSource.Value = dt;
            var allquotes = _Context.RequestQuotes.Include(c => c.Product).SingleOrDefault(c => c.QuoteId == id);
            var productid = allquotes.Product.Id;
            var productName = _Context.Products.Single(c => c.Id == productid);
            reportDataSource.Value = _Context.RequestQuotes.Include(c => c.Product).Where(c => c.QuoteId == id && c.Product.Name == productName.Name).ToList();

            localReport.DataSources.Add(reportDataSource);

            string reportType = reporttype;
            string mimeType;
            string encoding;
            string fileNameExtention = (reporttype == "Excel") ? "xlsx" : "pdf";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtention,
                out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename=Price Quotation Request." + fileNameExtention);

            return File(renderedBytes, fileNameExtention);
        }

        [SelectedTab("AllServices")]
        public ActionResult AllServices(string Page)
        {
            //var allServices = _Context.Serviceses.Count();

            IEnumerable<Services> viewModel = _Context.Serviceses.ToList();
            //ViewBag.TotalPages = Math.Ceiling(allServices / 3.0);
            //int page = int.Parse(Page ?? "1");
            //ViewBag.Page = page;
            //viewModel = viewModel.Skip((page - 1) * 3).Take(3);

            return View(viewModel);
        }
    }
}