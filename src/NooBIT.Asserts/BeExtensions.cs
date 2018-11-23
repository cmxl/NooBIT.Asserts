using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NooBIT.Asserts
{
    public static class BeExtensions
    {
        public static IBe<T> Equal<T>(this IBe<T> be, T expected) => be.Should.Equal(expected);
        public static IBe<T> Null<T>(this IBe<T> be) => be.Should.Apply(
                (t, a) => a.Null(t),
                (t, a) => a.NotNull(t));
    }

    public static class BeBoolExtensions
    {
        public static IBe<bool> True(this IBe<bool> be) => be.Should.Apply(
                (t, a) => a.True(t),
                (t, a) => a.False(t));

        public static IBe<bool> False(this IBe<bool> be) => be.Should.Apply(
                (t, a) => a.False(t),
                (t, a) => a.True(t));

        public static IBe<bool?> True(this IBe<bool?> be) => be.Should.Apply(
                (t, a) => a.True(t.HasValue && t.Value),
                (t, a) => a.False(!(t.HasValue && t.Value)));

        public static IBe<bool?> False(this IBe<bool?> be) => be.Should.Apply(
                (t, a) => a.False(t.HasValue && t.Value),
                (t, a) => a.True(!(t.HasValue && t.Value)));
    }

    public static class BeStringExtensions
    {
        public static IBe<string> Empty(this IBe<string> be) => be.Should.Apply(
                (t, a) => a.Equal(string.Empty, t),
                (t, a) => a.NotEqual(string.Empty, t));

        public static IBe<string> NullOrEmpty(this IBe<string> be) => be.Should.Apply(
                (t, a) => a.True(string.IsNullOrEmpty(t)),
                (t, a) => a.False(string.IsNullOrEmpty(t)));

        public static IBe<string> NullOrWhitespace(this IBe<string> be) => be.Should.Apply(
                (t, a) => a.True(string.IsNullOrWhiteSpace(t)),
                (t, a) => a.False(string.IsNullOrWhiteSpace(t)));
    }

    public static class BeCollectionExtensions
    {
        public static IBe<ICollection> Empty(this IBe<ICollection> be) => be.Should.Apply(
                (t, a) => a.Equal(0, t.Count),
                (t, a) => a.NotEqual(0, t.Count));
    }

    public static class BeDateTimeExtensions
    {
        public static IBe<DateTime> Today(this IBe<DateTime> be) => be.Should.Apply(
                (t, a) => a.Equal(DateTime.Today, t.Date),
                (t, a) => a.NotEqual(DateTime.Today, t.Date));
    }

    public static class BeDoubleExtensions
    {
        public static IBe<double> Positive(this IBe<double> be) => be.Should.Apply(
                (t, a) => a.GreaterThan(t, 0),
                (t, a) => a.LessThan(t, 0));

        public static IBe<double> Negative(this IBe<double> be) => be.Should.Apply(
                (t, a) => a.LessThan(t, 0),
                (t, a) => a.GreaterThan(t, 0));
    }

    public static class BeEnumerableExtensions
    {
        public static IBe<IEnumerable<T>> Empty<T>(this IBe<IEnumerable<T>> be) => be.Should.Apply(
                (t, a) => a.Equal(0, t.Count()),
                (t, a) => a.NotEqual(0, t.Count()));
    }

    public static class BeGuidExtensions
    {
        public static IBe<Guid> Empty(this IBe<Guid> be) => be.Should.Apply(
                (t, a) => a.Equal(Guid.Empty, t),
                (t, a) => a.NotEqual(Guid.Empty, t));
    }
}
