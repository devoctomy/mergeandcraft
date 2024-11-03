using MergeCraft.Core.Merge.Base;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceComponentItem<T> : WorkspaceItemBase
    {
        public T Component { get; set; }

        public WorkspaceComponentItem(
            string id,
            T component)
            : base(id)
        {
            Component = component;
        }
    }
}
