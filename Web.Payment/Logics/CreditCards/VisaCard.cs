using Web.Payment.Models.Interfaces;
using Web.Payment.Models;
using Web.Payment.Logics.CreditCards.Validators;


namespace Web.Payment.Logics.CreditCards
{
    public class VisaCard : CreditCard
    {
        #region Static Members

        public static ICardValidator Validator { get; private set; }
        static VisaCard()
        {
            Validator = new VisaCardValidator();
        }

        #endregion


        #region Constructors

        public VisaCard(ICreditCard card) : base(card) { }

        #endregion


        #region Override Methods

        public override CreditCardType CardType => CreditCardType.VisaCard;

        public override ICardValidator GetCardValidator() => Validator;

        #endregion
    }
}
