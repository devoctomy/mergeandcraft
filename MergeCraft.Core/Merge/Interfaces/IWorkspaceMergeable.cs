namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceMergeable<T> where T : class, IComponent<T>
    {
        T Component { get; set; }
    }
}
