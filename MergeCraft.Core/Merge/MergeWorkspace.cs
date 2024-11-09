using MergeCraft.Core.Collections.ReadOnly;
using MergeCraft.Core.Data;
using MergeCraft.Core.Exceptions;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class MergeWorkspace : IMergeWorkspace<IWorkspacePlaceable>
    {
        private readonly IWorkspaceMergerService<Component> _workspaceMergerService;
        private readonly IWorkspacePlaceable?[,] _workspace;

        public int Width { get; }
        public int Height { get; }
        public ReadOnly2DArray<IWorkspacePlaceable?> Workspace { get; }

        public MergeWorkspace(
            int width,
            int height,
            IWorkspaceMergerService<Component> workspaceMergerService)
        {
            Width = width;
            Height = height;
            _workspaceMergerService = workspaceMergerService;
            _workspace = new IWorkspacePlaceable?[Width, Height];
            Workspace = new ReadOnly2DArray<IWorkspacePlaceable?>(_workspace);
        }

        public bool Put(
            IWorkspacePlaceable workspaceItem,
            Location location)
        {
            if (Workspace[location.X, location.Y] != null)
            {
                return false;
            }

            _workspace[location.X, location.Y] = workspaceItem;
            return true;
        }

        public IWorkspacePlaceable? Get(Location location)
        {
            if ((location.X < 0 || location.X >= Width) ||
                (location.Y < 0 || location.Y >= Height))
            {
                throw new LocationOutOfBoundsException(location, Width, Height);
            }

            return Workspace[location.X, location.Y];
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

            if (Workspace[to.X, to.Y] != null)
            {
                var destination = Workspace[to.X, to.Y];

                if(!(source is IWorkspaceMergeable<Component>) ||
                    !(destination is IWorkspaceMergeable<Component>))
                {
                    // Can only merge workspace component items
                    return false;
                }

                var sourceComponentItem = source as IWorkspaceMergeable<Component>;
                var destinationComponentItem = destination as IWorkspaceMergeable<Component>;

                var merged = _workspaceMergerService.Merge(
                    sourceComponentItem!,
                    destinationComponentItem!);
                if (merged == null)
                {
                    return false;
                }

                _workspace[from.X, from.Y] = merged as IWorkspacePlaceable;
                return true;
            }

            _workspace[to.X, to.Y] = source;
            _workspace[from.X, from.Y] = null;
            return true;
        }
    }
}
