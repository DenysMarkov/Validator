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
        public void LoadingFileWithMixedPasswordsTest_4validPasswords()
        {
            // Arrange
            string fileName = "Resources\\mixed valid and invalid passwords.txt";
            TxtReader txtReader = new TxtReader(fileName);
            int expectedCount = 2;

            // Act
            List<string> passwordStrings = txtReader.Load();
            int actualCount = validator.ValidPasswordsCount(passwordStrings);

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void LoadingFileWithInvalidPasswordsTest_InvalidPassword()
        {
            // Arrange
            string fileName = "Resources\\invalid passwords.txt";
            TxtReader txtReader = new TxtReader(fileName);
            int expectedCount = 0;

            // Act
            List<string> passwordStrings = txtReader.Load();
            int actualCount = validator.ValidPasswordsCount(passwordStrings);

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
    }
}