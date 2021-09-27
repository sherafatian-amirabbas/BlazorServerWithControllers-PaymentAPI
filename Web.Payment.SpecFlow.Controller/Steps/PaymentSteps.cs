using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Web.Payment.Models;
using System.Linq;
using System.Text;
using Web.Payment.Common;
using Web.Payment.Logics;
using NUnit.Framework;

namespace Web.Payment.SpecFlow.Controller.Steps
{
    [Binding]
    public class PaymentSteps
    {
        CreditCard creditCard;
        ApiResult<PaymentSubmissionPayload> result;


        [Given(@"the payment data as")]
        public void GivenThePaymentDataAs(Table creditCardTable)
        {
            creditCard = creditCardTable.CreateInstance<CreditCard>();
        }

        [When(@"the data is posted")]
        public void WhenTheDataIsPosted()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            var requestContent = new StringContent(JsonConvert.SerializeObject(new {
                CardOwner = creditCard.CardOwner,
                CardNumber = creditCard.CardNumber,
                ExpirationDate = creditCard.ExpirationDate,
                CVC = creditCard.CVC,
            }), Encoding.UTF8, "application/json");
            var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Post, "/api/payment")
            {
                Content = requestContent
            }).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            result = JsonConvert.DeserializeObject<ApiResult<PaymentSubmissionPayload>>(responseContent);
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
            Assert.That(result.Succeed, Is.False);
        }

        [Then(@"The response must contain the error code")]
        public void ThenTheResponseMustContainTheErrorCode()
        {
            throw new NotImplementedException();
        }

        [Then(@"The response must contain the error code (.*)")]
        public void ThenTheResponseMustContainTheErrorCode(string ErrorCode)
        {
            Assert.That(result.ErrorCode, Is.EqualTo(ErrorCode));
        }


    }
}
