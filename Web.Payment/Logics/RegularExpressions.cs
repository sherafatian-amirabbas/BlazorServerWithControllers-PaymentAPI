using System.Text.RegularExpressions;


namespace Web.Payment.Logics
{
    public static class RegularExpressions
    {
        /// <summary>
        /// MasterCard numbers either start with the numbers 51 through 55 or with the numbers 2221 through 2720. All have 16 digits. http://www.regular-expressions.info/creditcard.html
        /// </summary>
        public static Regex MasterCardNumber = new Regex(@"^5[1-5][0-9]{14}$", RegexOptions.Compiled);


        /// <summary>
        /// All Visa card numbers start with a 4. New cards have 16 digits.Old cards have 13. http://www.regular-expressions.info/creditcard.html
        /// </summary>
        public static Regex VisaCardNumber = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$", RegexOptions.Compiled);


        /// <summary>
        /// American Express card numbers start with 34 or 37 and have 15 digits. http://www.regular-expressions.info/creditcard.html
        /// </summary>
        public static Regex AmericanExpressCardNumber = new Regex(@"^3[47][0-9]{13}$", RegexOptions.Compiled);


        /// <summary>
        /// Regex matches against 3 digits
        /// </summary>
        public static Regex ThreeDigits = new Regex(@"^[0-9]{3}$", RegexOptions.Compiled);


        /// <summary>
        /// Regex matches against 4 digits
        /// </summary>
        public static Regex FourDigits = new Regex(@"^[0-9]{4}$", RegexOptions.Compiled);
    }
}
