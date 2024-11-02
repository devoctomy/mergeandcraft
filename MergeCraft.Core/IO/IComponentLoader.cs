using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Craft.Interfaces;

namespace MergeCraft.Core.IO
{
    public interface IComponentLoader
    {
        Task<IEnumerable<IComponent>?> LoadAsync(CancellationToken cancellationToken);
    }
}
