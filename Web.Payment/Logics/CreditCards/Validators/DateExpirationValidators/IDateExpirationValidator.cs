using System;


namespace Web.Payment.Logics.CreditCards.Validators.DateExpirationValidators
{
    public interface IDateExpirationValidator
    {
        bool IsExpired(DateTime date);
    }
}
