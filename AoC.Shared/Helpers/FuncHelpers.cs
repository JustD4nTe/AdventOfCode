namespace AoC.Shared.Helpers;

public class FuncHelpers
{
    // https://trenki2.github.io/blog/2018/12/31/memoization-in-csharp/
    public static Func<A, R> Memoize<A, R>(Func<A, R> func)
    {
        var cache = new Dictionary<A, R>();

        return (a) =>
        {
            if (cache.TryGetValue(a, out R value))
                return value;

            value = func(a);
            cache.Add(a, value);

            return value;
        };
    }
}