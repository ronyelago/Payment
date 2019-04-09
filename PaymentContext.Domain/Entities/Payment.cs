using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(string payer, string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPayd, string address, string document, string email)
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
        public DateTime PaidDate { get; private set; }   
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPayd { get; private set; }
        public string Address { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }       
    }

    public class BoletoPayment : Payment
    {
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
    }

    public class CreditCardPayment : Payment
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }

    public class PayPalPayment : Payment
    {
        public string TransactionCode { get; set; }
    }
}