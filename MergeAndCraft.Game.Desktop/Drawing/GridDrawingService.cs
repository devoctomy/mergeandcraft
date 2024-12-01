using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MergeAndCraft.Game.Desktop.Drawing;

public class GridDrawingService
{
    private GraphicsDevice _graphicsDevice;
    private Texture2D _circleTexture;
    private Texture2D _lineTexture;

    public GridDrawingService(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;

        // Create a circle texture for rounded corners
        _circleTexture = CreateCircleTexture(20); // Radius for rounded corners

        // Create a 1x1 white texture for lines and fills
        _lineTexture = new Texture2D(graphicsDevice, 1, 1);
        _lineTexture.SetData(new[] { Color.White });
    }

    private Texture2D CreateCircleTexture(int radius)
    {
        int diameter = radius * 2;
        Texture2D texture = new Texture2D(_graphicsDevice, diameter, diameter);
        Color[] colorData = new Color[diameter * diameter];

        float centerX = radius;
        float centerY = radius;

        for (int y = 0; y < diameter; y++)
        {
            for (int x = 0; x < diameter; x++)
            {
                float distance = Vector2.Distance(new Vector2(x, y), new Vector2(centerX, centerY));
                colorData[x + y * diameter] = distance <= radius ? Color.White : Color.Transparent;
            }
        }

        texture.SetData(colorData);
        return texture;
    }

    public void DrawGrid(SpriteBatch spriteBatch, Rectangle bounds, Rectangle[,] grid, Color fillColor)
    {
        // Calculate drawable area (excluding outer margins)
        var hGridSpaces = grid.GetLength(0);
        var vGridSpaces = grid.GetLength(1);

        // Draw each grid space
        for (int row = 0; row < vGridSpaces; row++)
        {
            for (int col = 0; col < hGridSpaces; col++)
            {
                DrawObroundedRectangle(spriteBatch, grid[col, row], fillColor);
            }
        }
    }

    private void DrawObroundedRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color)
    {
        int radius = _circleTexture.Width / 2;

        // Draw corners using the circle texture
        Vector2 topLeft = new Vector2(rectangle.Left, rectangle.Top);
        Vector2 topRight = new Vector2(rectangle.Right - radius * 2, rectangle.Top);
        Vector2 bottomLeft = new Vector2(rectangle.Left, rectangle.Bottom - radius * 2);
        Vector2 bottomRight = new Vector2(rectangle.Right - radius * 2, rectangle.Bottom - radius * 2);

        spriteBatch.Draw(_circleTexture, topLeft, color);        // Top-left corner
        spriteBatch.Draw(_circleTexture, topRight, color);       // Top-right corner
        spriteBatch.Draw(_circleTexture, bottomLeft, color);     // Bottom-left corner
        spriteBatch.Draw(_circleTexture, bottomRight, color);    // Bottom-right corner

        // Draw top and bottom edges
        int horizontalWidth = rectangle.Width - radius * 2;
        spriteBatch.Draw(_lineTexture, new Rectangle(rectangle.Left + radius, rectangle.Top, horizontalWidth, radius), color); // Top edge
        spriteBatch.Draw(_lineTexture, new Rectangle(rectangle.Left + radius, rectangle.Bottom - radius, horizontalWidth, radius), color); // Bottom edge

        // Draw left and right edges
        int verticalHeight = rectangle.Height - radius * 2;
        spriteBatch.Draw(_lineTexture, new Rectangle(rectangle.Left, rectangle.Top + radius, radius, verticalHeight), color); // Left edge
        spriteBatch.Draw(_lineTexture, new Rectangle(rectangle.Right - radius, rectangle.Top + radius, radius, verticalHeight), color); // Right edge

        // Fill the center
        spriteBatch.Draw(_lineTexture, new Rectangle(rectangle.Left + radius, rectangle.Top + radius, horizontalWidth, verticalHeight), color);
    }
}
