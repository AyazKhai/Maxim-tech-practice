using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Tests
{
    public class Task4Tests
    {
        [TestCase("aa","aa")]
        [TestCase("cbafed", "afe")]
        [TestCase("edcbaabcde", "edcbaabcde")]
        public void LongestVowStrVowString_ValidInput_ReturnsCorrectResult(string input,string expected)
        {
            // Act
            string result = Task4.LongestVowStrVowString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void LongestVowStrVowString_NoVowels_ReturnsNull()
        {
            // Arrange
            string input = "bcdfghjklmnpqrstvwxz";

            // Act
            string result = Task4.LongestVowStrVowString(input);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void LongestVowStrVowString_EmptyInput_ReturnsNull()
        {
            // Arrange
            string input = "";

            // Act
            string result = Task4.LongestVowStrVowString(input);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void LongestVowStrVowString_AllVowels_ReturnsInput()
        {
            // Arrange
            string input = "aeiouy";

            // Act
            string result = Task4.LongestVowStrVowString(input);

            // Assert
            Assert.AreEqual(input, result);
        }
    }
}
