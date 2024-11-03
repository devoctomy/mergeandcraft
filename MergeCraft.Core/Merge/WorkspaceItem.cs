using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceItem : IWorkspaceItem<Component>
    {
        public string? Id { get; set; }
        public Component? Component { get; set; }

        public WorkspaceItem(
            string id,
            Component component)
        {
            Id = id;
            Component = component;
        }
    }
}
