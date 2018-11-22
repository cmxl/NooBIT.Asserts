using System;
using System.Collections.Generic;

namespace NooBIT.Asserts
{
    public class DateTimeToleranceComparer : IEqualityComparer<DateTime>
    {
        private readonly TimeSpan _tolerance;

        public DateTimeToleranceComparer(TimeSpan tolerance)
        {
            _tolerance = tolerance;
        }

        public bool Equals(DateTime x, DateTime y)
        {
            var difference = Math.Abs((x - y).Ticks);
            return difference <= _tolerance.Ticks;
        }

        public int GetHashCode(DateTime obj) => obj.GetHashCode();
    }
}