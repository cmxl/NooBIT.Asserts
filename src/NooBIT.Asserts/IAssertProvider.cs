using System;
using System.Collections.Generic;

namespace NooBIT.Asserts
{
    public interface IAssertProvider
    {
        void AssignableFrom<T>(T target, Type expectedType);
        void Contains<T>(T expected, IEnumerable<T> enumerable);
        void DoesNotContain<T>(T expected, IEnumerable<T> enumerable);
        void EndsWith(string expectedSubstring, string actual);
        void Equal(DateTime expected, DateTime actual, DatePrecision precision);
        void Equal(DateTime expected, DateTime actual, TimeSpan precision);
        void Equal(decimal expected, decimal actual, int precision);
        void Equal(double expected, double actual, int precision);
        void Equal(string expected, string actual);
        void Equal<T>(T expected, T actual);
        void Fail(string messageFormat, params object[] args);
        void False(bool value);
        void GreaterThan(double left, double right);
        void GreaterThan<T>(T left, T right);
        void GreaterThan<T>(T left, T right, IComparer<T> comparer);
        void GreaterThanOrEqual(double left, double right);
        void GreaterThanOrEqual<T>(T left, T right);
        void GreaterThanOrEqual<T>(T left, T right, IComparer<T> comparer);
        void InRange<T>(T actual, T low, T high) where T : IComparable;
        void InRange<T>(T actual, T low, T high, IComparer<T> comparer);
        void InstanceOfType(object actual, Type expectedType);
        void IsSubstringOf(string actual, string expectedSubstring);
        void LessThan(double left, double right);
        void LessThan<T>(T left, T right);
        void LessThan<T>(T left, T right, IComparer<T> comparer);
        void LessThanOrEqual(double left, double right);
        void LessThanOrEqual<T>(T left, T right);
        void LessThanOrEqual<T>(T left, T right, IComparer<T> comparer);
        void NotAssignableFrom<T>(T target, Type expectedType);
        void NotEqual(DateTime expected, DateTime actual, DatePrecision precision);
        void NotEqual(DateTime expected, DateTime actual, TimeSpan precision);
        void NotEqual(decimal expected, decimal actual, int precision);
        void NotEqual(double expected, double actual, int precision);
        void NotEqual(string expected, string actual);
        void NotEqual<T>(T expected, T actual);
        void NotInRange<T>(T actual, T low, T high) where T : IComparable;
        void NotInRange<T>(T actual, T low, T high, IComparer<T> comparer);
        void NotInstanceOfType(object actual, Type expectedType);
        void NotNull(object value);
        void NotSame(object expected, object actual);
        void Null(object value);
        void Same(object expected, object actual);
        void StartsWith(string expectedSubstring, string actual);
        void True(bool value);
    }
}