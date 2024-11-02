namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IComponentBom<T> where T : class, IComponent<T>, IWorkspaceItem
    {
        string? ScrapId { get; set; }
        T? Product { get; set; }
    }
}
