using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.Payment.Models.Interfaces;
using Web.Payment.Logics;
using System.Text.RegularExpressions;

namespace Web.Payment.Models
{
    public class CreditCard : ICreditCard
    {
        public static Regex ThreeDigitsCVCRegex = new Regex(@"^[0-9]{3}$", RegexOptions.Compiled);
        public static Regex FourDigitsCVCRegex = new Regex(@"^[0-9]{4}$", RegexOptions.Compiled);


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

        public virtual CreditCardType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool ValidateCardNumber()
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateCVC()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
