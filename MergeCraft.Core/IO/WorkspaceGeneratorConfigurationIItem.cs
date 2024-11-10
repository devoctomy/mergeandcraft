using MergeCraft.Core.IO.Interfaces;

namespace MergeCraft.Core.IO
{
    public class WorkspaceGeneratorConfigurationIItem : IWorkspaceGeneratorConfigurationIItem
    {
        public string? Id { get; set; }
        public float Probability { get; set; }
        public int Weight { get; set; }
    }
}
