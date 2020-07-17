using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AppClasses
{
    public class Funcionario
    {
        [Display(Name = "ID DO FUNCIONÁRIO:")]
        public ushort IdFuncionario { get; set; }

        [Display(Name = "NOME DO FUNCIONÁRIO:")]
        [Required(ErrorMessage = "Nome do funcionário é o brigatório.")]
        public string NomeFuncioario { get; set; }

        [Display(Name = "LOGIN:")]
        [Required(ErrorMessage = "Login do funcionário é obrigatório.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "O campo deve conter mais de 5 caracteres.")]
        [Remote("ValidaLogin", "Funcionario", ErrorMessage = "Login já cadastrado!")]
        public string Login { get; set; }

        [Display(Name = "SENHA:")]
        [Required(ErrorMessage = "Senha é um campo obrigatório.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "A senha deve ter de 8 a 16 caracteres.")]
        public string SenhaFuncionario { get; set; }

        [Display(Name = "CARGO:")]
        public string Cargo { get; set; }

        /*
            * Funcionario
            * IdFuncionario: ushort
            * NomeFuncionario: string
            * Login: string
            * SenhaFuncionario: string
            * -----------------------
            * CadastrarFuncionario()
            * ConsultaCliente()
            * CadastrarPacote()
            * ConsultaPacote()
         */
    }
}