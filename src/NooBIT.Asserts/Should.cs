using System;

namespace NooBIT.Asserts
{
    public class Should<T> : IShould<T>
    {
        public Should(T value, IAssertProvider provider)
        {
            Value = value;
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public IBe<T> Be => new Be<T>(this);

        public IShould<T> Not
        {
            get
            {
                Negate = !Negate;
                return this;
            }
        }

        public IAssertProvider Provider { get; }

        public T Value { get; }

        public bool Negate { get; private set; }

        public IBe<T> Apply(Action<T, IAssertProvider> positive, Action<T, IAssertProvider> negative)
        {
            if (Negate)
                negative(Value, Provider);
            else
                positive(Value, Provider);
            return Be;
        }

        public object Apply(Func<T, IAssertProvider, object> positive, Func<T, IAssertProvider, object> negative) => Negate
                ? negative(Value, Provider)
                : positive(Value, Provider);
    }

    public interface IShould<T>
    {
        IBe<T> Be { get; }
        IShould<T> Not { get; }
        T Value { get; }
        bool Negate { get; }
        IAssertProvider Provider { get; }
        IBe<T> Apply(Action<T, IAssertProvider> positive, Action<T, IAssertProvider> negative);
        object Apply(Func<T, IAssertProvider, object> positive, Func<T, IAssertProvider, object> negative);
    }
}
