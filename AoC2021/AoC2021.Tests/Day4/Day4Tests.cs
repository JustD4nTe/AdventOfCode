using AoC2021.Day4;
using Xunit;

namespace AoC2021.Tests.Day4;

public class Day4Tests
{
    [Theory]
    [InlineData("Day4/TestInput_a.txt",4512)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day4/TestInput_a.txt",1924)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}