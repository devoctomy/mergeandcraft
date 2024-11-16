using MergeCraft.Core.Merge;

namespace MergeCraft.Core.Data.Interfaces
{
    public interface IProbabilityDistributionService
    {
        public WorkspaceGeneratorConfigurationItem? Next(
            int remainingWeight,
            WorkspaceGeneratorConfiguration configuration);
    }
}
