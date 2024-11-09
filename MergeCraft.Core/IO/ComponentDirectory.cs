using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MergeCraft.Core.IO
{
    public class ComponentDirectory : IComponentDirectory<Component>
    {
        private readonly IComponentBomLoader<Component> _componentBomLoader;
        private readonly Dictionary<string, IComponentBom<Component>> _componentBoms;

        public IReadOnlyList<IComponentBom<Component>> Boms => _componentBoms.Values.ToList();

        public ComponentDirectory(IComponentBomLoader<Component> componentBomLoader)
        {
            _componentBomLoader = componentBomLoader;
            _componentBoms = new Dictionary<string, IComponentBom<Component>>();
        }

        public IComponentBom<Component>? GetBom(string key)
        {
            if(_componentBoms.TryGetValue(key, out var bom))
            {
                return bom;
            }

            return null;
        }

        public async Task LoadAsync(
            string[] componentBomDataFiles,
            CancellationToken cancellationToken)
        {
            _componentBoms.Clear();
            foreach (var curDataFile in componentBomDataFiles)
            {
                var bom = await _componentBomLoader.LoadAsync(
                    curDataFile,
                    cancellationToken) ?? throw new System.Exception("Failed to load component bom data file: " + curDataFile);
                _componentBoms.Add(bom.Id!, bom);
            }
        }
    }
}
