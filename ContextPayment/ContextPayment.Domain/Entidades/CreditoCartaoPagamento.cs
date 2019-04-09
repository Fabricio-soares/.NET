using System;
using ContextPayment.Domanin.ValueObject;

namespace ContextPayment.Domanin.Entidades
{
   
      public class CreditoCartaoPagamento : Pagamentos
    {
        public CreditoCartaoPagamento(DateTime dataPagameto, 
        DateTime expiracaoPagamento, 
        decimal total, 
        decimal totalPago,
         string proprietario, 
         Documento documento, 
         Endereco endereco, 
         Email email)
          : base(dataPagameto, expiracaoPagamento, total, totalPago, proprietario, documento, endereco, email)
        {
        }

        public String NomeCartao { get; set; } 
        public String CartaoNumero { get; set; } 
        public String UltimaTransacaoCartao { get; set; } 
    }
    
}