namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IComponentBom<T> where T : class, IComponent<T>
    {
        T? MergeTree { get; set; }
    }
}
