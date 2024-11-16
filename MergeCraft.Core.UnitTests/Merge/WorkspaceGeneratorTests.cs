using MergeCraft.Core.Data.Interfaces;
using MergeCraft.Core.Exceptions;
using MergeCraft.Core.IO.Interfaces;
using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;
using Moq;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class WorkspaceGeneratorTests
    {
        [Fact]
        public void GivenNotInitialised_WhenGenerate_ThenInvalidOperationExceptionThrown()
        {
            // Arrange
            var mockComponentDirectory = new Mock<IComponentDirectory<Component>>();
            var mockProbabilityDistributionService = new Mock<IProbabilityDistributionService>();
            var sut = new WorkspaceGenerator(
                mockComponentDirectory.Object,
                mockProbabilityDistributionService.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sut.Generate());
        }

        [Fact]
        public void GivenInitialised_AndRemainingWeight0_WhenGenerate_ThenNullReturned()
        {
            // Arrange
            var mockComponentDirectory = new Mock<IComponentDirectory<Component>>();
            var mockProbabilityDistributionService = new Mock<IProbabilityDistributionService>();
            var sut = new WorkspaceGenerator(
                mockComponentDirectory.Object,
                mockProbabilityDistributionService.Object);

            sut.Initialise(new WorkspaceGeneratorConfiguration
            {
                TotalWeight = 0
            });

            // Act
            var result = sut.Generate();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GivenInitialised_AndComponentBomNotFound_WhenGenerate_ThenComponentBomNotFoundExceptionThrown()
        {
            // Arrange
            var mockComponentDirectory = new Mock<IComponentDirectory<Component>>();
            var mockProbabilityDistributionService = new Mock<IProbabilityDistributionService>();
            var sut = new WorkspaceGenerator(
                mockComponentDirectory.Object,
                mockProbabilityDistributionService.Object);

            sut.Initialise(new WorkspaceGeneratorConfiguration
            {
                TotalWeight = 100,
            });

            mockProbabilityDistributionService.Setup(x => x.Next(
                It.IsAny<int>(),
                It.IsAny<WorkspaceGeneratorConfiguration>()))
                .Returns(new WorkspaceGeneratorConfigurationItem
                {
                    Id = "Foo"
                });

            // Act & Assert
            Assert.Throws<ComponentBomNotFoundException>(() => sut.Generate());
        }

        [Fact]
        public void GivenInitialised_AndComponentBomFound_WhenGenerate_ThenRandomComponentPicked_AndBomFound_AndWorkspaceComponentItemReturned()
        {
            // Arrange
            var mockComponentDirectory = new Mock<IComponentDirectory<Component>>();
            var mockComponentBom = new Mock<IComponentBom<Component>>();
            var mockProbabilityDistributionService = new Mock<IProbabilityDistributionService>();
            var sut = new WorkspaceGenerator(
                mockComponentDirectory.Object,
                mockProbabilityDistributionService.Object);

            var component = new Component
            {
                Id = "Foo"
            };
            var config = new WorkspaceGeneratorConfiguration
            {
                TotalWeight = 100,
            };

            sut.Initialise(config);

            mockProbabilityDistributionService.Setup(x => x.Next(
                It.IsAny<int>(),
                It.IsAny<WorkspaceGeneratorConfiguration>()))
                .Returns(new WorkspaceGeneratorConfigurationItem
                {
                    Id = "Foo"
                });

            mockComponentDirectory.Setup(x => x.GetBom(
                It.IsAny<string>()))
                .Returns(mockComponentBom.Object);

            mockComponentBom.Setup(x => x.Get(
                It.IsAny<string>()))
                .Returns(component);

            // Act
            var result = sut.Generate();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Foo", result.Component.Id);
            Assert.Equal(component, result.Component);
            mockProbabilityDistributionService.Verify(x => x.Next(
                It.IsAny<int>(),
                It.Is<WorkspaceGeneratorConfiguration>(y => y == config)),
                Times.Once);
            mockComponentDirectory.Verify(x => x.GetBom(
                It.Is<string>(y => y == "Foo")),
                Times.Once);
            mockComponentBom.Verify(x => x.Get(
                It.Is<string>(y => y == "Foo")),
                Times.Once);
        }
    }
}
