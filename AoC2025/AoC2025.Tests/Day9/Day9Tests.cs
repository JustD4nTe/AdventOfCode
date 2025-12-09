using AoC2025.Day9;

namespace AoC2025.Tests.Day9;

public class Day9Tests
{
    [Theory]
    [InlineData("Day9/TestInput_a.txt", 50)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    // not needed
    //[Theory]
    //[InlineData("Day9/TestInput_a.txt", 24)]
    //public void PartTwoTest(string input, long expectedResult)
    //{
    //    Assert.Equal(expectedResult, new PartTwo(input).Solve());
    //}
}