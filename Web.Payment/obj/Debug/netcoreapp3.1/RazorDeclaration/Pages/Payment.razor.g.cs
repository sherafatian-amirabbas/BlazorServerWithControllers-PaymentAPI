// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Web.Payment.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Web.Payment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Web.Payment.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Web.Payment.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Web.Payment.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\_Imports.razor"
using Web.Payment.Logics;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/payment")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Payment : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 67 "C:\Amir\Projects\BlazorServerWithControllers-PaymentAPI\Web.Payment\Pages\Payment.razor"
       
    PaymentState state;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        state = new PaymentState()
        {
            payment = new PaymentModel(),
            submissionState = null
        };
    }

    private async Task ValidSubmitHandler()
    {
        var serialized = JsonConvert.SerializeObject(state.payment);
        var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
        var response = await http.PostAsync($"{navigationManager.BaseUri}api/payment", stringContent);
        var result = await response.Content.ReadAsStringAsync();
        state.submissionState = JsonConvert.DeserializeObject<ApiResult<PaymentSubmissionPayload>>(result);
    }

    class PaymentState
    {
        public PaymentModel payment { get; set; }
        public ApiResult<PaymentSubmissionPayload> submissionState { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
