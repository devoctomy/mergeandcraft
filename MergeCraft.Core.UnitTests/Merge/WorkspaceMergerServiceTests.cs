using MergeCraft.Core.Merge;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class WorkspaceMergerServiceTests
    {
        [Fact]
        public void GivenSource_AndTarget_WhenMerge_ThenMergedItemReturned()
        {
            // Arrange
            var component = new Component
            {
                Id = "Foo",
                Product = new Component
                {
                    Id = "Bar"
                }
            };
            var source = new WorkspaceComponentItem(
                Guid.NewGuid().ToString(),
                component);
            var target = new WorkspaceComponentItem(
                Guid.NewGuid().ToString(),
                component);
            var sut = new WorkspaceMergerService();

            // Act
            var merged = sut.Merge(source, target);

            // Assert
            Assert.NotNull(merged);
            Assert.Equal(component.Product.Id, merged.Component.Id);
        }
    }
}
