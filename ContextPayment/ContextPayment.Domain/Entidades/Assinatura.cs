using System;
using System.Collections.Generic;
using System.Linq;

namespace ContextPayment.Domanin.Entidades
{
    public class Assinatura
    {
        private IList<Pagamentos> _Pagamento;
        public Assinatura(DateTime? dataExpiracao)
        {
            DataCriacao = DateTime.Now;
            UltimaDataAtualizacao = DateTime.Now;
            DataExpiracao = dataExpiracao;
            Ativa = true;
            _Pagamento = new List<Pagamentos>();
        }


        public DateTime DataCriacao { get; private set; } 
        public DateTime UltimaDataAtualizacao { get; private set; } 
        public DateTime? DataExpiracao { get; private set; } 
        public bool Ativa { get; private set; } 
        public IReadOnlyCollection<Pagamentos> Pagamento { get{return _Pagamento.ToArray();} }
        public void addPagamentos(Pagamentos add) => _Pagamento.Add(add);
        public void DesativarAssinaturaPagamentos() => Ativa = false;

    }


}