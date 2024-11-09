using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class ComponentBom : IComponentBom<Component>
    {
        public string? Id { get; set; }
        public Component? MergeTree { get; set; }

        public bool Contains(string key)
        {
            return Get(key) != null;
        }

        public Component? Get(string key)
        {
            var currentComponent = MergeTree;
            while (currentComponent != null)
            {
                if (currentComponent.Id == key)
                {
                    return currentComponent;
                }

                currentComponent = currentComponent!.Product;
            }

            return null;
        }
    }
}
