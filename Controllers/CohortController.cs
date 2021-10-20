using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UINProject.Models;

namespace UINProject.Controllers
{
    public class CohortController : Controller
    {
        Contexto contexto = new Contexto();
        // GET: Cohort
        public ActionResult Index()
        {
            var listaCohortes = contexto.Cohortes.ToList();
            return View(listaCohortes);
        }

        public ActionResult AgregarEditarCohorte(int IdCohorte=0)
        {
            var model = IdCohorte > 0 ? contexto.Cohortes.FirstOrDefault(x => x.IdCohorte == IdCohorte)
                                       : new Cohortes();

            ViewBag.YearsList = YearsList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AgregarEditarCohorte(Cohortes model)
        {
            if (ModelState.IsValid)
            {
                if (model.IdCohorte > 0)
                {
                    //Arreglamos el asnotracking para que no genere conflicto con el otro modelo   
                    var DatoExistente = contexto.Cohortes.AsNoTracking().FirstOrDefault(x => x.IdYear == model.IdYear);
                    var EsMismoDato = model.IdCohorte == DatoExistente.IdCohorte;

                    if (EsMismoDato)
                    {
                        contexto.Entry(model).State = EntityState.Modified;
                        contexto.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Existe = true;
                    }
                }

                else
                {
                    var ExisteYear = contexto.Cohortes.Where(x => x.IdYear == model.IdYear).Any();
                    if (!ExisteYear)
                    {
                        contexto.Entry(model).State = EntityState.Added;
                        contexto.SaveChanges();
                        return RedirectToAction("Index");  //any ayuda a contar si existe

                    }
                    else
                    {
                        ViewBag.Existe = true;
                    }
                }

            }

            ViewBag.YearsList = YearsList();
            return View(model);
        }

        //por orden primeros son los publicos y luego los privados
        public ActionResult EliminarCohorte(int IdCohorte)
        {
            var model = contexto.Cohortes.FirstOrDefault(x => x.IdCohorte == IdCohorte);
            contexto.Entry(model).State = EntityState.Deleted;
            contexto.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult AsignarEstudiante(int IdCohorte)
        {

            var model = contexto.Estudiantes.Where(x => x.IdCohorte == null).ToList();
            ViewBag.IdCohorte = IdCohorte;
            return View(model);
        }

        public ActionResult AsignarEstudiante(int IdEstudiante, int IdCohorte)
        {
            var estudiante = contexto.Estudiantes.FirstOrDefault(x => x.IdEstudiante == IdEstudiante);
            if (contexto.Cohortes.Where(x => x.IdCohorte == IdCohorte).Any())
            {
                estudiante.IdCohorte = IdCohorte;

                contexto.Entry(estudiante).State = EntityState.Modified;
                contexto.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        private List<SelectListItem> YearsList()
        {
            var listaYears = new List<SelectListItem>();

            foreach (var year in contexto.Years.ToList())
            {
                listaYears.Add(new SelectListItem() { Text = year.NombreYear, Value = year.IdYear.ToString() });

            }
            return listaYears;
        }
    }
}