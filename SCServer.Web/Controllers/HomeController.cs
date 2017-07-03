using SCServer.Common.Helpers;
using SCServer.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SCServer.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Buy()
        {
            Customer customer = new Customer();
            ViewBag.EditionId = 
   new List<SelectListItem>
    {
        new SelectListItem { Selected = true, Text = "Standard", Value = "23e02380-bf3b-4f53-a070-504e4d496fb1"},
        new SelectListItem { Selected = false, Text = "Professional", Value = "90621209-375e-4276-81d1-969a53771f73" },
        new SelectListItem { Selected = false, Text = "Ultimate", Value = "443fee9e-89d1-4981-ac69-01c2bbbe0763" },
    };
            return View(customer);
        }
        [HttpPost]
        public async Task<ActionResult> Buy(Customer customer)
        {
            customer.SecurityKey =   Guid.NewGuid ();
            IWebApiHelper webapi = new WebApiHelper("customer", false);
            Customer c= await webapi.Post<Customer>("", customer);
            ViewBag.EditionId =
  new List<SelectListItem>
    {
        new SelectListItem { Selected = true, Text = "Standard", Value = "23e02380-bf3b-4f53-a070-504e4d496fb1"},
        new SelectListItem { Selected = false, Text = "Professional", Value = "90621209-375e-4276-81d1-969a53771f73" },
        new SelectListItem { Selected = false, Text = "Ultimate", Value = "443fee9e-89d1-4981-ac69-01c2bbbe0763" },
    };
            return View(c);
        }

         
    }
}