using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentcontext.domain.Enums;
using paymentcontext.domain.ValueObjects;

namespace paymentcontext.tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void ShoudReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("1234", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessIfCNPJIsValid()
        {

        }

        public void ShoudReturnErrorWhenCPFIsInvalid()
        {

        }

        [TestMethod]
        public void ShouldReturnSuccessIfCPFIsValid()
        {

        }
    }
}
