using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppClasses
{
    public class Pacote
    {
        public ushort IdPacote { get; set; }
        public DateTime DataCheckin { get; set; }
        public DateTime DataCheckout { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string TipoTransporte { get; set; }
        public decimal ValorUnitario { get; set; }
        public string DescricaoPacote { get; set; }
        public string ResumoPacote { get; set; }
        public string RoteiroViagem { get; set; }
        /*
         * Pacote
IdPacote: ushort
QuantidadeDiarias: ushort
QuantidadeQuartos: ushort
DataCheckin: DateTime
DataCheckout: DateTime
Origem: string
Destino: string
NumeroAdultos: byte
NumeroCriancas: byte
TipoTransporte: string
ValorUnitario: double(10)
DescricaoPacote: string
ResumoPacote: string
RoteiroViagem: string
         */
    }
}