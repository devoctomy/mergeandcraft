using MergeCraft.Core.IO.Interfaces;
using MergeCraft.Core.Merge.Interfaces;
using System;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGenerator : IWorkspacePlaceable, IWorkspaceGenerator<WorkspaceGeneratorConfiguration, WorkspaceComponentItem>
    {
        private readonly IComponentDirectory<Component> _componentDirectory;
        private IWorkspaceGeneratorConfiguration<IWorkspaceGeneratorConfigurationItem>? _configuration;

        public string Id { get; }

        public WorkspaceGenerator(IComponentDirectory<Component> componentDirectory)
        {
            Id = Guid.NewGuid().ToString();
            _componentDirectory = componentDirectory;
        }

        public void Initialise(IWorkspaceGeneratorConfiguration<IWorkspaceGeneratorConfigurationItem> configuration)
        {
            _configuration = configuration;
        }

        public WorkspaceComponentItem? Generate()
        {
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
