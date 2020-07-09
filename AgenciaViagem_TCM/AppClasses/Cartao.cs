using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaViagem_TCM.Models
{
    public class Cartao
    {
        public ushort IdCartao { get; set; }
        public string NumeroCartao { get; set; }

        public string NomeTitular { get; set; }

        public DateTime DataValidade { get; set; }

        public ushort CVV { get; set; }

        public void VerificarCartao()
        { }

        /*
IdCartao: ushort
NumeroCartao: string
NomeTitular: string
DataValidade: Data
CVV: ushort
-----------------------
-VerificarCartao()
         */
    }
}