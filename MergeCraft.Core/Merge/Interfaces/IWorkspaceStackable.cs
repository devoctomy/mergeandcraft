namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceStackable<T> where T : class, IComponent<T>
    {
        public int Count { get; set; }
        T Component { get; set; }
    }
}
