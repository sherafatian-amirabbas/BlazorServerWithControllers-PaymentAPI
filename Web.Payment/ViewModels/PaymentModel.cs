using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.Payment.Models.Interfaces;

namespace Web.Payment.ViewModels
{
    public class PaymentModel : ICreditCard
    {
        [Required(ErrorMessage = "Card Owner field is required.")]
        public string CardOwner { get; set; }

        [Required(ErrorMessage = "Card Number field is required.")]
        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVC field is required.")]
        public string CVC { get; set; }
    }
}
