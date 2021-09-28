using System;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc.Testing;


namespace Web.Payment.SpecFlow.Controller.Support
{
    public class ApplicationContext
    {
        #region Static Members

        static WebApplicationFactory<Startup> _appFactory;
        static Lazy<HttpClient> _httpClientLazy;
        static Lazy<Uri> _baseUri;

        static ApplicationContext()
        {
            _appFactory = new WebApplicationFactory<Startup>();
            _httpClientLazy = new Lazy<HttpClient>(() => _appFactory.CreateClient());
            _baseUri = new Lazy<Uri>(() => _appFactory.ClientOptions.BaseAddress);
        }

        #endregion


        #region Properties

        public HttpClient HttpClient { get => _httpClientLazy.Value; }
        public Uri BaseUri { get => _baseUri.Value; }

        #endregion
    }
}
