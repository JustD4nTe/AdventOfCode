using AoC2023.Day1;

namespace AoC2023.Tests.Day1;

public class Day1Tests
{
    [Theory]
    [InlineData("Day1/TestInput_a.txt",142)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day1/TestInput_b.txt",281)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}