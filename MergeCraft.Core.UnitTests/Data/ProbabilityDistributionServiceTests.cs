using MergeCraft.Core.Data;
using MergeCraft.Core.Merge;

namespace MergeCraft.Core.UnitTests.Data
{
    public class ProbabilityDistributionServiceTests
    {
        [Fact]
        public void GivenConfiguration_WhenNext_AndItemsTooHeavy_TheNullReturned()
        {
            // Arrange
            var startWeight = 50;
            var configuration = new WorkspaceGeneratorConfiguration
            {
                Id = "test",
                TotalWeight = startWeight,
                Items =
                [
                    new() {
                        Id = "foo",
                        Weight = 100,
                        Probability = 100
                    }
                ]
            };

            var sut = new ProbabilityDistributionService();

            // Act
            var result = sut.Next(
                startWeight,
                configuration);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GivenConfiguration_WhenNext_ThenNextItemReturned_AndRemainingWeightReduced()
        {
            // Arrange
            var startWeight = 100;
            var configuration = new WorkspaceGeneratorConfiguration
            {
                Id = "test",
                TotalWeight = startWeight,
                Items =
                [
                    new() {
                        Id = "foo",
                        Weight = 10,
                        Probability = 50
                    },
                    new() {
                        Id = "bar",
                        Weight = 20,
                        Probability = 50
                    }
                ]
            };

            var sut = new ProbabilityDistributionService();

            // Act
            var result = sut.Next(
                startWeight,
                configuration);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GivenConfiguration_And5050Probability_WhenNext1000_ThenRoughlyEvenDistribution()
        {
            // Arrange
            var configuration = new WorkspaceGeneratorConfiguration
            {
                Id = "test",
                TotalWeight = int.MaxValue,
                Items =
                [
                    new() {
                        Id = "foo",
                        Weight = 10,
                        Probability = 50
                    },
                    new() {
                        Id = "bar",
                        Weight = 20,
                        Probability = 50
                    }
                ]
            };

            var sut = new ProbabilityDistributionService();

            // Act
            var results = new List<WorkspaceGeneratorConfigurationItem>();
            for(var i = 0; i < 1000; i++)
            {
                var value = sut.Next(int.MaxValue, configuration);
                if(value == null)
                {
                    break;
                }

                results.Add(value);
            }

            // Assert
            var fooCount = results.Count(r => r.Id == "foo");
            Assert.InRange(fooCount, 450, 550);
            var barCount = results.Count(r => r.Id == "bar");
            Assert.InRange(barCount, 450, 550);
        }
    }
}
