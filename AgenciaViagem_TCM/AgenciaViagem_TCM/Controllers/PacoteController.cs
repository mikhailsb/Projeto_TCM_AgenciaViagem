using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppClasses;
using AppDAO;

namespace AgenciaViagem_TCM.Controllers
{
    public class PacoteController : Controller
    {
        // GET: Pacote
        public ActionResult Index()
        {
            PacoteDAO pacotes = new PacoteDAO();

            var ListaPacotes = pacotes.Listar();

            return View(ListaPacotes);
        }

        public ActionResult CriarPacotes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CriarPacotes(Pacote pacote)
        {
            PacoteDAO InserirPacote = new PacoteDAO();

            InserirPacote.Inserir(pacote);

            return RedirectToAction("Index");
        }
        public ActionResult Editar(ushort IDPacote)
        {
            PacoteDAO buscaId = new PacoteDAO();

            return View(buscaId.BuscaID(IDPacote));
        }
        [HttpPost]
        public ActionResult Editar(Pacote pacote)
        {
            PacoteDAO AtualizaPacote = new PacoteDAO();

            AtualizaPacote.Atualizar(pacote);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(ushort IDPacote)
        {
            PacoteDAO buscaId = new PacoteDAO();

            return View(buscaId.BuscaID(IDPacote));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Pacote pacote)
        {
            PacoteDAO removePacote = new PacoteDAO();

            removePacote.Remover(pacote);

            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(ushort IDPacote)
        {
            PacoteDAO buscaId = new PacoteDAO();
            return PartialView(buscaId.BuscaID(IDPacote));
        }
    }
}