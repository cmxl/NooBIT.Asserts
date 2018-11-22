using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace NooBIT.Asserts.Xunit
{
    public class XunitAssertProvider : IAssertProvider
    {
        public void AreEqual<T>(T expected, T actual) => Assert.Equal(expected, actual);
        public void AreEqual(object expected, object actual) => Assert.Equal(expected, actual);
        public void AreEqual(double expected, double actual, int precision) => Assert.Equal(expected, actual, precision);
        public void AreEqual(DateTime expected, DateTime actual, TimeSpan tolerance) => Assert.Equal(expected, actual, tolerance);
        public void AreEqual(DateTime expected, DateTime actual, DatePrecision precision) => Assert.Equal(precision.Truncate(expected), precision.Truncate(actual));

        public void AreNotEqual<T>(T expected, T actual) => Assert.NotEqual(expected, actual);
        public void AreNotEqual(object expected, object actual) => Assert.NotEqual(expected, actual);
        public void AreNotEqual(double expected, double actual, int precision) => Assert.NotEqual(expected, actual, precision);
        public void AreNotEqual(DateTime expected, DateTime actual, TimeSpan tolerance) => Assert.NotEqual(expected, actual, new DateTimeToleranceComparer(tolerance));
        public void AreNotEqual(DateTime expected, DateTime actual, DatePrecision precision) => Assert.Equal(precision.Truncate(expected), precision.Truncate(actual));

        public void AreNotSame(object expected, object actual) => Assert.NotSame(expected, actual);
        public void AreSame(object expected, object actual) => Assert.Same(expected, actual);

        public void GreaterThan(double left, double right) => Assert.True(left > right);
        public void GreaterThan<T>(T left, T right) => throw new NotImplementedException();
        public void GreaterThan<T>(T left, T right, IComparer<T> comparer) => throw new NotImplementedException();
        public void GreaterThanOrEqual(double left, double right) => throw new NotImplementedException();
        public void GreaterThanOrEqual<T>(T left, T right) => throw new NotImplementedException();
        public void GreaterThanOrEqual<T>(T left, T right, IComparer<T> comparer) => throw new NotImplementedException();

        public void LessThan(double left, double right) => throw new NotImplementedException();
        public void LessThan<T>(T left, T right) => throw new NotImplementedException();
        public void LessThan<T>(T left, T right, IComparer<T> comparer) => throw new NotImplementedException();
        public void LessThanOrEqual(double left, double right) => throw new NotImplementedException();
        public void LessThanOrEqual<T>(T left, T right) => throw new NotImplementedException();
        public void LessThanOrEqual<T>(T left, T right, IComparer<T> comparer) => throw new NotImplementedException();

        public void InRange<T>(T target, T low, T high) => throw new NotImplementedException();
        public void NotInRange<T>(T target, T low, T high) => throw new NotImplementedException();

        public void IsInstanceOfType(object actual, Type expectedType) => Assert.IsType(expectedType, actual);
        public void IsNotInstanceOfType(object actual, Type expectedType) => Assert.IsNotType(expectedType, actual);

        public void IsNotNull(object value) => Assert.NotNull(value);
        public void IsNull(object value) => Assert.Null(value);

        public void IsSubstringOf(string actual, string expectedSubstring) => Assert.Contains(expectedSubstring, actual);

        public void IsTrue(bool value) => Assert.True(value);
        public void IsFalse(bool value) => Assert.False(value);

        public void AssignableFrom<T>(T target, Type expectedType) => Assert.IsAssignableFrom(expectedType, target);
        public void NotAssignableFrom<T>(T target, Type expectedType) { }

        public void Contains<T>(T item, IEnumerable<T> enumerable) => Assert.Contains(enumerable, x => x.Equals(item));
        public void NotContains<T>(T item, IEnumerable<T> enumerable) => Assert.DoesNotContain(enumerable, x => x.Equals(item));

        public void Fail(string messageFormat, params object[] args) => throw new XunitException(string.Format(messageFormat, args));

        public void StartsWith(string expectedSubstring, string actual) => Assert.StartsWith(expectedSubstring, actual);
        public void EndsWith(string expectedSubstring, string actual) => Assert.EndsWith(expectedSubstring, actual);
    }
}
