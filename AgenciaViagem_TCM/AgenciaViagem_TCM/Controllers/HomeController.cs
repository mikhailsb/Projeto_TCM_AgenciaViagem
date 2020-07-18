using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDAO;

namespace AgenciaViagem_TCM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Principal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarLogin(FormCollection form)
        {
            FuncionarioDAO verificarLogin = new FuncionarioDAO();

            verificarLogin.verificarLogin(form["Usuario"].ToString(), form["Senha"].ToString());

            if (verificarLogin.mensagem != "")
            {
                return RedirectToAction("Login", "Home", new { status = "false" });
            }
            else
            {
                if (verificarLogin.T)
                {
                    return RedirectToAction("Principal", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Home", new { status = "false" });
                }
            }
        }
    }
}