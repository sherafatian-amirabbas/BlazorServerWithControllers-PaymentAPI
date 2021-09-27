using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Web.Payment.Models.Interfaces;
using Web.Payment.Logics;
using model = Web.Payment.Models;

namespace Web.Payment.Logics.CreditCard
{
    public class AmericanCard : model.CreditCard
    {
        // American Express card numbers start with 34 or 37 and have 15 digits.
        // http://www.regular-expressions.info/creditcard.html

        public static Regex CardNumberRegex = new Regex(@"^3[47][0-9]{13}$", RegexOptions.Compiled);


        #region Constructors

        public AmericanCard(ICreditCard card) : base(card) { }

        #endregion


        public override CreditCardType Type { get => CreditCardType.AmericanCard; }

        public override bool ValidateCardNumber()
        {
            if (string.IsNullOrEmpty(this.CardNumber))
                return false;

            return CardNumberRegex.IsMatch(this.CardNumber);
        }

        public override bool ValidateCVC()
        {
            // As I searched, I found American Express cards have 4 digits as CVC

            return model.CreditCard.FourDigitsCVCRegex.IsMatch(this.CVC);
        }
    }
}
