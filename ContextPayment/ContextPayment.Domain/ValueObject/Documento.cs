using ContextPayment.Domanin.Enums;

namespace ContextPayment.Domanin.ValueObject
{
    public class Documento : ContextPayment.Shared.ValueObject.ValueObject
    {
        public Documento(string numero, ETipoDocumento tipo)
        {
            Numero = numero;
            Tipo = tipo;
        }

        public string Numero { get; private set; }
        public ETipoDocumento Tipo { get; private set; }
    }
    
}