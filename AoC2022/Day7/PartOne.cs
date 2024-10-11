using System.Linq;

namespace AoC2022.Day7;

internal static class PartOne
{
    class Node
    {
        public List<Node> Files { get; } = new();
        public string Name { get; }
        public Node? ParentDir { get; }
        public bool IsDir { get; }
        private long _size;

        public Node(string name, Node? parentDir)
        {
            Name = name;
            ParentDir = parentDir;
            IsDir = true;
        }

        public Node(long size, string name, Node? parentDir)
        {
            _size = size;
            Name = name;
            ParentDir = parentDir;
            IsDir = false;
        }

        public void Add(Node data) => Files.Add(data);
        public long GetSize()
            => IsDir ? Files.Sum(x => x.GetSize()) : _size;
    }

    public static long Solution()
    {
        var input = File.ReadAllLines("Day7/input.txt");
        var homeDir = new Node("/", null);
        var currentDir = homeDir;

        for (var i = 0; i < input.Length; i++)
        {
            var cmd = input[i].Split(" ");

            switch (cmd[1])
            {
                case "cd":
                    if (cmd[2] == "/")
                        currentDir = homeDir;
                    else if (cmd[2] == "..")
                        currentDir = currentDir.ParentDir!;
                    else
                        currentDir = currentDir.Files.Single(x => x.Name == cmd[2]);
                    break;
                case "ls":
                    for (; i < input.Length - 1; i++)
                    {
                        var j = i + 1;
                        
                        if (input[j].StartsWith("$"))
                            break;
                        
                        var file = input[j].Split(" ");

                        if (file[0] == "dir")
                            currentDir.Add(new(file[1], currentDir));
                        else
                            currentDir.Add(new(long.Parse(file[0]), file[1], currentDir));
                    }
                    break;
            }
        }

        return IdkHowToNameIt(homeDir).Sum(x => x.GetSize());
    }

    private static List<Node> IdkHowToNameIt(Node node)
    {
        var nodes = new List<Node>();

        if (node.GetSize() <= 100_000)
            nodes.Add(node);

        foreach (var file in node.Files.Where(x => x.IsDir))
            nodes.AddRange(IdkHowToNameIt(file));

        return nodes;
    }
}
