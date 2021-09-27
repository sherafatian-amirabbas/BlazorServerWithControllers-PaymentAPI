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
    public class VisaCard : model.CreditCard
    {
        // All Visa card numbers start with a 4. New cards have 16 digits. Old cards have 13.
        // http://www.regular-expressions.info/creditcard.html

        public static Regex CardNumberRegex = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$", RegexOptions.Compiled);


        #region Constructors

        public VisaCard(ICreditCard card) : base(card) { }

        #endregion


        public override CreditCardType Type { get => CreditCardType.VisaCard; }

        public override bool ValidateCardNumber()
        {
            if (string.IsNullOrEmpty(this.CardNumber))
                return false;

            return CardNumberRegex.IsMatch(this.CardNumber);
        }

        public override bool ValidateCVC()
        {
            // As I searched, I found Visa cards have 3 digits as CVC

            return model.CreditCard.ThreeDigitsCVCRegex.IsMatch(this.CVC);
        }
    }
}
