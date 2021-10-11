using System;
using System.Collections.Generic;

using Web.Payment.Common;
using Web.Payment.Logics.CreditCards.Brands.interfaces;
using Web.Payment.Logics.CreditCards.Validators.DateExpirationValidators;
using Web.Payment.Logics.Services;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics.CreditCards.Services
{
    public class CreditCardService : ICreditCardService
    {
        #region Static Mmbers

        static Lazy<IDateExpirationValidator> _dateValidator =
            new Lazy<IDateExpirationValidator>(() => new DateJustExpiredValidator());

        #endregion


        private readonly ICreditCardFactory iCreditCardFactory;


        #region Constructors

        public CreditCardService(ICreditCardFactory iCreditCardFactory)
        {
            this.iCreditCardFactory = iCreditCardFactory;
        }

        #endregion


        #region Public Methods

        public IDateExpirationValidator DateExpirationValidator => _dateValidator.Value;

        public IResult<IVerificationPayload> Verify(ICreditCard iCreditCard)
        {
            if (iCreditCard == null)
                throw new ArgumentNullException("iCreditCard", "cannot be null");


            bool succeed = false;
            List<ResultError> errors = new List<ResultError>();
            VerificationPayload payload = null;


            var cCard = this.iCreditCardFactory.GetConcreteCreditCard(iCreditCard);
            if (cCard == null)
                errors.Add(new ResultError("CC120", Messages.CC120));
            else
            {
                var validator = cCard.GetCardValidator();
                if (validator.ValidateCVC(cCard.CVC))
                {
                    succeed = true;
                    payload = new VerificationPayload(cCard.CardType);
                }
                else 
                    errors.Add(new ResultError("CC130", Messages.CC130));
            }

            return new Result<IVerificationPayload>(succeed, errors, payload);
        }

        #endregion
    }
}
