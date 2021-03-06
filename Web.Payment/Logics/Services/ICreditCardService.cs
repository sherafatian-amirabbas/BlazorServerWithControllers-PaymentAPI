using Web.Payment.Common;
using Web.Payment.Logics.CreditCards.Validators.DateExpirationValidators;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics.Services
{
    public interface ICreditCardService
    {
        IDateExpirationValidator DateExpirationValidator { get; }
        IResult<IVerificationPayload> Verify(ICreditCard iCreditCard);
    }
}
