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
            var doc = new Document("12345678901234", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShoudReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("1234", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("13289023430")]
        [DataRow("37802201250")]
        [DataRow("79928029156")]
        public void ShouldReturnSuccessIfCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
