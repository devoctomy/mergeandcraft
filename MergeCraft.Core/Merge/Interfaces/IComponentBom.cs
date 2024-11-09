namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IComponentBom<T> where T : class, IComponent<T>
    {
        public string? Id { get; set; }
        T? MergeTree { get; set; }
    }
}
