using System;
using Web.Payment.Models.Interfaces;


namespace Web.Payment.SpecFlow.Controller.Support
{
    public class CreditCardDataModel
    {
        public string CardOwner { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string CVC { get; set; }
    }
}
