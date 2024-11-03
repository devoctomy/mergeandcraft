using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceMergerService : IWorkspaceMergerService<Component>
    {
        public IWorkspaceMergeable<Component>? Merge(
            IWorkspaceMergeable<Component> source,
            IWorkspaceMergeable<Component> target)
        {
            if(source.Component.Id != target.Component.Id ||
                !source.Component.CanBeMerged)
            {
                return null;
            }

            return new WorkspaceComponentItem(
                Guid.NewGuid().ToString(),
                source.Component.Product!);
        }
    }
}
