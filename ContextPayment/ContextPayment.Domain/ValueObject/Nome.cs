namespace  ContextPayment.Domanin.ValueObject
{
    public class Nome : ContextPayment.Shared.ValueObject.ValueObject
    {
        public Nome(string primeiroNome, string segundoNome)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;
        }

        public string PrimeiroNome { get; private set; } 
        public string SegundoNome { get; private set; } 
    }
}