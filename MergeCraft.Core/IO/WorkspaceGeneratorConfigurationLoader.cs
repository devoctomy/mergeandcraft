using MergeCraft.Core.IO.Interfaces;
using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MergeCraft.Core.IO
{
    public class WorkspaceGeneratorConfigurationLoader : IWorkspaceGeneratorConfigurationLoader<WorkspaceGeneratorConfigurationItem>
    {
        public async Task<IWorkspaceGeneratorConfiguration<WorkspaceGeneratorConfigurationItem>?> LoadAsync(
            string path,
            CancellationToken cancellationToken)
        {
            var jsonRaw = await System.IO.File.ReadAllTextAsync(path, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var config = JsonSerializer.Deserialize<WorkspaceGeneratorConfiguration>(jsonRaw, options);
            return config;
        }
    }
}
