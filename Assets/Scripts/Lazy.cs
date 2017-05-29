using System;

namespace Assets.Scripts
{
    public class Lazy<T>
    {
        private bool _loaded = false;
        private T _value;
        private Func<T> _provider;

        public Lazy(Func<T> provider)
        {
            _provider = provider;
        }

        public T Value
        {
            get
            {
                if (_loaded == false)
                    _value = _provider();
                return _value;
            }
        }
    }      
}
