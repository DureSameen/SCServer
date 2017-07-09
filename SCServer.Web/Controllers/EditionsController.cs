using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCServer.Core.Dto;
using SCServer.Web.Models;
using SCServer.Common.Helpers;

namespace SCServer.Web.Controllers
{
    public class EditionsController : Controller
    {
        

        // GET: Editions
        public async Task<ActionResult> Index()
        {
           
            IWebApiHelper webapi = new WebApiHelper("edition", false);
            var all_editions= await webapi.Get<List<Edition>>("");

            return View(all_editions);
        }

        // GET: Editions/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            IWebApiHelper webapi = new WebApiHelper("edition", false);
            var edition = await webapi.Get<Edition>(id.ToString ());

            
            if (edition == null)
            {
                return HttpNotFound();
            }
            return View(edition);
        }

        // GET: Editions/Create
        public ActionResult Create()
        {

            Edition edition = new Edition();
            return View(edition);
        }

        // POST: Editions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sort_Key,Name,Enabled")] Edition edition)
        {
            if (ModelState.IsValid)
            {
                edition.Id = Guid.NewGuid();
                IWebApiHelper webapi = new WebApiHelper("edition", false);
                edition  = await webapi.Post<Edition>("", edition);
                return RedirectToAction("Index");
            }

            return View(edition);
        }

        // GET: Editions/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IWebApiHelper webapi = new WebApiHelper("edition", false);
            var edition = await webapi.Get<Edition>(id.ToString());

            
            if (edition == null)
            {
                return HttpNotFound();
            }
            return View(edition);
        }

        // POST: Editions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sort_Key,Name,Enabled")] Edition edition)
        {
            if (ModelState.IsValid)
            {
                edition.Id = Guid.NewGuid();
                IWebApiHelper webapi = new WebApiHelper("edition", false);
                edition = await webapi.Put<Edition>(edition);
                return RedirectToAction("Index");
            }
            return View(edition);
        }

        // GET: Editions/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IWebApiHelper webapi = new WebApiHelper("edition", false);
            var edition = await webapi.Get<Edition>(id.ToString());
            if (edition == null)
            {
                return HttpNotFound();
            }
            return View(edition);
        }

        // POST: Editions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                IWebApiHelper webapi = new WebApiHelper("edition", false);
                await webapi.Delete<Edition>(id.ToString());

            }
            catch
            { ViewBag.Message = "Cannot delete this record";  }
            return RedirectToAction("Index");
        }

       
    }
}
