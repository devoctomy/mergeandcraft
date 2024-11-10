namespace MergeCraft.Core.Merge.Interfaces
{
    public interface IWorkspaceGenerator<T> where T : class, IWorkspacePlaceable
    {
        public void Initialise(WorkspaceGeneratorConfiguration configuration);
        public T? Generate();
    }
}
