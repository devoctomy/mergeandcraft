using MergeCraft.Core.IO;

namespace MergeCraft.Core.UnitTests.IO
{
    public class ComponentLoaderTests
    {
        [Theory]
        [InlineData("Data/MetalComponents.json", new string[]
        {
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
            Assert.NotNull(componentBom.Product);

            var currentComponent = componentBom.Product;
            foreach (var expectedId in idChain)
            {
                Assert.NotNull(currentComponent);
                Assert.Equal(expectedId, currentComponent.Id);
                currentComponent = currentComponent.Product;
            }
        }
    }
}
