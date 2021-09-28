using Web.Payment.Logics.CreditCards.Validators;
using Web.Payment.Models;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics.CreditCards
{
    public class MasterCard : CreditCard
    {
        #region Static Members

        public static ICardValidator Validator { get; private set; }
        static MasterCard()
        {
            Validator = new MasterCardValidator();
        }

        #endregion


        #region Constructors

        public MasterCard(ICreditCard card) : base(card) { }

        #endregion


        #region Override Methods

        public override CreditCardType CardType => CreditCardType.MasterCard;

        public override ICardValidator GetCardValidator() => Validator;

        #endregion
    }
}
