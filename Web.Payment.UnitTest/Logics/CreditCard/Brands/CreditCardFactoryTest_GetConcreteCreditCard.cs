using NUnit.Framework;
using System;

using Web.Payment.Logics.CreditCards.Brands;


namespace Web.Payment.UnitTest.Logics.CreditCard.Brands
{
    [TestFixture]
    public class CreditCardFactoryTest_GetConcreteCreditCard
    {
        Models.CreditCard cCard = null;
        CreditCardFactory creditCardFactory;


        [SetUp]
        public void Setup()
        {
            creditCardFactory = new CreditCardFactory();
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
        [TestCase("4012888asd888881881")]
        [TestCase("4881881")]
        [TestCase("")]
        [TestCase("0")]
        [TestCase("6011111111111117")] // Discover card
        public void WhenCreditCardNumberIsValidNotValid_ReturnNull(string cardNumber)
        {
            // Arrange
            cCard.CardNumber = cardNumber;

            // Act
            var result = creditCardFactory.GetConcreteCreditCard(cCard);

            // Assert
            Assert.That(result, Is.Null);
        }

        #endregion


        #region Successful Cases

        [Test]
        [TestCase("4012888888881881")]
        [TestCase("4444333222111")]
        public void WhenCreditCardNumberIsValidForVisaCard_ReturnVisaCardInstance(string cardNumber)
        {
            // Arrange
            cCard.CardNumber = cardNumber;

            // Act
            var result = creditCardFactory.GetConcreteCreditCard(cCard);

            // Assert
            Assert.That(result, Is.InstanceOf<VisaCard>());
        }

        [Test]
        [TestCase("5555555555554444")]
        [TestCase("5105105105105100")]
        public void WhenCreditCardNumberIsValidForMasterCard_ReturnMasterCardInstance(string cardNumber)
        {
            // Arrange
            cCard.CardNumber = cardNumber;

            // Act
            var result = creditCardFactory.GetConcreteCreditCard(cCard);

            // Assert
            Assert.That(result, Is.InstanceOf<MasterCard>());
        }

        [Test]
        [TestCase("378282246310005")]
        [TestCase("371449635398431")]
        public void WhenCreditCardNumberIsValidForAmericanExpressCard_ReturnAmericanCardInstance(string cardNumber)
        {
            // Arrange
            cCard.CardNumber = cardNumber;

            // Act
            var result = creditCardFactory.GetConcreteCreditCard(cCard);

            // Assert
            Assert.That(result, Is.InstanceOf<AmericanCard>());
        }

        #endregion
    }
}
