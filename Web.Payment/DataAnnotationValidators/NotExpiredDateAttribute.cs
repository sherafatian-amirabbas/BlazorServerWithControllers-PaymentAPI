using System;
using System.ComponentModel.DataAnnotations;

using Web.Payment.Logics.CreditCards.Validators.DateExpirationValidators;
using Web.Payment.Logics.Services;

namespace Web.Payment.DataAnnotationValidators
{
    public class NotExpiredDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is DateTime)
            {
                var dateExpirationValidator = GetDateExpirationValidator(validationContext);
                if (dateExpirationValidator.IsExpired((DateTime)value))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }


        #region Private Methods

        private IDateExpirationValidator GetDateExpirationValidator(ValidationContext validationContext)
        {
            var creditCardService = GetCreditCardService(validationContext);
            return creditCardService.DateExpirationValidator;
        }

        private ICreditCardService GetCreditCardService(ValidationContext validationContext)
        {
            return (ICreditCardService)validationContext.GetService(typeof(ICreditCardService));
        }

        #endregion
    }
}
