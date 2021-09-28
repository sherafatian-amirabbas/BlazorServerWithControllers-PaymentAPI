using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Payment.Logics.CreditCards.Validators
{
    public interface ICardValidator
    {
        bool ValidateCardNumber(string cardNumber);
        bool ValidateCVC(string CVC);
    }
}
