using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Payment.ViewModels
{
    public class VerificationModel
    {
        [Required(ErrorMessage = "Card Owner field is required.")]
        public string CardOwner { get; set; }

        [Required(ErrorMessage = "Card Number field is required.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiration Date field is required.")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVC field is required.")]
        public string CVC { get; set; }
    }
}
