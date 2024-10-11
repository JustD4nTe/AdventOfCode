namespace AoC2021.Day8
{
    internal class Solution
    {
        private readonly List<List<string>> _tests;
        private readonly List<List<string>> _outputs;

        public Solution()
        {
            var temp = Helper.ReadFile("Day8")
                             .Split("\n")
                             .Select(x => x.Split("|").Select(x => x.Trim()).ToList())
                             .ToList();

            _tests = temp.ConvertAll(x => x[0].Split(" ").Select(x => x.Trim()).ToList());
            _outputs = temp.ConvertAll(x => x[1].Split(" ").Select(x => x.Trim()).ToList());
        }

        public long PartOne()
        {
            return _outputs.SelectMany(x => x).Count(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7);
        }

        public long PartTwo()
        {
            for (var i = 0; i < _tests.Count; i++)
            {
                var test = _tests[i];
            }


            return -1;
        }
    }
}
