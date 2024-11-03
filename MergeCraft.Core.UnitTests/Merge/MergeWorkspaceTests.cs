using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;
using Moq;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class MergeWorkspaceTests
    {
        [Fact]
        public void GivenItem_AndLocation_WhenPut_ThenItemIsPlaced()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceMergerService<Component>>();
            var sut = new MergeWorkspace(
                2,
                2,
                mockWorkspaceMergerService.Object);

            // Act
            var success = sut.Put(
                new WorkspaceComponentItem(
                    "Foo",
                    new Component()),
                new Data.Location(0, 0));

            // Assert
            Assert.True(success);
        }

        [Fact]
        public void GivenWorkspaceWithItem_AndLocation_WhenGet_ThenItemIsReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceMergerService<Component>>();
            var sut = new MergeWorkspace(
                2,
                2,
                mockWorkspaceMergerService.Object);
            var item = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            sut.Put(
                item,
                new Data.Location(0, 0));

            // Act
            var result = sut.Get(new Data.Location(0, 0));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(item, result);
        }
    }
}
