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
            var object1 = objectPool.Get();

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
            _ = objectPool.Get();
            var object2 = objectPool.Get();

            objectPool.Return(object2);

            // Assert
            Assert.Same(object2, objectPool.Get());
        }

        [Fact]
        public void GivenObjectPoolWhenManyObjectsReturnedThenCheckPoolCapacity()
        {
            // Arrange
            var objectPool = new ObjectPool<Student>(2);

            // Act
            var object1 = objectPool.Get();
            var object2 = objectPool.Get();
            var object3 = objectPool.Get();

            objectPool.Return(object1);
            objectPool.Return(object2);
            objectPool.Return(object3);

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
            var object1 = objectPool.Get();

            objectPool.Return(object1);

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
            var object1 = objectPool.Get();

            objectPool.Return(object1);

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
            var object1 = objectPool.Get();

            objectPool.Return(object1);

            objectPool.Dispose();

            // Assert
            Assert.Throws<ObjectDisposedException>(() => objectPool.Get());
        }
    }
}
