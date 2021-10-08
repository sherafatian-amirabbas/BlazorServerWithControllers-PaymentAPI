using System;
using System.Text.RegularExpressions;

using Web.Payment.Logics.CreditCards.Brands.interfaces;
using Web.Payment.Logics.CreditCards.Validators;
using Web.Payment.Models;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics.CreditCards.Brands
{
    public class MasterCard : CreditCard
    {
        #region Static Members

        /// <summary>
        /// MasterCard numbers either start with the numbers 51 through 55 or with the numbers 2221 through 2720. All have 16 digits. http://www.regular-expressions.info/creditcard.html
        /// </summary>
        public static readonly Regex MasterCardNumber = new Regex(@"^5[1-5][0-9]{14}$", RegexOptions.Compiled);

        private static Lazy<ICardValidator> _validator = new Lazy<ICardValidator>(() => new MasterCardValidator());
        public static ICardValidator Validator => _validator.Value;

        public static ICardBuilder<MasterCard> Builder => new CardBuilder();

        #endregion


        #region Constructors

        public MasterCard(ICreditCard card) : base(card) { }

        #endregion


        #region Override Methods

        public override CreditCardType CardType => CreditCardType.MasterCard;

        public override ICardValidator GetCardValidator() => Validator;

        #endregion


        #region Inner Classes

        public class CardBuilder : ICardBuilder<MasterCard>
        {
            public MasterCard Create(ICreditCard card)
            {
                return new MasterCard(card);
            }
        }

        #endregion
    }
}
