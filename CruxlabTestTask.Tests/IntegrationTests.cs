using CruxlabTestTask.BL;

namespace CruxlabTestTask.Tests
{
    public class IntegrationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*[TestCase("abcdj", 1, 5, 'a', 1)]
        [TestCase("bhhkkbbjjjb", 3, 6, 'b', 3)]*/
        [Test]
        public void LoadingFileWithMixedPasswordsTest_4validPasswords()
        {
            // Arrange
            string fileName = "Resources\\mixed valid and invalid passwords.txt";
            TxtReader txtReader = new TxtReader(fileName);
            Validator validator = new Validator();
            int expectedCount = 2;

            // Act
            List<string> passwordStrings = txtReader.Load();
            int actualCount = validator.ValidPasswordsCount(passwordStrings);

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /*[TestCase("asfalseiruqwo", 2, 4, 'z')]*/
        [Test]
        public void LoadingFileWithInvalidPasswordsTest_InvalidPassword(/*string passString, int min, int max, char symbol*/)
        {
            // Arrange
            string fileName = "Resources\\invalid passwords.txt";
            TxtReader txtReader = new TxtReader(fileName);
            Validator validator = new Validator();
            int expectedCount = 0;

            // Act
            List<string> passwordStrings = txtReader.Load();
            int actualCount = validator.ValidPasswordsCount(passwordStrings);

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}