using Flunt.Validations;
using paymentcontext.domain.ValueObjects;
using paymentcontext.shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student(Name name, Document document, Email email)
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
            bool hasActiveSubscription = false;

            foreach (Subscription sub in _subscriptions)
            {
                if (sub.Active)
                {
                    hasActiveSubscription = true;
                }
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasActiveSubscription, "Student.Subscriptions", "Você já possui uma assinatura ativa")
                .IsGreaterThan(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos."));
        }
    }
}