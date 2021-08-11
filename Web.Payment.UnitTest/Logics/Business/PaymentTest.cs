using NUnit.Framework;
using System;
using logics = Web.Payment.Logics;
using Web.Payment.Logics.CreditCard;
using Web.Payment.Models;
using Moq;
using Web.Payment.Logics;

namespace Web.Payment.UnitTest.Logics.Business
{
    public class PaymentTest
    {
        Mock<ICreditCardFactory> iCreditCardFactory = null;
        CreditCard cCard = null;

        [SetUp]
        public void Setup()
        {
            iCreditCardFactory = new Mock<ICreditCardFactory>();
            cCard = new CreditCard()
            {
                CardOwner = "",
                CardNumber = "",
                CVC = "",
                ExpirationDate = default(DateTime)
            };
        }


        #region Failed Cases

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Submit_WhenCardOwnerIsNotValid_ReturnErrorCode100(string cardOwner)
        {
            // Arrange
            cCard.CardOwner = cardOwner;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(() => null);

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("100"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Submit_WhenCardNumberIsEmpty_ReturnErrorCode105(string cardNumber)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = cardNumber;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(() => null);

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("105"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Submit_WhenCVCIsEmpty_ReturnErrorCode110(string cvc)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = "232423";
            cCard.CVC = cvc;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(() => null);

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("110"));
        }

        [Test]
        [TestCase("0")]
        [TestCase("-1")]
        [TestCase("-123")]
        public void Submit_WhenCVCIsZeroOrNegative_ReturnErrorCode115(string cvc)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = "232423";
            cCard.CVC = cvc;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(() => null);

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("115"));
        }

        [Test]
        [TestCase("0")]
        [TestCase("1111111111111111")]
        [TestCase("222222222222222")]
        [TestCase("378282246310005")] // American Express card
        [TestCase("3530111333300000")] // JCB card
        [TestCase("5105105105105100")] // Master card
        [TestCase("6011111111111117")] // Discover card
        [TestCase("76009244561")] // Dankort card
        [TestCase("888888888888888")]
        [TestCase("999999999999999")]
        public void Submit_WhenVisaCardNumberIsNotValid_ReturnErrorCode120(string cardNumber)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = cardNumber;
            cCard.CVC = "123";
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(new VisaCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("120"));
        }

        [Test]
        [TestCase("0")]
        [TestCase("1111111111111111")]
        [TestCase("222222222222222")]
        [TestCase("378282246310005")] // American Express card
        [TestCase("3530111333300000")] // JCB card
        [TestCase("4012888888881881")] // Visa card
        [TestCase("6011111111111117")] // Discover card
        [TestCase("76009244561")] // Dankort card
        [TestCase("888888888888888")]
        [TestCase("999999999999999")]
        public void Submit_WhenMasterCardNumberIsNotValid_ReturnErrorCode120(string cardNumber)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = cardNumber;
            cCard.CVC = "123";
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(new MasterCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("120"));
        }

        [Test]
        [TestCase("0")]
        [TestCase("1111111111111111")]
        [TestCase("222222222222222")]
        [TestCase("3530111333300000")] // JCB card
        [TestCase("4012888888881881")] // Visa card
        [TestCase("5105105105105100")] // Master card
        [TestCase("6011111111111117")] // Discover card
        [TestCase("76009244561")] // Dankort card
        [TestCase("888888888888888")]
        [TestCase("999999999999999")]
        public void Submit_WhenAmericanExpressCardNumberIsNotValid_ReturnErrorCode120(string cardNumber)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = cardNumber;
            cCard.CVC = "123";
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(new AmericanCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("120"));
        }

        [Test]
        public void Submit_WhenExpirationDateIsPassed_ReturnErrorCode125()
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = "4222222222222"; // A valid Visa card number
            cCard.CVC = "123";
            cCard.ExpirationDate = DateTime.Now.AddDays(-1);
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new VisaCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("125"));
        }

        [Test]
        [TestCase("1")]
        [TestCase("12")]
        [TestCase("1234")]
        [TestCase("12345")]
        [TestCase("123456")]
        [TestCase("1234567")]
        [TestCase("12345678")]
        [TestCase("123456789")]
        public void Submit_WhenCVCIsNotValidForVisaCard_ReturnErrorCode130(string cvc)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = "4222222222222"; // A valid Visa card number
            cCard.CVC = cvc;
            cCard.ExpirationDate = DateTime.Now;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new VisaCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("130"));
        }

        [Test]
        [TestCase("1")]
        [TestCase("12")]
        [TestCase("1234")]
        [TestCase("12345")]
        [TestCase("123456")]
        [TestCase("1234567")]
        [TestCase("12345678")]
        [TestCase("123456789")]
        public void Submit_WhenCVCIsNotValidForMasterCard_ReturnErrorCode130(string cvc)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = "5555555555554444"; // A valid Master card number
            cCard.CVC = cvc;
            cCard.ExpirationDate = DateTime.Now;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new MasterCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("130"));
        }

        [Test]
        [TestCase("1")]
        [TestCase("12")]
        [TestCase("123")]
        [TestCase("12345")]
        [TestCase("123456")]
        [TestCase("1234567")]
        [TestCase("12345678")]
        [TestCase("123456789")]
        public void Submit_WhenCVCIsNotValidForAmericanExpressCard_ReturnErrorCode130(string cvc)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = "371449635398431"; // A valid American card number
            cCard.CVC = cvc;
            cCard.ExpirationDate = DateTime.Now;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new AmericanCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.ErrorCode, Is.EqualTo("130"));
        }

        #endregion


        #region Successful Cases

        [Test]
        [TestCase("4012888888881881", "123")]
        [TestCase("4444333222111", "678")]
        public void Submit_WhenCreditCardInfoIsValidForVisaCard_ReturnCardTypeAndSucceedAsTrue(string cardNumber, string cvc)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = cardNumber;
            cCard.CVC = cvc;
            cCard.ExpirationDate = DateTime.Now;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new VisaCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.True);
            Assert.That(result.Payload.CardType, Is.EqualTo(CreditCardType.VisaCard));
        }

        [Test]
        [TestCase("5555555555554444", "123")]
        [TestCase("5105105105105100", "678")]
        public void Submit_WhenCreditCardInfoIsValidForMasterCard_ReturnCardTypeAndSucceedAsTrue(string cardNumber, string cvc)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = cardNumber;
            cCard.CVC = cvc;
            cCard.ExpirationDate = DateTime.Now;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new MasterCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.True);
            Assert.That(result.Payload.CardType, Is.EqualTo(CreditCardType.MasterCard));
        }

        [Test]
        [TestCase("378282246310005", "1234")]
        [TestCase("371449635398431", "6789")]
        public void Submit_WhenCreditCardInfoIsValidForAmericanExpressCard_ReturnCardTypeAndSucceedAsTrue(string cardNumber, string cvc)
        {
            // Arrange
            cCard.CardOwner = "Owner";
            cCard.CardNumber = cardNumber;
            cCard.CVC = cvc;
            cCard.ExpirationDate = DateTime.Now;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new AmericanCard(cCard));

            // Act
            var result = new logics.Payment(cCard, iCreditCardFactory.Object).Submit();

            // Assert
            Assert.That(result.Succeed, Is.True);
            Assert.That(result.Payload.CardType, Is.EqualTo(CreditCardType.AmericanCard));
        }

        #endregion
    }
}