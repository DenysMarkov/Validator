namespace CruxlabTestTask.BL
{
    /// <summary>
    /// Class for working with text files.
    /// </summary>
    public class TxtReader
    {
        private FileStream fileStream;
        private StreamReader textReader;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="adressFile">Adress of text file.</param>
        public TxtReader(string adressFile)
        {
            fileStream = new FileStream(adressFile, FileMode.Open, FileAccess.Read);
            textReader = new StreamReader(fileStream);
        }

        /// <summary>
        /// Loading password data strings.
        /// </summary>
        /// <returns>List of password strings.</returns>
        public List<string> Load()
        {
            List<string> listToParse = new List<string>();
            string str = textReader.ReadLine();

            while (!string.IsNullOrEmpty(str))
            {
                listToParse.Add(str);

                str = textReader.ReadLine();
            }

            textReader.Close();
            fileStream.Close();

            return listToParse;
        }
    }
}