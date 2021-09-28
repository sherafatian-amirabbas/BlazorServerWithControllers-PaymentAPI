using System;
using System.Net.Http;
using System.Text;

using Newtonsoft.Json;


namespace Web.Payment.SpecFlow.Controller.Support
{
    public class AppHttpClient
    {
        private readonly ApplicationContext appContext;
        private readonly HttpClient httpClient;


        #region Constructors

        public AppHttpClient(ApplicationContext appContext)
        {
            this.appContext = appContext;
            this.httpClient = this.appContext.HttpClient;
        }

        #endregion


        #region Public Methods


        public HttpResponseMessage Post(HttpContent data, Uri endPoint)
        {
            return this.httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, endPoint)
            {
                Content = data
            })
            .Result;
        }

        public StringContent SerializeContent(object data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }

        public T DeserializeContent<T>(HttpResponseMessage response)
        {
            string content = this.ReadContent(response);
            return JsonConvert.DeserializeObject<T>(content);
        }

        public string ReadContent(HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }

        #endregion
    }
}
