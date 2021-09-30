using System;
using System.Net;

using Web.Payment.Common;
using Web.Payment.Logics;
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
            var result = this.appHttpClient.DeserializeContent<Result<CreditCardService.VerificationPayload>>(response);
            return new VerificationResult(response.StatusCode, result);
        }

        #endregion


        #region Inner Classes

        public class VerificationResult
        {
            public VerificationResult(HttpStatusCode statusCode, Result<CreditCardService.VerificationPayload> result)
            {
                StatusCode = statusCode;
                ApiResult = result;
            }

            public HttpStatusCode StatusCode { get; }
            public Result<CreditCardService.VerificationPayload> ApiResult { get; }
        }

        #endregion
    }
}
