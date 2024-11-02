using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.IO
{
    public interface IScrapLoader<T> where T : IScrap, IWorkspaceItem
    {
        Task<IEnumerable<T>?> LoadAsync(CancellationToken cancellationToken);
    }
}
