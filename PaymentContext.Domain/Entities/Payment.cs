using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        public DateTime PaidDate { get; set; }   
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPayd { get; set; }
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