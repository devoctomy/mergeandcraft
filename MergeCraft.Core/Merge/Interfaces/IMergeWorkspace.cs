using MergeCraft.Core.Collections.ReadOnly;
using MergeCraft.Core.Data;

namespace MergeCraft.Core.Merge.Interfaces
{
    internal interface IMergeWorkspace<T> where T : class
    {
        public int Width { get; }
        public int Height { get; }
        public ReadOnly2DArray<T?>? Workspace { get; }

        bool Put(
            T workspaceItem,
            Location location);
        bool Move(
            Location from,
            Location to);
    }
}
