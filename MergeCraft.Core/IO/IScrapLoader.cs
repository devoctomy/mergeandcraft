using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.IO
{
    public interface IScrapLoader
    {
        Task<IEnumerable<IScrap>?> LoadAsync(CancellationToken cancellationToken);
    }
}
