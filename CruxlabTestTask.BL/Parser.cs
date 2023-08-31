namespace CruxlabTestTask.BL
{
    /// <summary>
    /// Class for parsing strings with passwords of text files.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// The first parsing option (lazy).
        /// </summary>
        /// <param name="passwordString">Password string.</param>
        /// <returns><see cref="PasswordDataString"/> object.</returns>
        public static PasswordDataString Parse(string passwordString)
        {
            PasswordDataString passwordDataString = new();

            var splitedString = passwordString.Split(new char[] { '-', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            passwordDataString.Symbol = splitedString[0].ToCharArray().First();
            passwordDataString.Min = Convert.ToUInt32(splitedString[1]);
            passwordDataString.Max = Convert.ToUInt32(splitedString[2]);
            passwordDataString.Password = splitedString[3];

            return passwordDataString;
        }

        /// <summary>
        /// The second variant of parsing with a strong check string for validity.
        /// </summary>
        /// <param name="passwordString">Password string.</param>
        /// <returns><see cref="PasswordDataString"/> object.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static PasswordDataString HardParse(string passwordString)
        {
            PasswordDataString passwordDataString = new();

            var indexWhiteSpace = passwordString.IndexOf(' ');
            var subString = passwordString.Substring(0, indexWhiteSpace);
            if (!char.TryParse(subString, out char symbol))
            {
                throw new ArgumentException("Invalid string in file! Unable to determine symbol.", nameof(subString));
            }
            else
            {
                passwordDataString.Symbol = symbol;
            }

            var indexHyphen = passwordString.IndexOf('-');
            subString = passwordString.Substring(indexWhiteSpace + 1, indexHyphen - indexWhiteSpace - 1);
            if (!uint.TryParse(subString, out uint number1))
            {
                throw new ArgumentException("Invalid string in file! Unable to determine Min value.", nameof(subString));
            }
            else
            {
                passwordDataString.Min = number1;
            }

            var indexColon = passwordString.IndexOf(':');
            subString = passwordString.Substring(indexHyphen + 1, indexColon - indexHyphen - 1);
            if (!uint.TryParse(subString, out uint number2))
            {
                throw new ArgumentException("Invalid string in file! Unable to determine Max value.", nameof(subString));
            }
            else if (number1 > number2)
            {
                throw new ArgumentException("Invalid string in file! Min value cannot be biggest than Max.", nameof(subString));
            }
            else
            {
                passwordDataString.Max = number2;
            }

            subString = passwordString.Substring(indexColon + 2);
            if (string.IsNullOrWhiteSpace(subString))
            {
                throw new ArgumentException("Invalid string in file! Password is null.", nameof(subString));
            }
            else
            {
                passwordDataString.Password = subString;
            }

            return passwordDataString;
        }

        /// <summary>
        /// Batch parsing of password strings.
        /// </summary>
        /// <param name="passwordStrings">List of password strings.</param>
        /// <param name="isHardParse">Choice of parsing method: true - hard parsing, false - lazy parsing.</param>
        /// <returns>List of <see cref="PasswordDataString"/>.</returns>
        public static IEnumerable<PasswordDataString> ParseBatch(IEnumerable<string> passwordStrings, bool isHardParse = true)
        {
            List<PasswordDataString> passwordDataStrings = new(passwordStrings.Count());
            PasswordDataString passwordDataString;

            foreach (string passwordString in passwordStrings)
            {
                passwordDataString = isHardParse is true ? HardParse(passwordString) : Parse(passwordString);
                
                passwordDataStrings.Add(passwordDataString);
            }

            return passwordDataStrings;
        }
    }
}