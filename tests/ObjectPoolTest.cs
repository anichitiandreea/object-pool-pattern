using ObjectPoolPattern;

namespace Tests
{
    public class ObjectPoolTest
    {
        [Fact]
        public void GivenGetObjectWhenPoolIsEmptyThenCheckCreatedObject()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(3);

            // Act
            var result = objectPool.GetObject();

            // Assert
            Assert.Equal(0, objectPool.GetObjectCount());
            Assert.NotNull(result);
        }

        [Fact]
        public void GivenReturnObjectWhenObjectReturnedThenCheckPoolCount()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(2);

            // Act
            var result1 = objectPool.GetObject();
            var result2 = objectPool.GetObject();

            objectPool.ReturnObject(result2);

            // Assert
            Assert.Equal(1, objectPool.GetObjectCount());
        }
    }
}
