using System;

using Web.Payment.Models.Interfaces;
using Web.Payment.Logics;
using Web.Payment.Logics.CreditCards;
using Web.Payment.Logics.CreditCards.Validators;

namespace Web.Payment.Models
{
    public class CreditCard : ICreditCard
    {
        #region Constructors

        public CreditCard() { }

        public CreditCard(ICreditCard creditCard)
        {
            this.CardOwner = creditCard.CardOwner;
            this.CardNumber = creditCard.CardNumber;
            this.ExpirationDate = creditCard.ExpirationDate;
            this.CVC = creditCard.CVC;
        }

        #endregion


        #region Properties

        public string CardOwner { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string CVC { get; set; }

        #endregion


        #region Abstract Members

        public virtual CreditCardType CardType { get => throw new NotImplementedException(); }

        public virtual ICardValidator GetCardValidator() => throw new NotImplementedException();

        #endregion
    }
}
