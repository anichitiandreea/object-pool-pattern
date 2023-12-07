namespace ObjectPoolPattern
{
    public class ObjectPool<T>(int objectLimit = 100) where T : IResettable, new()
    {
        private readonly Queue<T> objects = new(objectLimit);
        private readonly int objectLimit = objectLimit;

        public T GetObject()
        {
            if (objects.Count != 0)
            {
                return objects.Dequeue();
            }

            return new T();
        }

        public int GetObjectCount()
        {
            return objects.Count;
        }

        public void ReturnObject(T obj)
        {
            if (objects.Count == objectLimit)
            {
                return;
            }

            obj.Reset();

            objects.Enqueue(obj);
        }
    }
}
