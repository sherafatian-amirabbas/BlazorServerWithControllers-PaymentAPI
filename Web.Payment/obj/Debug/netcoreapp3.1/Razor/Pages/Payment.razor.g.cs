#pragma checksum "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22dc16f027370f838929fed7f3feea829f46292b"
// <auto-generated/>
#pragma warning disable 1591
namespace Web.Payment.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Web.Payment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Web.Payment.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Web.Payment.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
using Web.Payment.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\_Imports.razor"
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
#nullable restore
#line 9 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
 if (state != null && state.payment != null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "card p-3 col-lg-6 offset-lg-3");
            __builder.AddMarkupContent(3, "\r\n\r\n");
#nullable restore
#line 13 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
         if (state.submissionState != null && state.submissionState.Succeed)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "            ");
            __builder.OpenElement(5, "label");
            __builder.AddAttribute(6, "class", "text-success");
            __builder.AddContent(7, "Operation is successfully done via your ");
            __builder.AddContent(8, 
#nullable restore
#line 15 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                                                                                  state.submissionState.Payload.CardType.GetDisplayName()

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(9, ".");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 16 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(11, "            Please fill out the form to make the payment\r\n");
            __builder.AddContent(12, "            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(13);
            __builder.AddAttribute(14, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 21 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                             state.payment

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 21 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                                                           ValidSubmitHandler

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(16, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(17, "\r\n\r\n                <br>\r\n\r\n                ");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "form-floating mb-3");
                __builder2.AddMarkupContent(20, "\r\n                    ");
                __builder2.OpenElement(21, "input");
                __builder2.AddAttribute(22, "type", "text");
                __builder2.AddAttribute(23, "class", "form-control");
                __builder2.AddAttribute(24, "id", "input_owner");
                __builder2.AddAttribute(25, "placeholder", "card owner");
                __builder2.AddAttribute(26, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 27 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                                        state.payment.CardOwner

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(27, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => state.payment.CardOwner = __value, state.payment.CardOwner));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(29, "\r\n\r\n                ");
                __builder2.OpenElement(30, "div");
                __builder2.AddAttribute(31, "class", "form-floating mb-3");
                __builder2.AddMarkupContent(32, "\r\n                    ");
                __builder2.OpenElement(33, "input");
                __builder2.AddAttribute(34, "type", "number");
                __builder2.AddAttribute(35, "class", "form-control");
                __builder2.AddAttribute(36, "id", "input_number");
                __builder2.AddAttribute(37, "placeholder", "card number");
                __builder2.AddAttribute(38, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 32 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                                        state.payment.CardNumber

#line default
#line hidden
#nullable disable
                , culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.AddAttribute(39, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => state.payment.CardNumber = __value, state.payment.CardNumber, culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(40, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n\r\n                ");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "form-floating mb-3");
                __builder2.AddMarkupContent(44, "\r\n                    ");
                __builder2.OpenElement(45, "input");
                __builder2.AddAttribute(46, "type", "date");
                __builder2.AddAttribute(47, "class", "form-control");
                __builder2.AddAttribute(48, "id", "input_expiry");
                __builder2.AddAttribute(49, "placeholder", "expiration date");
                __builder2.AddAttribute(50, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 37 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                                        state.payment.ExpirationDate

#line default
#line hidden
#nullable disable
                , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.AddAttribute(51, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => state.payment.ExpirationDate = __value, state.payment.ExpirationDate, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(52, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(53, "\r\n\r\n                ");
                __builder2.OpenElement(54, "div");
                __builder2.AddAttribute(55, "class", "form-floating mb-3");
                __builder2.AddMarkupContent(56, "\r\n                    ");
                __builder2.OpenElement(57, "input");
                __builder2.AddAttribute(58, "type", "number");
                __builder2.AddAttribute(59, "class", "form-control");
                __builder2.AddAttribute(60, "id", "input_cvc");
                __builder2.AddAttribute(61, "placeholder", "CVC");
                __builder2.AddAttribute(62, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 42 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                                        state.payment.CVC

#line default
#line hidden
#nullable disable
                , culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.AddAttribute(63, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => state.payment.CVC = __value, state.payment.CVC, culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(64, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n\r\n                ");
                __builder2.AddMarkupContent(66, "<button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n\r\n                <br>\r\n                <br>\r\n\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(67);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(68, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(69);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(70, "\r\n\r\n");
#nullable restore
#line 53 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                 if (state.submissionState != null && !state.submissionState.Succeed)
                {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(71, "                    ");
                __builder2.OpenElement(72, "ul");
                __builder2.AddMarkupContent(73, "\r\n                        ");
                __builder2.OpenElement(74, "li");
                __builder2.AddAttribute(75, "style", "color: red;");
                __builder2.AddContent(76, 
#nullable restore
#line 56 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                                                 state.submissionState.ErrorMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(77, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(78, "\r\n");
#nullable restore
#line 58 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
                }

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(79, "\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(80, "\r\n");
#nullable restore
#line 61 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(81, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(82, "\r\n");
#nullable restore
#line 64 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 67 "C:\Users\amirabba\Desktop\BlazorServerWithControllers\Web.Payment\Pages\Payment.razor"
       
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
