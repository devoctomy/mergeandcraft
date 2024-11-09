using MergeCraft.Core.Merge.Interfaces;
using System.Xml;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGeneratorItem : IWorkspacePlaceable, IWorkspaceGenerator<WorkspaceComponentItem>
    {
        public string Id { get; }
        public int Count { get; private set; }

        public WorkspaceGeneratorItem(
            string id,
            int count)
        {
            Id = id;
            Count = count;
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
