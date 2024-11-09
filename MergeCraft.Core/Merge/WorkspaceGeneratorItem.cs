using MergeCraft.Core.IO;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGeneratorItem : IWorkspacePlaceable, IWorkspaceGenerator<WorkspaceComponentItem>
    {
        private readonly IComponentDirectory<Component> _componentDirectory;

        public string Id { get; }
        public int Count { get; private set; }

        public WorkspaceGeneratorItem(
            string id,
            int count,
            IComponentDirectory<Component> componentDirectory)
        {
            Id = id;
            Count = count;
            _componentDirectory = componentDirectory;
        }

        public WorkspaceComponentItem? Generate()
        {
            if(Count > 0)
            {
                var bom = _componentDirectory.GetBom(Id);
                if(bom == null)
                {
                    throw new System.Exception($"Bom not found for component {Id}");
                }

                var component = bom.Get(Id)!;
                var item = new WorkspaceComponentItem(
                    Id,
                    component);
                Count--;
                return item;
            }

            return null;
        }
    }
}
