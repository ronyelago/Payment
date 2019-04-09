using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
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
        public bool Active { get; set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }
    }
}