using System.ComponentModel.DataAnnotations;


namespace Web.Payment.Logics
{
    public enum CreditCardType
    {
        [Display(Name = "None")]
        None = 1,

        [Display(Name = "Visa Card")]
        VisaCard = 2,

        [Display(Name = "Master Card")]
        MasterCard = 4,

        [Display(Name = "American Express Card")]
        AmericanCard = 8
    }
}
