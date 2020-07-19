using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppClasses
{
    public class Endereco
    {
        public ushort IdEndereco { get; set; }
        public ushort IdCliente { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public ushort NumeroEnd { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public void VerificarEndereco()
        { }

        /*
         * Endereco

CEP: string
Rua: string
NumeroEndereco: ushort
Bairro: string
Cidade: string
UF: string
-----------------------
VerificarEndereco()

         */
    }
}