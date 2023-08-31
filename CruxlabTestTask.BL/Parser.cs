namespace CruxlabTestTask.BL
{
    /// <summary>
    /// 
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// First option of parsing.
        /// </summary>
        /// <param name="passwordString"></param>
        /// <returns></returns>
        public static PassDataString Parse(string passwordString)
        {
            //тут можно было бы ещё реализовать с использованием регулярных выражений, но я их плохо помню, поэтому:
            PassDataString passDataString = new PassDataString();

            var splitedString = passwordString.Split(new char[] { '-', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            passDataString.Symbol = splitedString[0].ToCharArray().First();
            passDataString.Min = Convert.ToUInt32(splitedString[1]);
            passDataString.Max = Convert.ToUInt32(splitedString[2]);
            passDataString.Password = splitedString[3];

            return passDataString;
        }

        /// <summary>
        /// Second option of parsing with strong check string for valid.
        /// </summary>
        /// <param name="passwordString"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static PassDataString HardParse(string passwordString)
        {
            //тут можно было бы ещё реализовать с использованием регулярных выражений, но я их плохо помню, поэтому:
            PassDataString passDataString = new PassDataString();

            var indexWhiteSpace = passwordString.IndexOf(' ');
            var subString = passwordString.Substring(0, indexWhiteSpace);
            if (!char.TryParse(subString, out char symbol))
            {
                throw new ArgumentException("Invalid string in file!", nameof(subString));
            }
            else
            {
                passDataString.Symbol = symbol;
            }

            var indexHyphen = passwordString.IndexOf('-');
            subString = passwordString.Substring(indexWhiteSpace + 1, indexHyphen - indexWhiteSpace - 1);
            if (!uint.TryParse(subString, out uint number1))
            {
                throw new ArgumentException("Invalid string in file!", nameof(subString));
            }
            else
            {
                passDataString.Min = number1;
            }

            var indexColon = passwordString.IndexOf(':');
            subString = passwordString.Substring(indexHyphen + 1, indexColon - indexHyphen - 1);
            if (!uint.TryParse(subString, out uint number2))
            {
                throw new ArgumentException("Invalid string in file!", nameof(subString));
            }
            else if (number1 > number2)
            {
                throw new ArgumentException("Invalid string in file! Min value cannot be biggest than Max.", nameof(subString));
            }
            else
            {
                passDataString.Max = number2;
            }

            passDataString.Password = passwordString.Substring(indexColon + 2);

            return passDataString;
        }

        // TODO: REMOVE Parse1
        /// <summary>
        /// First option of parsing.
        /// </summary>
        /// <param name="passwordString"></param>
        /// <returns></returns>
        public static PassDataString Parse1(string passwordString)
        {
            //тут можно было бы ещё реализовать с использованием регулярных выражений, но я их плохо помню, поэтому:
            PassDataString passDataString = new PassDataString();
            var splitedString = passwordString.Split(' ');
            passDataString.Symbol = splitedString[0].ToCharArray().First();
            var strMinMax = splitedString[1].Split(new char[] { '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
            var strMin = strMinMax.First();
            var strMax = strMinMax.Last();
            passDataString.Min = Convert.ToUInt32(strMin);
            passDataString.Max = Convert.ToUInt32(strMax);
            passDataString.Password = splitedString[2];

            return passDataString;
        }
    }
}