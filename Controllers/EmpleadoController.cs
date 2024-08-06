using CRUDempleados.Data;
using CRUDempleados.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CRUDempleados.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoData _EmpleadoData = new EmpleadoData();
        public IActionResult Listar()
        {
            var oLista = _EmpleadoData.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EmpleadoModel oEmpleado)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _EmpleadoData.Crear(oEmpleado);
                if (respuesta)
                    return RedirectToAction("Listar");
                else
                    return View();
            }
            else
                return View(oEmpleado);

        }

        public IActionResult Editar(int id)
        {
            var oEmpleado = _EmpleadoData.Obtener(id);
            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Editar(EmpleadoModel oEmpleado)
        {
            var respuesta = _EmpleadoData.Actualizar(oEmpleado);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult ObtenerPorID(int id)
        {
            var oEmpleado = _EmpleadoData.Obtener(id);
            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult ObtenerPorID(EmpleadoModel oEmpleado)
        {
            var respuesta = _EmpleadoData.Obtener(oEmpleado.EmpleadoID);
            if (respuesta == null)
                return RedirectToAction();
            else
                return View("ObtenerPorID");
        }

        public IActionResult Eliminar(int id)
        {
            var oEmpleado = _EmpleadoData.Obtener(id);
            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpleadoModel oEmpleado)
        {
            var respuesta = _EmpleadoData.Eliminar(oEmpleado.EmpleadoID);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
