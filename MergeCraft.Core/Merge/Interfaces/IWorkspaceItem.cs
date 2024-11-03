namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceItem<T> where T : class, IComponent<T>
    {
        public string? Id { get; set; }
        public T Component { get; set; }
    }
}
