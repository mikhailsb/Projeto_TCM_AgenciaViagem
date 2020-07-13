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
        public ActionResult CriarPacotes(Pacote Pacote)
        {
            PacoteDAO InserirPacote = new PacoteDAO();

            InserirPacote.Inserir(Pacote);

            return View();
        }
    }
}