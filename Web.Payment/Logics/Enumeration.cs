using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Payment.Logics
{
    public enum CreditCardType
    {
        [Display(Name = "Visa Card")]
        VisaCard = 1,

        [Display(Name = "Master Card")]
        MasterCard = 2,

        [Display(Name = "American Express Card")]
        AmericanCard = 4
    }
}
