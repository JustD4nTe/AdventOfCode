using AoC2024.Day25;
using Xunit;

namespace AoC2024.Tests.Day25;

public class Day25Tests
{
    [Theory]
    [InlineData("Day25/TestInput_a.txt",3)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
}