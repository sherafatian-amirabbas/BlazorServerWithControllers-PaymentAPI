using System;
using System.Net;

using Web.Payment.Common;
using Web.Payment.Logics;
using Web.Payment.SpecFlow.Controller.Support;


namespace Web.Payment.SpecFlow.Controller.Drivers
{
    public class PaymentDriver
    {
        const string END_POINT = "/api/payment";

        private readonly ApplicationContext appContext;
        private readonly AppHttpClient appHttpClient;


        #region Constructors

        public PaymentDriver(ApplicationContext appContext, AppHttpClient appHttpclient)
        {
            this.appContext = appContext;
            this.appHttpClient = appHttpclient;
        }

        #endregion


        #region Public Methods

        public VerificationResult Verify(CreditCardDataModel creditCard)
        {
            var endPoint = new Uri(this.appContext.BaseUri, END_POINT);
            var content = this.appHttpClient.SerializeContent(creditCard);
            var response = this.appHttpClient.Post(content, endPoint);
            var apiResult = this.appHttpClient.DeserializeContent<ApiResult<PaymentSubmissionPayload>>(response);
            return new VerificationResult(response.StatusCode, apiResult);
        }

        #endregion


        #region Inner Classes

        public class VerificationResult
        {
            public VerificationResult(HttpStatusCode statusCode, ApiResult<PaymentSubmissionPayload> apiResult)
            {
                StatusCode = statusCode;
                ApiResult = apiResult;
            }

            public HttpStatusCode StatusCode { get; }
            public ApiResult<PaymentSubmissionPayload> ApiResult { get; }
        }

        #endregion
    }
}
