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
    public class MasterCard : model.CreditCard
    {
        // MasterCard numbers either start with the numbers 51 through 55 or with the numbers 2221 through 2720. All have 16 digits.
        // http://www.regular-expressions.info/creditcard.html

        public static Regex CardNumberRegex = new Regex(@"^5[1-5][0-9]{14}$", RegexOptions.Compiled);


        #region Constructors

        public MasterCard(ICreditCard card) : base(card) { }

        #endregion


        public override CreditCardType Type { get => CreditCardType.MasterCard; }

        public override bool ValidateCardNumber()
        {
            if (string.IsNullOrEmpty(this.CardNumber))
                return false;

            return CardNumberRegex.IsMatch(this.CardNumber);
        }

        public override bool ValidateCVC()
        {
            // As I searched, I found Master cards have 3 digits as CVC

            return model.CreditCard.ThreeDigitsCVCRegex.IsMatch(this.CVC);
        }
    }
}
