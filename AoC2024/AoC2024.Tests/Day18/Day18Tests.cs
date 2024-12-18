using AoC2024.Day18;
using Xunit;

namespace AoC2024.Tests.Day18;

public class Day18Tests
{
    [Theory]
    [InlineData("Day18/TestInput_a.txt",22)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input, 6, 12).Solve());
    }
}