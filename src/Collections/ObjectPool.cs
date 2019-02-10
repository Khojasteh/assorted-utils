using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Assorted.Utils.Collections
{
    /// <summary>
    /// Defines a pool of reusable objects.
    /// </summary>
    /// <typeparam name="T">Specifies the type of objects in the pool.</typeparam>
    /// <threadsafety static="true" instance="true"/>
    public class ObjectPool<T> : IDisposable
        where T: class
    {
        private readonly BlockingCollection<T> _pool;
        private readonly Func<T> _valueFactory;
        private readonly Action<T> _valueReset;
        private int _disposed = 0;

        /// <overloads>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class.
        /// </overloads>
        /// <summary>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class without an upper bound capacity. 
        /// When a new object needs to be initialized, the default constructor of the target type is used.
        /// </summary>
        public ObjectPool()
            : this(0, () => (T)Activator.CreateInstance(typeof(T)), null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class without an upper bound capacity.
        /// When a new object needs to be initialized, the default constructor of the target type is used.
        /// The specified action is used to reset a consumed object.
        /// </summary>
        /// <param name="valueReset">
        /// A delegate to reset a used instance before putting it back in the pool.
        /// </param>
        public ObjectPool(Action<T> valueReset)
            : this(0, () => (T)Activator.CreateInstance(typeof(T)), valueReset) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class without an upper bound capacity.
        /// When a new object needs to be initialized, the specified initialization function is used.
        /// </summary>
        /// <param name="valueFactory">
        /// The delegate invoked to produce a new instance of type <typeparamref name="T"/> when it is needed.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="valueFactory"/> is <see langword="null"/>.</exception>
        public ObjectPool(Func<T> valueFactory)
            : this(0, valueFactory, null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class without an upper bound capacity.
        /// When a new object needs to be initialized, the specified initialization function is used.
        /// The specified action is used to reset a consumed object.
        /// </summary>
        /// <param name="valueFactory">
        /// The delegate invoked to produce a new instance of type <typeparamref name="T"/> when it is needed.
        /// </param>
        /// <param name="valueReset">
        /// A delegate to reset a used instance before putting it back in the pool.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="valueFactory"/> is <see langword="null"/>.</exception>
        public ObjectPool(Func<T> valueFactory, Action<T> valueReset)
            : this(0, valueFactory, valueReset) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class with an upper bound capacity.
        /// When a new object needs to be initialized, the default constructor of the target type is used.
        /// </summary>
        /// <param name="maxCapacity">
        /// The maximum number of objects that the pool is allowed to store.
        /// </param>
        public ObjectPool(int maxCapacity)
            : this(maxCapacity, () => (T)Activator.CreateInstance(typeof(T)), null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class with an upper bound capacity.
        /// When a new object needs to be initialized, the default constructor of the target type is used.
        /// The specified action is used to reset a consumed object.
        /// </summary>
        /// <param name="maxCapacity">
        /// The maximum number of objects that the pool is allowed to store.
        /// </param>
        /// <param name="valueReset">
        /// A delegate to reset a used instance before putting it back in the pool.
        /// </param>
        public ObjectPool(int maxCapacity, Action<T> valueReset)
            : this(maxCapacity, () => (T)Activator.CreateInstance(typeof(T)), valueReset) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class with an upper bound capacity.
        /// When a new object needs to be initialized, the specified initialization function is used.
        /// The specified action is used to reset a consumed object.
        /// </summary>
        /// <param name="maxCapacity">
        /// The maximum number of objects that the pool is allowed to store.
        /// </param>
        /// <param name="valueFactory">
        /// The delegate invoked to produce a new instance of type <typeparamref name="T"/> when it is needed.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="valueFactory"/> is <see langword="null"/>.</exception>
        public ObjectPool(int maxCapacity, Func<T> valueFactory)
            : this(maxCapacity, valueFactory, null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ObjectPool{T}"/> class with an upper bound capacity.
        /// When a new object needs to be initialized, the specified initialization function is used.
        /// The specified action is used to reset a consumed object.
        /// </summary>
        /// <param name="maxCapacity">
        /// The maximum number of objects that the pool is allowed to store.
        /// </param>
        /// <param name="valueFactory">
        /// The delegate invoked to produce a new instance of type <typeparamref name="T"/> when it is needed.
        /// </param>
        /// <param name="valueReset">
        /// A delegate to reset a used instance before putting it back in the pool.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="valueFactory"/> is <see langword="null"/>.</exception>
        public ObjectPool(int maxCapacity, Func<T> valueFactory, Action<T> valueReset)
        {
            Contract.Requires<ArgumentNullException>(valueFactory != null, nameof(valueFactory));

            _pool = (maxCapacity <= 0) ? new BlockingCollection<T>() : new BlockingCollection<T>(maxCapacity);
            _valueFactory = valueFactory;
            _valueReset = valueReset;
        }

        /// <summary>
        /// Finalizes the instance of <see cref="ObjectPool{T}"/> class.
        /// </summary>
        ~ObjectPool() {
            Dispose(false);
        }

        /// <summary>
        /// Gets the number of objects which are currently in the pool.
        /// </summary>
        public int Count => _pool.Count;

        /// <summary>
        /// Gets the maximum number of objects that the pool is allowed to store.
        /// </summary>
        public int MaxCapacity => _pool.BoundedCapacity;

        /// <summary>
        /// Gets whether this instance has been disposed.
        /// </summary>
        public bool IsDisposed => (_disposed != 0);

        /// <summary>
        /// Clears the pool and disposes all the disposable objects in it.
        /// </summary>
        public virtual void Clear()
        {
            while (_pool.TryTake(out var obj))
                DisposeObject(obj);
        }

        /// <summary>
        /// Returns an object from the pool. If the pool is empty, a new object is initialized.
        /// </summary>
        /// <returns>An <see cref="ObjectPool{T}.Proxy"/> object that holds an instance of type <typeparamref name="T"/>.</returns>
        /// <seealso cref="Proxy"/>
        public virtual Proxy Acquire() {
            if (!_pool.TryTake(out var obj))
                obj = _valueFactory();

            return new Proxy(this, obj);
        }

        /// <summary>
        /// Disposes a proxy object and puts its value back in the pool if the pool's maximum capacity has not been reached; otherwise,
        /// disposes the value too.
        /// </summary>
        /// <param name="proxy">The <see cref="ObjectPool{T}.Proxy"/> object that holds the actual object to be released.</param>
        public void Release(Proxy proxy)
        {
            proxy?.Dispose();
        }

        /// <summary>
        /// Releases all resources used by the <see cref="ObjectPool{T}"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Puts an object back in the pool if the pool's maximum capacity has not been reached; otherwise,
        /// disposes the object.
        /// </summary>
        /// <param name="obj">The object to be released.</param>
        protected virtual void ReleaseObject(T obj)
        {
            if (obj != null)
            {
                _valueReset?.Invoke(obj);
                if (!_pool.TryAdd(obj))
                    DisposeObject(obj);
            }
        }

        /// <summary>
        /// Disposes the specified object if it implements the <see cref="IDisposable"/> interface.
        /// </summary>
        /// <param name="obj">The object to be disposed.</param>
        protected virtual void DisposeObject(T obj) 
        {
            if (obj is IDisposable disposable)
                disposable.Dispose();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="ObjectPool{T}"/> and 
        /// optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true"/> to release both managed and unmanaged resources; 
        /// <see langword="false"/> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
            {
                if (disposing)
                {
                    _pool.CompleteAdding();
                    Clear();
                    _pool.Dispose();
                }
            }
        }

        #region Proxy

        /// <summary>
        /// Wraps an object that has been acquired from an object pool.
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        /// <seealso cref="ObjectPool{T}.Acquire()"/>
        public sealed class Proxy : IDisposable
        {
            private readonly ObjectPool<T> _pool;
            private readonly T _value;
            private int _disposed = 0;

            /// <summary>
            /// Initializes an instance of <see cref="Proxy"/> class.
            /// </summary>
            /// <param name="pool">The <see cref="ObjectPool{T}"/> object, where this instance belongs to.</param>
            /// <param name="value">The value guarded by this proxy.</param>
            internal Proxy(ObjectPool<T> pool, T value) {
                _pool = pool;
                _value = value;
            }

            /// <summary>
            /// Gets the <see cref="ObjectPool{T}"/>, which owns this instance.
            /// </summary>
            public ObjectPool<T> Pool => _pool;

            /// <summary>
            /// Gets the value guarded by this instance.
            /// </summary>
            public T Value => (_disposed == 0) ? _value : throw new ObjectDisposedException(GetType().FullName);

            /// <summary>
            /// Gets whether the <see cref="Value"/> has been released to the <see cref="Pool"/>.
            /// </summary>
            public bool IsDisposed => (_disposed != 0);

            /// <summary>
            /// Releases this instance and puts the <see cref="Value"/> back in the <see cref="Pool"/>.
            /// </summary>
            public void Dispose()
            {
                if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
                    _pool.ReleaseObject(_value);
            }

            /// <summary>
            /// Returns a string representation of this instance.
            /// </summary>
            /// <returns>The result of calling <see cref="Object.ToString()"/> on the <see cref="Value"/>.</returns>
            public override string ToString() => Value.ToString();

            /// <summary>
            /// Implicitly converts an <see cref="ObjectPool{T}.Proxy"/> object to an object of type <typeparamref name="T"/>.
            /// </summary>
            /// <param name="proxy">An <see cref="ObjectPool{T}.Proxy"/> object.</param>
            /// <returns>The object of type <typeparamref name="T"/>, which is guarded by the specified <paramref name="proxy"/>.</returns>
            public static implicit operator T(Proxy proxy) => proxy?.Value;
       }

        #endregion
    }
}