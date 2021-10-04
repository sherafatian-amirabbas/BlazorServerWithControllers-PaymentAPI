using System;

using Web.Payment.Models;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics.CreditCards.Brands
{
    public interface ICreditCardFactory
    {
        CreditCard GetConcreteCreditCard(ICreditCard cCard);
    }

    public class CreditCardFactory : ICreditCardFactory
    {
        public CreditCard GetConcreteCreditCard(ICreditCard cCard)
        {
            if (cCard == null)
                throw new ArgumentNullException();


            if (AmericanCard.Validator.ValidateCardNumber(cCard.CardNumber))
                return new AmericanCard(cCard);

            if (MasterCard.Validator.ValidateCardNumber(cCard.CardNumber))
                return new MasterCard(cCard);

            if (VisaCard.Validator.ValidateCardNumber(cCard.CardNumber))
                return new VisaCard(cCard);


            return null;
        }
    }
}
