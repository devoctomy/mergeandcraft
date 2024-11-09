using MergeCraft.Core.IO;
using MergeCraft.Core.Merge;
using Moq;

namespace MergeCraft.Core.UnitTests.IO
{
    public class ComponentDirectoryTests
    {
        [Fact]
        public async Task GivenDataPaths_WhenLoadAsync_ThenAllComponentBomsLoaded()
        {
            // Arrange
            var mockComponentBomLoader = new Mock<IComponentBomLoader<Component>>();
            var sut = new ComponentDirectory(mockComponentBomLoader.Object);

            mockComponentBomLoader.Setup(x => x.LoadAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync((string path, CancellationToken ct) => {
                    return new ComponentBom
                    {
                        Id = path
                    };
                });

            var cancellationTokenSource = new CancellationTokenSource();

            // Act
            await sut.LoadAsync(
                ["path1", "path2"],
                cancellationTokenSource.Token);

            // Assert
            Assert.Equal(2, sut.Boms.Count);
        }

        [Fact]
        public async Task GivenKey_AndBomExists_WhenGetBom_ThenComponentBomReturned()
        {
            // Arrange
            var mockComponentBomLoader = new Mock<IComponentBomLoader<Component>>();
            var sut = new ComponentDirectory(mockComponentBomLoader.Object);

            mockComponentBomLoader.Setup(x => x.LoadAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync((string path, CancellationToken ct) => {
                    return new ComponentBom
                    {
                        Id = path
                    };
                });

            var cancellationTokenSource = new CancellationTokenSource();

            await sut.LoadAsync(
                ["path1", "path2"],
                cancellationTokenSource.Token);

            // Act
            var result1 = sut.GetBom("path1");
            var result2 = sut.GetBom("path2");

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
        }

        [Fact]
        public async Task GivenKey_AndBomNotExists_WhenGetBom_Then()
        {
            // Arrange
            var mockComponentBomLoader = new Mock<IComponentBomLoader<Component>>();
            var sut = new ComponentDirectory(mockComponentBomLoader.Object);

            mockComponentBomLoader.Setup(x => x.LoadAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync((string path, CancellationToken ct) => {
                    return new ComponentBom
                    {
                        Id = path
                    };
                });

            var cancellationTokenSource = new CancellationTokenSource();

            await sut.LoadAsync(
                ["path1", "path2"],
                cancellationTokenSource.Token);

            // Act
            var result = sut.GetBom("FooBar");

            // Assert
            Assert.Null(result);
        }
    }
}
