using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGeneratorConfigurationItem : IWorkspaceGeneratorConfigurationItem
    {
        public string? Id { get; set; }
        public float Probability { get; set; }
        public int Weight { get; set; }
    }
}
