using System;
using ContextPayment.Domanin.ValueObject;

namespace ContextPayment.Domanin.Entidades
{
    public abstract class Pagamentos
    {
        protected Pagamentos(DateTime dataPagameto, DateTime expiracaoPagamento,
         decimal total, decimal totalPago, string proprietario, Documento documento,
          Endereco endereco, Email email)
        {
            Numero = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            DataPagameto = dataPagameto;
            ExpiracaoPagamento = expiracaoPagamento;
            Total = total;
            TotalPago = totalPago;
            Proprietario = proprietario;
            Documento = documento;
            Endereco = endereco;
            Email = email;
        }

        public String Numero { get;  private set; } 
        public DateTime DataPagameto { get; private set; } 
        public DateTime ExpiracaoPagamento { get; private set; } 
        public Decimal Total { get; private set; } 
        public Decimal TotalPago { get; private set; } 
        public String Proprietario { get; private set; } 
        public Documento Documento { get; private set; } 
        public Endereco Endereco { get; private set; } 
        public Email Email { get; private set; } 

    }
   
}