using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppClasses
{
    public class Pacote
    {
        public ushort IdPacote { get; set; }

        [Display(Name = "Data de Checkin")]
        [Required(ErrorMessage = "Checkin é um campo obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCheckin { get; set; }

        [Display(Name = "Data de Checkout")]
        [Required(ErrorMessage = "Checkout é um campo obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCheckout { get; set; }

        [Required(ErrorMessage = "Origem é um campo obrigatório!")]
        public string Origem { get; set; }

        [Required(ErrorMessage = "Destino é um campo obrigatório!")]
        public string Destino { get; set; }

        [Display(Name = "Tipo de transporte")]
        [Required(ErrorMessage = "Tipo Transporte é um campo obrigatório!")]
        public string TipoTransporte { get; set; }

        [Display(Name = "Valor Unitário")]
        [Required(ErrorMessage = "Tipo Transporte é um campo obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorUnitario { get; set; }

        [Display(Name = "Descrição Pacote")]
        [Required(ErrorMessage = "Tipo Transporte é um campo obrigatório!")]
        public string DescricaoPacote { get; set; }

        [Display(Name = "Resumo Pacote")]
        [Required(ErrorMessage = "Tipo Transporte é um campo obrigatório!")]
        public string ResumoPacote { get; set; }

        [Display(Name = "Roteiro Viagem")]
        [Required(ErrorMessage = "Tipo Transporte é um campo obrigatório!")]
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