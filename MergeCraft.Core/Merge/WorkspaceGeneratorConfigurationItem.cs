using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGeneratorConfigurationItem
    {
        public string? Id { get; set; }
        public int Probability { get; set; }
        public int Weight { get; set; }
    }
}
