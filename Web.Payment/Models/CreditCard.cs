using System;
using System.ComponentModel.DataAnnotations;

using Web.Payment.Models.Interfaces;
using Web.Payment.Logics;
using Web.Payment.Logics.CreditCards.Validators;
using Web.Payment.DataAnnotationValidators;


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

        [Required(ErrorMessage = "CC100")]
        public string CardOwner { get; set; }

        [Required(ErrorMessage = "CC105")]
        public string CardNumber { get; set; }

        [NotExpiredDate(ErrorMessage = "CC125")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "CC110")]
        [Range(0, int.MaxValue, ErrorMessage = "CC115")]
        public string CVC { get; set; }

        #endregion


        #region Abstract Members

        public virtual CreditCardType CardType { get => CreditCardType.None; }

        public virtual ICardValidator GetCardValidator() => throw new NotImplementedException();

        #endregion
    }
}
