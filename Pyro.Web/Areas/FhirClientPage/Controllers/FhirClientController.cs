using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pyro.Web.Areas.FhirClientPage.Controllers
{
  [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]   
  public class FhirClientController : Controller
    {
        // GET: FhirClientPage/FhirClient
        public ActionResult Index()
        {
            var temp = new Models.FhirClientViewModel();
            return View(temp);
        }

        // GET: FhirClientPage/FhirClient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FhirClientPage/FhirClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FhirClientPage/FhirClient/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FhirClientPage/FhirClient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FhirClientPage/FhirClient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FhirClientPage/FhirClient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FhirClientPage/FhirClient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
