using MergeCraft.Core.Merge;
using MergeCraft.Core.Merge.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MergeCraft.Core.IO
{
    public class ScrapLoader : IScrapLoader
    {
        private const string IdPrefix = "SCRAP";
        private string _dataPath;

        public ScrapLoader(string dataPath)
        {
            _dataPath = dataPath;
        }

        public async Task<IEnumerable<IScrap>?> LoadAsync(CancellationToken cancellationToken)
        {
            var jsonRaw = await System.IO.File.ReadAllTextAsync(_dataPath, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var scrap = JsonSerializer.Deserialize<List<Scrap>>(jsonRaw, options);
            scrap?.ForEach(x => x.Id = $"{IdPrefix}.{x.Id}");

            return scrap;
        }
    }
}
