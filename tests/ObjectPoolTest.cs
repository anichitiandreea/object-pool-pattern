using ObjectPoolPattern;

namespace Tests
{
    public class ObjectPoolTest
    {
        [Fact]
        public void GivenObjectPoolWhenPoolIsEmptyThenCheckPoolCapacity()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(3);

            // Act
            var object1 = objectPool.GetObject();

            // Assert
            Assert.Equal(0, objectPool.CurrentCapacity);
            Assert.NotNull(object1);
        }

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

        [Fact]
        public void GivenObjectPoolWhenManyObjectsReturnedThenCheckPoolCapacity()
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
            Assert.Equal(2, objectPool.CurrentCapacity);
            Assert.True(object3.IsDisposed);
        }

        [Fact]
        public void GivenObjectPoolWhenDisposedPoolThenCheckDisposedObjects()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(2);

            // Act
            var object1 = objectPool.GetObject();

            objectPool.ReturnObject(object1);

            objectPool.Dispose();

            // Assert
            Assert.True(object1.IsDisposed);
        }

        [Fact]
        public void GivenObjectPoolWhenDisposedPoolThenCheckIfDisposed()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(2);

            // Act
            var object1 = objectPool.GetObject();

            objectPool.ReturnObject(object1);

            objectPool.Dispose();

            // Assert
            Assert.True(objectPool.IsDisposed);
        }

        [Fact]
        public void GivenObjectPoolWhenExceptionThrownThenHandleGracefully()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(2);

            // Act
            var object1 = objectPool.GetObject();

            objectPool.ReturnObject(object1);

            objectPool.Dispose();

            // Assert
            Assert.Throws<ObjectDisposedException>(() => objectPool.GetObject());
        }
    }
}
