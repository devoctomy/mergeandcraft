using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class ComponentBom : IComponentBom<Component>
    {
        public Component? MergeTree { get; set; }
    }
}
