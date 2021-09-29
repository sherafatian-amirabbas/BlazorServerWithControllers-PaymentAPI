
namespace Web.Payment.Logics.CreditCards.Validators
{
    public interface ICardValidator
    {
        bool ValidateCardNumber(string cardNumber);
        bool ValidateCVC(string CVC);
    }
}
