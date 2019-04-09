using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        public string Payer { get; set; }
        public string Number { get; set; }
        public DateTime PaidDate { get; set; }   
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPayd { get; set; }
        public string Address { get; set; }
        public string Document { get; set; }

    }

    public class BoletoPayment : Payment
    {

    }

    public class CreditCardPayment : Payment
    {

    }

    public class PayPalPayment : Payment
    {
        
    }
}