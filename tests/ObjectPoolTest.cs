using ObjectPoolPattern;

namespace Tests
{
    public class ObjectPoolTest
    {
        [Fact]
        public void GivenGetObjectWhenPoolIsEmptyThenCheckPoolCount()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(3);

            // Act
            var object1 = objectPool.GetObject();

            // Assert
            Assert.Equal(0, objectPool.GetObjectCount());
            Assert.NotNull(object1);
        }

        [Fact]
        public void GivenReturnObjectWhenObjectReturnedThenCheckPoolCount()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(2);

            // Act
            var object1 = objectPool.GetObject();
            var object2 = objectPool.GetObject();

            objectPool.ReturnObject(object2);

            // Assert
            Assert.Equal(1, objectPool.GetObjectCount());
        }

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
    }
}
