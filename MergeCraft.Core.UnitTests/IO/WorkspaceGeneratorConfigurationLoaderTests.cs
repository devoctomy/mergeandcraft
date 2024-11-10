using MergeCraft.Core.IO;

namespace MergeCraft.Core.UnitTests.IO
{
    public class WorkspaceGeneratorConfigurationLoaderTests
    {
        [Fact]
        public async Task GivenPath_WhenLoadAsync_ThenLoadedConfigurationReturned()
        {
            // Arrange
            var sut = new WorkspaceGeneratorConfigurationLoader();
            var cancellationTokenSource = new CancellationTokenSource();

            // Act
            var result = await sut.LoadAsync(
                "Data/MetalJunkGenerator.json",
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(result);
        }
    }
}
