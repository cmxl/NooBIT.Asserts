using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NooBIT.Asserts
{
    public static class BeExtensions
    {
        public static T Equal<T>(this IBe<T> be, T expected) => be.Should.Equal(expected);
        public static void Null<T>(this IBe<T> be) => be.Should.Apply(
                (t, a) => a.IsNull(t),
                (t, a) => a.IsNotNull(t));
    }

    public static class BeBoolExtensions
    {
        public static bool True(this IBe<bool> be) => be.Should.Apply(
                (t, a) => a.IsTrue(t),
                (t, a) => a.IsFalse(t));

        public static bool False(this IBe<bool> be) => be.Should.Apply(
                (t, a) => a.IsFalse(t),
                (t, a) => a.IsTrue(t));

        public static bool? True(this IBe<bool?> be) => be.Should.Apply(
                (t, a) => a.IsTrue(t.HasValue && t.Value),
                (t, a) => a.IsFalse(!(t.HasValue && t.Value)));

        public static bool? False(this IBe<bool?> be) => be.Should.Apply(
                (t, a) => a.IsFalse(t.HasValue && t.Value),
                (t, a) => a.IsTrue(!(t.HasValue && t.Value)));
    }

    public static class BeStringExtensions
    {
        public static string Empty(this IBe<string> be) => be.Should.Apply(
                (t, a) => a.AreEqual(string.Empty, t),
                (t, a) => a.AreNotEqual(string.Empty, t));

        public static string NullOrEmpty(this IBe<string> be) => be.Should.Apply(
                (t, a) => a.IsTrue(string.IsNullOrEmpty(t)),
                (t, a) => a.IsFalse(string.IsNullOrEmpty(t)));

        public static string NullOrWhitespace(this IBe<string> be) => be.Should.Apply(
                (t, a) => a.IsTrue(string.IsNullOrWhiteSpace(t)),
                (t, a) => a.IsFalse(string.IsNullOrWhiteSpace(t)));
    }

    public static class BeCollectionExtensions
    {
        public static ICollection Empty(this IBe<ICollection> be) => be.Should.Apply(
                (t, a) => a.AreEqual(0, t.Count),
                (t, a) => a.AreNotEqual(0, t.Count));
    }

    public static class BeDateTimeExtensions
    {
        public static DateTime Today(this IBe<DateTime> be) => be.Should.Apply(
                (t, a) => a.AreEqual(DateTime.Today, t.Date),
                (t, a) => a.AreNotEqual(DateTime.Today, t.Date));
    }

    public static class BeDoubleExtensions
    {
        public static double Positive(this IBe<double> be) => be.Should.Apply(
                (t, a) => a.IsTrue(t > 0),
                (t, a) => a.IsFalse(t < 0));

        public static double Negative(this IBe<double> be) => be.Should.Apply(
                (t, a) => a.IsTrue(t < 0),
                (t, a) => a.IsFalse(t > 0));
    }

    public static class BeEnumerableExtensions
    {
        public static IEnumerable<T> Empty<T>(this IBe<IEnumerable<T>> be) => be.Should.Apply(
                (t, a) => a.AreEqual(0, t.Count()),
                (t, a) => a.AreNotEqual(0, t.Count()));
    }

    public static class BeGuidExtensions
    {
        public static Guid Empty(this IBe<Guid> be) => be.Should.Apply(
                (t, a) => a.AreEqual(Guid.Empty, t),
                (t, a) => a.AreNotEqual(Guid.Empty, t));
    }
}
