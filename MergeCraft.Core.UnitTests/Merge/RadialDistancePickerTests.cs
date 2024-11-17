using MergeCraft.Core.Data;
using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class RadialDistancePickerTests
    {
        [Fact]
        public void GivenWorkspaceOf5x5_WhenPickingFromCentre_ThenEmptySpaceShouldBeReturned()
        {
            // Arrange
            var mockWorkspaceComponentMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var workspace = new MergeWorkspace(mockWorkspaceComponentMergerService.Object);
            var sut = new RadialDistancePicker();

            workspace.Initialise(5, 5);

            // Act
            var location = sut.PickEmpty(
                workspace,
                new Location(2, 2),
                2);

            // Assert
            Assert.NotNull(location);
            Assert.True(location.X != 2 || location.Y != 2);
        }

        [Fact]
        public void GivenWorkspaceOf5x5_AndOnlyOneSpaceEmpty_WhenPickingFromCentre_ThenEmptySpaceShouldBeReturned()
        {
            // Arrange
            var mockWorkspaceComponentMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var workspace = new MergeWorkspace(mockWorkspaceComponentMergerService.Object);
            var mockPlaceableItems = new List<Mock<IWorkspacePlaceable>>();
            var sut = new RadialDistancePicker();

            workspace.Initialise(5, 5);

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 0)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 0)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 0)));

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(0, 1)));
            //mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 1))); // This is the only empty space within the radius that is empty
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 1)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 1)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(4, 1)));

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(0, 2)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 2)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 2)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 2)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(4, 2)));

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(0, 3)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 3)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 3)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 3)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(4, 3)));

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 4)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 4)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 4)));

            // Act
            var location = sut.PickEmpty(
                workspace,
                new Location(2, 2),
                2);

            // Assert
            Assert.NotNull(location);
            Assert.Equal(1, location.X);
            Assert.Equal(1, location.Y);
        }

        [Fact]
        public void GivenWorkspaceOf5x5_AndNoEmptySpaces_WhenPickingFromCentre_ThenNullShouldBeReturned()
        {
            // Arrange
            var mockWorkspaceComponentMergerService = new Mock<IWorkspaceComponentMergerService<Component>>();
            var workspace = new MergeWorkspace(mockWorkspaceComponentMergerService.Object);
            var mockPlaceableItems = new List<Mock<IWorkspacePlaceable>>();
            var sut = new RadialDistancePicker();

            workspace.Initialise(5, 5);

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 0)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 0)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 0)));

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(0, 1)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 1)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 1)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 1)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(4, 1)));

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(0, 2)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 2)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 2)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 2)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(4, 2)));

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(0, 3)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 3)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 3)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 3)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(4, 3)));

            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(1, 4)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(2, 4)));
            mockPlaceableItems.Add(PutMockPlaceable(workspace, new Location(3, 4)));

            // Act
            var location = sut.PickEmpty(
                workspace,
                new Location(2, 2),
                2);

            // Assert
            Assert.Null(location);
        }

        private Mock<IWorkspacePlaceable> PutMockPlaceable(
            MergeWorkspace workspace,
            Location location)
        {
            var mockPlaceable = new Mock<IWorkspacePlaceable>();
            workspace.Put(
                mockPlaceable.Object,
                location);
            return mockPlaceable;
        }
    }
}
