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

        [Fact]
        public void GivenConfiguration_And5050Probability_WhenNext1000_ThenRoughlyEvenDistribution()
        {
            // Arrange
            var configuration = new WorkspaceGeneratorConfiguration
            {
                Id = "test",
                RemainingWeight = int.MaxValue,
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
            var results = new List<WorkspaceGeneratorConfigurationItem>();
            for(var i = 0; i < 1000; i++)
            {
                results.Add(sut.Next(configuration));
            }
            var result = sut.Next(configuration);

            // Assert
            var fooCount = results.Count(r => r.Id == "foo");
            Assert.InRange(fooCount, 480, 520);
            var barCount = results.Count(r => r.Id == "bar");
            Assert.InRange(barCount, 480, 520);
        }
    }
}
