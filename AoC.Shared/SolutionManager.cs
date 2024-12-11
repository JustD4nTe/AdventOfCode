using System.Diagnostics;

namespace AoC.Shared;

public static class SolutionManager
{
    public static void BenchmarkSolution(Solution solution)
    {
        var beforeMemory = GC.GetTotalMemory(true);
        var sw = Stopwatch.StartNew();

        var result = solution.Solve();
        
        sw.Stop();
        var memory = GC.GetTotalMemory(true) - beforeMemory;

        Console.WriteLine("##################################################");
        Console.WriteLine(solution.GetType().FullName);
        Console.WriteLine($"Memory: {memory}, Time: {sw.Elapsed}s | {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Result: {result}");
    }
}