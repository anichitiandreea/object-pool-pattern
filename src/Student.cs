namespace ObjectPoolPattern
{
    public class Student() : IResettable
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }

        public void Reset()
        {
            FirstName = null;
            LastName = null;
            Age = 0;
        }
    }
}
