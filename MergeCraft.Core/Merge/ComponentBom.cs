using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class ComponentBom : IComponentBom<Component>
    {
        public string? ScrapId { get; set; }
        public Component? Product { get; set; }
    }
}
