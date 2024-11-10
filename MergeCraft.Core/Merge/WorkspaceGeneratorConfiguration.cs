using MergeCraft.Core.Merge.Interfaces;
using System.Collections.Generic;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGeneratorConfiguration : IWorkspaceGeneratorConfiguration<WorkspaceGeneratorConfigurationItem>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TotalWeight { get; set; }
        public List<WorkspaceGeneratorConfigurationItem>? Items { get; set; }
    }
}
