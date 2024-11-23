using MergeCraft.Core.Merge;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class WorkspaceComponentMergerServiceTests
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
            var sut = new WorkspaceComponentMergerService();

            // Act
            var merged = sut.Merge(source, target);

            // Assert
            Assert.NotNull(merged);
            Assert.Equal(component.Product.Id, merged.Component.Id);
        }

        [Fact]
        public void GivenSource_AndTarget_AndComponentIdsMismatch_WhenMerge_ThenNullReturned()
        {
            // Arrange
            var component1 = new Component
            {
                Id = Guid.NewGuid().ToString(),
                Product = new Component
                {
                    Id = "Foo"
                }
            };
            var component2 = new Component
            {
                Id = Guid.NewGuid().ToString(),
                Product = new Component
                {
                    Id = "Bar"
                }
            };
            var source = new WorkspaceComponentItem(
                Guid.NewGuid().ToString(),
                component1);
            var target = new WorkspaceComponentItem(
                Guid.NewGuid().ToString(),
                component2);
            var sut = new WorkspaceComponentMergerService();

            // Act
            var merged = sut.Merge(source, target);

            // Assert
            Assert.Null(merged);
        }
    }
}
