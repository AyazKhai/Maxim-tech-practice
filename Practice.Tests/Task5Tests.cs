namespace Practice.Tests
{
    public class Task5Tests
    {
        [TestCase("cba", "abc")]
        [TestCase("dcba", "abcd")]
        [TestCase("", "")]
        [TestCase("aAaBb", "ABaab")]
        [TestCase("abcdcba", "aabbccd")]
        public void QuickSortString_ValidInput_ReturnsSortedString(string input, string expected)
        {
            // Act
            string result = Task5.QuickSortString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("cba", "abc")]
        [TestCase("dcba", "abcd")]
        [TestCase("", "")]
        [TestCase("aAaBb", "ABaab")]
        [TestCase("abcdcba", "aabbccd")]
        public void TreeSort_ValidInput_ReturnsSortedString(string input, string expected)
        {
            // Arrange
            using (var sw = new System.IO.StringWriter())
            {
                System.Console.SetOut(sw);

                BinaryTreeSort.SortString(input);
                string result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
                
            }
        }
    }
}
