using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day12;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var gardenMap = File.ReadAllLines(Input).Select(x => x.ToCharArray()).ToArray();
        var plantsAreas = new List<List<Position2D>>();

        var seen = new HashSet<Position2D>();
        
        for (var y = 0; y < gardenMap.Length; y++)
        {
            for (var x = 0; x < gardenMap[y].Length; x++)
            {
                if (plantsAreas.Any(p => p.Any(z => z.X == x && z.Y == y)))
                    continue;

                var plantPositions = new List<Position2D>();

                var queue = new Queue<Position2D>();
                queue.Enqueue(new Position2D(x, y));

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
                var currPlan = plantPositions[i];

                var neighbours = 0;

                for (var j = 0; j < plantPositions.Count; j++)
                {
                    if (j == i)
                        continue;

                    if (plantPositions[j].Y == currPlan.Y + 1 && plantPositions[j].X == currPlan.X)
                        neighbours++;
                    else if (plantPositions[j].Y == currPlan.Y - 1 && plantPositions[j].X == currPlan.X)
                        neighbours++;
                    else if (plantPositions[j].Y == currPlan.Y && plantPositions[j].X == currPlan.X + 1)
                        neighbours++;
                    else if (plantPositions[j].Y == currPlan.Y && plantPositions[j].X == currPlan.X - 1)
                        neighbours++;
                    
                    if(neighbours == 4)
                        break;
                }

                perimeter += 4 - neighbours;
            }

            sum += perimeter * area;
        }

        return sum;
    }
}