using MergeCraft.Core.IO;
using MergeCraft.Core.Merge.Interfaces;
using System.Xml;

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
                var item = new WorkspaceComponentItem(
                    Id,
                    new Component()); // !!! Get component reference to create
                Count--;
                return item;
            }

            return null;
        }
    }
}
