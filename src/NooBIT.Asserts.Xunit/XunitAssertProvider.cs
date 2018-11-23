using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace NooBIT.Asserts.Xunit
{
    public class XunitAssertProvider : IAssertProvider
    {
        #region Equality
        public void Equal<T>(T expected, T actual) => Assert.Equal(expected, actual);
        public void Equal(string expected, string actual) => Assert.Equal(expected, actual);
        public void Equal(double expected, double actual, int precision) => Assert.Equal(expected, actual, precision);
        public void Equal(decimal expected, decimal actual, int precision) => Assert.Equal(expected, actual, precision);
        public void Equal(DateTime expected, DateTime actual, TimeSpan precision) => Assert.Equal(expected, actual, precision);
        public void Equal(DateTime expected, DateTime actual, DatePrecision precision) => Assert.Equal(precision.Truncate(expected), precision.Truncate(actual));

        public void NotEqual<T>(T expected, T actual) => Assert.NotEqual(expected, actual);
        public void NotEqual(string expected, string actual) => Assert.NotEqual(expected, actual);
        public void NotEqual(double expected, double actual, int precision) => Assert.NotEqual(expected, actual, precision);
        public void NotEqual(decimal expected, decimal actual, int precision) => Assert.NotEqual(expected, actual, precision);
        public void NotEqual(DateTime expected, DateTime actual, TimeSpan precision) => Assert.NotEqual(expected, actual, new DateTimeToleranceComparer(precision));
        public void NotEqual(DateTime expected, DateTime actual, DatePrecision precision) => Assert.NotEqual(precision.Truncate(expected), precision.Truncate(actual));
        #endregion

        #region Same
        public void Same(object expected, object actual) => Assert.Same(expected, actual);
        public void NotSame(object expected, object actual) => Assert.NotSame(expected, actual);
        #endregion

        #region Comparisson

        #region Greater
        public void GreaterThan(double left, double right)
        {
            if (!(left > right))
                Fail($"{left} is not greater than {right}");
        }

        public void GreaterThan<T>(T left, T right)
        {
            if (!(Comparer<T>.Default.Compare(left, right) > 0))
                Fail($"{left} is not greater than {right}");
        }

        public void GreaterThan<T>(T left, T right, IComparer<T> comparer)
        {
            if (!(comparer.Compare(left, right) > 0))
                Fail($"{left} is not greater than {right}");
        }

        public void GreaterThanOrEqual(double left, double right)
        {
            if (!(left >= right))
                Fail($"{left} is not greater than or equal to {right}");
        }

        public void GreaterThanOrEqual<T>(T left, T right)
        {
            if (!(Comparer<T>.Default.Compare(left, right) >= 0))
                Fail($"{left} is not greater than or equal to {right}");
        }

        public void GreaterThanOrEqual<T>(T left, T right, IComparer<T> comparer)
        {
            if (!(comparer.Compare(left, right) >= 0))
                Fail($"{left} is not greater than or equal to {right}");
        }
        #endregion

        #region Less
        public void LessThan(double left, double right)
        {
            if (!(left < right))
                Fail($"{left} is not less than {right}");
        }

        public void LessThan<T>(T left, T right)
        {
            if (!(Comparer<T>.Default.Compare(left, right) < 0))
                Fail($"{left} is not less than {right}");
        }

        public void LessThan<T>(T left, T right, IComparer<T> comparer)
        {
            if (!(comparer.Compare(left, right) < 0))
                Fail($"{left} is not less than {right}");
        }

        public void LessThanOrEqual(double left, double right)
        {
            if (!(left <= right))
                Fail($"{left} is not less than or equal to {right}");
        }

        public void LessThanOrEqual<T>(T left, T right)
        {
            if (!(Comparer<T>.Default.Compare(left, right) <= 0))
                Fail($"{left} is not less than or equal to {right}");
        }

        public void LessThanOrEqual<T>(T left, T right, IComparer<T> comparer)
        {
            if (!(comparer.Compare(left, right) <= 0))
                Fail($"{left} is not less than or equal to {right}");
        }
        #endregion

        #endregion

        #region Ranges
        public void InRange<T>(T actual, T low, T high) where T : IComparable => Assert.InRange(actual, low, high);
        public void InRange<T>(T actual, T low, T high, IComparer<T> comparer) => Assert.InRange(actual, low, high, comparer);

        public void NotInRange<T>(T actual, T low, T high) where T : IComparable => Assert.NotInRange(actual, low, high);
        public void NotInRange<T>(T actual, T low, T high, IComparer<T> comparer) => Assert.NotInRange(actual, low, high, comparer);
        #endregion

        #region Instances and Types
        public void InstanceOfType(object actual, Type expectedType) => Assert.IsType(expectedType, actual);
        public void NotInstanceOfType(object actual, Type expectedType) => Assert.IsNotType(expectedType, actual);

        public void AssignableFrom<T>(T target, Type expectedType) => Assert.IsAssignableFrom(expectedType, target);
        public void NotAssignableFrom<T>(T target, Type expectedType)
        {
            if (target == null || expectedType.IsAssignableFrom(typeof(T)))
                Fail($"{typeof(T)} is actually assignable from {expectedType}");
        }
        #endregion

        #region Boolean
        public void True(bool value) => Assert.True(value);
        public void False(bool value) => Assert.False(value);
        #endregion

        #region Nullable
        public void Null(object value) => Assert.Null(value);
        public void NotNull(object value) => Assert.NotNull(value);
        #endregion

        #region Enumerable
        public void Contains<T>(T expected, IEnumerable<T> enumerable) => Assert.Contains(expected, enumerable);
        public void DoesNotContain<T>(T expected, IEnumerable<T> enumerable) => Assert.DoesNotContain(expected, enumerable);
        #endregion

        #region Strings
        public void IsSubstringOf(string actual, string expectedSubstring) => Assert.Contains(expectedSubstring, actual);
        public void StartsWith(string expectedSubstring, string actual) => Assert.StartsWith(expectedSubstring, actual);
        public void EndsWith(string expectedSubstring, string actual) => Assert.EndsWith(expectedSubstring, actual);

        public void IsNotSubstringOf(string actual, string expectedSubstring) {
            if (actual != null && actual.IndexOf(expectedSubstring) >= 0)
                Fail($"'{actual}' does contain '{expectedSubstring}'");
        }

        public void DoesNotStartWith(string expectedSubstring, string actual)
        {
            if (expectedSubstring != null && actual != null && actual.StartsWith(expectedSubstring))
                Fail($"'{actual}' does start with '{expectedSubstring}'");
        }

        public void DoesNotEndWith(string expectedSubstring, string actual)
        {
            if (expectedSubstring != null && actual != null && actual.EndsWith(expectedSubstring))
                Fail($"'{actual}' does end with '{expectedSubstring}'");
        }
        #endregion

        #region Fail
        public void Fail(string messageFormat, params object[] args) => throw new XunitException(string.Format(messageFormat, args));
        #endregion
    }
}
