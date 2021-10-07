using Web.Payment.Common;
using Web.Payment.Logics.CreditCards.Brands;


namespace Web.Payment.Logics.CreditCards.Validators
{
    public class MasterCardValidator : ICardValidator
    {
        public bool ValidateCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return false;

            return MasterCard.MasterCardNumber.IsMatch(cardNumber);
        }

        public bool ValidateCVC(string CVC)
        {
            return RegularExpressions.ThreeDigits.IsMatch(CVC);
        }
    }
}
