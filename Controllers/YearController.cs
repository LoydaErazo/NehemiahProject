using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UINProject.Models;

namespace UINProject.Controllers
{
    public class YearController : Controller
    {
        Contexto contexto = new Contexto();
        // GET: Year
        public ActionResult Index()
        {
            var listyear = contexto.Years.ToList();
            return View(listyear);
        }

        public ActionResult AddEditYear(int IdYear = 0)
        {
            var year = new Years();

            if (IdYear > 0)
            {
                year = contexto.Years.FirstOrDefault(x => x.IdYear == IdYear);
            }
            return View(year);
        }

        [HttpPost]
        public ActionResult AddEditYear(Years years)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(years).State = years.IdYear > 0 ? EntityState.Modified : EntityState.Added;
                contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(years);
        }

        public ActionResult DeleteYear(int IdYear)
        {
            var model = contexto.Years.FirstOrDefault(x => x.IdYear == IdYear);
            contexto.Entry(model).State = EntityState.Deleted;
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}