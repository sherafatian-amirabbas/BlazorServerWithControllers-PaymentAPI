using System;
using Web.Payment.Logics.CreditCards.Brands.interfaces;
using Web.Payment.Logics.CreditCards.Validators;
using Web.Payment.Models;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics.CreditCards.Brands
{
    public class MasterCard : CreditCard
    {
        #region Static Members

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
