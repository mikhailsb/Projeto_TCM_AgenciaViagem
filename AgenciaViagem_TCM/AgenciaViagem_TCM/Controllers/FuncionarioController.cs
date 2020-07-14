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


            //return View();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(ushort IDFunc)
        {
            FuncionarioDAO buscaId = new FuncionarioDAO();

            return View(buscaId.BuscaID(IDFunc));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Funcionario funcionario)
        {
            FuncionarioDAO removeFunc = new FuncionarioDAO();

            removeFunc.Remover(funcionario);

            return RedirectToAction("Index");
        }

        public ActionResult ValidaLogin(Funcionario funcionario)
        {
            FuncionarioDAO validar = new FuncionarioDAO();

            bool resultado = validar.ValidaLogin(funcionario.Login);

            if(resultado == true)
            {
                return Json(string.Format("Login {0} já está cadastrado.", funcionario.Login), JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(ushort IDFunc)
        {
            FuncionarioDAO buscaId = new FuncionarioDAO();

            return View(buscaId.BuscaID(IDFunc));
        }
        [HttpPost]
        public ActionResult Editar(Funcionario funcionario)
        {
            FuncionarioDAO AtualizarFunc = new FuncionarioDAO();

            AtualizarFunc.Atualizar(funcionario);

            return RedirectToAction("Index");
        }


    }
}