using ReactiveUI;

namespace MergeAndCraft.App.ViewModels;

public class WorkspaceGridDrawingOptions : ReactiveObject
{
    private int _width;
    private int _height;
    private int _horizontalSpacing;
    private int _verticalSpacing;
    private int _topMargin;
    private int _leftMargin;
    private int _rightMargin;
    private int _bottomMargin;
    private int _radiusX;
    private int _radiusY;

    public int Width
    {
        get => _width;
        set => this.RaiseAndSetIfChanged(ref _width, value);
    }

    public int Height
    {
        get => _height;
        set => this.RaiseAndSetIfChanged(ref _height, value);
    }

    public int HorizontalSpacing
    {
        get => _horizontalSpacing;
        set => this.RaiseAndSetIfChanged(ref _horizontalSpacing, value);
    }

    public int VerticalSpacing
    {
        get => _verticalSpacing;
        set => this.RaiseAndSetIfChanged(ref _verticalSpacing, value);
    }

    public int TopMargin
    {
        get => _topMargin;
        set => this.RaiseAndSetIfChanged(ref _topMargin, value);
    }

    public int LeftMargin
    {
        get => _leftMargin;
        set => this.RaiseAndSetIfChanged(ref _leftMargin, value);
    }

    public int RightMargin
    {
        get => _rightMargin;
        set => this.RaiseAndSetIfChanged(ref _rightMargin, value);
    }

    public int BottomMargin
    {
        get => _bottomMargin;
        set => this.RaiseAndSetIfChanged(ref _bottomMargin, value);
    }

    public int RadiusX
    {
        get => _radiusX;
        set => this.RaiseAndSetIfChanged(ref _radiusX, value);
    }

    public int RadiusY
    {
        get => _radiusY;
        set => this.RaiseAndSetIfChanged(ref _radiusY, value);
    }


    public WorkspaceGridDrawingOptions(
        int width,
        int height,
        int horizontalSpacing,
        int verticalSpacing,
        int topMargin,
        int leftMargin,
        int rightMargin,
        int bottomMargin,
        int radiusX,
        int radiusY)
    {
        Width = width;
        Height = height;
        HorizontalSpacing = horizontalSpacing;
        VerticalSpacing = verticalSpacing;
        TopMargin = topMargin;
        LeftMargin = leftMargin;
        RightMargin = rightMargin;
        BottomMargin = bottomMargin;
        RadiusX = radiusX;
        RadiusY = radiusY;
    }
}
