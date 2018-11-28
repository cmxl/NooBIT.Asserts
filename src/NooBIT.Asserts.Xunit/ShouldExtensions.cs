using NooBIT.Asserts.Xunit;

namespace NooBIT.Asserts
{
    public static class ShouldExtensions
    {
        private static readonly IAssertProvider _assertProvider = new XunitAssertProvider();

        public static IShould<T> Should<T>(this T obj) => new Should<T>(obj, _assertProvider);
    }
}
