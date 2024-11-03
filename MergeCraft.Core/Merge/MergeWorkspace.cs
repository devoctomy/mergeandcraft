using MergeCraft.Core.Collections.ReadOnly;
using MergeCraft.Core.Craft.Interfaces;
using MergeCraft.Core.Data;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class MergeWorkspace : ICraftWorkspace<Component>
    {
        private Component?[,] _workspace;

        public int Width { get; }
        public int Height { get; }
        public ReadOnly2DArray<Component?> Workspace { get; }

        public MergeWorkspace(
            int width,
            int height,
            IMergerService<Component> mergerService)
        {
            Width = width;
            Height = height;
            _workspace = new Component?[Width, Height];
            Workspace = new ReadOnly2DArray<Component?>(_workspace);
        }

        public bool Put(
            Component component,
            Location location)
        {
            if (Workspace[location.X, location.Y] != null)
            {
                return false;
            }

            _workspace[location.X, location.Y] = component;
            return true;
        }

        public bool Move(
            Location from,
            Location to)
        {
            var source = Workspace[from.X, from.Y];
            if (source == null)
            {
                return false;
            }

            if (Workspace[to.X, to.Y] == null)
            {
                var destination = Workspace[to.X, to.Y];
                // merge
            }

            _workspace[to.X, to.Y] = source;
            _workspace[from.X, from.Y] = null;
            return true;
        }
    }
}
