namespace CruxlabTestTask.BL
{
    /// <summary>
    /// Validator. Main class.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Determines if the password is valid.
        /// </summary>
        /// <param name="passwordString">Password data string.</param>
        /// <returns>Result.</returns>
        private bool IsValid(PasswordDataString passwordDataString)
        {
            int count = 0;

            foreach (var symbol in passwordDataString.Password)
            {
                if (symbol.Equals(passwordDataString.Symbol))
                {
                    count++;
                }
            }

            return count >= passwordDataString.Min && count <= passwordDataString.Max;
        }

        /// <summary>
        /// Counts how many passwords are valid in the list.
        /// </summary>
        /// <param name="passwordDataStrings">List of password data strings.</param>
        /// <returns>Number of valid passwords.</returns>
        public int ValidPasswordsCount(IEnumerable<PasswordDataString> passwordDataStrings)
        {
            int count = 0;

            foreach (var passwordDataString in passwordDataStrings)
            {
                if (IsValid(passwordDataString))
                {
                    count++;
                }
            }

            return count;
        }
    }
}