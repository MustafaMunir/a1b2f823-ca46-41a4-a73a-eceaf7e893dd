using Xunit;
using IntSequenceString;

namespace IntSequenceString.UnitTests
{
    public class IntSequenceString_LongestIncreasingSubsequence
    {
        private readonly IntSequenceString _intSequenceString;

        public IntSequenceString_LongestIncreasingSubsequence()
        {
            _intSequenceString = new IntSequenceString();
        }

        [Theory]
        [InlineData("6 1 5 9 2", "1 5 9")]
        public void LongestIncreasingSubsequenceTests(string input, string expected)
        {
            var result = _intSequenceString.LongestIncreasingSubsequence(input);
            Assert.True(result.Equals(expected), "Unexpected result.");
        }
    }
}