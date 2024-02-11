namespace Practice.Tests
{
    public class Task2Tests
    {
        [TestCase("abc", true)]
        [TestCase("abc123", false)]
        [TestCase("ABC", false)]
        [TestCase("aBc", false)]
        [TestCase("a!b@c#", false)]
        public void IsValidEngStringInLower_InputString_ReturnsExpectedResult(string input, bool expected)
        {
            // Act
            bool result = Task2.IsValidEngStringInLower(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("abc", "")]
        [TestCase("abc123", "123")]
        [TestCase("ABC", "ABC")]
        [TestCase("aBc", "B")]
        [TestCase("a!b@c#", "!@#")]
        public void GetNonEnglishLetterInLowerCase_InputString_ReturnsExpectedResult(string input, string expected)
        {
            // Act
            string result = Task2.GetNonEnglishLetterInLowerCase(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
