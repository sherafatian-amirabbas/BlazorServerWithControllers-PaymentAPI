using System;
using System.Net;

using Web.Payment.SpecFlow.Controller.Support;


namespace Web.Payment.SpecFlow.Controller.Drivers
{
    public class CreditCardDriver
    {
        const string END_POINT = "/api/CreditCard/verify";

        private readonly ApplicationContext appContext;
        private readonly AppHttpClient appHttpClient;


        #region Constructors

        public CreditCardDriver(ApplicationContext appContext, AppHttpClient appHttpclient)
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
            var result = this.appHttpClient.DeserializeContent<SpCreditCardApiResult<SPCreditCardVerificationPayload>>(response);
            return new VerificationResult(response.StatusCode, result);
        }

        #endregion


        #region Inner Classes

        public class VerificationResult
        {
            public VerificationResult(HttpStatusCode statusCode, SpCreditCardApiResult<SPCreditCardVerificationPayload> result)
            {
                StatusCode = statusCode;
                ApiResult = result;
            }

            public HttpStatusCode StatusCode { get; }
            public SpCreditCardApiResult<SPCreditCardVerificationPayload> ApiResult { get; }
        }

        #endregion
    }
}
