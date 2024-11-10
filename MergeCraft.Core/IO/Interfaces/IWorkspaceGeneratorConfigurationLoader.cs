using MergeCraft.Core.Merge;
using System.Threading;
using System.Threading.Tasks;

namespace MergeCraft.Core.IO.Interfaces
{
    public interface IWorkspaceGeneratorConfigurationLoader
    {
        public Task<WorkspaceGeneratorConfiguration?> LoadAsync(
            string path,
            CancellationToken cancellationToken);
    }
}
