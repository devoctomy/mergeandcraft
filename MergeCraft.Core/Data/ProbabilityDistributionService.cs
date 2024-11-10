using MergeCraft.Core.Data.Interfaces;
using MergeCraft.Core.Merge;
using System;
using System.Linq;

namespace MergeCraft.Core.Data
{
    public class ProbabilityDistributionService : IProbabilityDistributionService
    {
        private readonly Random _random;

        public ProbabilityDistributionService()
        {
            _random = new Random();
        }

        public WorkspaceGeneratorConfigurationItem Next(WorkspaceGeneratorConfiguration configuration)
        {
            var items = configuration.Items;
            items = items.Where(x => x.Weight < configuration.RemainingWeight).ToList();

            var runningTotal = 0;
            var chances = items.Select(x =>
            new
            {
                Key = x,
                Probability = runningTotal += x.Probability
            }).ToList();
            var select = _random.Next(0, runningTotal + 1);
            var picked = chances.First(x => x.Probability >= select);

            var item = picked.Key;
            configuration.RemainingWeight -= item.Weight;
            return item;
        }
    }
}
