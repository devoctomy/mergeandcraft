using MergeCraft.Core.Data;
using MergeCraft.Core.Merge;

namespace MergeCraft.Core.UnitTests.Data
{
    public class ProbabilityDistributionServiceTests
    {
        [Fact]
        public void GivenConfiguration_WhenNext_ThenNextItemReturned_AndRemainingWeightReduced()
        {
            // Arrange
            var startWeight = 100;
            var configuration = new WorkspaceGeneratorConfiguration
            {
                Id = "test",
                RemainingWeight = startWeight,
                Items = new List<WorkspaceGeneratorConfigurationItem>
                {
                    new WorkspaceGeneratorConfigurationItem
                    {
                        Id = "foo",
                        Weight = 10,
                        Probability = 50
                    },
                    new WorkspaceGeneratorConfigurationItem
                    {
                        Id = "bar",
                        Weight = 20,
                        Probability = 50
                    }
                }
            };

            var sut = new ProbabilityDistributionService();

            // Act
            var result = sut.Next(configuration);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(startWeight - result.Weight, configuration.RemainingWeight);
        }
    }
}
