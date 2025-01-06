using AoC2021.Day13;

namespace AoC2021.Tests.Day13;

public class Day13Tests
{
    [Theory]
    [InlineData("Day13/TestInput_a.txt",17)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
}