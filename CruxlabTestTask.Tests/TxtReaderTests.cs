using CruxlabTestTask.BL;

namespace CruxlabTestTask.Tests
{
    public class TxtReaderTests
    {
        [Test]
        public void LoadTest_addressTXTFile_LoadedStrings()
        {
            // Arrange
            string fileName = "Resources\\valid passwords.txt";
            TxtReader txtReader = new(fileName);
            List<string> expectedPasswordStrings = new()
            {
                "d 2-4: adalsdeiruddqwo",
                "G 4-7: zGhhFbGjGjbGG",
                "L 11-14: aiLLuvLLLLnibLvaLLibn_LLiaeuvnL",
                "5 2-5: Nj5dncnC5nJN5Cs5C"
            };

            // Act
            var actualPasswordStrings = txtReader.Load();

            // Assert
            Assert.IsNotNull(actualPasswordStrings);
            Assert.True(IsEqualObjects(expectedPasswordStrings, actualPasswordStrings));
        }

        private bool IsEqualObjects (List<string> expected, List<string> actual)
        {
            for (var i = 0; i < expected.Count(); i++)
            {
                Assert.That(actual[i], Is.EqualTo(expected[i]));
            }

            return true;
        }
    }
}