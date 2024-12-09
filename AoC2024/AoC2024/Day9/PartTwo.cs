using System.Text;
using AoC.Shared;

namespace AoC2024.Day9;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var diskMap = File.ReadAllLines(Input)[0].Select(x => int.Parse(x.ToString())).ToArray();
        var buff = InitBuffer(diskMap);
        Defragmentation(buff);
        return CalculateChecksum(buff);
    }

    private static long CalculateChecksum(List<SpaceLength> buff)
    {
        var positionId = 0;
        long sum = 0;

        foreach (var item in buff)
        {
            switch (item)
            {
                case EmptyLength empty:
                    positionId += empty.Length;
                    continue;
                case FileLength file:
                {
                    for (var i = 0; i < file.Length; ++i)
                    {
                        sum += file.IdNumber * positionId;
                        positionId++;
                    }

                    break;
                }
            }
        }

        return sum;
    }

    private static void Defragmentation(List<SpaceLength> buff)
    {
        for (var rightIndex = buff.Count - 1; rightIndex >= 0; rightIndex--)
        {
            var isFileMoved = false;
            if (buff[rightIndex] is EmptyLength)
                continue;

            // var memory = DumpMemory(buff);

            var fileToMove = (FileLength)buff[rightIndex];
            for (var leftIndex = 0; leftIndex < rightIndex; leftIndex++)
            {
                if (buff[leftIndex] is FileLength)
                    continue;

                if (buff[leftIndex] is EmptyLength space)
                {
                    if (fileToMove.Length == space.Length)
                    {
                        buff[leftIndex] = buff[rightIndex];
                        buff[rightIndex] = new EmptyLength(buff[leftIndex].Length);

                        isFileMoved = true;
                    }
                    else if (fileToMove.Length < space.Length)
                    {
                        buff.Insert(leftIndex + 1, new EmptyLength(space.Length - fileToMove.Length));
                        buff[leftIndex] = fileToMove;
                        buff[++rightIndex] = new EmptyLength(fileToMove.Length);

                        isFileMoved = true;
                    }

                    if (!isFileMoved)
                        continue;

                    if (buff[rightIndex - 1] is EmptyLength leftSpace)
                    {
                        buff[rightIndex - 1] = new EmptyLength(buff[rightIndex].Length + leftSpace.Length);
                        buff.RemoveAt(rightIndex--);
                    }

                    if (rightIndex + 1 < buff.Count && buff[rightIndex + 1] is EmptyLength rightSpace)
                    {
                        buff[rightIndex] = new EmptyLength(buff[rightIndex].Length + rightSpace.Length);
                        buff.RemoveAt(rightIndex + 1);
                    }

                    break;
                }
            }
        }
    }

    private static List<SpaceLength> InitBuffer(int[] diskMap)
    {
        var buff = new List<SpaceLength>();

        for (int i = 1, fileId = 0; i <= diskMap.Length; i++)
        {
            if (diskMap[i - 1] == 0)
                continue;

            if (i % 2 == 1)
                buff.Add(new FileLength(diskMap[i - 1], fileId++));
            else
                buff.Add(new EmptyLength(diskMap[i - 1]));
        }

        return buff;
    }

    private static string DumpMemory(List<SpaceLength> buff)
    {
        var strBuilder = new StringBuilder();

        foreach (var space in buff)
            strBuilder.Append(space);

        return strBuilder.ToString();
    }

    private record SpaceLength(int Length)
    {
        public override string ToString() => string.Join("", Enumerable.Range(1, Length).Select(x => "_"));
    }

    private record FileLength(int Length, int IdNumber) : SpaceLength(Length)
    {
        public override string ToString() =>
            string.Join("", Enumerable.Range(1, Length).Select(x => IdNumber.ToString()));
    }

    private record EmptyLength(int Length) : SpaceLength(Length)
    {
        public override string ToString() => string.Join("", Enumerable.Range(1, Length).Select(x => "."));
    }
}