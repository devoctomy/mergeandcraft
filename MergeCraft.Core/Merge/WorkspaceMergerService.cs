using MergeCraft.Core.Merge.Base;
using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceMergerService : IWorkspaceMergerService<Component>
    {
        public WorkspaceComponentItem<Component>? Merge(
            WorkspaceComponentItem<Component> source,
            WorkspaceComponentItem<Component> target,
            IComponentBom<Component> bom)
        {
            if(source.Id != target.Id)
            {
                throw new ArgumentException("Source and target Ids do not match, items cannot be merged.");
            }

            if (source.Component.CanBeMerged)
            {
                return new WorkspaceComponentItem<Component>(
                    Guid.NewGuid().ToString(),
                    source.Component.Product!);
            }

            return null;
        }
    }
}
