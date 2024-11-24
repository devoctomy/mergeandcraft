using Avalonia.Media.Imaging;
using Avalonia.Media;
using Avalonia.Rendering.SceneGraph;
using Avalonia;
using SkiaSharp;
using Svg.Skia;
using System.IO;
using System;
using MergeAndCraft.App.Services;
using MergeAndCraft.App.Controls;
using Avalonia.Media.Immutable;

namespace MergeAndCraft.App.Drawing;

public class WorkspaceGridItemDrawOperation : ICustomDrawOperation
{
    private readonly Bitmap _bitmap;
    private readonly Rect _bounds;

    public WorkspaceGridItemDrawOperation(
        Stream svgStream,
        Rect bounds)
    {
        if (bounds.Width <= 0 || bounds.Height <= 0)
        {
            return;
        }

        _bounds = bounds;


        var skSvg = new SKSvg();
        skSvg.Load(svgStream);
        var svgBounds = skSvg.Picture!.CullRect;
        float scaleX = (float)(_bounds.Width / svgBounds.Width);
        float scaleY = (float)(_bounds.Height / svgBounds.Height);
        int bitmapWidth = (int)Math.Ceiling(_bounds.Width);
        int bitmapHeight = (int)Math.Ceiling(_bounds.Height);

        using var skBitmap = new SKBitmap(bitmapWidth, bitmapHeight, SKColorType.Bgra8888, SKAlphaType.Premul);
        using var canvas = new SKCanvas(skBitmap);
        canvas.Clear(SKColors.Transparent);
        canvas.Scale(scaleX, scaleY);
        canvas.DrawPicture(skSvg.Picture);
        _bitmap = ConvertSKBitmapToAvaloniaBitmap(skBitmap);
    }

    private Bitmap ConvertSKBitmapToAvaloniaBitmap(SKBitmap skBitmap)
    {
        using var image = SKImage.FromBitmap(skBitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);

        using var dataStream = data.AsStream();
        dataStream.Seek(0, SeekOrigin.Begin);

        return new Bitmap(dataStream);
    }

    public Rect Bounds => _bounds;

    public void Dispose()
    {
        _bitmap?.Dispose();
    }

    public bool Equals(ICustomDrawOperation? other)
    {
        if (other is WorkspaceGridItemDrawOperation operation)
        {
            return _bounds.Equals(operation._bounds) &&
                   Equals(_bitmap, operation._bitmap);
        }
        return false;
    }

    public bool HitTest(Point p)
    {
        return Bounds.Contains(p);
    }

    public void Render(ImmediateDrawingContext context)
    {
        var brush = new ImmutableSolidColorBrush(Colors.Red);
        var pen = new ImmutablePen(new ImmutableSolidColorBrush(Colors.White), 1);
        context.DrawRectangle(brush, pen, Bounds);

        context.DrawBitmap(_bitmap, new Rect(0, 0, _bitmap.PixelSize.Width, _bitmap.PixelSize.Height), Bounds);
    }
}
