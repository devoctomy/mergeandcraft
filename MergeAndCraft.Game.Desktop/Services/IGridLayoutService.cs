using MergeAndCraft.App.ViewModels;
using Microsoft.Xna.Framework;

namespace MergeAndCraft.Game.Desktop.Services;

public interface IGridLayoutService
{
    Rectangle[,] Layout(
        WorkspaceGridDrawingOptions drawingOptions,
        Rectangle bounds);
}
