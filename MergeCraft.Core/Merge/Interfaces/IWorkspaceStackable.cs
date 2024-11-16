namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceStackable<T, CT> where T : class, IWorkspacePlaceable
    {
        public int Count { get; }
        public int Max { get; }
        public CT Component { get; }
        public bool Push();
        public T? Pop();
    }
}
