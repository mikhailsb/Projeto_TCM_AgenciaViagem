using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppClasses;
using AppDAO;

namespace AgenciaViagem_TCM.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteDAO listaCliente = new ClienteDAO();

            var clie = listaCliente.Listar();



            return View(clie);
        }
        public ActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroCliente(Cliente cliente)
        {
            return View();
        }
    }
}