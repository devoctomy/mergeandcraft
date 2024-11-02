using MergeCraft.Core.Merge;

namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IComponent
    {
        public MergeRequirement? MergeRequirement { get; set; }
    }
}
