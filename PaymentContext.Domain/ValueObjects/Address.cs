using Flunt.Validations;
using paymentcontext.shared.ValueObjects;

namespace paymentcontext.domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Address.Street", "Rua muito curta")
                .HasMaxLen(Street, 100, "Address.Street", "Rua muito longa")
                .IsNullOrEmpty(Street, "Address.Street", "Rua inválida")
                .HasMinLen(City, 3, "Address.City", "Nome de cidade muito curto")
                .HasMaxLen(City, 100, "Address.City", "Nome de cidade muito longo")
                .IsNullOrEmpty(City, "Name.LastName", "Cidade inválida")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}
