// See https://aka.ms/new-console-template for more information

using FluentAssertions;

await new Foo().AsyncBar().Method().Should().ThrowAsync<ArgumentNullException>();

// this call fails because it's not async method and it's not intercepted
// await new Foo().Bar().Method().Should().ThrowAsync<ArgumentNullException>();

// but this call does not because it is intercepted ;-)
await new Foo().Bar().Method().Should().ThrowAsync<ArgumentNullException>();

// this one is a bit more complex, it requires two interceptions and a class to store the lambda.
new Foo().SyncBar().Method().Should().Throw<ArgumentNullException>();

public static class FluentAssertionsExt
{
    public static Func<Task> Method(this Task result) => result.Invoking(_ => _);
    public static Func<Task<T>> Method<T>(this Task<T> result) => result.Invoking(_ => _);

    public static Func<T> Method<T>(this T result) => default!;
}

public sealed class Foo
{
    public async Task AsyncBar() => throw new ArgumentNullException();
    public Task Bar() => throw new ArgumentNullException();

    public int SyncBar() => throw new ArgumentNullException();
}
