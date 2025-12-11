using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2025.Day05;

public class PartOne(string input, int ingredientIdRangeCount) : Solution(input)
{
    public override long Solve()
    {
        var ingredientIds = File.ReadAllLines(Input)
            .ToArray();

        var freshIngredientIdRanges = ingredientIds.Take(ingredientIdRangeCount)
            .Select(x => x.Split("-"))
            .Select(x => new AoCRange(long.Parse(x[0]), long.Parse(x[1])))
            .ToArray();

        var freshIngredientsCount = 0;
        for (var i = ingredientIdRangeCount + 1; i < ingredientIds.Length; i++)
        {
            var ingredientId = long.Parse(ingredientIds[i]);

            if(freshIngredientIdRanges.Any(x => x.IsInRange(ingredientId)))
                freshIngredientsCount++;
        }

        return freshIngredientsCount;
    }
}