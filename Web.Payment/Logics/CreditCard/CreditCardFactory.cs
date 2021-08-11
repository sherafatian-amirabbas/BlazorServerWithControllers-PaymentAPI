using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Payment.Models.Interfaces;
using model = Web.Payment.Models;

namespace Web.Payment.Logics.CreditCard
{
    public interface ICreditCardFactory
    {
        model.CreditCard GetConcreteCreditCard(ICreditCard cCard);
    }

    public class CreditCardFactory : ICreditCardFactory
    {
        public model.CreditCard GetConcreteCreditCard(ICreditCard cCard)
        {
            var visaCard = new VisaCard(cCard);
            if (visaCard.ValidateCardNumber())
                return visaCard;

            var masterCard = new MasterCard(cCard);
            if (masterCard.ValidateCardNumber())
                return masterCard;

            var americanCard = new AmericanCard(cCard);
            if (americanCard.ValidateCardNumber())
                return americanCard;

            return null;
        }
    }
}
