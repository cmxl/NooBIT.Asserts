using System;

namespace NooBIT.Asserts
{
    public static class ShouldExtensions
    {
        public static IShould<T> Should<T>(this T obj, IAssertProvider assertProvider) => new Should<T>(obj, assertProvider);

        public static IBe<T> Equal<T>(this IShould<T> should, T expected) => should.Apply(
            (v, p) => p.Equal(expected, v),
            (v, p) => p.NotEqual(expected, v));
    }

    public static class ShouldStringExtensions
    {
        public static IBe<string> Contain(this IShould<string> should, string expectedSubstring) => should.Apply(
                (t, a) => a.IsSubstringOf(t, expectedSubstring),
                (t, a) =>
                {
                    if (t.Contains(expectedSubstring))
                        a.Fail($"'{t}' contains '{expectedSubstring}' but was not expected to.");
                });

        public static IBe<string> StartWith(this IShould<string> should, string expectedSubstring) => should.Apply(
                (t, a) => a.StartsWith(expectedSubstring, t),
                (t, a) =>
                {
                    if (!t.StartsWith(expectedSubstring))
                        a.Fail($"Expected string '{t}' to not start with '{expectedSubstring}', but it did.");
                });

        public static IBe<string> EndWith(this IShould<string> should, string expectedSubstring) => should.Apply(
                (t, a) => a.EndsWith(expectedSubstring, t),
                (t, a) =>
                {
                    if (t.EndsWith(expectedSubstring))
                        a.Fail($"Expected string '{t}' to not end with '{expectedSubstring}', but it did.");
                });
    }

    public static class ShouldDoubleExtensions
    {
        public static IBe<double> Equal(this IShould<double> should, double expected, int precision) => should.Apply(
                (t, a) => a.Equal(expected, t, precision),
                (t, a) => a.NotEqual(expected, t, precision));
    }

    public static class ShouldDateTimeExtensions
    {
        public static IBe<DateTime> Equal(this IShould<DateTime> should, DateTime expected, TimeSpan tolerance) => should.Apply(
                (t, a) => a.Equal(expected, t, tolerance),
                (t, a) => a.NotEqual(expected, t, tolerance));

        public static IBe<DateTime> Equal(this IShould<DateTime> should, DateTime expected, DatePrecision precision) => should.Apply(
                (t, a) => a.Equal(expected, t, precision),
                (t, a) => a.NotEqual(expected, t, precision));
    }
}
