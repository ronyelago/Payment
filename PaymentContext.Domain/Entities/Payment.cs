using paymentcontext.domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(
            string payer, 
            string number, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPayd, 
            Address address, 
            Document document, 
            Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            Payer = payer;
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPayd = totalPayd;
            Address = address;
            Document = document;
            Email = email;
        }

        public string Payer { get; private set; }
        public string Number { get; private set; }
        public Document Document { get; private set; }
        public DateTime PaidDate { get; private set; }   
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPayd { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }       
    }
}