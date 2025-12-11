using AoC.Shared;
using AoC.Shared.ValueObjects;
using System.Runtime.CompilerServices;

namespace AoC2025.Day05;

public class PartTwo(string input, int ingredientIdRangeCount) : Solution(input)
{
    public override long Solve()
    {
        var freshIngredientIdRanges = File.ReadAllLines(Input)
            .Take(ingredientIdRangeCount)
            .Select(x => x.Split("-"))
            .Select(x => new AoCRange(long.Parse(x[0]), long.Parse(x[1])))
            .ToArray();

        var totalFreshIngredientIdsCount = 0L;

        for (var i = 0; i < ingredientIdRangeCount; i++)
        {
            if (freshIngredientIdRanges[i].IsEmpty())
            {
                continue;
            }

            for (var j = i + 1; j < ingredientIdRangeCount; j++)
            {
                if (freshIngredientIdRanges[i].IsInRange(freshIngredientIdRanges[j]))
                {
                    freshIngredientIdRanges[j] = AoCRange.CreateEmpty();
                }
                // maybe next range already contains current range?
                else if (freshIngredientIdRanges[j].IsInRange(freshIngredientIdRanges[i]))
                {
                    freshIngredientIdRanges[i] = AoCRange.CreateEmpty();
                    break;
                }
                else if (freshIngredientIdRanges[i].IsInRange(freshIngredientIdRanges[j].Left))
                {
                    freshIngredientIdRanges[j] = freshIngredientIdRanges[j] with { Left = freshIngredientIdRanges[i].Right + 1 };
                }
                else if (freshIngredientIdRanges[i].IsInRange(freshIngredientIdRanges[j].Right))
                {
                    freshIngredientIdRanges[j] = freshIngredientIdRanges[j] with { Right = freshIngredientIdRanges[i].Left - 1 };
                }
            }

            if (freshIngredientIdRanges[i].IsEmpty())
            {
                continue;
            }

            totalFreshIngredientIdsCount += freshIngredientIdRanges[i].ValueCount();
        }

        return totalFreshIngredientIdsCount;
    }
}