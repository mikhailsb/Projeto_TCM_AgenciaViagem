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

        public ActionResult Detalhes(ushort IDClie)
        {
            ClienteDAO buscaId = new ClienteDAO();

            return PartialView(buscaId.BuscaID(IDClie));
        }
        public ActionResult DetalhesCliente(ushort IDClie)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = IDClie;
            ClienteDAO ClieEndereco = new ClienteDAO();
            cliente = ClieEndereco.BuscaID(IDClie);

            var cliend = ClieEndereco.ListarEndereco(cliente);

            ViewData["IdCliente"] = cliente.IdCliente;
            ViewData["NomeCliente"] = cliente.NomeCliente;
            ViewData["Email"] = cliente.Email;
            ViewData["CPF"] = cliente.CPF;
            ViewData["RG"] = cliente.RG;
            ViewData["Telefone"] = cliente.Telefone;

            return View(cliend);
        }

        public ActionResult CadastrarEndereco(ushort IDClie)
        {
            Endereco endereco = new Endereco();
            endereco.IdCliente = IDClie;
            return View(endereco);
        }
        [HttpPost]
        public ActionResult CadastrarEndereco(Cliente cliente, Endereco endereco)
        {
            ClienteDAO CadastrarEndereco = new ClienteDAO();

            CadastrarEndereco.CadastrarEndereco(endereco);

            return RedirectToAction("DetalhesCliente", new { IDClie = endereco.IdCliente });
        }

        public ActionResult RemoverEndereco(ushort IDEnde)
        {
            ClienteDAO BuscarEndereco = new ClienteDAO();
            return View(BuscarEndereco.BuscaEndereco(IDEnde));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoverEndereco(Endereco endereco)
        {
            ClienteDAO RemoveEnde = new ClienteDAO();
            RemoveEnde.RemoverEndereco(endereco.IdEndereco);

            return RedirectToAction("Index");
        }

        public ActionResult EditarEndereco(ushort IDEnde)
        {
            ClienteDAO BuscarEndereco = new ClienteDAO();
            return View(BuscarEndereco.BuscaEndereco(IDEnde));
        }
        [HttpPost]
        public ActionResult EditarEndereco(Endereco endereco)
        {
            ClienteDAO AtualizarEndereco = new ClienteDAO();

            AtualizarEndereco.AlterarEndereco(endereco);

            return RedirectToAction("Index");
        }
    }
}