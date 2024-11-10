using MergeCraft.Core.Merge.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MergeCraft.Core.IO.Interfaces
{
    public interface IWorkspaceGeneratorConfigurationLoader<T> where T : class, IWorkspaceGeneratorConfigurationItem
    {
        public Task<IWorkspaceGeneratorConfiguration<T>?> LoadAsync(
            string path,
            CancellationToken cancellationToken);
    }
}
