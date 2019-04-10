using paymentcontext.shared.ValueObjects;

namespace paymentcontext.domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}
