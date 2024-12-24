using AoC2024.Day24;
using Xunit;

namespace AoC2024.Tests.Day24;

public class Day24Tests
{
    [Theory]
    [InlineData("Day24/TestInput_a.txt",4)]
    [InlineData("Day24/TestInput_b.txt",2024)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
}