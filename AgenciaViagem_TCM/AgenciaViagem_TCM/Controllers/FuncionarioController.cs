using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppClasses;
using AppDAO;

namespace AgenciaViagem_TCM.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            FuncionarioDAO listaFuncionario = new FuncionarioDAO();

            var func = listaFuncionario.Listar();

            return View(func);
        }

        
        public ActionResult CadastrarFunc()
        {
            //Funcionario funcionario = new Funcionario();

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarFunc(Funcionario funcionario)
        {
            FuncionarioDAO FuncInserir = new FuncionarioDAO();

            FuncInserir.Inserir(funcionario);

            //return RedirectToAction();


            return View();
        }


    }
}