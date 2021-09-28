using Web.Payment.Common;


namespace Web.Payment.Logics.CreditCards.Validators
{
    public class VisaCardValidator : ICardValidator
    {
        public bool ValidateCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return false;

            return RegularExpressions.VisaCardNumber.IsMatch(cardNumber);
        }

        public bool ValidateCVC(string CVC)
        {
            return RegularExpressions.ThreeDigits.IsMatch(CVC);
        }
    }
}
