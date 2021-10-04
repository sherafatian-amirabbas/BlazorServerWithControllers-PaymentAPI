
namespace Web.Payment.Logics.Services
{
    public interface IVerificationPayload
    {
        CreditCardType CardType { get; }
    }
}
