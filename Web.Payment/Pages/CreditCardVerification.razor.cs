using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using Newtonsoft.Json;

using Web.Payment.Common;
using Web.Payment.ViewModels;
using Web.Payment.Logics;


namespace Web.Payment.Pages
{
    public partial class CreditCardVerification : ComponentBase
    {
        const string END_POINT = "api/CreditCard/verify";


        #region Injects

        [Inject]
        protected HttpClient http { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        #endregion


        protected VerificationState State { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            State = new VerificationState()
            {
                Model = new VerificationModel(),
                VerificationResult = null
            };
        }


        #region Handlers

        protected async Task VerificationHandler()
        {
            var serialized = JsonConvert.SerializeObject(State.Model);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await http.PostAsync($"{navigationManager.BaseUri + END_POINT}", stringContent);
            var result = await response.Content.ReadAsStringAsync();
            State.VerificationResult = JsonConvert.DeserializeObject<Result<CreditCardService.VerificationPayload>>(result);
        }

        #endregion


        #region Inner Classes

        protected class VerificationState
        {
            public VerificationModel Model { get; set; }
            public Result<CreditCardService.VerificationPayload> VerificationResult { get; set; }
        }

        #endregion
    }
}
