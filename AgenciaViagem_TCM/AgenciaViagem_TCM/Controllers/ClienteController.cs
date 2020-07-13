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
            ClienteDAO InserirClie = new ClienteDAO();

            InserirClie.Insert(cliente);

            return RedirectToAction("Index");
        }

        public ActionResult ValidaEmail(Cliente cliente)
        {
            ClienteDAO validar = new ClienteDAO();

            bool resultado = validar.ValidaEmail(cliente.Email);

            if (resultado == true)
            {
                return Json(string.Format("E-mail {0} já está cadastrado.", cliente.Email), JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}