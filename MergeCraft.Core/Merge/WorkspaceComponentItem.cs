using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceComponentItem : IWorkspacePlaceable, IWorkspaceMergeable<Component>
    {
        public string Id { get; }
        public Component Component { get; set; }

        public WorkspaceComponentItem(
            string id,
            Component component)
        {
            Id = id;
            Component = component;
        }
    }
}
