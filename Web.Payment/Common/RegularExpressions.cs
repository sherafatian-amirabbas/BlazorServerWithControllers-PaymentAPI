using System.Text.RegularExpressions;


namespace Web.Payment.Common
{
    public static class RegularExpressions
    {
        /// <summary>
        /// Regex matches against 3 digits
        /// </summary>
        private static Regex _threeDigits = new Regex(@"^[0-9]{3}$", RegexOptions.Compiled);
        static public Regex ThreeDigits => _threeDigits;

        /// <summary>
        /// Regex matches against 4 digits
        /// </summary>
        private static Regex _fourDigits = new Regex(@"^[0-9]{4}$", RegexOptions.Compiled);
        static public Regex FourDigits => _fourDigits;
    }
}
