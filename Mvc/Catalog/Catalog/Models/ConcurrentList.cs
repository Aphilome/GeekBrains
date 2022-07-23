namespace Catalog.Models
{
    public class ConcurrentList<T>
    {
        private object _lock = new object();
        private int _virtualSize = 0;
        private T[]? _array = null;

        public ConcurrentList()
        {
            if (_array != null)
                return;
            lock (_lock)
            {
                if (_array != null)
                    return;
                _array = new T[1];
            }
        }
        
        public ConcurrentList(int capacity)
        {
            if (_array != null)
                return;
            lock (_lock)
            {
                if (_array != null)
                    return;
                if (capacity < 0)
                    throw new ArgumentOutOfRangeException(nameof(capacity));
                _array = new T[capacity == 0 ? 1 : capacity];
            }
        }

        public int Length => _array.Length;

        public void Add(T item)
        {
            lock (_lock)
            {
                if (_virtualSize == Length)
                    Rebuilder();
                AddItem(item);
            }
        }
        
        public void Remove(T item)
        {
            if (_virtualSize == 0)
                return;
            lock (_lock)
            {
                RemoveItem(item);
            }
        }
        
        public void Clear()
        {
            if (_virtualSize == 0)
                return;
            lock (_lock)
            {
                ClearArray();
            }
        }

        public T this[int i]
        {
            get => _array[i];
            set
            {
                lock (_lock)
                {
                    _array[i] = value;
                }
            }
        }

        #region For single thread methods!!!

        private void Rebuilder()
        {
            var newArray = new T[Length == 0 ? 1 : 2 * Length];
            for (var i = 0; i < Length; ++i)
                newArray[i] = _array[i];
            _array = newArray;
        }

        private void AddItem(T item)
        {
            _array[_virtualSize++] = item;
        }

        private void RemoveItem(T item)
        {
            var removeIndex = -1;
            for (int i = 0; i < Length; ++i)
            {
                if (_array[i].Equals(item))
                {
                    removeIndex = i;
                    break;
                }
            }
            if (removeIndex == -1)
                return;
            var newArray = new T[Length];
            for (var i = 0; i < Length; ++i)
            {
                if (i == removeIndex)
                    continue;
                if (i < removeIndex)
                    newArray[i] = _array[i];
                else
                    newArray[i - 1] = _array[i];
            }
            _array = newArray;
            _virtualSize--;
        }

        private void ClearArray()
        {
            _array = new T[Length];
            _virtualSize = 0;
        }

        #endregion
    }
}
