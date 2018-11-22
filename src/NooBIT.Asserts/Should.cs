using System;

namespace NooBIT.Asserts
{
    public class Should<T> : IShould<T>
    {
        internal readonly T _value;
        private readonly IAssertProvider _provider;
        internal bool _negate;

        public Should(T value, IAssertProvider provider)
        {
            _value = value;
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public IBe<T> Be => new Be<T>(this);

        public IShould<T> Not
        {
            get
            {
                _negate = !_negate;
                return this;
            }
        }

        public T Value => _value;

        public bool Negate => _negate;

        public T Apply(Action<T, IAssertProvider> positive, Action<T, IAssertProvider> negative)
        {
            if (_negate)
                negative(_value, _provider);
            else
                positive(_value, _provider);
            return _value;
        }

        public object Apply(Func<T, IAssertProvider, object> positive, Func<T, IAssertProvider, object> negative) => _negate
                ? negative(_value, _provider)
                : positive(_value, _provider);
    }

    public interface IShould<T>
    {
        IBe<T> Be { get; }
        IShould<T> Not { get; }
        T Value { get; }
        bool Negate { get; }
        T Apply(Action<T, IAssertProvider> positive, Action<T, IAssertProvider> negative);
        object Apply(Func<T, IAssertProvider, object> positive, Func<T, IAssertProvider, object> negative);
    }
}
