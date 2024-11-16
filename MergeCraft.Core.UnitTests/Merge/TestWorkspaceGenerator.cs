using MergeCraft.Core.Merge.Interfaces;
using MergeCraft.Core.Merge;

namespace MergeCraft.Core.UnitTests.Merge
{
    public class TestWorkspaceGenerator : IWorkspacePlaceable, IWorkspaceGenerator<WorkspaceComponentItem>
    {
        public string Id => Guid.NewGuid().ToString();
        public bool GenerateCalled { get; private set; }
        public bool InitialiseCalled { get; private set; }

        private string _workspaceComponentItemId;
        private Component _workspaceComponentItemComponent;

        public TestWorkspaceGenerator(
            string workspaceComponentItemId,
            Component workspaceComponentItemComponent)
        {
            _workspaceComponentItemId = workspaceComponentItemId;
            _workspaceComponentItemComponent = workspaceComponentItemComponent;
        }

        public WorkspaceComponentItem? Generate()
        {
            GenerateCalled = true;
            return new WorkspaceComponentItem(
                _workspaceComponentItemId,
                _workspaceComponentItemComponent); ;
        }

        public void Initialise(WorkspaceGeneratorConfiguration configuration)
        {
            InitialiseCalled = true;
        }
    }
}
