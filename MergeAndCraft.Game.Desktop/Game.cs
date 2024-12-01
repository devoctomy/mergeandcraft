using MergeAndCraft.App.ViewModels;
using MergeAndCraft.Game.Desktop.Drawing;
using MergeAndCraft.Game.Desktop.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MergeAndCraft.Game.Desktop;

public class Game : Microsoft.Xna.Framework.Game
{
    private GridDrawingService? _gridDrawingService;
    private GraphicsDeviceManager? _graphics;
    private SpriteBatch? _spriteBatch;
    private IGridLayoutService _gridLayoutService;
    private Rectangle[,] _grid;

    public Game(IServiceProvider serviceProvider)
    {
        _graphics = new GraphicsDeviceManager(this);
        _gridLayoutService = (IGridLayoutService)serviceProvider.GetService(typeof(IGridLayoutService))!;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _gridDrawingService = new GridDrawingService(_graphics!.GraphicsDevice);
        _grid = _gridLayoutService.Layout(new WorkspaceGridDrawingOptions
        {
            Width = 5,
            Height = 4,
            LeftMargin = 20,
            TopMargin = 20,
            RightMargin = 20,
            BottomMargin = 20,
            HorizontalSpacing = 4,
            VerticalSpacing = 4
        }, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch!.Begin();

        Rectangle bounds = new(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        _gridDrawingService!.DrawGrid(_spriteBatch, bounds, _grid,  Color.Black);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
