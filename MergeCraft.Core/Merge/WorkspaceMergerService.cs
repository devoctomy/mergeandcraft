using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceMergerService : IWorkspaceMergerService<Component>
    {
        public IWorkspaceItem<Component> Merge(
            IWorkspaceItem<Component> source,
            IWorkspaceItem<Component> target,
            IComponentBom<Component> bom)
        {
            throw new NotImplementedException();
        }
    }
}
