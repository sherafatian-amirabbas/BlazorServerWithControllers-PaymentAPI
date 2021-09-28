using System.Net;
using Microsoft.AspNetCore.Mvc;

using Web.Payment.Logics;
using Web.Payment.Models;


namespace Web.Payment.Controllers
{
    public class ApiController : Controller
    {
        private readonly Facade facade;

        public ApiController(Facade facade)
        {
            this.facade = facade;
        }


        [Route("/api/CreditCard/verify")]
        [HttpPost]
        public IActionResult Verify([FromBody]CreditCard cCard)
        {
            var result = facade.VerifyCreditCard(cCard);
            var returnValue = new JsonResult(result);

            if (!result.Succeed)
                returnValue.StatusCode = (int)HttpStatusCode.BadRequest;

            return returnValue;
        }
    }
}