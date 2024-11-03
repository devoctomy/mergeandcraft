namespace MergeCraft.Core.Merge.Base
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
