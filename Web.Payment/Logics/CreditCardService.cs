using System;
using System.Collections.Generic;

using Web.Payment.Common;
using Web.Payment.Common.DataAnnotationValidators;
using Web.Payment.Logics.CreditCards;
using Web.Payment.Logics.CreditCards.Validators.DateExpirationValidators;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics
{
    public class CreditCardService
    {
        #region Static Mmbers

        public static IDateExpirationValidator DateValidator { get; private set; }
        static CreditCardService()
        {
            DateValidator = new DateJustExpiredValidator();
        }

        #endregion


        private readonly ICreditCardFactory iCreditCardFactory;


        #region Constructors

        public CreditCardService(ICreditCardFactory iCreditCardFactory)
        {
            this.iCreditCardFactory = iCreditCardFactory;
        }

        #endregion


        #region Public Methods

        public Result<VerificationPayload> Verify(ICreditCard iCreditCard)
        {
            if (iCreditCard == null)
                throw new ArgumentNullException();

            List<Err> errors = new List<Err>();

            var cCard = this.iCreditCardFactory.GetConcreteCreditCard(iCreditCard);
            if (cCard == null)
                errors.Add(new Err("CC120", Messages.CC120));
            else
            {
                var validator = cCard.GetCardValidator();
                if (!validator.ValidateCVC(cCard.CVC))
                    errors.Add(new Err("CC130", Messages.CC130));
            }

            var result = new Result<VerificationPayload>(false, errors);
            if (errors.Count == 0)
            {
                result.Succeed = true;
                result.Payload = new VerificationPayload(cCard.CardType);
            }

            return result;
        }

        #endregion


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
