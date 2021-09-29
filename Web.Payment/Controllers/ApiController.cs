using System.Net;

using Microsoft.AspNetCore.Mvc;

using Web.Payment.Logics;
using Web.Payment.Models;
using Web.Payment.Common;


namespace Web.Payment.Controllers
{
    public class ApiController : Controller
    {
        private readonly CreditCardFacade creditCardFacade;

        public ApiController(CreditCardFacade creditCardFacade)
        {
            this.creditCardFacade = creditCardFacade;
        }


        [Route("/api/CreditCard/verify")]
        [HttpPost]
        public IActionResult Verify([FromBody] CreditCard cCard)
        {
            Result<CreditCardService.VerificationPayload> result;
            if (!ModelState.IsValid)
            {
                var errorList = ModelState.ToErrorList();
                result = new Result<CreditCardService.VerificationPayload>(Errors: errorList);
            }
            else
                result = creditCardFacade.VerifyCreditCard(cCard);

            var returnValue = new JsonResult(result);

            if (!result.Succeed)
                returnValue.StatusCode = (int)HttpStatusCode.BadRequest;

            return returnValue;
        }
    }
}