using System;

using Web.Payment.Models.Interfaces;
using Web.Payment.Models;
using Web.Payment.Logics.CreditCards.Validators;
using Web.Payment.Logics.CreditCards.Brands.interfaces;

namespace Web.Payment.Logics.CreditCards.Brands
{
    public class AmericanCard : CreditCard
    {
        #region Static Members

        private static Lazy<ICardValidator> _validator = new Lazy<ICardValidator>(() => new AmericanCardValidator());
        public static ICardValidator Validator => _validator.Value;


        public static ICardBuilder<AmericanCard> Builder => new CardBuilder();

        #endregion


        #region Constructors

        public AmericanCard(ICreditCard card) : base(card) { }

        #endregion


        #region Override Methods

        public override CreditCardType CardType => CreditCardType.AmericanCard;

        public override ICardValidator GetCardValidator() => Validator;

        #endregion


        #region Inner Classes

        public class CardBuilder : ICardBuilder<AmericanCard>
        {
            public AmericanCard Create(ICreditCard card)
            {
                return new AmericanCard(card);
            }
        }

        #endregion
    }
}
