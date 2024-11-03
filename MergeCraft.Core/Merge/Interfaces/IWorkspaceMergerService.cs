namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceMergerService<T> where T : class, IComponent<T>
    {
        public IWorkspaceItem<T> Merge(
            IWorkspaceItem<T> source,
            IWorkspaceItem<T> target,
            IComponentBom<T> bom);
    }
}
