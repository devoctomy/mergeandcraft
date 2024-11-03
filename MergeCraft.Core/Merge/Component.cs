using MergeCraft.Core.Merge.Interfaces;
using System.Text.Json.Serialization;

namespace MergeCraft.Core.Merge
{
    public class Component : IWorkspaceItem, IComponent<Component>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsMergable { get; set; }
        public Component? Product { get; set; }
    }
}
