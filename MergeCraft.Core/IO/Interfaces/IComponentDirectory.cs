using MergeCraft.Core.Merge.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MergeCraft.Core.IO.Interfaces
{
    public interface IComponentDirectory<T> where T : class, IComponent<T>
    {
        IReadOnlyList<IComponentBom<T>> Boms { get; }
        IComponentBom<T>? GetBom(string key);
        public Task LoadAsync(
            string[] componentDataFiles,
            CancellationToken cancellationToken);
    }
}
