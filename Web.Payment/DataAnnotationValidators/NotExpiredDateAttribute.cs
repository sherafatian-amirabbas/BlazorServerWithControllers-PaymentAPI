using Web.Payment.Common.DataAnnotationValidators;
using Web.Payment.Logics;


namespace Web.Payment.DataAnnotationValidators
{
    public class NotExpiredDateAttribute : NotExpiredDateAbstractAttribute
    {
        public override IDateExpirationValidator GetDateValidator()
        {
            return CreditCardFacade.DateExpirationValidator;
        }
    }
}
