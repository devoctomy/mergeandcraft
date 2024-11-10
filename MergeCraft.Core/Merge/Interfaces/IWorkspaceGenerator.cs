namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceGenerator<ConfigT, T>
        where ConfigT : IWorkspaceGeneratorConfiguration<IWorkspaceGeneratorConfigurationItem>
        where T : class, IWorkspacePlaceable
    {
        public void Initialise(IWorkspaceGeneratorConfiguration<IWorkspaceGeneratorConfigurationItem> configuration);
        public T? Generate();
    }
}
