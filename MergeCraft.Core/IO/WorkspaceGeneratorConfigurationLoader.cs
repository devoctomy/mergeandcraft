using MergeCraft.Core.IO.Interfaces;
using MergeCraft.Core.Merge;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MergeCraft.Core.IO
{
    public class WorkspaceGeneratorConfigurationLoader : IWorkspaceGeneratorConfigurationLoader
    {
        public async Task<WorkspaceGeneratorConfiguration?> LoadAsync(
            string path,
            CancellationToken cancellationToken)
        {
            var jsonRaw = await System.IO.File.ReadAllTextAsync(path, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var config = JsonSerializer.Deserialize<WorkspaceGeneratorConfiguration>(jsonRaw, options);
            if(config != null)
            {
                config.RemainingWeight = config.TotalWeight; // Move this into a public method
            }

            return config;
        }
    }
}
