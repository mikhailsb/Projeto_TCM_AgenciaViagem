using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppClasses
{
    public class Pacote
    {
        [Display(Name = "ID DO PACOTE:")]
        public ushort IdPacote { get; set; }

        [Display(Name = "DATA DE CHECK-IN:")]
        [Required(ErrorMessage = "Checkin é um campo obrigatório!")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCheckin { get; set; }

        [Display(Name = "DATA DE CHECK-OUT:")]
        [Required(ErrorMessage = "Checkout é um campo obrigatório!")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCheckout { get; set; }

        [Display(Name = "ORIGEM:")]
        [Required(ErrorMessage = "Origem é um campo obrigatório!")]
        public string Origem { get; set; }

        [Display(Name = "DESTINO:")]
        [Required(ErrorMessage = "Destino é um campo obrigatório!")]
        public string Destino { get; set; }

        [Display(Name = "TRANSPORTE:")]
        [Required(ErrorMessage = "Tipo Transporte é um campo obrigatório!")]
        public string TipoTransporte { get; set; }

        [Display(Name = "VALOR UNITÁRIO:")]
        [Required(ErrorMessage = "Valor é um campo obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorUnitario { get; set; }

        [Display(Name = "DESCRIÇÃO:")]
        [Required(ErrorMessage = "Tipo Transporte é um campo obrigatório!")]
        public string DescricaoPacote { get; set; }

        [Display(Name = "RESUMO:")]
        [Required(ErrorMessage = "Tipo Transporte é um campo obrigatório!")]
        public string ResumoPacote { get; set; }

        [Display(Name = "ROTEIRO:")]
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