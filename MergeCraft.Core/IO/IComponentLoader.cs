using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.IO
{
    public interface IComponentLoader<T> where T : IComponent, IWorkspaceItem
    {
        Task<IEnumerable<T>?> LoadAsync(CancellationToken cancellationToken);
    }
}
