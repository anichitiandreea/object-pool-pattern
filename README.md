# Object pool pattern in C#

This is a basic implementation of the object pool pattern using .NET 8.

Pool generic class definition is as follows:

``` csharp
public class ObjectPool<T>(int capacity = 100) : IDisposable where T : IResettable, new()
```

The pool contains 2 main methods, one for getting the object from the pool and other for returning it.

The object pool implements the IDisposable interface.
Also, the generic type should implement the IResettable interface so that every object will reset when it is returned back to the pool.

Here is an example of the Student class, which is used to create a pool of Student objects:

``` csharp
public class Student() : IResettable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public void Reset()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Age = 0;
    }
}
```

An usage sample can be seen in the tests folder:

``` csharp
[Fact]
public void GivenObjectPoolWhenObjectReturnedThenCheckReturnedObject()
{
    // Arrange
    var objectPool = new ObjectPool<Student>(2);

    // Act
    _ = objectPool.GetObject();
    var object2 = objectPool.GetObject();

    objectPool.ReturnObject(object2);

    // Assert
    Assert.Same(object2, objectPool.GetObject());
}
```
