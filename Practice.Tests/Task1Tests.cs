namespace Practice.Tests
{
    public class Task1Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Replacer_EvenLengthInput_ReversesFirstHalfAndSecondHalf()
        {
            // Arrange
            string input = "abcdefgh";

            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.AreEqual("dcbahgfe", input);
        }

        [Test]
        public void Replacer_OddLengthInput_ReversesWholeStringAndAppendsOriginal()
        {
            // Arrange
            string input = "abcde";

            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.AreEqual("edcbaabcde", input);
        }

        [Test]
        public void Replacer_OddLengthInput_ReversesWholeStringAndAppendsOriginal_Russian_InLowerCase()
        {
            // Arrange
            string input = "АБВГД";

            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.AreEqual("ДГВБААБВГД", input);
        }

        [Test]
        public void Replacer_OddLengthInput_ReversesWholeStringAndAppendsOriginal_Russian_InSmallCase()
        {
            // Arrange
            string input = "абвгд";

            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.AreEqual("дгвбаабвгд", input);
        }

        [Test]
        public void Replacer_EvenLengthInput_ReversesFirstHalfAndSecondHalf_Russian_InSmallCase()
        {
            // Arrange
            string input = "абвгдежз";

            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.AreEqual("гвбазжед", input);
        }

        [Test]
        public void Replacer_EvenLengthInput_ReversesFirstHalfAndSecondHalf_Russian_InLowerCase()
        {
            // Arrange
            string input = "АБВГДЕЖЗ";

            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.AreEqual("ГВБАЗЖЕД", input);
        }
        [TestCase("a")]
        public void Replacer_OneSymbLengthInput_ReversesFirstHalfAndSecondHalf(string teststring)
        {
            string input = teststring;
            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.AreEqual("aa", input);
        }

        [TestCase("ab")]
        public void Replacer_TwoSymbLengthInput_ReversesFirstHalfAndSecondHalf(string teststring)
        {
            string input = teststring;
            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.AreEqual("ab", input);
        }

        [Test]
        public void Replacer_NullInput_ReturnsNull()
        {
            // Arrange
            string input = null;

            // Act
            Task1.Replacer(ref input);

            // Assert
            Assert.IsNull(input);
        }

    }


}