using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppClasses
{
    public class Cliente
    {
        [Display(Name = "ID DO CLIENTE:")]
        public ushort IdCliente { get; set; }

        [Display(Name = "NOME DO CLIENTE:")]
        [Required(ErrorMessage = "Nome do cliente é um campo obrigatório.")]
        public string NomeCliente { get; set; }

        [Display(Name = "E-MAIL:")]
        [Required(ErrorMessage = "E-mail é um campo obrigatório.")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z])\s+<(\w[-.\w]*\w@\w[-.\w]*\w\.\w{2,3})>$|^(\w[-.\w]*\w@\w[-.\w]*\w\.\w{2,3})$", ErrorMessage = "Informe um e-mail válido")]
        [Remote("ValidaEmail", "Cliente", ErrorMessage = "Email já cadastrado!")]
        public virtual string Email { get; set; }

        [Display(Name = "CPF: ")]
        [Required(ErrorMessage = "CPF é um campo obrigatório.")]
        public string CPF { get; set; }

        [Display(Name = "RG: ")]
        [Required(ErrorMessage = "RG é um campo obrigatório.")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Telefone é um campo obrigatório.")]
        [Display(Name = "TELEFONE: ")]
        public string Telefone { get; set; }


        //-----------------------
        //CadastrarCliente()
        //ConsultaAgenda()
        //RealizarCompra()
    }
}