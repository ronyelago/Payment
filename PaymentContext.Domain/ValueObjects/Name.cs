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
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome muito curto")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome muito longo")
                .IsNullOrEmpty(FirstName, "Name.FirstName", "Nome inválido")
                .HasMinLen(LastName, 3, "Name.Lastname", "Sobrenome muito curto")
                .HasMaxLen(LastName, 40, "Name.LastName", "Sobrenome muito longo")
                .IsNullOrEmpty(LastName, "Name.LastName", "Sobrenome inválido")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
