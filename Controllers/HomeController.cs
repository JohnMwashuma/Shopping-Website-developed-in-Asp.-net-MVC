using GrandLabFixers.Models;
using GrandLabFixers.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GrandLabFixers.Controllers
{
    [SelectedTab("Home")]
    public class HomeController : Controller
    {
        public ApplicationDbContext Context;

        public HomeController()
        {
            Context = new ApplicationDbContext();
        }

        [AllowAnonymous]
        public ActionResult Service(string Page, string search, ServiceViewModel model)
        {

            ViewBag.Fumigation = model.GetTotal("Fumigation Services");
            ViewBag.BedBug = model.GetTotal("Bed Bug Control Services");
            ViewBag.Rodent = model.GetTotal("Rodent Control Services");
            ViewBag.Termite = model.GetTotal("Termite Control Services");
            ViewBag.Rodent = model.GetTotal("Rodent Control Services");
            ViewBag.CockRoach = model.GetTotal("CockRoach Control Services");
            ViewBag.Mosquito = model.GetTotal("Mosquito Control Services");
            ViewBag.Ant = model.GetTotal("Ant Control Services");
            ViewBag.Flies = model.GetTotal("Flies Control Services");
            ViewBag.Mite = model.GetTotal("Mite Control Services");
            ViewBag.Sanitary = model.GetTotal("Sanitary Bins Cleaning Services");

            var allservices = Context.Serviceses.Count();
            IEnumerable<Services> services = Context.Serviceses.Include(c => c.ServiceCategory).ToList();
            if (!String.IsNullOrEmpty(search))
            {
                services = services.Where(c => c.Name.ToLower().StartsWith(search.ToLower()));
            }
            ViewBag.TotalPages = Math.Ceiling(allservices / 4.0);
            int page = int.Parse(Page ?? "1");
            ViewBag.Page = page;
            services = services.Skip((page - 1) * 4).Take(4);

            return View(services);
        }

        [AllowAnonymous]
        public ActionResult Index(string Page, string search, ProductsForm model, string urlname)
        {

            ViewBag.Dissection = model.GetTotal("Dissection Tools");
            ViewBag.LifeScience = model.GetTotal("Life Science");
            ViewBag.Bacteria = model.GetTotal("Agar, Petri Dishes, And Bacteria");
            ViewBag.RingStands = model.GetTotal("Ring Stands, Clamps and Supports");
            ViewBag.Thermometers = model.GetTotal("Thermometers");
            ViewBag.Distillation = model.GetTotal("Distillation Glassware and Equipment");
            ViewBag.OrganicChemistry = model.GetTotal("Organic Chemistry Equipment");
            ViewBag.PeriodicTables = model.GetTotal("Models and Periodic Tables");
            ViewBag.GlassandRubber = model.GetTotal("Glass and Rubber Tubing");
            ViewBag.Stoppers = model.GetTotal("Stoppers and Corks");
            ViewBag.Beakers = model.GetTotal("Beakers");
            ViewBag.Flasks = model.GetTotal("Flasks");
            ViewBag.Cylinders = model.GetTotal("Graduated Cylinders");
            ViewBag.LabGlassware = model.GetTotal("Pyrex Lab Glassware");
            ViewBag.TestTubes = model.GetTotal("Test Tubes");
            ViewBag.Funnels = model.GetTotal("Funnels");
            ViewBag.Burettes = model.GetTotal("Burettes");
            ViewBag.Droppers = model.GetTotal("Pipettes and Droppers");
            ViewBag.Bottles = model.GetTotal("Bottles and Jars");
            ViewBag.EvaporatingDishes = model.GetTotal("Evaporating Dishes and Test Plates");
            ViewBag.Mortar = model.GetTotal("Mortar and Pestles");
            ViewBag.Crucibles = model.GetTotal("Crucibles");
            ViewBag.Chemicals = model.GetTotal("Chemicals");
            ViewBag.SafetyEquipment = model.GetTotal("Safety Equipment");
            ViewBag.MeasuringTools = model.GetTotal("Measuring Tools");
            ViewBag.SpringScales = model.GetTotal("Spring Scales and Balances");
            ViewBag.MassesWeights = model.GetTotal("Masses and Weights");
            ViewBag.PhysicsThermometers = model.GetTotal("Physics Thermometers");
            ViewBag.Electricity = model.GetTotal("Electricity");
            ViewBag.Magnets = model.GetTotal("Magnets and Magnetism");


            var allProducts = Context.Products.Count();
            IEnumerable<Product> products = Context.Products.Include(c => c.Category).ToList();

            if (!String.IsNullOrEmpty(urlname))
            {
                allProducts = Context.Products.Count(c => c.Category.Name == urlname);
                products = Context.Products.Where(c => c.Category.Name == urlname).ToList();


            }
            else
            {
                products = Context.Products.Include(c => c.Category).ToList();

            }
            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(c => c.Name.ToLower().StartsWith(search.ToLower()));
                //products = (from N in products where N.Name.StartsWith(searchString) select new { N.Name });
            }
            ViewBag.TotalPages = Math.Ceiling(allProducts / 3.0);
            int page = int.Parse(Page ?? "1");
            ViewBag.Page = page;
            products = products.Skip((page - 1) * 3).Take(3);

            return View(products);
        }

        [AllowAnonymous]
        public ActionResult filters(string Page, string search, ProductsForm model, string urlname)
        {
            ViewBag.Dissection = model.GetTotal("Dissection Tools");
            ViewBag.LifeScience = model.GetTotal("Life Science");
            ViewBag.Bacteria = model.GetTotal("Agar, Petri Dishes, And Bacteria");
            ViewBag.RingStands = model.GetTotal("Ring Stands, Clamps and Supports");
            ViewBag.Thermometers = model.GetTotal("Pyrex Lab Glassware");
            ViewBag.Distillation = model.GetTotal("Distillation Glassware and Equipment");
            ViewBag.OrganicChemistry = model.GetTotal("Organic Chemistry Equipment");
            ViewBag.PeriodicTables = model.GetTotal("Models and Periodic Tables");
            ViewBag.GlassandRubber = model.GetTotal("Glass and Rubber Tubing");
            ViewBag.Stoppers = model.GetTotal("Stoppers and Corks");
            ViewBag.Beakers = model.GetTotal("Beakers");
            ViewBag.Flasks = model.GetTotal("Flasks");
            ViewBag.Cylinders = model.GetTotal("Graduated Cylinders");
            ViewBag.LabGlassware = model.GetTotal("Pyrex Lab Glassware");
            ViewBag.TestTubes = model.GetTotal("Test Tubes");
            ViewBag.Funnels = model.GetTotal("Funnels");
            ViewBag.Burettes = model.GetTotal("Burettes");
            ViewBag.Droppers = model.GetTotal("Pipettes and Droppers");
            ViewBag.Bottles = model.GetTotal("Bottles and Jars");
            ViewBag.EvaporatingDishes = model.GetTotal("Evaporating Dishes and Test Plates");
            ViewBag.Mortar = model.GetTotal("Mortar and Pestles");
            ViewBag.Crucibles = model.GetTotal("Crucibles");
            ViewBag.Chemicals = model.GetTotal("Chemicals");
            ViewBag.SafetyEquipment = model.GetTotal("Safety Equipment");
            ViewBag.MeasuringTools = model.GetTotal("Measuring Tools");
            ViewBag.SpringScales = model.GetTotal("Spring Scales and Balances");
            ViewBag.MassesWeights = model.GetTotal("Masses and Weights");
            ViewBag.PhysicsThermometers = model.GetTotal("Physics Thermometers");
            ViewBag.Electricity = model.GetTotal("Electricity");
            ViewBag.Magnets = model.GetTotal("Magnets and Magnetism");
            @ViewBag.UrlName = urlname;


            var allProducts = Context.Products.Count(c => c.Category.Name == urlname);
            IEnumerable<Product> dissectionproducts = Context.Products.Where(c => c.Category.Name == urlname).ToList();
            if (!String.IsNullOrEmpty(search))
            {
                dissectionproducts = dissectionproducts.Where(c => c.Name.ToLower().StartsWith(search.ToLower()));
                //products = (from N in products where N.Name.StartsWith(searchString) select new { N.Name });
            }
            ViewBag.TotalPages = Math.Ceiling(allProducts / 3.0);
            int page = int.Parse(Page ?? "1");
            ViewBag.Page = page;
            dissectionproducts = dissectionproducts.Skip((page - 1) * 3).Take(3);

            return View("Index", dissectionproducts);
        }

        [AllowAnonymous]
        public ActionResult servicefilter(string Page, string search, ServiceViewModel model, string urlname)
        {
            ViewBag.Fumigation = model.GetTotal("Fumigation Services");
            ViewBag.BedBug = model.GetTotal("Bed Bug Control Services");
            ViewBag.Rodent = model.GetTotal("Rodent Control Services");
            ViewBag.Termite = model.GetTotal("Termite Control Services");
            ViewBag.Rodent = model.GetTotal("Rodent Control Services");
            ViewBag.CockRoach = model.GetTotal("CockRoach Control Services");
            ViewBag.Mosquito = model.GetTotal("Mosquito Control Services");
            ViewBag.Ant = model.GetTotal("Ant Control Services");
            ViewBag.Flies = model.GetTotal("Flies Control Services");
            ViewBag.Mite = model.GetTotal("Mite Control Services");
            ViewBag.Sanitary = model.GetTotal("Sanitary Bins Cleaning Services");


            var allservices = Context.Serviceses.Count(c => c.ServiceCategory.Name == urlname);
            IEnumerable<Services> services = Context.Serviceses.Where(c => c.ServiceCategory.Name == urlname).ToList();
            if (!String.IsNullOrEmpty(search))
            {
                services = services.Where(c => c.Name.ToLower().StartsWith(search.ToLower()));
            }
            ViewBag.TotalPages = Math.Ceiling(allservices / 4.0);
            int page = int.Parse(Page ?? "1");
            ViewBag.Page = page;
            services = services.Skip((page - 1) * 4).Take(4);

            return View("Service", services);

        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}