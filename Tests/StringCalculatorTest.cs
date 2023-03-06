using Workshop;

namespace Tests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.SumString("");
            Assert.Equal(0, result);    
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("1", 1)]
        [InlineData("225", 225)]
        [InlineData("25", 25)]
        public void SingleNumberReturnsValue(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12,13", 25)]
        [InlineData("1,3", 4)]
        [InlineData("225,34", 259)]

        public void StringSumComa(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12\n13", 25)]
        [InlineData("1\n3", 4)]
        [InlineData("225\n34", 259)]

        public void StringSumNewLine(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12\n13,1", 26)]
        [InlineData("0,1\n3", 4)]
        [InlineData("1,225\n34", 260)]

        public void MultiSeparatedValues(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-3,4")]
        [InlineData("1\n5,-34")]

        public void NegativeValueThrowsArgumentException(string str)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                StringCalculator.SumString(str);
            });
        }

        [Theory]
        [InlineData("1200\n13,1", 14)]
        [InlineData("0,1\n35466", 1)]
        [InlineData("15,1001\n1", 16)]
        [InlineData("1000", 1000)]
        [InlineData("1768", 0)]

        public void IgnoringNumbersGreaterThan1000(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("//#\n12\n13#1", 26)]
        [InlineData("//$\n0,1\n35$46", 82)]
        [InlineData("//a\n15a11\n1", 27)]

        public void CustomSeparator(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }
    }
}