using Merkur.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merkur.Web.Controllers
{
    public class ClientesMerkurController : Controller
    {
        // GET: ClientesMerkur
        public ActionResult Index()
        {
            var clienteBL = new ClientesBL();
            var clientes = clienteBL.ObtenerClientes();
            return View(clientes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var nuevoCliente = new Cliente();
            return View(nuevoCliente);
        }
        [HttpPost]
        public ActionResult Create(Cliente nuevoCliente)
        {
            if (ModelState.IsValid)
            {
                var clienteBL = new ClientesBL();
                clienteBL.GuardarClientes(nuevoCliente);

                return RedirectToAction("Index");
            }

            return View(nuevoCliente);
        }

        public ActionResult Edit(int id)
        {
            var clienteBL = new ClientesBL();
            var cliente = clienteBL.ObtenerClientes(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            var clientesBL = new ClientesBL();
            clientesBL.GuardarClientes(cliente);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var clientesBL = new ClientesBL();
            var cliente = clientesBL.ObtenerClientes(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(Cliente cliente)
        {
            var clientesBL = new ClientesBL();
            clientesBL.Eliminar(cliente);

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var clientesBL = new ClientesBL();
            var cliente = clientesBL.ObtenerClientes(id);
            return View(cliente);
        }
    }
}