using System;
using System.Text.RegularExpressions;

using Web.Payment.Models.Interfaces;
using Web.Payment.Models;
using Web.Payment.Logics.CreditCards.Validators;
using Web.Payment.Logics.CreditCards.Brands.interfaces;


namespace Web.Payment.Logics.CreditCards.Brands
{
    public class VisaCard : CreditCard
    {
        #region Static Members

        /// <summary>
        /// All Visa card numbers start with a 4. New cards have 16 digits.Old cards have 13. http://www.regular-expressions.info/creditcard.html
        /// </summary>
        public static readonly Regex VisaCardNumber = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$", RegexOptions.Compiled);

        private static Lazy<ICardValidator> _validator = new Lazy<ICardValidator>(() => new VisaCardValidator());
        public static ICardValidator Validator => _validator.Value;

        public static ICardBuilder<VisaCard> Builder => new CardBuilder();

        #endregion


        #region Constructors

        public VisaCard(ICreditCard card) : base(card) { }

        #endregion


        #region Override Methods

        public override CreditCardType CardType => CreditCardType.VisaCard;

        public override ICardValidator GetCardValidator() => Validator;

        #endregion


        #region Inner Classes

        public class CardBuilder : ICardBuilder<VisaCard>
        {
            public VisaCard Create(ICreditCard card)
            {
                return new VisaCard(card);
            }
        }

        #endregion
    }
}
