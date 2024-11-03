using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceComponentStackItem : IWorkspacePlaceable, IWorkspaceStackable<Component>
    {
        public string Id { get; }
        public int Count { get; set; }
        public Component Component { get; set; }

        public WorkspaceComponentStackItem(
            string id,
            int count,
            Component component)
        {
            Id = id;
            Count = count;
            Component = component;
        }
    }
}
