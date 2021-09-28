using Web.Payment.Common;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics
{
    public class Facade
    {
        private readonly CreditCardService creditCardService;

        public Facade(CreditCardService creditCardService)
        {
            this.creditCardService = creditCardService;
        }

        public Result<CreditCardService.VerificationPayload> VerifyCreditCard(ICreditCard cCard)
        {
            return this.creditCardService.Verify(cCard);
        }
    }
}
