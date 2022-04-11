using DEMO.Data;
using DEMO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEMO.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly DEP_EM_DB _cadena;

        public EmpleadosController(DEP_EM_DB Cadena)
            {
            _cadena = Cadena;
        }

        public IActionResult Index()
        {

            var Res = _cadena.Empleados.Include(x=>x.DEPARTAMENTO).OrderBy(x=>x.N_EMPLEADO).ToList();

            return View(Res);
        }

        public IActionResult CREAR()
        {
            ViewBag.Departamento = _cadena.Departamento.OrderBy(X => X.N_DEPARTAMENTO).ToList();
            return View();
        }

        /// <summary>
        /// METOO DE CREACION DE NUEVO EMPLEADO
        /// </summary>
        /// <param name="modelo"> Recibe como parametro los Valores de la Vista</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CREAR(EMPLEADOS modelo)
        {
            if (ModelState.IsValid)
            {
                _cadena.Empleados.Add(modelo);
                _cadena.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departamento = _cadena.Departamento.OrderBy(X => X.N_DEPARTAMENTO).ToList();
            return View();
        }

        public IActionResult EDITAR(int? ID)
        {
            ViewBag.Departamento = _cadena.Departamento.OrderBy(X => X.N_DEPARTAMENTO).ToList();
            var Result = _cadena.Empleados.Find(ID);
            return View("CREAR",Result);
        }

        /// <summary>
        /// METOO DE EDITAR  EMPLEADO
        /// </summary>
        /// <param name="modelo"> Recibe como parametro el ID de la vista</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EDITAR(EMPLEADOS modelo)
        {
            if (ModelState.IsValid)
            {
                _cadena.Empleados.Update(modelo);
                _cadena.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departamento = _cadena.Departamento.OrderBy(X => X.N_DEPARTAMENTO).ToList();
            return View(modelo);
        }

        /// <summary>
        /// METOO DE ELIMINAR EMPLEADO
        /// </summary>
        /// <param name="modelo"> Recibe como parametro el ID de la vista</param>
        /// <returns></returns>
        public IActionResult ELIMINAR(int? ID)
        {
            var Result = _cadena.Empleados.Find(ID);
            if (Result != null)
            {
                _cadena.Empleados.Remove(Result);
                _cadena.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
