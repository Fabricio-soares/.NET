namespace ContextPayment.Domanin.ValueObject
{
    public class Email : ContextPayment.Shared.ValueObject.ValueObject
     {
        public Email(string email)
        {
            this.email = email;
        }

        public string email { get; set; }
    }
}