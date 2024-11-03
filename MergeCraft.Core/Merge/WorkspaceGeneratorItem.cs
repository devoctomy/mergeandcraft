using MergeCraft.Core.Merge.Interfaces;

namespace MergeCraft.Core.Merge
{
    public class WorkspaceGeneratorItem : IWorkspacePlaceable, IWorkspaceGenerator
    {
        public string Id { get; }

        public WorkspaceGeneratorItem(string id)
        {
            Id = id;
        }
    }
}
