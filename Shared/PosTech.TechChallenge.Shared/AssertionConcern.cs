using PosTech.PortFolio.Entities;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PosTech.TechChallenge.Shared
{
    public class AssertionConcern
    {
        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue)) { throw new ArgumentException(message); }
        }

        public static void AssertArgumentNotNull(object objectData, string message)
        {
            if(objectData == null) {  throw new ArgumentException(message);}
        }

        public static void AssertArgumentLength(string stringValue, int minLength, int maxLength, string message)
        {
            if (stringValue.Length < minLength || stringValue.Length > maxLength) { throw new ArgumentException(message); }
        }

        public static void AssertArgumentMinValue(int numValue, int minLength, string message)
        {
            if (numValue < minLength) { throw new ArgumentException(message); }
        }

        public static void AssertDoublePositiveValue(double doubleValue, string message)
        {
            if (doubleValue < 0)
                throw new ArgumentException(message);
        }
        public static void AssertArgumentDate(DateTime dateValue, DateTime minDate, DateTime maxData, string message)
        {
            if(dateValue <  minDate || dateValue > maxData) { throw new ArgumentException(message); }
        }

        public static void AssertArgumentEmailIsValid(string email, string message)
        {

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException(message);

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }

                if (!Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    throw new ArgumentException(message);
            }
            catch (Exception)
            {
                throw new ArgumentException(message);
            }
        }

        public static void AssertArgumentIsNull(object objectData, string message)
        {
            if (objectData != null)
                throw new ArgumentException(message);
        }

        public static void AssetArgumentNotEquals(string baseValue, string value, string message)
        {
            if((bool)baseValue?.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                throw new ArgumentException(message);
        }
    }
}
