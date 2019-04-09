using System;
using ContextPayment.Domanin.ValueObject;

namespace ContextPayment.Domanin.Entidades
{
  public class BoletoPagamento : Pagamentos
    {
        public BoletoPagamento(DateTime dataPagameto, DateTime expiracaoPagamento, decimal total,
         decimal totalPago, string proprietario, Documento documento, Endereco endereco, Email email) : base(dataPagameto, expiracaoPagamento, total, totalPago, proprietario, documento, endereco, email)
        {
        }

        public String CodigoBarra { get; set; } 
        public String BoletoNumero { get; set; } 

    }   
}