using MergeCraft.Core.IO;

namespace MergeCraft.Core.UnitTests.IO
{
    public class ComponentLoaderTests
    {
        [Theory]
        [InlineData("Data/MetalComponents.json", new string[]
        {
            "scrap.metal",
            "component.metal.wire",
            "component.metal.spring"
        })]
        public async Task GivenFileName_WhenLoadAsync_ThenComponentsAreReturned(
            string path,
            string[] idChain)
        {
            // Arrange
            var componentLoader = new ComponentBomLoader(path);

            // Act
            var componentBom = (await componentLoader.LoadAsync(CancellationToken.None));

            // Assert
            Assert.NotNull(componentBom);
            Assert.NotNull(componentBom.MergeTree);

            var currentComponent = componentBom.MergeTree;
            foreach (var expectedId in idChain)
            {
                Assert.NotNull(currentComponent);
                Assert.Equal(expectedId, currentComponent.Id);
                currentComponent = currentComponent.Product;
            }
        }
    }
}
