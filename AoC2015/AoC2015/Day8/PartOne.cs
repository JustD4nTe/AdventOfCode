using System.Text;

namespace AoC2015.Day8;

public class PartOne
{
    private const string inputFile = "Day8/input.txt";

    public long Solve()
    {
        var input = File.ReadAllLines(inputFile);

        var counter = 0;

        var stringBuilder = new StringBuilder();
        foreach (var line in input)
        {
            for (var i = 1; i < line.Length - 1; i++)
            {
                if (line[i] == '\\')
                {                    
                    i++;
                    
                    if (line[i] == 'x')
                    {
                        i++;
                        var a = (char)int.Parse(line.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                        i ++;
                        stringBuilder.Append(a);
                        continue;
                    }
                }

                stringBuilder.Append(line[i]);
            }

            counter += line.Length - stringBuilder.Length;

            stringBuilder.Clear();

        }

        return counter;
    }
}