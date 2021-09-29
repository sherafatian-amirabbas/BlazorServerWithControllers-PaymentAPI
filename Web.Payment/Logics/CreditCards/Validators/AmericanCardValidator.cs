
namespace Web.Payment.Logics.CreditCards.Validators
{
    public class AmericanCardValidator : ICardValidator
    {
        public bool ValidateCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return false;

            return RegularExpressions.AmericanExpressCardNumber.IsMatch(cardNumber);
        }

        public bool ValidateCVC(string CVC)
        {
            return RegularExpressions.FourDigits.IsMatch(CVC);
        }
    }
}
