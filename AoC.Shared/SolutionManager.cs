using System.Diagnostics;

namespace AoC.Shared;

public static class SolutionManager
{
    private static Stopwatch sw;
    public static void BenchmarkSolution(Solution solution)
    {
        var beforeMemory = GC.GetTotalMemory(true);
        sw = Stopwatch.StartNew();

        var result = solution.Solve();
        
        sw.Stop();
        var memory = GC.GetTotalMemory(true) - beforeMemory;

        Console.WriteLine("##################################################");
        Console.WriteLine(solution.GetType().FullName);
        Console.WriteLine($"Memory: {memory}, Time: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Result: {result}");
    }
}