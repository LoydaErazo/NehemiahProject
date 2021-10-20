using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UINProject.Models;

namespace UINProject.Controllers
{
    public class EspecialidadController : Controller
    {
        Contexto contexto = new Contexto();


        // GET: Especialidades
        public ActionResult Index()
        {
            var ListEspe = contexto.Especialidades.ToList();
            return View(ListEspe);
        }

        public ActionResult AgregarEditarEspecialidad(int IdEspecialidad = 0)
        {
            var especialidad = new Especialidades();
            if (IdEspecialidad > 0)
            {
                especialidad = contexto.Especialidades.FirstOrDefault(x => x.IdEspecialidad == IdEspecialidad);
            }

            return View(especialidad);
        }

        [HttpPost]
        public ActionResult AgregarEditarEspecialidad(Especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(especialidades).State = especialidades.IdEspecialidad > 0 ? EntityState.Modified : EntityState.Added;
                contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(especialidades);

        }
        public ActionResult EliminarEspecialidades(int IdEspecialidad)
        {
            var model = contexto.Especialidades.FirstOrDefault(x => x.IdEspecialidad == IdEspecialidad);
            contexto.Entry(model).State = EntityState.Deleted;
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AsignarEstudiantes(int IdEspecialidad)
        {
            var model = contexto.Estudiantes.Where(x => x.IdEspecialidad == null).ToList();
            ViewBag.IdEspecialidad = IdEspecialidad;

            return View(model);
        }
        public ActionResult Asignar( int IdEstudiante, int IdEspecialidad)
        {
            var Estudiante = contexto.Estudiantes.FirstOrDefault(x => x.IdEstudiante == IdEstudiante);
            if(contexto.Especialidades.Where(x=>x.IdEspecialidad == IdEspecialidad).Any())
            {
                Estudiante.IdEspecialidad = IdEspecialidad;
                contexto.Entry(Estudiante).State = EntityState.Modified;
                contexto.SaveChanges();
            }

          return  RedirectToAction("Index");
        }
    }
}