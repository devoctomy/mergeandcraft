using MergeCraft.Core.IO.Interfaces;
using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGenerator : IWorkspacePlaceable
    {
        private readonly IComponentDirectory<Component> _componentDirectory;
        private WorkspaceGeneratorConfiguration? _configuration;

        private int _remainingWeight;
        public string Id { get; }

        public WorkspaceGenerator(IComponentDirectory<Component> componentDirectory)
        {
            Id = Guid.NewGuid().ToString();
            _componentDirectory = componentDirectory;
        }

        public void Initialise(WorkspaceGeneratorConfiguration configuration)
        {
            _configuration = configuration;
            _remainingWeight = _configuration.TotalWeight;
        }

        public WorkspaceComponentItem? Generate()
        {
            // need probabilty distribution classes

            /*if(Count > 0)
            {
                var bom = _componentDirectory.GetBom(Id);
                if (bom == null)
                {
                    throw new ComponentBomNotFoundException(Id);
                }

                var component = bom.Get(Id)!;
                var item = new WorkspaceComponentItem(
                    Id,
                    component);
                Count--;
                return item;
            }*/

            return null;
        }
    }
}
