using MergeCraft.Core.Data;
using MergeCraft.Core.Data.Interfaces;
using MergeCraft.Core.Exceptions;
using MergeCraft.Core.IO.Interfaces;
using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;
using Moq;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class MergeWorkspaceTests
    {
        [Fact]
        public void GivenItem_AndLocation_WhenPut_ThenTrueReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);

            sut.Initialise(1, 1);

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
        public void GivenItem_AndNonEmptyLocation_WhenPut_ThenFalseReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(1, 1);

            var componentItem = new WorkspaceComponentItem(
                "Foo",
                new Component());
            sut.Put(
                componentItem,
                new Location(0, 0));

            // Act
            var success = sut.Put(
                new WorkspaceComponentItem(
                    "Foo",
                    new Component()),
                new Location(0, 0));

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void GivenUnInitialisedWorkspace_WhenPut_ThenMergeWorkspaceNotInitialisedExceptionThrown()
        {
            // Arrange
            var mockPlaceableItem = new Mock<IWorkspacePlaceable>();
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);

            // Act & Assert
            Assert.ThrowsAny<MergeWorkspaceNotInitialisedException>(() => sut.Put(mockPlaceableItem.Object, new Location(0, 0)));
        }

        [Fact]
        public void GivenWorkspaceWithItem_AndLocation_WhenGet_ThenItemIsReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

            var componentItem = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            sut.Put(
                componentItem,
                new Location(0, 0));

            // Act
            var result = sut.Get(new Location(0, 0));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(componentItem, result);
        }

        [Fact]
        public void GivenUnInitialisedWorkspace_WhenGet_ThenMergeWorkspaceNotInitialisedExceptionThrown()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);

            // Act & Assert
            Assert.ThrowsAny<MergeWorkspaceNotInitialisedException>(() => sut.Get(new Location(0, 0)));
        }

        [Fact]
        public void GivenWorkspace_AndLocationOOB_WhenGet_ThenLocationOutOfBoundsExceptionIsThrown()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

            var componentItem = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            sut.Put(
                componentItem,
                new Location(0, 0));

            // Act & Assert
            Assert.ThrowsAny<LocationOutOfBoundsException>(() => sut.Get(new Location(4, 4)));
        }

        [Fact]
        public void GivenEmptyWorkspace_AndFromLocation_AndToLocation_WhenMove_ThenFalseReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

            // Act
            var result = sut.Move(
                new Location(0, 0),
                new Location(1, 1));

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GivenWorkspaceWithWithOneItem_AndFromLocation_AndToLocation_WhenMove_ThenTrueReturned_AndItemMoved()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

            var componentItem = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            sut.Put(
                componentItem,
                new Location(0, 0));

            // Act
            var result = sut.Move(
                new Location(0, 0),
                new Location(1, 1));

            // Assert
            Assert.True(result);
            var item = sut.Get(new Location(1, 1));
            Assert.NotNull(item);
            Assert.Equal(componentItem, item);
        }

        [Fact]
        public void GivenWorkspaceWithWithGenerator_WhenActivate_ThenGeneratorGenerateCalled()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

            var generator = new TestWorkspaceGenerator(
                "Foo",
                new Component());
            sut.Put(
                generator,
                new Location(0, 0));

            // Act
            var result = sut.Activate(
                new Location(0, 0));

            // Assert
            Assert.True(result);
            Assert.True(generator.GenerateCalled);
        }

        [Fact]
        public void GivenUnInitialisedWorkspace_WhenActivate_ThenMergeWorkspaceNotInitialisedExceptionThrown()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);

            // Act & Assert
            Assert.ThrowsAny<MergeWorkspaceNotInitialisedException>(() => sut.Activate(new Location(0, 0)));
        }

        [Fact]
        public void GivenWorkspaceWithWithComponentItem_WhenActivate_ThenFalseReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

            var componentItem = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            sut.Put(
                componentItem,
                new Location(0, 0));

            // Act
            var result = sut.Activate(
                new Location(0, 0));

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GivenEmptyWorkspace_WhenActivate_ThenFalseReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

            // Act
            var result = sut.Activate(
                new Location(0, 0));

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GivenUnInitialisedWorkspace_WhenMove_ThenMergeWorkspaceNotInitialisedExceptionThrown()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);

            // Act & Assert
            Assert.ThrowsAny<MergeWorkspaceNotInitialisedException>(() => sut.Move(
                new Location(0, 0),
                new Location(1, 1)));
        }

        [Fact]
        public void GivenWorkspaceWithNonMergeableItems_AndFromLocation_AndToLocation_WhenMove_ThenFalseReturned()
        {
            // Arrange
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var mockProbabilityDistributionService = new Mock<IProbabilityDistributionService>();
            var mockComponentDirectory = new Mock<IComponentDirectory<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

            var from = new WorkspaceComponentItem(
                    "Foo",
                    new Component());
            var to = new WorkspaceGeneratorItem(
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
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

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
            var mockWorkspaceMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var sut = new MergeWorkspace(mockWorkspaceMergerService.Object);
            sut.Initialise(2, 2);

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
