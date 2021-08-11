using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Payment.Common;
using Web.Payment.Logics.CreditCard;
using Web.Payment.Models.Interfaces;
using model = Web.Payment.Models;

namespace Web.Payment.Logics
{
    public class Payment
    {
        private readonly ICreditCard iCreditCard;
        private readonly ICreditCardFactory iFactory;
        private model.CreditCard creditCard;

        public Payment(ICreditCard iCreditCard, ICreditCardFactory iFactory)
        {
            this.iCreditCard = iCreditCard;
            this.iFactory = iFactory;
            this.creditCard = this.iFactory.GetConcreteCreditCard(this.iCreditCard);
        }

        public ApiResult<PaymentSubmissionPayload> Submit()
        {
            var returnValue = this.ValidateCreditCard();
            if (!returnValue.Succeed)
                return returnValue;


            /* Rest of the submission code comes here */


            returnValue.Payload = new PaymentSubmissionPayload()
            {
                CardType = creditCard.Type
            };
            return returnValue;
        }


        #region Private Members

        private ApiResult<PaymentSubmissionPayload> ValidateCreditCard()
        {
            var returnValue = new ApiResult<PaymentSubmissionPayload>(false, (int)HttpStatusCode.BadRequest);

            if (String.IsNullOrWhiteSpace(this.iCreditCard.CardOwner))
            {
                returnValue.ErrorMessage = "Card Owner field is required";
                returnValue.ErrorCode = "100";
                return returnValue;
            }

            if (string.IsNullOrWhiteSpace(this.iCreditCard.CardNumber))
            {
                returnValue.ErrorMessage = "Card Number field is required";
                returnValue.ErrorCode = "105";
                return returnValue;
            }


            if (string.IsNullOrWhiteSpace(this.iCreditCard.CVC))
            {
                returnValue.ErrorMessage = "CVC field should be greater than zero";
                returnValue.ErrorCode = "110";
                return returnValue;
            }


            int cvc = 0;
            if (!int.TryParse(this.iCreditCard.CVC, out cvc) || cvc <= 0)
            {
                returnValue.ErrorMessage = "CVC field should be greater than zero";
                returnValue.ErrorCode = "115";
                return returnValue;
            }


            if (creditCard == null || !creditCard.ValidateCardNumber())
            {
                returnValue.ErrorMessage = "Card Number is not valid";
                returnValue.ErrorCode = "120";
                return returnValue;
            }

            if (creditCard.ExpirationDate.Date < DateTime.Now.Date)
            {
                returnValue.ErrorMessage = "The card is expired";
                returnValue.ErrorCode = "125";
                return returnValue;
            }

            if (!creditCard.ValidateCVC())
            {
                returnValue.ErrorMessage = "CVC is not valid";
                returnValue.ErrorCode = "130";
                return returnValue;
            }

            return new ApiResult<PaymentSubmissionPayload>(true);
        }

        #endregion
    }

    public class PaymentSubmissionPayload
    {
        public CreditCardType CardType { get; set; }
    }
}
