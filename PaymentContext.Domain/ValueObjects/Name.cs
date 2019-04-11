using Flunt.Validations;
using paymentcontext.shared.ValueObjects;

namespace paymentcontext.domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                    .Requires()
                    .IsNullOrEmpty(FirstName, "Name.FirstName", "Nome inválido")
                    .IsNullOrEmpty(LastName, "Name.LastName", "Sobrenome inválido")
                );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
