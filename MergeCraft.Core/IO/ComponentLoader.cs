using MergeCraft.Core.Craft;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Craft.Interfaces;

namespace MergeCraft.Core.IO
{
    public class ComponentLoader : IComponentLoader
    {
        private const string IdPrefix = "component";
        private string _dataPath;

        public ComponentLoader(string dataPath)
        {
            _dataPath = dataPath;
        }

        public async Task<IEnumerable<IComponent>?> LoadAsync(CancellationToken cancellationToken)
        {
            var jsonRaw = await System.IO.File.ReadAllTextAsync(_dataPath, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var components = JsonSerializer.Deserialize<List<Component>>(jsonRaw, options);
            components?.ForEach(x => x.Id = $"{IdPrefix}.{x.Id}");

            return components;
        }
    }
}
