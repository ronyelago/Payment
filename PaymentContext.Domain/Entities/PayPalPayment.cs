using paymentcontext.domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            string transactionCode, 
            string payer, 
            string number, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPayd, 
            string address, 
            Document document, 
            string email) : base (payer, number, paidDate, expireDate, total, totalPayd, address, document, email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}
