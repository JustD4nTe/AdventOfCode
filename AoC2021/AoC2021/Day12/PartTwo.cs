using AoC.Shared;
using AoC.Shared.Helpers;
using AoC.Shared.Types;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day12;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input);

        var caves = new Dictionary<string, List<string>>();

        foreach (var connection in rawInput)
        {
            var buff = connection.Split("-");
            var firstCave = buff[0];
            var secondCave = buff[1];

            if (caves.TryGetValue(firstCave, out var a))
                a.Add(secondCave);
            else
                caves[firstCave] = [secondCave];

            if (caves.TryGetValue(secondCave, out var b))
                b.Add(firstCave);
            else
                caves[secondCave] = [firstCave];
        }

        var paths = new List<string>();
        var queue = new Queue<Cave>();

        foreach (var cave in caves["start"])
            queue.Enqueue(new Cave(cave, ["start", cave]));

        do
        {
            var currCave = queue.Dequeue();

            if (currCave.Name == "end")
            {
                paths.Add(string.Join(",", currCave.Path) + ",end");
                continue;
            }

            foreach (var nextCave in caves[currCave.Name])
            {
                if (nextCave == "start")
                    continue;

                Cave next;
                if (nextCave.All(char.IsLower) && currCave.Path.Contains(nextCave))
                {
                    if (currCave.IsTwiceSmall)
                        continue;

                    next = new Cave(nextCave, [..currCave.Path, nextCave], true);
                }
                else
                {
                    next = new Cave(nextCave, [..currCave.Path, nextCave], currCave.IsTwiceSmall);
                }

                queue.Enqueue(next);
            }
        } while (queue.Count > 0);


        return paths.Distinct().LongCount();
    }

    private record Cave(string Name, string[] Path, bool IsTwiceSmall = false);
}