# Object pool pattern in C#

This is a basic implementation of the object pool pattern using .NET 8.

The ObjectPool generic class contains 2 main methods, one for getting the object from the object pool and other for returning it.
It also implements the IResettable interface so that every object will reset when it is returned back to the pool.

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
public void GivenReturnObjectWhenManyObjectsReturnedThenCheckPoolCount()
{
    // Arrange
    var objectPool = new ObjectPool<Student>(2);

    // Act
    var object1 = objectPool.GetObject();
    var object2 = objectPool.GetObject();
    var object3 = objectPool.GetObject();

    objectPool.ReturnObject(object1);
    objectPool.ReturnObject(object2);
    objectPool.ReturnObject(object3);

    // Assert
    Assert.Equal(2, objectPool.GetObjectCount());
}
```
