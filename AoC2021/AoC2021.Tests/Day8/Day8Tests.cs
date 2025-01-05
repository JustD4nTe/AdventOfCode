using AoC2021.Day8;
using Xunit;

namespace AoC2021.Tests.Day8;

public class Day8Tests
{
    [Theory]
    [InlineData("Day8/TestInput_a.txt",26)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
}