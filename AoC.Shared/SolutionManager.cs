using System.Diagnostics;

namespace AoC.Shared;

public static class SolutionManager
{
    private static Stopwatch sw;
    public static void BenchmarkSolution(Solution solution)
    {
        sw = Stopwatch.StartNew();
        var beforeMemory = GC.GetTotalMemory(true);

        var result = solution.Solve();
        
        var memory = GC.GetTotalMemory(true) - beforeMemory;
        sw.Stop();

        Console.WriteLine("##################################################");
        Console.WriteLine(solution.GetType().FullName);
        Console.WriteLine($"Memory: {memory}, Time: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Result: {result}");
    }
}