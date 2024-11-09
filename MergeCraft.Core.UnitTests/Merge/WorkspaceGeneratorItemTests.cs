using MergeCraft.Core.Exceptions;
using MergeCraft.Core.IO;
using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;
using Moq;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class WorkspaceGeneratorItemTests
    {
        [Fact]
        public void GivenId_AndCount1_WhenGenerate2_ThenFirstComponentIsReturned_AndSecondIsNull()
        {
            // Arrange
            var mockComponentDirectory = new Mock<IComponentDirectory<Component>>();
            var workspaceGeneratorItem = new WorkspaceGeneratorItem(
                "component.metal.spring",
                1,
                mockComponentDirectory.Object);

            mockComponentDirectory.Setup(x => x.GetBom("component.metal.spring"))
                .Returns(new ComponentBom
                {
                    Id = "bom.metal",
                    MergeTree = new Component
                    {
                        Id = "component.metal.spring",
                        Bom = null
                    }
                });

            // Act
            var workspaceComponentItem1 = workspaceGeneratorItem.Generate();
            var workspaceComponentItem2 = workspaceGeneratorItem.Generate();

            // Assert
            Assert.NotNull(workspaceComponentItem1);
            Assert.Equal("component.metal.spring", workspaceComponentItem1.Id);
            Assert.NotNull(workspaceComponentItem1.Component);
            Assert.Null(workspaceComponentItem2);
        }

        [Fact]
        public void GivenId_AndCount_WhenGenerate_AndBomNotFound_ThenExceptionThrown()
        {
            // Arrange
            var id = "component.metal.spring";
            var mockComponentDirectory = new Mock<IComponentDirectory<Component>>();
            var workspaceGeneratorItem = new WorkspaceGeneratorItem(
                id,
                1,
                mockComponentDirectory.Object);

            mockComponentDirectory.Setup(x => x.GetBom(id))
                .Returns(default(ComponentBom));

            // Act & Assert
            var exception = Assert.Throws<ComponentBomNotFoundException>(() => workspaceGeneratorItem.Generate());
            Assert.Equal($"Bom not found for component '{id}'.", exception.Message);
            Assert.Equal(id, exception.Id);
        }
    }
}
