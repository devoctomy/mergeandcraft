using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.IO
{
    public class ComponentBomLoader : IComponentBomLoader<Component>
    {
        private string _dataPath;

        public ComponentBomLoader(string dataPath)
        {
            _dataPath = dataPath;
        }

        public async Task<IComponentBom<Component>?> LoadAsync(CancellationToken cancellationToken)
        {
            var jsonRaw = await System.IO.File.ReadAllTextAsync(_dataPath, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var bom = JsonSerializer.Deserialize<ComponentBom>(jsonRaw, options);
            return bom;
        }
    }
}
