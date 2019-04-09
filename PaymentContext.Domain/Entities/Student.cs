using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;

            _subscriptions = new List<Subscription>();
        }

        private IList<Subscription> _subscriptions;

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            // se já houver uma assinatura ativa, cancele
            // ou
            // cancele todas as outras assinaturas e defina esta como principal

            foreach (var sub in Subscriptions)
            {
                sub.Disable();
            }

            _subscriptions.Add(subscription);
        }
    }
}