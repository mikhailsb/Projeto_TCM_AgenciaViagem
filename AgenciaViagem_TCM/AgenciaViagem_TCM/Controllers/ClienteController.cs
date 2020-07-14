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
        public ActionResult Editar(ushort IDClie)
        {
            ClienteDAO buscaId = new ClienteDAO();

            return View(buscaId.BuscaID(IDClie));
        }
        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            ClienteDAO AtualizarCliente = new ClienteDAO();

            AtualizarCliente.Atualizar(cliente);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(ushort IDClie)
        {
            ClienteDAO buscaId = new ClienteDAO();

            return View(buscaId.BuscaID(IDClie));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cliente cliente)
        {
            ClienteDAO removeClie = new ClienteDAO();

            removeClie.Remover(cliente);

            return RedirectToAction("Index");
        }
    }
}