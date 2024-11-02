using MergeCraft.Core.Craft.Interfaces;

namespace MergeCraft.Core.Craft
{
    public class Component : IComponent
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public MergeRequirement? MergeRequirement { get; set; }
    }
}
