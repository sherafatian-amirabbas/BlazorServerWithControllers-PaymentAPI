using System;

namespace Web.Payment.Models.Interfaces
{
    public interface ICreditCard
    {
        string CardNumber { get; set; }
        string CardOwner { get; set; }
        string CVC { get; set; }
        DateTime ExpirationDate { get; set; }
    }
}