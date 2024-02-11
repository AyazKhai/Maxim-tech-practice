namespace Practice.Tests
{
    public class Task3Tests
    {
        [Test]
        public void GetRecurLettersString_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            string input = "abcde";
            string expected = "a 1; b 1; c 1; d 1; e 1; ";

            // Act
            var result = Task3.GetRecurLettersString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetRecurLettersString_RepeatingCharacters_ReturnsExpectedResult()
        {
            // Arrange
            string input = "aabbc";
            string expected = "a 2; b 2; c 1; ";

            // Act
            var result = Task3.GetRecurLettersString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetRecurLettersString_EmptyInput_ReturnsEmptyString()
        {
            // Arrange
            string input = "";
            string expected = "";

            // Act
            var result = Task3.GetRecurLettersString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetRecurLettersString_NonEnglishCharacters_ReturnsEmptyString()
        {
            // Arrange
            string input = "abc123";
            string expected = "";

            // Act
            var result = Task3.GetRecurLettersString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetRecurLettersString_NullInput_ReturnsEmptyString()
        {
            // Arrange
            string input = null;
            string expected = "";

            // Act
            var result = Task3.GetRecurLettersString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetRecurLettersArrayAsync_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            string input = "abcde";
            string[] expected = { "a 1", "b 1", "c 1", "d 1", "e 1" };

            // Act
            var result = Task3.GetRecurLettersArrayAsync(input).Result;

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void GetRecurLettersArrayAsync_RepeatingCharacters_ReturnsExpectedResult()
        {
            // Arrange
            string input = "aabbc";
            string[] expected = { "a 2", "b 2", "c 1" };

            // Act
            var result = Task3.GetRecurLettersArrayAsync(input).Result;

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void GetRecurLettersArrayAsync_EmptyInput_ReturnsEmptyArray()
        {
            // Arrange
            string input = "";
            string[] expected = { };

            // Act
            var result = Task3.GetRecurLettersArrayAsync(input).Result;

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void GetRecurLettersArrayAsync_NonEnglishCharacters_ReturnsEmptyArray()
        {
            // Arrange
            string input = "abc123";
            string[] expected = { };

            // Act
            var result = Task3.GetRecurLettersArrayAsync(input).Result;

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void GetRecurLettersArrayAsync_NullInput_ReturnsEmptyArray()
        {
            // Arrange
            string input = null;
            string[] expected = { };

            // Act
            var result = Task3.GetRecurLettersArrayAsync(input).Result;

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }


}
