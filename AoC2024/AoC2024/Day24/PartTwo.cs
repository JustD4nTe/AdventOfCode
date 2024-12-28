using System.Collections.Specialized;
using System.Text;
using AoC.Shared;

namespace AoC2024.Day24;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n").Select(x => x.Split("\r\n")).ToArray();

        var strBuilder = new StringBuilder();

        var inputs = rawInput[1].Where(x => x.StartsWith('x') || x.StartsWith('y')).OrderBy(x => x).ToArray();
        var internalInputs = rawInput[1].Except(inputs).ToArray();
        var temp = inputs.Union(internalInputs).ToArray();
        
        foreach (var line in temp)
        {
            var buff = line.Split(" -> ");
            var output = buff[1];

            buff = buff[0].Split(" ");
            var wireA = buff[0];
            var wireB = buff[2];

            switch(buff[1]) 
            {
                case "AND":
                    strBuilder.AppendLine($"{wireA} --> {output}[\"{output}\"]");
                    strBuilder.AppendLine($"{wireB} --> {output}[\"{output}\"]");
                    break;
                case "OR":
                    strBuilder.AppendLine($"{wireA} --o {output}{{{{\"{output}\"}}}}");
                    strBuilder.AppendLine($"{wireB} --o {output}{{{{\"{output}\"}}}}");
                    break;
                case "XOR" :
                    strBuilder.AppendLine($"{wireA} --x {output}[/\"{output}\"\\]");
                    strBuilder.AppendLine($"{wireB} --x {output}[/\"{output}\"\\]");
                    break;
            };
        }

        File.WriteAllText("Day24/output.txt", strBuilder.ToString());

        string[] result = ["z39", "pfw", "z33", "dqr", "z21", "shh", "vgs", "dtk"];

        Console.WriteLine(string.Join(",", result.OrderBy(x => x)));
        
        return -1;
    }
}