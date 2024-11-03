using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.IO
{
    public interface IComponentBomLoader<T> where T : class, IComponent<T>
    {
        Task<IComponentBom<T>?> LoadAsync(CancellationToken cancellationToken);
    }
}
