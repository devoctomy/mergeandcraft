using MergeCraft.Core.Merge;

namespace MergeCraft.Core.Data.Interfaces
{
    public interface IProbabilityDistributionService
    {
        public WorkspaceGeneratorConfigurationItem Next(WorkspaceGeneratorConfiguration configuration);
    }
}
