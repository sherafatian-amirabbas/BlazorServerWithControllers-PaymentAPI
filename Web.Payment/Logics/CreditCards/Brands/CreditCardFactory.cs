using System;
using System.Collections.Generic;
using System.Linq;

using Web.Payment.Logics.CreditCards.Brands.interfaces;
using Web.Payment.Logics.CreditCards.Validators;
using Web.Payment.Models;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.Logics.CreditCards.Brands
{
    public class CreditCardFactory : ICreditCardFactory
    {
        static Lazy<List<ValidatorCreatorPair>> brands => new Lazy<List<ValidatorCreatorPair>>(() =>
        {
            return new List<ValidatorCreatorPair>()
            {
                new ValidatorCreatorPair(AmericanCard.Validator, AmericanCard.Builder.Create),
                new ValidatorCreatorPair(MasterCard.Validator, MasterCard.Builder.Create),
                new ValidatorCreatorPair(VisaCard.Validator, VisaCard.Builder.Create)
            };
        });


        public CreditCard GetConcreteCreditCard(ICreditCard cCard)
        {
            if (cCard == null)
                throw new ArgumentNullException();

            var brand = brands.Value.FirstOrDefault(u => u.Validator.ValidateCardNumber(cCard.CardNumber));
            if (brand != null)
                return brand.Creator(cCard);

            return null;
        }


        #region inner classes

        class ValidatorCreatorPair
        {
            public ValidatorCreatorPair(ICardValidator validator, Func<ICreditCard, CreditCard> creator)
            {
                Validator = validator;
                Creator = creator;
            }

            public ICardValidator Validator { get; }
            public Func<ICreditCard, CreditCard> Creator { get; }
        }

        #endregion
    }
}
