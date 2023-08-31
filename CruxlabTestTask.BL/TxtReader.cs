namespace CruxlabTestTask.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class TxtReader
    {
        private FileStream fileStream;
        private StreamReader textReader;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adressFile"></param>
        public TxtReader(string adressFile)
        {
            fileStream = new FileStream(adressFile, FileMode.Open, FileAccess.Read);
            textReader = new StreamReader(fileStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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