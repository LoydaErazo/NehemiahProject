using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UINProject.Models;

namespace UINProject.Controllers
{
    public class EstudianteController : Controller
    {
        Contexto contexto = new Contexto();
        // GET: Estudiante
        public ActionResult Index()
        {
            var model = contexto.Estudiantes.ToList();
            return View(model);
        }
        public ActionResult CrearEditarEstudiante(int IdEstudiante=0)
        {
            var model = IdEstudiante > 0 ? contexto.Estudiantes.FirstOrDefault(x => x.IdEstudiante == IdEstudiante)
                                           : new Estudiantes();
            return View(model);
        }

        [HttpPost]
        public ActionResult CrearEditarEstudiante(Estudiantes model)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(model).State = model.IdEstudiante > 0 ? EntityState.Modified : EntityState.Added;
                contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult EliminarEstudiante(int IdEstudiante)
        {
            var model = contexto.Estudiantes.FirstOrDefault(x => x.IdEstudiante == IdEstudiante);
            contexto.Entry(model).State = EntityState.Deleted;
            contexto.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
