using MergeCraft.Core.Data;
using MergeCraft.Core.IO;
using MergeCraft.Core.Merge;

namespace MergeAndCraft.IntTests.StepDefinitions
{
    [Binding]
    public sealed class MergeWorkspaceStepDefinitions
    {
        private BindingContext _bindingContext;

        public MergeWorkspaceStepDefinitions(BindingContext bindingContext)
        {
            _bindingContext = bindingContext;
        }

        [Given("MergeWorkspace is initialised with a width of (.*) and a height of (.*)")]
        public void GivenMergeWorkspaceIsInitialisedWithAWidthOfAndAHeightOf(
            int width,
            int height)
        {
            var mergeWorkspace = new MergeWorkspace(new WorkspaceComponentMergerService());
            mergeWorkspace.Initialise(width, height);
            _bindingContext.MergeWorkspace = mergeWorkspace;
        }

        [Given("ComponentDirectory loaded with (.*)")]
        public async Task GivenComponentDirectoryLoadedWith(string path)
        {
            var paths = path.Split(',');
            var componentDirectory = new ComponentDirectory(new ComponentBomLoader());
            await componentDirectory.LoadAsync(paths, CancellationToken.None);
            _bindingContext.ComponentDirectory = componentDirectory;
        }


        [Given("(.*) WorkspaceGenerator configuration loaded from (.*)")]
        public async Task GivenJunkWorkspaceGeneratorConfigurationLoadedFrom(
            string name,
            string path)
        {
            var loader = new WorkspaceGeneratorConfigurationLoader();
            var config = await loader.LoadAsync(path, CancellationToken.None);
            var generator = new WorkspaceGeneratorItem(
                _bindingContext.ComponentDirectory!,
                new ProbabilityDistributionService());
        }

    }
}
