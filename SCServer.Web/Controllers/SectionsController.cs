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
    public class SectionsController : Controller
    {


        // GET: Sections
        public async Task<ActionResult> Index()
        {

            IWebApiHelper webapi = new WebApiHelper("section", false);
            var all_sections = await webapi.Get<List<Section>>("");

            return View(all_sections);
        }

        // GET: Sections/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IWebApiHelper webapi = new WebApiHelper("section", false);
            var section = await webapi.Get<Section>(id.ToString());


            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: Sections/Create
        public async Task<ActionResult> Create(Guid? id)
        {

            Section section = new Section();
            ViewBag.EditionId = await GetEditions(id);
            return View(section);
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sort_Key,Name,Enabled")] Section section)
        {
            if (ModelState.IsValid)
            {
                section.Id = Guid.NewGuid();
                IWebApiHelper webapi = new WebApiHelper("section", false);
                section = await webapi.Post<Section>("", section);
                return RedirectToAction("Index");
            }
            ViewBag.EditionId = await GetEditions(section.EditionId);
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IWebApiHelper webapi = new WebApiHelper("section", false);
            var section = await webapi.Get<Section>(id.ToString());
            ViewBag.EditionId = await GetEditions(section.EditionId );

            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sort_Key,Name,Enabled")] Section section)
        {
            if (ModelState.IsValid)
            {
                section.Id = Guid.NewGuid();
                IWebApiHelper webapi = new WebApiHelper("section", false);
                section = await webapi.Put<Section>(section);
                return RedirectToAction("Index");
            }
            ViewBag.EditionId = await GetEditions(section.EditionId);
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IWebApiHelper webapi = new WebApiHelper("section", false);
            var section = await webapi.Get<Section>(id.ToString());
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                IWebApiHelper webapi = new WebApiHelper("section", false);
                await webapi.Delete<Section>(id.ToString());

            }
            catch
            { ViewBag.Message = "Cannot delete this record"; }
            return RedirectToAction("Index");
        }

        private static async Task<List<SelectListItem>> GetEditions(Guid? id)
        {
            IWebApiHelper webapi = new WebApiHelper("edition", false);
            var all_editions = await webapi.Get<List<Edition>>("");

            var list = new List<SelectListItem>();

            foreach (var edition in all_editions)
            {
                var item = new SelectListItem { Selected = false, Text = edition.Name, Value = edition.Id.ToString() };
                list.Add(item);
            }
            if (id.HasValue)
                list.Where(i => i.Value == id.ToString()).First().Selected=true;
            else

                list.First().Selected = true;

            return list;
        }
    }
}
