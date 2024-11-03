using MergeCraft.Core.Merge;

namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IComponent<T> where T : class, IComponent<T>
    {
        public bool IsMergable { get; }
        public T? Product { get; set; }
    }
}
