using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Payment.Common;
using Web.Payment.Logics.CreditCard;
using Web.Payment.Models;
using Web.Payment.Models.Interfaces;

namespace Web.Payment.Logics
{
    public class Facade
    {
        private static CreditCardFactory iCreditCardFactory;

        static Facade()
        {
            iCreditCardFactory = new CreditCardFactory();
        }

        public static ApiResult<PaymentSubmissionPayload> SubmitPayment(ICreditCard cCard)
        {
            return new Payment(cCard, iCreditCardFactory).Submit();
        }
    }
}
