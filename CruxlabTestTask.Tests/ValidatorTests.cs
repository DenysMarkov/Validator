using CruxlabTestTask.BL;

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
            List<string> passwordStrings = new List<string>
            {
                "a 1-5: abcdj" ,
                "b 3-6: bhhkkbbjjjb"
            };
            int expectedCount = 2;

            // Act
            int actualCount = validator.ValidPasswordsCount(passwordStrings);

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ValidPasswordsCountTest_InvalidPassword_0EqualPass()
        {
            // Arrange
            List<string> passwordStrings = new List<string>
            {
                "f 12-15: asfgalTseiQrCuqXwo",
                "e 111-122: asfgalTsezvhfvoeojeovGhUFeDhoekkviQrCuqXwo",
                "j 2-4: asfalseiruqwo"
            };
            int expectedCount = 0;

            // Act
            int actualCount = validator.ValidPasswordsCount(passwordStrings);

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}