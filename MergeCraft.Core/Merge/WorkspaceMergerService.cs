using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceMergerService : IWorkspaceMergerService<Component>
    {
        public IWorkspaceMergeable<Component>? Merge(
            IWorkspaceMergeable<Component> source,
            IWorkspaceMergeable<Component> target,
            IComponentBom<Component> bom)
        {
            if(source.Component.Id != target.Component.Id)
            {
                throw new ArgumentException("Source and target component Ids do not match, items cannot be merged.");
            }

            if (source.Component.CanBeMerged)
            {
                return new WorkspaceComponentItem(
                    Guid.NewGuid().ToString(),
                    source.Component.Product!);
            }

            return null;
        }
    }
}
