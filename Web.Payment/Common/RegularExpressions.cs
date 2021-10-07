using System.Text.RegularExpressions;


namespace Web.Payment.Common
{
    public static class RegularExpressions
    {
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
