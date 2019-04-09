using System;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode, 
            string boletoNumber,
            string payer,
            string number,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPayd,
            string address,
            string document,
            string email) : base(payer, number, paidDate, expireDate, total, totalPayd, address, document, email)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
