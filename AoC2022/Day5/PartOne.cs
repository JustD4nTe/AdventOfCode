namespace AoC2022.Day5;

internal static class PartOne
{
    record Procedure
    {
        public int Count { get; }
        public int From { get; }
        public int Target { get; }

        public Procedure(string procedure)
        {
            var buff = procedure.Split(" ");
            Count = int.Parse(buff[1]);
            From = int.Parse(buff[3]) - 1;
            Target = int.Parse(buff[5]) - 1;
        }
    }

    public static string Solution()
    {
        var input = File.ReadAllLines("Day5/input.txt");
        var ship = CreateShip(input);

        for (var i = 10; i < input.Length; i++)
        {
            var procedure = new Procedure(input[i]);

            for (var j = 0; j < procedure.Count; j++)
            {
                ship[procedure.Target].Insert(0, ship[procedure.From][0]);
                ship[procedure.From].RemoveAt(0);
            }
        }

        return string.Join("", ship.Select(x => x[0]));
    }

    private static List<List<char>> CreateShip(string[] input)
    {
        var ship = Enumerable.Range(1, 9).Select(x => new List<char>()).ToList();

        for (var i = 0; i < 8; i++)
        {
            for (int j = 1, k = 0; j < 36; j += 4, k++)
            {
                if (!char.IsWhiteSpace(input[i][j]))
                    ship[k].Add(input[i][j]);
            }
        }

        return ship;
    }
}
