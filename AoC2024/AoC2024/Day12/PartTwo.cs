using System.Text;
using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day12;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var gardenMap = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();
        var plantsAreas = new List<List<Position>>();

        var seen = new HashSet<Position>();
        
        for (var y = 0; y < gardenMap.Length; y++)
        {
            for (var x = 0; x < gardenMap[y].Length; x++)
            {
                if (plantsAreas.Any(p => p.Any(z => z.X == x && z.Y == y)))
                    continue;

                var plantPositions = new List<Position>();

                var queue = new Queue<Position>();
                queue.Enqueue(new Position(x, y));

                do
                {
                    var position = queue.Dequeue();
                    plantPositions.Add(position);
                    seen.Add(position);

                    if (position.Y + 1 < gardenMap.Length 
                        && gardenMap[position.Y + 1][position.X] == gardenMap[position.Y][position.X] 
                        && !queue.Contains(position with { Y = position.Y + 1 })
                        && !seen.Contains(position with { Y = position.Y + 1 }))
                    {
                        queue.Enqueue(position with { Y = position.Y + 1 });
                    }

                    if (position.X + 1 < gardenMap[position.Y].Length 
                        && gardenMap[position.Y][position.X + 1] == gardenMap[position.Y][position.X] 
                        && !queue.Contains(position with { X = position.X + 1 })
                        && !seen.Contains(position with { X = position.X + 1 }))
                    {
                        queue.Enqueue(position with { X = position.X + 1 });
                    }
                    
                    if (position.Y - 1 >= 0 
                        && gardenMap[position.Y - 1][position.X] == gardenMap[position.Y][position.X] 
                        && !queue.Contains(position with { Y = position.Y - 1 })
                        && !seen.Contains(position with { Y = position.Y - 1 }))
                    {
                        queue.Enqueue(position with { Y = position.Y - 1 });
                    }

                    if (position.X - 1 >= 0 
                        && gardenMap[position.Y][position.X - 1] == gardenMap[position.Y][position.X] 
                        && !queue.Contains(position with { X = position.X - 1 })
                        && !seen.Contains(position with { X = position.X - 1 }))
                    {
                        queue.Enqueue(position with { X = position.X - 1 });
                    }
                    
                } while (queue.Count > 0);

                plantsAreas.Add(plantPositions.Distinct().ToList());
            }
        }

        var sum = 0;

        foreach (var plantPositions in plantsAreas)
        {
            var area = plantPositions.Count;
            var perimeter = 0;

            for (var i = 0; i < plantPositions.Count; i++)
            {
                var currPlant = plantPositions[i];

                var neighbours = 8;

                for (var j = 0; j < plantPositions.Count; j++)
                {
                    if (j == i)
                        continue;

                    var neighbourPlant = plantPositions[j];
                    
                    if (neighbourPlant.Y == currPlant.Y + 1 && neighbourPlant.X == currPlant.X)
                        neighbours--;
                    else if (neighbourPlant.Y == currPlant.Y - 1 && neighbourPlant.X == currPlant.X)
                        neighbours--;
                    else if (neighbourPlant.Y == currPlant.Y && neighbourPlant.X == currPlant.X + 1)
                        neighbours--;
                    else if (neighbourPlant.Y == currPlant.Y && neighbourPlant.X == currPlant.X - 1)
                        neighbours--;
                }

                perimeter += 8 - neighbours;
            }

            sum += perimeter * area;
        }

        return sum;
    }
}