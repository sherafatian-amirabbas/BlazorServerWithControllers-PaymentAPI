using System;
using TechTalk.SpecFlow;

namespace Web.Payment.SpecFlow.Controller.Steps
{
    [Binding]
    public class PaymentSteps
    {
        [Given(@"the payment data as")]
        public void GivenThePaymentDataAs(Table table)
        {
            throw new NotImplementedException();
        }

        [When(@"the data is posted")]
        public void WhenTheDataIsPosted()
        {
            throw new NotImplementedException();
        }

        [Then(@"the result must be successful")]
        public void ThenTheResultMustBeSuccessful()
        {
            throw new NotImplementedException();
        }

        [Then(@"The response must contain the type of the Credit Card as ""(.*)""")]
        public void ThenTheResponseMustContainTheTypeOfTheCreditCardAs(string p0)
        {
            throw new NotImplementedException();
        }

        [Then(@"the result must NOT be successful")]
        public void ThenTheResultMustNOTBeSuccessful()
        {
            throw new NotImplementedException();
        }

        [Then(@"The response must contain the error Code")]
        public void ThenTheResponseMustContainTheErrorCode()
        {
            throw new NotImplementedException();
        }

    }
}
