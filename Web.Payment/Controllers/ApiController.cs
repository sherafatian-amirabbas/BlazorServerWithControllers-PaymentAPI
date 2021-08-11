using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Payment.Logics;
using Web.Payment.Models.Interfaces;
using Web.Payment.Models;
using Web.Payment.ViewModels;

namespace Web.Payment.Controllers
{
    public class ApiController : Controller
    {
        [Route("/api/payment")]
        [HttpPost]
        public IActionResult Payment([FromBody]CreditCard cCard)
        {
            var result = Facade.SubmitPayment(cCard);
            var returnValue = new JsonResult(result);

            if (!result.Succeed)
                returnValue.StatusCode = result.StatusCode;

            return returnValue;
        }
    }
}