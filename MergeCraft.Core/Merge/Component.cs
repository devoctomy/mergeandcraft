using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class Component : IWorkspaceItem, IComponent<Component>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Component? Product { get; set; }
    }
}
