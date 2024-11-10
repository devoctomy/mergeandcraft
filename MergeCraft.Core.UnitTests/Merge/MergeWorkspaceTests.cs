using MergeCraft.Core.Data;
using MergeCraft.Core.Data.Interfaces;
using MergeCraft.Core.IO.Interfaces;
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
                new Location(0, 0));

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
                new Location(0, 0));

            // Act
            var result = sut.Get(new Location(0, 0));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(item, result);
        }

        [Fact]
        public void GivenWorkspaceWithNonMergeableItems_AndFromLocation_AndToLocation_WhenMove_ThenFalseReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceMergerService<Component>>();
            var mockProbabilityDistributionService = new Mock<IProbabilityDistributionService>();
            var mockComponentDirectory = new Mock<IComponentDirectory<Component>>();
            var sut = new MergeWorkspace(
                2,
                2,
                mockWorkspaceMergerService.Object);
            var from = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            var to = new WorkspaceGenerator(
                mockComponentDirectory.Object,
                mockProbabilityDistributionService.Object);
            sut.Put(
                from,
                new Location(0, 0));
            sut.Put(
                to,
                new Location(1, 1));

            // Act
            var result = sut.Move(
                new Location(0, 0),
                new Location(1, 1));

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GivenWorkspaceWithMergeableItems_AndFromLocation_AndToLocation_AndItemInBothLocations_AndMergeSuccess_WhenMove_ThenMergeServiceCalled_AndTrueReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceMergerService<Component>>();
            var sut = new MergeWorkspace(
                2,
                2,
                mockWorkspaceMergerService.Object);
            var from = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            var to = new WorkspaceComponentItem(
                    "Bar",
                    new Component());
            sut.Put(
                from,
                new Location(0, 0));
            sut.Put(
                to,
                new Location(1, 1));

            mockWorkspaceMergerService.Setup(x => x.Merge(
                It.IsAny<IWorkspaceMergeable<Component>>(),
                It.IsAny<IWorkspaceMergeable<Component>>()))
                .Returns(new WorkspaceComponentItem(
                    "FooBar",
                    new Component()));

            // Act
            var result = sut.Move(
                new Location(0, 0),
                new Location(1, 1));

            // Assert
            Assert.True(result);
            mockWorkspaceMergerService.Verify(x => x.Merge(
                from,
                to),
                Times.Once);
        }

        [Fact]
        public void GivenWorkspaceWithMergeableItems_AndFromLocation_AndToLocation_AndItemInBothLocations_AndMergeFailed_WhenMove_ThenMergeServiceCalled_AndFalseReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceMergerService<Component>>();
            var sut = new MergeWorkspace(
                2,
                2,
                mockWorkspaceMergerService.Object);
            var from = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            var to = new WorkspaceComponentItem(
                    "Bar",
                    new Component());
            sut.Put(
                from,
                new Location(0, 0));
            sut.Put(
                to,
                new Location(1, 1));

            mockWorkspaceMergerService.Setup(x => x.Merge(
                It.IsAny<IWorkspaceMergeable<Component>>(),
                It.IsAny<IWorkspaceMergeable<Component>>()))
                .Returns(default(WorkspaceComponentItem));

            // Act
            var result = sut.Move(
                new Location(0, 0),
                new Location(1, 1));

            // Assert
            Assert.False(result);
            mockWorkspaceMergerService.Verify(x => x.Merge(
                from,
                to),
                Times.Once);
        }
    }
}
