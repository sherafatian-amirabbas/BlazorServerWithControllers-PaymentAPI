using System;
using System.ComponentModel.DataAnnotations;


namespace Web.Payment.Common.DataAnnotationValidators
{
    public abstract class NotExpiredDateAbstractAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is DateTime)
            {
                if (this.GetDateValidator().IsExpired((DateTime)value))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }

        public abstract IDateExpirationValidator GetDateValidator();
    }
}
