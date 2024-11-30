using System.Text;

namespace AoC2015.Day8;

public class PartTwo
{
    private const string inputFile = "Day8/input.txt";

    public long Solve()
    {
        var input = File.ReadAllLines(inputFile);

        var counter = 0;

        var stringBuilder = new StringBuilder();

        foreach (var line in input)
        {
            stringBuilder.Append('"');

            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '\"')
                {
                    stringBuilder.Append("\\\"");
                }
                else if (line[i] == '\\')
                {
                    stringBuilder.Append("\\\\");
                }
                else
                {
                    stringBuilder.Append(line[i]);
                }
            }

            stringBuilder.Append('"');

            counter += stringBuilder.Length - line.Length;

            stringBuilder.Clear();

        }

        return counter;
    }
}