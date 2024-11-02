using MergeCraft.Core.Craft.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace MergeCraft.Core.IO
{
    public interface IScrapLoader
    {
        Task<IEnumerable<IScrap>?> LoadAsync(CancellationToken cancellationToken);
    }
}
