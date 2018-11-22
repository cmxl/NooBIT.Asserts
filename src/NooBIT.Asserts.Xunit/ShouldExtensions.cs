using NooBIT.Asserts.Xunit;

namespace NooBIT.Asserts
{
    public static class ShouldExtensions
    {
        public static IShould<T> Should<T>(this T obj) => new Should<T>(obj, new XunitAssertProvider());
    }
}
