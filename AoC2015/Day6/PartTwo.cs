namespace AoC2015.Day6;

static class PartTwo
{
    private const string inputFile = "Day6/input.txt";
    private const int gridSize = 1000;
    public static long Solve()
    {
        var input = File.ReadAllLines(inputFile);

        long[][] lightGrid = new long[gridSize][];

        for (var i = 0; i < gridSize; i++)
            lightGrid[i] = new long[gridSize];

        foreach (var row in input)
        {
            Operation operation;
            int[][] positions;
            if (row.StartsWith("turn on"))
            {
                operation = Operation.TurnOn;
                positions = GetPositions(row, "turn on ".Length);
            }
            else if (row.StartsWith("turn off"))
            {
                operation = Operation.TurnOff;
                positions = GetPositions(row, "turn off ".Length);
            }
            else
            {
                operation = Operation.Toggle;
                positions = GetPositions(row, "toggle ".Length);
            }

            for (var x = positions[0][0]; x <= positions[1][0]; x++)
            {
                for (var y = positions[0][1]; y <= positions[1][1]; y++)
                {
                    switch (operation)
                    {
                        case Operation.TurnOn:
                            lightGrid[x][y]++;
                            break;
                        case Operation.TurnOff:
                            if (--lightGrid[x][y] < 0)
                                lightGrid[x][y] = 0;
                            break;
                        case Operation.Toggle:
                            lightGrid[x][y] += 2;
                            break;
                    }
                }
            }
        }

        return lightGrid.Sum(x => x.Sum());
    }

    private static int[][] GetPositions(string row, int i)
        => row[i..].Split(" through ")
                   .Select(x => x.Split(",")
                                 .Select(int.Parse)
                                 .ToArray())
                   .ToArray();

    private enum Operation { TurnOn, TurnOff, Toggle }
}