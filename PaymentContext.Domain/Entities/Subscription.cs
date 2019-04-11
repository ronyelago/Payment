using Flunt.Validations;
using paymentcontext.shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        public Subscription(DateTime? expireDate)
        {
            ExpireDate = expireDate;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Active = true;
            
            _payments = new List<Payment>();
        }

        private IList<Payment> _payments;

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                    .Requires()
                    .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve estar no futuro")
                );

            _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Disable()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}