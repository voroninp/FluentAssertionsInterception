// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

namespace FluentAssertions.Interceptors;

file static class GeneratedInterceptor
{
    [InterceptsLocationAttribute(@"C:\Users\pavel\source\repos\voroninp\FluentAssertionsInterception\FluentAssertionsInterception\Program.cs", line: 11, character: 17)]
    internal static Task Bar(this Foo foo)
    {
        try
        {
            return foo.Bar();
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }

    private static class Calls
    {
        public static Delegate Call1;
    }

    [InterceptsLocationAttribute(@"C:\Users\pavel\source\repos\voroninp\FluentAssertionsInterception\FluentAssertionsInterception\Program.cs", line: 14, character: 11)]
    internal static int SyncBar(this Foo foo)
    {
        Calls.Call1 = () => foo.SyncBar();

        return default;
    }

    [InterceptsLocationAttribute(@"C:\Users\pavel\source\repos\voroninp\FluentAssertionsInterception\FluentAssertionsInterception\Program.cs", line: 14, character: 21)]
    internal static Func<T> Method<T>(this T result)
    {
        var call = Calls.Call1 as Func<T>;
        Calls.Call1 = null!;
        return call;
    }
}
