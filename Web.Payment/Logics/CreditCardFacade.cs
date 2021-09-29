using Web.Payment.Common;
using Web.Payment.Common.DataAnnotationValidators;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics
{
    public class CreditCardFacade
    {
        #region Static Members

        public static IDateExpirationValidator DateExpirationValidator
        {
            get => CreditCardService.DateValidator;
        }

        #endregion


        private readonly CreditCardService creditCardService;

        #region Constructors

        public CreditCardFacade(CreditCardService creditCardService)
        {
            this.creditCardService = creditCardService;
        }

        #endregion


        #region Public Methods

        public Result<CreditCardService.VerificationPayload> VerifyCreditCard(ICreditCard cCard)
        {
            return this.creditCardService.Verify(cCard);
        }

        #endregion
    }
}
