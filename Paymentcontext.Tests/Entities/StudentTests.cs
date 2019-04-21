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
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("37810823899", EDocumentType.CPF);
            var email = new Email("bruce.wayne@gmail.com");
            var address = new Address("Rua Wash", "122", "Cool Bairro", "Gotham", "SP", "BR", "06795005");

            _student = new Student(name, document, email);
            _subscription = new Subscription(null);

            var payment = new PayPalPayment("123456", "Wayne Corp", "4321", DateTime.Now, DateTime.Now, 10, 10, address, document, email);

            _subscription.AddPayment(payment);
        }

        [TestMethod]
        public void ShoudReturnErrorWhenHadActiveSubscription()
        {
            
        }

        [TestMethod]
        public void ShoudReturnErrorWhenHadNoActiveSubscription()
        {
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShoudReturnErrorWhenSubscriptionHasNoPayment()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("37810823899", EDocumentType.CPF);
            var email = new Email("bruce.wayne@gmail.com");

            var student = new Student(name, document, email);
        }
    }
}