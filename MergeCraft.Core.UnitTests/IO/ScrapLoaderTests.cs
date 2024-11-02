using MergeCraft.Core.IO;

namespace MergeCraft.Core.UnitTests.IO
{
    public class ScrapLoaderTests
    {
        [Fact]
        public async Task GivenFileName_WhenLoadAsync_ThenScrapIsReturned()
        {
            // Arrange
            var scrapLoader = new ScrapLoader("Data/Scrap.json");

            // Act
            var scrap = (await scrapLoader.LoadAsync(CancellationToken.None))?.ToList();

            // Assert
            Assert.NotNull(scrap);
            Assert.True(
                scrap.Any(x => x.Id!.Equals("scrap.wood", StringComparison.InvariantCultureIgnoreCase)) &&
                scrap.Any(x => x.Id!.Equals("scrap.metal", StringComparison.InvariantCultureIgnoreCase)) &&
                scrap.Any(x => x.Id!.Equals("scrap.electronics", StringComparison.InvariantCultureIgnoreCase)) &&
                scrap.Any(x => x.Id!.Equals("scrap.glass", StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
