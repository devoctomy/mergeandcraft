using MergeCraft.Core.Data.Interfaces;
using MergeCraft.Core.Exceptions;
using MergeCraft.Core.IO.Interfaces;
using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGenerator : IWorkspacePlaceable, IWorkspaceGenerator<WorkspaceComponentItem>
    {
        private readonly IComponentDirectory<Component> _componentDirectory;
        private readonly IProbabilityDistributionService _probabilityDistributionService;
        private WorkspaceGeneratorConfiguration? _configuration;

        private int _remainingWeight;
        public string Id { get; }

        public WorkspaceGenerator(
            IComponentDirectory<Component> componentDirectory,
            IProbabilityDistributionService probabilityDistributionService)
        {
            Id = Guid.NewGuid().ToString();
            _componentDirectory = componentDirectory;
            _probabilityDistributionService = probabilityDistributionService;
        }

        public void Initialise(WorkspaceGeneratorConfiguration configuration)
        {
            _configuration = configuration;
            _remainingWeight = _configuration.TotalWeight;
        }

        public WorkspaceComponentItem? Generate()
        {
            if(_configuration == null)
            {
                throw new InvalidOperationException("Generator not initialised.");
            }

            if (_configuration.RemainingWeight > 0)
            {
                var picked = _probabilityDistributionService.Next(_configuration);
                var bom = _componentDirectory.GetBom(picked.Id!);
                if (bom == null)
                {
                    throw new ComponentBomNotFoundException(picked.Id!);
                }

                var component = bom.Get(picked.Id!)!;
                var item = new WorkspaceComponentItem(
                    Guid.NewGuid().ToString(),
                    component);
                return item;
            }

            return null;
        }
    }
}
