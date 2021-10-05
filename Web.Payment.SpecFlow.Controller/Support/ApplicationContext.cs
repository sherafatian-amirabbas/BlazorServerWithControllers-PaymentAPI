using System;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc.Testing;


namespace Web.Payment.SpecFlow.Controller.Support
{
    public class ApplicationContext
    {
        #region Static Members

        static Lazy<WebApplicationFactory<Startup>> _appFactory = new Lazy<WebApplicationFactory<Startup>>(() => new WebApplicationFactory<Startup>());

        static Lazy<HttpClient> _httpClientLazy = new Lazy<HttpClient>(() => _appFactory.Value.CreateClient());

        static Lazy<Uri> _baseUri = new Lazy<Uri>(() => _appFactory.Value.ClientOptions.BaseAddress);

        #endregion


        #region Properties

        public HttpClient HttpClient { get => _httpClientLazy.Value; }
        public Uri BaseUri { get => _baseUri.Value; }

        #endregion
    }
}
