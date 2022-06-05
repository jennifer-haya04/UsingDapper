using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;
using UsingDapper.Models;
using UsingDapper.Repository;

namespace UsingDapper.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteRepository clienteRepo = new ClienteRepository();
            return View(clienteRepo.ListarClientes());
        }

        // GET: Cliente/Create
        public ActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCliente(ClienteModel Cliente)
        {

            ClienteRepository clienteRepo = new ClienteRepository();
            clienteRepo.CrearCliente(Cliente);

            return RedirectToAction("Index", "Cliente");

        }

        // GET: Cliente/Edit/5
        public ActionResult EditarCliente(int id)
        {
            ClienteRepository clienteRepo = new ClienteRepository();
            return View(clienteRepo.getClientexID(id));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult EditarCliente(ClienteModel ClienteUP)
        {
            
            ClienteRepository clienteRepo = new ClienteRepository();
            clienteRepo.EditarCliente(ClienteUP);

           return RedirectToAction("Index", "Cliente");
        }

        // GET: Cliente/Delete/5
        public ActionResult EliminarCliente(int id)
        {
            ClienteRepository clienteRepo = new ClienteRepository();
            clienteRepo.EliminarCliente(id);
            return RedirectToAction("Index", "Cliente");
        }

        // POST: Cliente/Delete/5
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
