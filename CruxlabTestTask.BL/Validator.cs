namespace CruxlabTestTask.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passwordString"></param>
        /// <returns></returns>
        private bool IsValid(string passwordString)
        {
            var passDataString = Parser.HardParse(passwordString);

            int count = 0;

            foreach (var symbol in passDataString.Password)
            {
                if (symbol.Equals(passDataString.Symbol))
                {
                    count++;
                }
            }

            return count >= passDataString.Min && count <= passDataString.Max;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passwordStrings"></param>
        /// <returns></returns>
        public int ValidPasswordsCount(IEnumerable<string> passwordStrings)
        {
            int count = 0;

            foreach (var passwordString in passwordStrings)
            {
                if (IsValid(passwordString))
                {
                    count++;
                }
            }

            return count;
        }
    }
}