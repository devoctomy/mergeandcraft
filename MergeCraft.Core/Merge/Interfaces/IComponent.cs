namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IComponent<T> where T : class, IComponent<T>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public T? Product { get; set; }
        public bool CanBeMerged { get; }
        public IComponentBom<T>? Bom { get; set; }
    }
}
