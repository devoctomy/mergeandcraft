using MergeCraft.Core.Collections.ReadOnly;
using MergeCraft.Core.Data;
using MergeCraft.Core.Exceptions;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class MergeWorkspace : IMergeWorkspace<IWorkspacePlaceable>
    {
        private readonly IWorkspaceComponentMergerService<Component> _workspaceComponentMergerService;
        private IWorkspacePlaceable?[,]? _workspace;
        private bool _initialised = false;

        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;
        public ReadOnly2DArray<IWorkspacePlaceable?>? Workspace { get; private set; }

        public MergeWorkspace(IWorkspaceComponentMergerService<Component> workspaceComponentMergerService)
        {
            _workspaceComponentMergerService = workspaceComponentMergerService;
        }

        public void Initialise(
            int width,
            int height)
        {
            Width = width;
            Height = height;
            _workspace = new IWorkspacePlaceable?[Width, Height];
            Workspace = new ReadOnly2DArray<IWorkspacePlaceable?>(_workspace);
            _initialised = true;
        }

        public bool Put(
            IWorkspacePlaceable workspaceItem,
            Location location)
        {
            if(!_initialised)
            {
                throw new MergeWorkspaceNotInitialisedException();
            }

            CheckLocationInBounds(location);

            if (Workspace![location.X, location.Y] != null)
            {
                return false;
            }

            _workspace![location.X, location.Y] = workspaceItem;
            return true;
        }

        public IWorkspacePlaceable? Get(Location location)
        {
            if (!_initialised)
            {
                throw new MergeWorkspaceNotInitialisedException();
            }

            CheckLocationInBounds(location);

            return Workspace![location.X, location.Y];
        }

        public bool Move(
            Location from,
            Location to)
        {
            if (!_initialised)
            {
                throw new MergeWorkspaceNotInitialisedException();
            }

            CheckLocationInBounds(from);
            CheckLocationInBounds(to);

            var source = Workspace![from.X, from.Y];
            if (source == null)
            {
                return false;
            }

            var destination = Workspace[to.X, to.Y];
            if (destination == null)
            {
                _workspace![to.X, to.Y] = source;
                _workspace[from.X, from.Y] = null;
                return true;
            }

            // !!! Need to do this more dynamically rather than assuming we want to merge components

            if (!(source is IWorkspaceMergeable<Component>) ||
                !(destination is IWorkspaceMergeable<Component>))
            {
                // Can only merge workspace component items at current
                return false;
            }

            var sourceComponentItem = source as IWorkspaceMergeable<Component>;
            var destinationComponentItem = destination as IWorkspaceMergeable<Component>;

            var merged = _workspaceComponentMergerService.Merge(
                sourceComponentItem!,
                destinationComponentItem!);
            if (merged == null)
            {
                return false;
            }

            _workspace![from.X, from.Y] = merged as IWorkspacePlaceable;
            return true;
        }

        public bool Activate(Location location)
        {
            if (!_initialised)
            {
                throw new MergeWorkspaceNotInitialisedException();
            }

            CheckLocationInBounds(location);

            var workspaceItem = Get(location);
            if (workspaceItem == null)
            {
                return false;
            }

            return workspaceItem switch
            {
                IWorkspaceGenerator<WorkspaceComponentItem> generator => ActivateGenerator(generator),
                _ => false
            };
        }

        private bool ActivateGenerator(IWorkspaceGenerator<WorkspaceComponentItem> generator)
        {
            var workspaceComponentItem = generator.Generate();
            // place workspaceComponentItem
            return workspaceComponentItem != null;
        }

        private void CheckLocationInBounds(Location location)
        {
            if ((location.X < 0 || location.X >= Width) || 
                (location.Y < 0 || location.Y >= Height))
            {
                throw new LocationOutOfBoundsException(location, Width, Height);
            }
        }
    }
}
