using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class ComponentBom : IComponentBom<Component>
    {
        public string? Id { get; set; }
        public Component? MergeTree { get; set; }
    }
}
