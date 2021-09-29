using System;


namespace Web.Payment.Common.DataAnnotationValidators
{
    public interface IDateExpirationValidator
    {
        bool IsExpired(DateTime date);
    }
}
