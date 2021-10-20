using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UINProject.Models;

namespace UINProject.Controllers
{
    public class DepartamentoController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Departamento
        public ActionResult Index()
        {
            var listaDepar = contexto.Departamentos.ToList();
            return View(listaDepar);
        }

        public ActionResult AgregarEditarDepartamento(int IdDireccion = 0)
        {
            var departamento = new Departamentos();
            if (IdDireccion > 0)
            {
                departamento = contexto.Departamentos.FirstOrDefault(x => x.IdDireccion == IdDireccion);
            }

            return View(departamento);
        }

        [HttpPost]
        public ActionResult AgregarEditarDepartamento(Departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(departamentos).State = departamentos.IdDireccion > 0 ? EntityState.Modified : EntityState.Added;
                contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(departamentos);

        }

        public ActionResult EliminarDepartamento(int IdDireccion = 0)
        {
            var model = contexto.Departamentos.FirstOrDefault(x => x.IdDireccion == IdDireccion);
            contexto.Entry(model).State = EntityState.Deleted;
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
