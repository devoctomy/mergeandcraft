﻿using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using MergeCraft.Core.Merge;

namespace MergeCraft.Core.IO
{
    public class ComponentLoader : IComponentLoader<Component>
    {
        private const string IdPrefix = "component";
        private string _dataPath;

        public ComponentLoader(string dataPath)
        {
            _dataPath = dataPath;
        }

        public async Task<IEnumerable<Component>?> LoadAsync(CancellationToken cancellationToken)
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
