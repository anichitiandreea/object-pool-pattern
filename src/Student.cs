namespace ObjectPoolPattern
{
    public class Student() : IResettable, IDisposable
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public bool IsDisposed { get; private set; }

        public void Reset()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Age = 0;
        }

        public void Dispose()
        {
            IsDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
