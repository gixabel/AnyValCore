using System;
using System.Linq;
using System.Text;

namespace AnyValCore
{
    public class AnyVal
    {
        private const string DownCharList = "abcdefghijklmnopqrstuvwxyz";
        private const string UpDownCharList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string UpDownNumberCharList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string EndOfLineDot = ".\r\n";
        private static readonly Random Randomizer = new Random(Environment.TickCount);

        /// <summary>
        /// Gets a positive integer, starting from zero to the maximum possible value
        /// </summary>
        /// <returns>Integer</returns>
        public static int PositiveInt32() => Randomizer.Next(int.MaxValue);

        /// <summary>
        /// Given a max value, gets a random positive integer
        /// </summary>
        /// <param name="maximumValue">Maximum value</param>
        /// <returns>Random positive integer</returns>
        public static int PositiveInt32(int maximumValue) => Randomizer.Next(Math.Abs(maximumValue));

        /// <summary>
        /// Given two values, gets a random positive value in between
        /// </summary>
        /// <param name="minimumValue">start range</param>
        /// <param name="maximumValue">End range</param>
        /// <returns></returns>
        public static int PositiveInt32(int minimumValue, int maximumValue)
        {
            var startValue = Math.Abs(minimumValue);
            var endValue = Math.Abs(maximumValue);
            return startValue == endValue
                ? startValue
                : startValue > endValue
                    ? Randomizer.Next(startValue - endValue) + endValue
                    : Randomizer.Next(endValue - startValue) + startValue;
        }

        /// <summary>
        /// Gets a random positive long value
        /// </summary>
        /// <returns>Long value</returns>
        public static long PositiveInt64()
        {
            long result = Randomizer.Next(Math.Abs(int.MaxValue));
            return result << 20;
        }

        /// <summary>
        /// Gets a random lowercase string with a variable, no more than 20 characters long string
        /// </summary>
        /// <returns>Random string</returns>
        public static string StringLowerCase()
        {
            return
                new string(DownCharList
                    .Select(c => DownCharList[Randomizer.Next(DownCharList.Length)])
                    .Take(Randomizer.Next(16) + 4)
                    .ToArray());
        }

        /// <summary>
        /// Given a length, returns a random string in lowercase
        /// </summary>
        /// <param name="size">String length</param>
        /// <returns>Random string</returns>
        public static string StringLowerCase(int size)
        {
            var result = string.Empty;
            while (result.Length < size)
            {
                result += DownCharList[Randomizer.Next(DownCharList.Length)];
            }
            return result;
        }

        /// <summary>
        /// Gets a random mixed case string with a variable, no more than 20 characters long string
        /// </summary>
        /// <returns>Random string</returns>
        public static string String()
        {
            var totalLength = Randomizer.Next(16) + 4;
            return new string(UpDownNumberCharList
                .Select(c => UpDownCharList[Randomizer.Next(UpDownCharList.Length)])
                .Take(totalLength)
                .ToArray());
        }

        /// <summary>
        /// Given a length, returns a random mixed case string
        /// </summary>
        /// <param name="size">String length</param>
        /// <returns>Random string</returns>
        public static string String(int size)
        {
            var result = string.Empty;
            while (result.Length < size)
            {
                result += UpDownCharList[Randomizer.Next(UpDownCharList.Length)];
            }
            return result;
        }

        /// <summary>
        /// Gets a random mixed case and numbers string with a variable, no more than 20 characters long string
        /// </summary>
        /// <returns>Random string</returns>
        public static string Alphanumeric()
        {
            var totalLength = Randomizer.Next(16) + 4;
            return new string(UpDownNumberCharList
                .Select(c => UpDownCharList[Randomizer.Next(UpDownCharList.Length)])
                .Take(totalLength)
                .ToArray());
        }

        /// <summary>
        /// Given a length, returns a random mixed case string and numbers
        /// </summary>
        /// <param name="size">String length</param>
        /// <returns>Random string</returns>
        public static string Alphanumeric(int size)
        {
            var result = string.Empty;
            while (result.Length < size)
            {
                result += UpDownCharList[Randomizer.Next(UpDownCharList.Length)];
            }
            return result;
        }

        /// <summary>
        /// Gets a random decimal value
        /// </summary>
        /// <returns>Random decimal</returns>
        public static decimal Decimal() => (decimal)Randomizer.NextDouble() * Randomizer.Next(100);

        /// <summary>
        /// Gets a random decimal value
        /// </summary>
        /// <param name="maximumValue">Maximum value</param>
        /// <returns>Random decimal</returns>
        public static decimal Decimal(int maximumValue) => (decimal)Randomizer.NextDouble() * maximumValue;

        /// <summary>
        /// Gets a random date between year 1990 and 2040
        /// </summary>
        /// <returns>Random date</returns>
        public static DateTime DateTime()
        {
            var thisYear = System.DateTime.Now.Year;
            var result = new DateTime(Randomizer.Next(thisYear - 20, thisYear + 19), 1, 1);
            return result.AddDays(Randomizer.Next(365));
        }

        /// <summary>
        /// Given a date and time, returns a future date
        /// </summary>
        /// <param name="anyDateTime"></param>
        /// <returns>Random future date</returns>
        public static DateTime DateTimeAfter(DateTime anyDateTime)
        {
            var result = anyDateTime.AddYears(Randomizer.Next(20));
            return result.AddDays(Randomizer.Next(365));
        }

        /// <summary>
        /// Given a date and time, returns a past date
        /// </summary>
        /// <param name="anyDateTime"></param>
        /// <returns>Random past date</returns>
        public static DateTime DateTimeBefore(DateTime anyDateTime)
        {
            var result = anyDateTime.AddYears(Randomizer.Next(19) * -1);
            return result.AddDays(Randomizer.Next(365) * -1);
        }

        /// <summary>
        /// Gets a random email
        /// </summary>
        /// <returns>Random email</returns>
        public static string EmailString() => $"{StringLowerCase()}@{StringLowerCase()}.{StringLowerCase(3)}";

        [Obsolete("Use EmailString instead")]
        public string Email() => $"{StringLowerCase()}@{StringLowerCase()}.{StringLowerCase(3)}";

        /// <summary>
        /// Gets a random integer, can be positive or negative
        /// </summary>
        /// <returns>Random integer</returns>
        public static int Int32() => Randomizer.Next(int.MaxValue) - Randomizer.Next(int.MaxValue);

        /// <summary>
        /// Gets a pseudo-paragraph composed by random words
        /// </summary>
        /// <param name="maximumLength"></param>
        /// <returns>String</returns>
        public static string Paragraphs(int maximumLength)
        {
            var result = new StringBuilder(String(maximumLength));
            var currentPos = maximumLength - EndOfLineDot.Length;
            while (currentPos > 0)
            {
                foreach (var endOfLineDotChar in EndOfLineDot)
                {
                    result[currentPos++] = endOfLineDotChar;
                }
                currentPos -= PositiveInt32(150) + 40;
            }
            currentPos = maximumLength - EndOfLineDot.Length - PositiveInt32(14);
            while (currentPos > 0)
            {
                if (result[currentPos] != EndOfLineDot[0] &&
                    result[currentPos] != EndOfLineDot[1] &&
                    result[currentPos] != EndOfLineDot[2])
                {
                    result[currentPos] = ' ';
                }
                currentPos -= PositiveInt32(12) + 2;
            }
            return result.ToString();
        }

        /// <summary>
        /// Generates an address
        /// </summary>
        /// <returns>String</returns>
        public static string AddressString() => $"{PositiveInt32(9999)} {String(PositiveInt32(5, 10))} {String(2)}";

        /// <summary>
        /// Generates a random boolean
        /// </summary>
        /// <returns>Bool</returns>
        public static bool Bool() => Randomizer.NextDouble() >= 0.5;

        /// <summary>
        /// Generates a random value of an enum
        /// </summary>
        /// <returns>Item of T</returns>
        public static T OfEnum<T>()
        {
            var value = Enum.GetValues(typeof(T));
            return (T) value.GetValue(Randomizer.Next(value.Length));
        }

        /// <summary>
        /// Generates a random value of an enum, except the first item
        /// </summary>
        /// <returns>Item of T</returns>
        public static T OfEnumExceptFirst<T>()
        {
            var value = Enum.GetValues(typeof(T));
            return (T) value.GetValue(Randomizer.Next(value.Length - 1) + 1);
        }
    }
}
