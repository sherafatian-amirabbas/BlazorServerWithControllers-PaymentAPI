using System.Net;

using Microsoft.AspNetCore.Mvc;

using Web.Payment.Models;
using Web.Payment.Common;
using Web.Payment.Logics.Services;


namespace Web.Payment.Controllers
{
    public class ApiController : Controller
    {
        private readonly ICreditCardService creditCardService;

        public ApiController(ICreditCardService creditCardService)
        {
            this.creditCardService = creditCardService;
        }


        [Route("/api/CreditCard/verify")]
        [HttpPost]
        public IActionResult Verify([FromBody] CreditCard cCard)
        {
            Result<IVerificationPayload> result;
            if (!ModelState.IsValid)
            {
                var errorList = ModelState.ToErrorList();
                result = new Result<IVerificationPayload>(Errors: errorList);
            }
            else
                result = creditCardService.Verify(cCard);

            var returnValue = new JsonResult(result);

            if (!result.Succeed)
                returnValue.StatusCode = (int)HttpStatusCode.BadRequest;

            return returnValue;
        }
    }
}