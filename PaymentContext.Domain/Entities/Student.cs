using paymentcontext.domain.ValueObjects;
using paymentcontext.shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student(Name name, string lastName, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        private IList<Subscription> _subscriptions;

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; set; }
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