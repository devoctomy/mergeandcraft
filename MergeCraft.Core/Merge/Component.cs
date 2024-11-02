using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class Component : IComponent
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public MergeRequirement? MergeRequirement { get; set; }
    }
}
