using System;
using ContextPayment.Domanin.ValueObject;
using System.Collections.Generic;
using ContextPayment.Shared.Entidades;

namespace ContextPayment.Domanin.Entidades
{
    public class Estudantes : Entity
    {
        private List<Assinatura> _Assinaturas;
        public Estudantes(Nome nome, string documento, string email, Guid id) : base(id)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            _Assinaturas = new List<Assinatura>();

        }

        public Nome Nome { get; set; }
        public string Documento { get; private set; } 
        public string Email { get; private set; } 
        public Endereco Endereco { get; private set; } 
        public IReadOnlyCollection<Assinatura> Assinaturas { get{return _Assinaturas.ToArray();} } 


        public void AddAssinaturas(Assinatura add){
            //Se já tiver assinatura ativa, Cancela
            foreach (var sub in Assinaturas) {
              sub.DesativarAssinaturaPagamentos();
            }

            _Assinaturas.Add(add);
        }
    }
}