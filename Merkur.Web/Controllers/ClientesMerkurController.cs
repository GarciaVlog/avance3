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

        ClientesBL clienteBL;

        public ClientesMerkurController()
        {
            clienteBL = new ClientesBL();
        }
            
            // GET: ClientesMerkur
        public ActionResult Index()
        {
            
            var ListadeClientes = clienteBL.ObtenerClientes();
            return View(ListadeClientes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var nuevoCliente = new Cliente();
            return View(nuevoCliente);
        }
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteBL = new ClientesBL();
                clienteBL.GuardarCliente(cliente);

                return RedirectToAction("Index");
            }

            return View(cliente);
        } 

        public ActionResult Edit(int id)
        {
            var cliente = clienteBL.ObtenerCliente(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            var clientesBL = new ClientesBL();
            clientesBL.GuardarCliente(cliente);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var clientesBL = new ClientesBL();
            var cliente = clientesBL.ObtenerCliente(id);
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
            var cliente = clienteBL.ObtenerCliente(id);
            return View(cliente);
        }
    }
}