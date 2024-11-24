using ReactiveUI;

namespace MergeAndCraft.App.ViewModels
{
    public class MergeWorkspaceGridViewModel : ReactiveObject
    {
        private WorkspaceGridDrawingOptions _drawingOptions;

        public WorkspaceGridDrawingOptions WorkspaceGridDrawingOptions
        {
            get => _drawingOptions;
            set => this.RaiseAndSetIfChanged(ref _drawingOptions, value);
        }

        public MergeWorkspaceGridViewModel(
            WorkspaceGridDrawingOptions drawingOptions)
        {
            _drawingOptions = drawingOptions;
        }
    }
}
