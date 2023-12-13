namespace ObjectPoolPattern
{
    public class ObjectPool<T>(int capacity = 100) : IDisposable where T : IResettable, new()
    {
        private readonly Queue<T> objects = new(capacity);
        private readonly int capacity = capacity;

        public int CurrentCapacity => objects.Count;
        public bool IsDisposed { get; private set; }

        public T GetObject()
        {
            ObjectDisposedException.ThrowIf(IsDisposed, this);

            if (CurrentCapacity != 0)
            {
                return objects.Dequeue();
            }

            return new T();
        }

        public void ReturnObject(T instance)
        {
            if (CurrentCapacity == capacity)
            {
                if (IsDisposableObject(instance))
                {
                    (instance as IDisposable).Dispose();
                }

                instance = default;

                return;
            }

            instance.Reset();

            objects.Enqueue(instance);
        }

        public void Dispose()
        {
            foreach (var instance in objects)
            {
                if (IsDisposableObject(instance))
                {
                    (instance as IDisposable).Dispose();
                }
            }

            objects.Clear();

            this.IsDisposed = true;

            GC.SuppressFinalize(this);
        }

        private static bool IsDisposableObject(T obj)
        {
            return obj is IDisposable;
        }
    }
}
