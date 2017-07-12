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
    public class ModulesController : Controller
    {


        // GET: Modules
        public async Task<ActionResult> Index()
        {

            IWebApiHelper webapi = new WebApiHelper("module", false);
            var all_modules = await webapi.Get<List<Module>>("");

            return View(all_modules);
        }

        // GET: Modules/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IWebApiHelper webapi = new WebApiHelper("module", false);
            var module = await webapi.Get<Module>(id.ToString());


            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {

            Module module = new Module();
            return View(module);
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sort_Key,Name,Enabled,TypeName")] Module module)
        {
            if (ModelState.IsValid)
            {
                module.Id = Guid.NewGuid();
                IWebApiHelper webapi = new WebApiHelper("module", false);
                module = await webapi.Post<Module>("", module);
                return RedirectToAction("Index");
            }

            return View(module);
        }

        // GET: Modules/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IWebApiHelper webapi = new WebApiHelper("module", false);
            var module = await webapi.Get<Module>(id.ToString());


            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sort_Key,Name,Enabled,TypeName")] Module module)
        {
            if (ModelState.IsValid)
            {
               
                IWebApiHelper webapi = new WebApiHelper("module", false);
                module = await webapi.Put<Module>(module);
                return RedirectToAction("Index");
            }
            return View(module);
        }

        // GET: Modules/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IWebApiHelper webapi = new WebApiHelper("module", false);
            var module = await webapi.Get<Module>(id.ToString());
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                IWebApiHelper webapi = new WebApiHelper("module", false);
                await webapi.Delete<Module>(id.ToString());

            }
            catch
            { ViewBag.Message = "Cannot delete this record"; }
            return RedirectToAction("Index");
        }


    }
}
