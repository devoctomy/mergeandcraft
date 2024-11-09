using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.IO
{
    public class ComponentBomLoader : IComponentBomLoader<Component>
    {
        public async Task<IComponentBom<Component>?> LoadAsync(
            string path,
            CancellationToken cancellationToken)
        {
            var jsonRaw = await System.IO.File.ReadAllTextAsync(path, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var bom = JsonSerializer.Deserialize<ComponentBom>(jsonRaw, options);
            if(bom != null)
            {
                var currentComponent = bom.MergeTree;
                while (currentComponent != null)
                {
                    currentComponent.Bom = bom;
                    currentComponent = currentComponent.Product;
                }
            }

            return bom;
        }
    }
}
