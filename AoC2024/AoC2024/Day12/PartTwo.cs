using System.Text;
using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2024.Day12;

public class PartTwo(string input) : Solution(input)
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
            var plantType = gardenMap[plantPositions[0].Y][plantPositions[0].X];

            foreach (var (x, y) in plantPositions)
            {
                var corners = 0;
                // ======= outer corners =======
                // up right
                if ((y - 1 < 0 && x + 1 == gardenMap[y].Length)
                    || (y - 1 >= 0 && x + 1 == gardenMap[y].Length &&gardenMap[y - 1][x] != plantType)
                    || (y - 1 < 0 && x + 1 < gardenMap[y].Length && gardenMap[y][x + 1] != plantType)
                    || (y - 1 >= 0 && x + 1 < gardenMap[y].Length
                                   && gardenMap[y - 1][x] != plantType
                                   && gardenMap[y][x + 1] != plantType))
                {
                    corners++;
                }

                // down right
                if ((y + 1 == gardenMap.Length && x + 1 == gardenMap[y].Length)
                    || (y + 1 < gardenMap.Length && x + 1 == gardenMap[y].Length && gardenMap[y + 1][x] != plantType)
                    || (y + 1 == gardenMap.Length && x + 1 < gardenMap[y].Length && gardenMap[y][x + 1] != plantType)
                    || (y + 1 < gardenMap.Length && x + 1 < gardenMap[y].Length
                                                 && gardenMap[y][x + 1] != plantType
                                                 && gardenMap[y + 1][x] != plantType))
                {
                    corners++;
                }

                // down left
                if ((y + 1 == gardenMap.Length && x - 1 < 0)
                    ||(y + 1 < gardenMap.Length && x - 1 < 0 && gardenMap[y + 1][x] != plantType)
                    || (y + 1 == gardenMap.Length && x - 1 >= 0 && gardenMap[y][x - 1] != plantType)
                    || (y + 1 < gardenMap.Length && x - 1 >= 0
                                                 && gardenMap[y + 1][x] != plantType
                                                 && gardenMap[y][x - 1] != plantType))
                {
                    corners++;
                }

                // up left
                if ((y - 1 < 0 && x - 1 < 0)
                    || (y - 1 >= 0 && x - 1 < 0 && gardenMap[y - 1][x] != plantType)
                    || (y - 1 < 0 && x - 1 >= 0 && gardenMap[y][x - 1] != plantType)
                    || (y - 1 >= 0 && x - 1 >= 0
                                   && gardenMap[y][x - 1] != plantType
                                   && gardenMap[y - 1][x] != plantType))
                {
                    corners++;
                }

                // ======= inner corners =======
                // up right
                if (y - 1 >= 0 && x + 1 < gardenMap[y].Length
                               && gardenMap[y - 1][x] == plantType
                               && gardenMap[y][x + 1] == plantType
                               && gardenMap[y - 1][x + 1] != plantType)
                {
                    corners++;
                }
                // down right
                if (y + 1 < gardenMap.Length && x + 1 < gardenMap[y].Length
                                             && gardenMap[y][x + 1] == plantType
                                             && gardenMap[y + 1][x] == plantType
                                             && gardenMap[y + 1][x + 1] != plantType)
                {
                    corners++;
                }

                // down left
                if (y + 1 < gardenMap.Length && x - 1 >= 0
                                             && gardenMap[y + 1][x] == plantType
                                             && gardenMap[y][x - 1] == plantType
                                             && gardenMap[y + 1][x - 1] != plantType)
                {
                    corners++;
                }

                // up left
                if (y - 1 >= 0 && x - 1 >= 0
                               && gardenMap[y][x - 1] == plantType
                               && gardenMap[y - 1][x] == plantType
                               && gardenMap[y - 1][x - 1] != plantType)
                {
                    corners++;
                }


                perimeter += corners;
            }

            sum += perimeter * area;
        }

        return sum;
    }
}