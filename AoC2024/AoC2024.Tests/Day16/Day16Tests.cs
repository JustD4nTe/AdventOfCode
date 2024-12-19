using AoC2024.Day16;
using Xunit;

namespace AoC2024.Tests.Day16;

public class Day16Tests
{
    [Theory]
    [InlineData("Day16/TestInput_a.txt",7036)]
    [InlineData("Day16/TestInput_b.txt",11048)]
    [InlineData("Day16/TestInput_c.txt",4013)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day16/TestInput_a.txt",45)]
    [InlineData("Day16/TestInput_b.txt",64)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}