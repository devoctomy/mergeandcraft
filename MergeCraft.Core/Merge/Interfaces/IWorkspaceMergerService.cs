using MergeCraft.Core.Merge.Base;

namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceMergerService<T> where T : class, IComponent<T>
    {
        public WorkspaceComponentItem<T>? Merge(
            WorkspaceComponentItem<T> source,
            WorkspaceComponentItem<T> target,
            IComponentBom<T> bom);
    }
}
