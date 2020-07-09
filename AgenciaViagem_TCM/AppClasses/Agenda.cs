using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaViagem_TCM.Models
{
    public class Agenda
    {
        public ushort IdAgenda { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataIda { get; set; }
        public DateTime DataVolta { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }

        /*
         * Agenda
NomeCliente: string
DataIda: DateTime
DataVolta: DateTime
Origem: string
Destino: string
         */
    }
}