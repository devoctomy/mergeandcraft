using MergeCraft.Core.Merge;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class WorkspaceComponentStackItemTests
    {
        [Fact]
        public void GivenStackItem_WithCount5_WhenPop6_Then5Popped()
        {
            // Arrange
            var sut = new WorkspaceComponentStackItem(
                new Component
                {
                    Id = "Foo"
                },
                5,
                5);

            // Act
            var popped = new List<WorkspaceComponentItem>();
            for (var i = 0; i < 6; i++)
            {
                var item = sut.Pop();
                if (item != null)
                {
                    popped.Add(item);
                }
            }

            // Assert
            Assert.NotEmpty(sut.Id);
            Assert.Equal(5, popped.Count);
            Assert.All(popped, x => Assert.Equal("Foo", x.Component.Id));
        }

        [Fact]
        public void GivenStackItem_WithCount0_AndMax5_WhenPush6_Then6Pushed()
        {
            // Arrange
            var sut = new WorkspaceComponentStackItem(
                new Component
                {
                    Id = "Foo"
                },
                0,
                5);

            // Act
            var count = 0;
            for (var i = 0; i < 6; i++)
            {
                var pushed = sut.Push();
                if(pushed)
                {
                    count++;
                }
            }

            // Assert
            Assert.NotEmpty(sut.Id);
            Assert.Equal(5, count);
        }
    }
}
