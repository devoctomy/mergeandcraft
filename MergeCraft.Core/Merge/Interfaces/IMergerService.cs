namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IMergerService<T> where T : class?, IWorkspaceItem, IComponent<T>
    {
        public T Merge(
            T source,
            T destination,
            ComponentBom bom);
    }
}
