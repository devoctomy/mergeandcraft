using MergeCraft.Core.Merge.Interfaces;
using System.Text.Json.Serialization;

namespace MergeCraft.Core.Merge
{
    public class Component : IComponent<Component>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Component? Product { get; set; }
        public bool CanBeMerged => (Product == null);
        [JsonIgnore]
        public IComponentBom<Component>? Bom { get; set; }
    }
}
