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


        public async Task<ActionResult> Buy()
        {
            Customer customer = new Customer();



            ViewBag.EditionId = await GetEditions();
  
            return View(customer);
        }

        private static async Task<List<SelectListItem>> GetEditions()
        {
            IWebApiHelper webapi = new WebApiHelper("edition", false);
            var all_editions = await webapi.Get<List<Edition>>("");

            var list = new List<SelectListItem>();

            foreach (var edition in all_editions)
            {
                var item = new SelectListItem { Selected = false, Text = edition.Name, Value = edition.Id.ToString() };
                list.Add(item);
            }

            list.First().Selected = true;

            return list;
        }
        [HttpPost]
        public async Task<ActionResult> Buy(Customer customer)
        {
            customer.SecurityKey =   Guid.NewGuid ();
            IWebApiHelper webapi = new WebApiHelper("customer", false);
            Customer c= await webapi.Post<Customer>("", customer);
            ViewBag.EditionId = await GetEditions();
            return View(c);
        }

         
    }
}