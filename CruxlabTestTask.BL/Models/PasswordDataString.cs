namespace CruxlabTestTask.BL.Models
{
    /// <summary>
    /// Helper class. Represents a single line with a password requirement and a password in a text file.
    /// </summary>
    public class PasswordDataString
    {
        /// <summary>
        /// First password requirement (repeating symbol).
        /// </summary>
        public char Symbol { get; set; }
        /// <summary>
        /// Part of the second password requirement (minimum number of repeating symbol).
        /// </summary>
        public uint Min { get; set; }
        /// <summary>
        /// Part of the second password requirement (maximum number of repeating symbol).
        /// </summary>
        public uint Max { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string? Password { get; set; }
    }
}