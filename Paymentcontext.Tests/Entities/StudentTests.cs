using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentcontext.domain.Enums;
using paymentcontext.domain.ValueObjects;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void ShoudReturnErrorWhenHadActiveSubscription()
        {
            
        }

        [TestMethod]
        public void ShoudReturnErrorWhenHadNoActiveSubscription()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("37810823899", EDocumentType.CPF);
            var email = new Email("bruce.wayne@gmail.com");

            var student = new Student(name, document, email);
        }
    }
}