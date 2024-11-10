namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceComponentMergerService<T> where T : class, IComponent<T>
    {
        public IWorkspaceMergeable<T>? Merge(
            IWorkspaceMergeable<T> source,
            IWorkspaceMergeable<T> target);
    }
}
