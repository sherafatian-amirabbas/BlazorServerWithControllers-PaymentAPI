using System;

using Web.Payment.Common;
using Web.Payment.Logics.CreditCards;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics
{
    public class CreditCardService
    {
        private readonly ICreditCardFactory iCreditCardFactory;

        public CreditCardService(ICreditCardFactory iCreditCardFactory)
        {
            this.iCreditCardFactory = iCreditCardFactory;
        }

        public Result<VerificationPayload> Verify(ICreditCard iCreditCard)
        {
            if (iCreditCard == null)
                throw new ArgumentNullException();


            var result = new Result<VerificationPayload>(false);

            if (String.IsNullOrWhiteSpace(iCreditCard.CardOwner))
            {
                result.ErrorMessage = "Card Owner field is required";
                result.ErrorCode = "100";
                return result;
            }

            if (string.IsNullOrWhiteSpace(iCreditCard.CardNumber))
            {
                result.ErrorMessage = "Card Number field is required";
                result.ErrorCode = "105";
                return result;
            }


            if (string.IsNullOrWhiteSpace(iCreditCard.CVC))
            {
                result.ErrorMessage = "CVC field should be greater than zero";
                result.ErrorCode = "110";
                return result;
            }


            int cvc = 0;
            if (!int.TryParse(iCreditCard.CVC, out cvc) || cvc <= 0)
            {
                result.ErrorMessage = "CVC field should be a number and greater than zero";
                result.ErrorCode = "115";
                return result;
            }


            if (iCreditCard.ExpirationDate.Date < DateTime.Now.Date)
            {
                result.ErrorMessage = "The card is expired";
                result.ErrorCode = "125";
                return result;
            }


            var cCard = this.iCreditCardFactory.GetConcreteCreditCard(iCreditCard);
            if (cCard == null)
            {
                result.ErrorMessage = "Card Number is not valid";
                result.ErrorCode = "120";
                return result;
            }


            var validator = cCard.GetCardValidator();
            if (!validator.ValidateCardNumber(cCard.CardNumber))
            {
                result.ErrorMessage = "Card Number is not valid";
                result.ErrorCode = "120";
                return result;
            }


            if (!validator.ValidateCVC(cCard.CVC))
            {
                result.ErrorMessage = "CVC is not valid";
                result.ErrorCode = "130";
                return result;
            }


            result.Succeed = true;
            result.Payload = new VerificationPayload(cCard.CardType);
            return result;
        }


        #region Inner Classes

        public class VerificationPayload
        {
            public VerificationPayload(CreditCardType cardType)
            {
                this.CardType = cardType;
            }

            public CreditCardType CardType { get; set; }
        }

        #endregion
    }
}
