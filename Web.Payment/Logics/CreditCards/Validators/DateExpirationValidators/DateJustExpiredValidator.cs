using System;

using Web.Payment.Common.DataAnnotationValidators;


namespace Web.Payment.Logics.CreditCards.Validators.DateExpirationValidators
{
    /// <summary>
    /// Date is expired if it is behind, even a second.
    /// </summary>
    public class DateJustExpiredValidator : IDateExpirationValidator
    {
        public bool IsExpired(DateTime date)
        {
            return date < DateTime.Now.Date;
        }
    }
}
