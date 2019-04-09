using paymentcontext.domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        public Student(Name name, string lastName, Document document, string email)
        {
            Name = name;
            Document = document;
            Email = email;

            _subscriptions = new List<Subscription>();
        }

        private IList<Subscription> _subscriptions;

        public Name Name { get; private set; }
        public Document Document { get; private set; }
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