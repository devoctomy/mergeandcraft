using MergeCraft.Core.Collections.ReadOnly;

namespace MergeCraft.Core.UnitTests.Collections.ReadOnly
{
    public class ReadOnly2DArrayTests
    {
        [Fact]
        public void GivenArray_AndReadOnly2DArray_WhenGetLength_ThenReturnLength()
        {
            // Arrange
            var array = new int[2, 3];
            var readOnly2DArray = new ReadOnly2DArray<int>(array);

            // Act
            var length0 = readOnly2DArray.GetLength(0);
            var length1 = readOnly2DArray.GetLength(1);

            // Assert
            Assert.Equal(2, length0);
            Assert.Equal(3, length1);
        }
    }
}
