using System.Net;

using NUnit.Framework;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using Web.Payment.Common;
using Web.Payment.SpecFlow.Controller.Support;
using Web.Payment.SpecFlow.Controller.Drivers;
using Web.Payment.Logics;


namespace Web.Payment.SpecFlow.Controller.Steps
{
    [Binding]
    public class CreditCardSteps
    {
        private readonly CreditCardDriver creditCardDriver;


        private CreditCardDataModel creditCard;
        private CreditCardDriver.VerificationResult verificationResult;


        #region Constructor

        public CreditCardSteps(CreditCardDriver paymentDriver)
        {
            this.creditCardDriver = paymentDriver;
        }

        #endregion


        [Given(@"the Credit Card data as")]
        public void GivenThePaymentDataAs(Table creditCardTable)
        {
            creditCard = creditCardTable.CreateInstance<CreditCardDataModel>();
        }

        [When(@"the data is posted to verify")]
        public void WhenTheDataIsPostedToVerify()
        {
            verificationResult = this.creditCardDriver.Verify(creditCard);
        }

        [Then(@"the result must be successful")]
        public void ThenTheResultMustBeSuccessful()
        {
            Assert.That(verificationResult.ApiResult.Succeed, Is.True);
            Assert.That(verificationResult.ApiResult.Payload, Is.Not.Null);
            Assert.That(verificationResult.ApiResult.Payload.CardType, Is.Not.EqualTo(CreditCardType.None));
            Assert.That(verificationResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"the response must contain the type of the Credit Card as (.*)")]
        public void ThenTheResponseMustContainTheTypeOfTheCreditCardAs(string cardTypeDisplayName)
        {
            Assert.That(verificationResult.ApiResult.Payload.CardType.GetDisplayName(), Is.EqualTo(cardTypeDisplayName));
        }

        [Then(@"the result must NOT be successful")]
        public void ThenTheResultMustNOTBeSuccessful()
        {
            Assert.That(verificationResult.ApiResult.Succeed, Is.False);
            Assert.That(verificationResult.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Then(@"the response must contain the error code (.*)")]
        public void ThenTheResponseMustContainTheErrorCode(string ErrorCode)
        {
            Assert.That(verificationResult.ApiResult.Errors.ContainsCode(ErrorCode), Is.True);
        }
    }
}
