using Web.Payment.Models.Interfaces;
using Web.Payment.Models;
using Web.Payment.Logics.CreditCards.Validators;


namespace Web.Payment.Logics.CreditCards.Brands
{
    public class AmericanCard : CreditCard
    {
        #region Static Members

        public static ICardValidator Validator { get; private set; }
        static AmericanCard()
        {
            Validator = new AmericanCardValidator();
        }

        #endregion


        #region Constructors

        public AmericanCard(ICreditCard card) : base(card) { }

        #endregion


        #region Override Methods

        public override CreditCardType CardType => CreditCardType.AmericanCard;

        public override ICardValidator GetCardValidator() => Validator;

        #endregion
    }
}
