namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceGenerator<T> where T : class, IWorkspacePlaceable
    {
        string Id { get; }
        int Count { get; }
        public T? Generate();
    }
}
