using System;

using NUnit.Framework;
using Moq;

using Web.Payment.Logics;
using Web.Payment.Common;
using Web.Payment.Logics.CreditCards.Brands;
using Web.Payment.Logics.CreditCards.Services;
using Web.Payment.Logics.CreditCards.Brands.interfaces;


namespace Web.Payment.UnitTest.Logics.CreditCard.Services
{
    [TestFixture]
    public class VerifyTest
    {
        Mock<ICreditCardFactory> iCreditCardFactory = null;
        CreditCardService creditCardService;

        Models.CreditCard cCard = null;


        [SetUp]
        public void Setup()
        {
            iCreditCardFactory = new Mock<ICreditCardFactory>();
            creditCardService = new CreditCardService(iCreditCardFactory.Object);

            cCard = new Models.CreditCard()
            {
                CardOwner = "CardOwner",
                CardNumber = "371449635398431",
                CVC = "6789",
                ExpirationDate = DateTime.Now.AddMonths(1)
            };
        }


        #region Failed Cases

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
        public void Verify_WhenVisaCardNumberIsNotValid_ReturnErrorCodeCC120(string cardNumber)
        {
            // Arrange
            cCard.CardNumber = cardNumber;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(new VisaCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.Errors.ContainsCode("CC120"), Is.True);
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
        public void Verify_WhenMasterCardNumberIsNotValid_ReturnErrorCodeCC120(string cardNumber)
        {
            // Arrange
            cCard.CardNumber = cardNumber;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(new MasterCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.Errors.ContainsCode("CC120"), Is.True);
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
        public void Verify_WhenAmericanExpressCardNumberIsNotValid_ReturnErrorCodeCC120(string cardNumber)
        {
            // Arrange
            cCard.CardNumber = cardNumber;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(null)).Returns(new AmericanCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.Errors.ContainsCode("CC120"), Is.True);
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
        public void Verify_WhenCVCIsNotValidForVisaCard_ReturnErrorCodeCC130(string cvc)
        {
            // Arrange
            cCard.CardNumber = "4444333222111";
            cCard.CVC = cvc;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new VisaCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.Errors.ContainsCode("CC130"), Is.True);
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
        public void Verify_WhenCVCIsNotValidForMasterCard_ReturnErrorCodeCC130(string cvc)
        {
            // Arrange
            cCard.CardNumber = "5105105105105100";
            cCard.CVC = cvc;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new MasterCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.Errors.ContainsCode("CC130"), Is.True);
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
        public void Verify_WhenCVCIsNotValidForAmericanExpressCard_ReturnErrorCodeCC130(string cvc)
        {
            // Arrange
            cCard.CardNumber = "378282246310005";
            cCard.CVC = cvc;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new AmericanCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.False);
            Assert.That(result.Errors.ContainsCode("CC130"), Is.True);
        }

        #endregion


        #region Successful Cases

        [Test]
        [TestCase("4012888888881881", "123")]
        [TestCase("4444333222111", "678")]
        public void Verify_WhenCreditCardInfoIsValidForVisaCard_ReturnCardTypeAndSucceedAsTrue(string cardNumber, string cvc)
        {
            // Arrange
            cCard.CardNumber = cardNumber;
            cCard.CVC = cvc;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new VisaCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.True);
            Assert.That(result.Payload.CardType, Is.EqualTo(CreditCardType.VisaCard));
        }

        [Test]
        [TestCase("5555555555554444", "123")]
        [TestCase("5105105105105100", "678")]
        public void Verify_WhenCreditCardInfoIsValidForMasterCard_ReturnCardTypeAndSucceedAsTrue(string cardNumber, string cvc)
        {
            // Arrange
            cCard.CardNumber = cardNumber;
            cCard.CVC = cvc;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new MasterCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.True);
            Assert.That(result.Payload.CardType, Is.EqualTo(CreditCardType.MasterCard));
        }

        [Test]
        [TestCase("378282246310005", "1234")]
        [TestCase("371449635398431", "6789")]
        public void Verify_WhenCreditCardInfoIsValidForAmericanExpressCard_ReturnCardTypeAndSucceedAsTrue(string cardNumber, string cvc)
        {
            // Arrange
            cCard.CardNumber = cardNumber;
            cCard.CVC = cvc;
            iCreditCardFactory.Setup(t => t.GetConcreteCreditCard(cCard)).Returns(new AmericanCard(cCard));

            // Act
            var result = creditCardService.Verify(cCard);

            // Assert
            Assert.That(result.Succeed, Is.True);
            Assert.That(result.Payload.CardType, Is.EqualTo(CreditCardType.AmericanCard));
        }

        #endregion
    }
}