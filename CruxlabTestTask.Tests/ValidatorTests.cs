using CruxlabTestTask.BL;
using CruxlabTestTask.BL.Models;

namespace CruxlabTestTask.Tests
{
    public class ValidatorTests
    {
        Validator validator;

        [SetUp]
        public void Setup()
        {
            validator = new Validator();
        }

        [Test]
        public void ValidPasswordsCountTest_ValidPasswords_2EqualPass()
        {
            // Arrange
            List<PasswordDataString> passwordDataStrings = new()
            {
                new PasswordDataString
                {
                    Symbol = 'a',
                    Min = 1,
                    Max = 5,
                    Password = "abcdj"
                },
                new PasswordDataString
                {
                    Symbol = 'b',
                    Min = 2,
                    Max = 7,
                    Password = "bhhkkbbjjjb"
                }
            };
            int expectedCount = 2;

            // Act
            int actualCount = validator.ValidPasswordsCount(passwordDataStrings);

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void ValidPasswordsCountTest_InvalidPassword_0EqualPass()
        {
            // Arrange
            List<PasswordDataString> passwordDataStrings = new()
            {
                new PasswordDataString
                {
                    Symbol = 'f',
                    Min = 12,
                    Max = 15,
                    Password = "asfgalTseiQrCuqXwo"
                },
                new PasswordDataString
                {
                    Symbol = 'e',
                    Min = 111,
                    Max = 122,
                    Password = "asfgalTsezvhfvoeojeovGhUFeDhoekkviQrCuqXwo"
                },
                new PasswordDataString
                {
                    Symbol = 'j',
                    Min = 2,
                    Max = 4,
                    Password = "asfalseiruqwo"
                }
            };
            int expectedCount = 0;

            // Act
            int actualCount = validator.ValidPasswordsCount(passwordDataStrings);

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
    }
}