using AoC.Shared;

namespace AoC2024.Day9;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var diskMap = File.ReadAllLines(Input)[0].Select(x => int.Parse(x.ToString())).ToArray();
        var fileSystem = GetFiles(diskMap);
        Defragmentation(fileSystem);

        long sum = 0;

        for (var i = 0; i < fileSystem.Count; i++)
            sum += fileSystem[i]!.Value * i;

        return sum;
    }

    private static void Defragmentation(List<int?> fileBlocks)
    {
        // Remove from 'memory' rightmost free space
        for (var i = fileBlocks.Count - 1; i >= 0; i--)
        {
            if (fileBlocks[i] is not null)
                break;

            fileBlocks.RemoveAt(i);
        }

        for (var i = 0; i < fileBlocks.Count; i++)
        {
            if (fileBlocks[i] is not null)
                continue;

            while (fileBlocks[^1] is null)
            {
                fileBlocks.RemoveAt(fileBlocks.Count - 1);
            }

            fileBlocks[i] = fileBlocks[^1];
            fileBlocks.RemoveAt(fileBlocks.Count - 1);
        }
    }

    private static List<int?> GetFiles(int[] diskMap)
    {
        var fileBlocks = new List<int?>();
        for (int i = 1, fileId = 0; i <= diskMap.Length; i++)
        {
            if (i % 2 == 1)
            {
                for (var j = 0; j < diskMap[i - 1]; j++)
                    fileBlocks.Add(fileId);

                fileId++;
            }
            else
            {
                for (var j = 0; j < diskMap[i - 1]; j++)
                    fileBlocks.Add(null);
            }
        }

        return fileBlocks;
    }
}