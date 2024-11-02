using MergeCraft.Core.IO;

namespace MergeCraft.Core.UnitTests.IO
{
    public class ComponentLoaderTests
    {
        [Theory]
        [InlineData("Data/MetalComponents.json",
            new[]
            {
                "component.metal.wire:scrap.metal",
                "component.metal.spring:component.metal.wire"
            })]
        public async Task GivenFileName_WhenLoadAsync_ThenComponentsAreReturned(
            string path,
            string[] expectedComponents)
        {
            // Arrange
            var componentLoader = new ComponentLoader(path);

            // Act
            var components = (await componentLoader.LoadAsync(CancellationToken.None))?.ToList();

            // Assert
            Assert.NotNull(components);
            foreach(var expectedComponent in expectedComponents)
            {
                var expectedComponentParts = expectedComponent.Split(':');
                Assert.Contains(components, x =>
                    x.Id!.Equals(expectedComponentParts[0], StringComparison.InvariantCultureIgnoreCase) &&
                    x.MergeRequirement!.SourceId == expectedComponentParts[1]);
            }
        }
    }
}
