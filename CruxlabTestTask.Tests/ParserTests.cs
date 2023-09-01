using CruxlabTestTask.BL;
using CruxlabTestTask.BL.Models;

namespace CruxlabTestTask.Tests
{
    public class ParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(" t 1-5: ttxftngccstYtStt2")]
        [TestCase(" 1-5: ttxftngccstYtStt2")]
        [TestCase("t -5: ttxftngccstYtStt2")]
        [TestCase("t 15: ttxftngccstYtStt2")]
        [TestCase("t 1-: ttxftngccstYtStt2")]
        [TestCase("t 1-5 ttxftngccstYtStt2")]
        [TestCase("t 5-1: ttxftngccstYtStt2")]
        [TestCase("t 1-5: ")]
        [TestCase("t 1-5:")]
        public void HardParseTest_InvalidPasswordString_ArgumentException(string passwordString)
        {
            // Arrange
            string invalidPasswordString = passwordString;

            // Act $ Assert
            Assert.Throws<ArgumentException>(() => Parser.HardParse(passwordString));
        }

        [Test]
        public void HardParseTest_ValidPasswordString_ParcedString()
        {
            // Arrange
            string passwordString = "H 8-12: ttojisc4j78xftngccstYtStt2";
            PasswordDataString expectedParsedString = 
                new PasswordDataString
                {
                    Symbol = 'H',
                    Min = 8,
                    Max = 12,
                    Password = "ttojisc4j78xftngccstYtStt2"
                };

            // Act
            var actualParsedString = Parser.HardParse(passwordString);

            // Assert
            Assert.IsNotNull(actualParsedString);
            Assert.True(IsEqualObjects(expectedParsedString, actualParsedString));
        }

        [Test]
        public void ParseBatchTest_2validPasswordStrings_2parcedStrings()
        {
            // Arrange
            List<string> passwordStrings = new()
            {
                "t 1-5: ttxftngccstYtStt2",
                "5 2-11: afhoo4fo4hf98h"
            };
            List<PasswordDataString> expectedParsedStrings = new()
            {
                new PasswordDataString
                {
                    Symbol = 't',
                    Min = 1,
                    Max = 5,
                    Password = "ttxftngccstYtStt2"
                },
                new PasswordDataString
                {
                    Symbol = '5',
                    Min = 2,
                    Max = 11,
                    Password = "afhoo4fo4hf98h"
                }
            };

            // Act
            var actualParsedStrings = Parser.ParseBatch(passwordStrings);

            // Assert
            Assert.IsNotNull(actualParsedStrings);
            Assert.True(IsEqualObjects(expectedParsedStrings, actualParsedStrings));
        }

        private bool IsEqualObjects (List<PasswordDataString> expected, IEnumerable<PasswordDataString> actual)
        {
            List<PasswordDataString> listActual = (List<PasswordDataString>)actual;

            for (var i = 0; i < expected.Count(); i++)
            {
                IsEqualObjects(expected[i], listActual[i]);
            }

            return true;
        }

        private bool IsEqualObjects (PasswordDataString expected, PasswordDataString actual)
        {
            Assert.That(actual.Symbol, Is.EqualTo(expected.Symbol));
            Assert.That(actual.Min, Is.EqualTo(expected.Min));
            Assert.That(actual.Max, Is.EqualTo(expected.Max));
            Assert.That(actual.Password, Is.EqualTo(expected.Password));

            return true;
        }
    }
}