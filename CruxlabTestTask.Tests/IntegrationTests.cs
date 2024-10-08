using CruxlabTestTask.BL;

namespace CruxlabTestTask.Tests
{
    public class IntegrationTests
    {
        Validator validator;

        [SetUp]
        public void Setup()
        {
            validator = new Validator();
        }

        [Test]
        public void LoadingFileWithValidPasswordsTest_4validPasswords_4validPasswords()
        {
            // Arrange
            string fileName = "Resources\\valid passwords.txt";
            TxtReader txtReader = new(fileName);
            int expectedCount = 4;

            // Act
            List<string> passwordStrings = txtReader.Load();
            var parsedStrings = Parser.ParseBatch(passwordStrings);
            int actualCount = validator.ValidPasswordsCount(parsedStrings);

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void LoadingFileWithMixedPasswordsTest_2validAnd1invalidPasswords_2validPasswords()
        {
            // Arrange
            string fileName = "Resources\\mixed valid and invalid passwords.txt";
            TxtReader txtReader = new(fileName);
            int expectedCount = 2;

            // Act
            List<string> passwordStrings = txtReader.Load();
            var parsedStrings = Parser.ParseBatch(passwordStrings);
            int actualCount = validator.ValidPasswordsCount(parsedStrings);

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void LoadingFileWithInvalidPasswordsTest_InvalidPasswords_0validPasswords()
        {
            // Arrange
            string fileName = "Resources\\invalid passwords.txt";
            TxtReader txtReader = new(fileName);
            int expectedCount = 0;

            // Act
            List<string> passwordStrings = txtReader.Load();
            var parsedStrings = Parser.ParseBatch(passwordStrings);
            int actualCount = validator.ValidPasswordsCount(parsedStrings);

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void LoadingFileWithInvalidPasswordStringsTest_InvalidPasswordString_ArgumentException()
        {
            // Arrange
            string fileName = "Resources\\invalid password strings.txt";
            TxtReader txtReader = new(fileName);
            List<string> passwordStrings = txtReader.Load();

            // Act $ Assert
            Assert.Throws<ArgumentException>(() => Parser.ParseBatch(passwordStrings));
        }
    }
}