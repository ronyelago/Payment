using paymentcontext.domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            string cardHolderName, 
            string cardNumber, 
            string lastTransactionNumber, 
            string payer,
            string number,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPayd,
            string address,
            Document document,
            string email) : base(payer, number, paidDate, expireDate, total, totalPayd, address, document, email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}
