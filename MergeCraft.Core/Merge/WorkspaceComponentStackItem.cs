using MergeCraft.Core.Merge.Base;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceComponentStackItem<T> : WorkspaceItemBase
    {
        public int Count { get; set; }
        public T Component { get; set; }

        public WorkspaceComponentStackItem(
            string id,
            int count,
            T component)
            : base(id)
        {
            Count = count;
            Component = component;
        }
    }
}
