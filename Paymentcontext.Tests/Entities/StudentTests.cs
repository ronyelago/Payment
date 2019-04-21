using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentcontext.domain.Enums;
using paymentcontext.domain.ValueObjects;
using PaymentContext.Domain.Entities;
using System;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("37810823899", EDocumentType.CPF);
            _email = new Email("bruce.wayne@gmail.com");
            _address = new Address("Rua Wash", "122", "Cool Bairro", "Gotham", "SP", "BR", "06795005");

            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShoudReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("123456", "Wayne Corp", "4321", DateTime.Now, DateTime.Now, 10, 10, _address, _document, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShoudReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("123456", "Wayne Corp", "4321", DateTime.Now, DateTime.Now, 10, 10, _address, _document, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }

        [TestMethod]
        public void ShoudReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            
            Assert.IsTrue(_student.Invalid);
        }
    }
}