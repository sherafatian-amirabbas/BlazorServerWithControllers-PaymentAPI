using Web.Payment.Logics.Services;


namespace Web.Payment.Logics.CreditCards.Services
{
    public class VerificationPayload : IVerificationPayload
    {
        public VerificationPayload(CreditCardType cardType)
        {
            this.CardType = cardType;
        }

        public CreditCardType CardType { get; private set; }
    }
}
