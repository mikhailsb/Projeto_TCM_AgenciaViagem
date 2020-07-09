using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppClasses
{
    public class Funcionario
    {
        public ushort IdFuncionario { get; set; }

        [Required(ErrorMessage = "Nome do funcionário é o brigatório.")]
        public string NomeFuncioario { get; set; }

        [Required(ErrorMessage = "Login do funcionário é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo deve conter mais de 5 caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "A senha deve ter de 8 a 16 caracteres.")]
        public string SenhaFuncionario { get; set; }

        public string Cargo { get; set; }

        public void CadastrarFuncionario()
        { }

        public void ConsultaCliente()
        { }

        public void CadastrarPacote()
        { }

        public void ConsultaPacote()
        { }

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