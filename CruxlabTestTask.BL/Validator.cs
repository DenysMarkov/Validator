using System.Linq;
using CruxlabTestTask.BL.Models;

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
        /// <param name="passwordDataString">Password data string.</param>
        /// <returns>Result.</returns>
        private bool IsValid(PasswordDataString passwordDataString)
        {
            int count = passwordDataString.Password.Count(symbol => symbol.Equals(passwordDataString.Symbol));

            return count >= passwordDataString.Min && count <= passwordDataString.Max;
        }

        /// <summary>
        /// Counts how many passwords are valid in the list.
        /// </summary>
        /// <param name="passwordDataStrings">List of password data strings.</param>
        /// <returns>Number of valid passwords.</returns>
        public int ValidPasswordsCount(IEnumerable<PasswordDataString> passwordDataStrings)
        {
            int count = passwordDataStrings.Count(passwordDataString => IsValid(passwordDataString));

            return count;
        }
    }
}