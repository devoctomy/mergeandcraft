using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceComponentStackItem : IWorkspacePlaceable, IWorkspaceStackable<WorkspaceComponentItem, Component>
    {
        public string Id { get; }
        public int Count { get; private set; }
        public Component Component { get; }

        public WorkspaceComponentStackItem(
            Component component,
            int count)
        {
            Id = Guid.NewGuid().ToString();
            Component = component;
            Count = count;
        }

        public WorkspaceComponentItem? Pick()
        {
            if(Count == 0)
            {
                return null;
            }

            var item = new WorkspaceComponentItem(
                Guid.NewGuid().ToString(),
                Component);
            Count--;
            return item;
        }
    }
}
