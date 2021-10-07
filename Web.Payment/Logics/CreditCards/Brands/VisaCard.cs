using System;

using Web.Payment.Models.Interfaces;
using Web.Payment.Models;
using Web.Payment.Logics.CreditCards.Validators;
using Web.Payment.Logics.CreditCards.Brands.interfaces;

namespace Web.Payment.Logics.CreditCards.Brands
{
    public class VisaCard : CreditCard
    {
        #region Static Members

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
