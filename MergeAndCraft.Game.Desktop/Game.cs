using MergeAndCraft.Game.Desktop.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MergeAndCraft.Game.Desktop;

public class Game : Microsoft.Xna.Framework.Game
{
    private GridDrawingService _gridDrawingService;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game()
    {
        _graphics = new GraphicsDeviceManager(this);        

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _gridDrawingService = new GridDrawingService(_graphics.GraphicsDevice);

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

        _spriteBatch.Begin();

        Rectangle bounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        int margin = 20;
        int hGridSpaces = 5;
        int vGridSpaces = 4;

        _gridDrawingService.DrawGrid(_spriteBatch, bounds, margin, hGridSpaces, vGridSpaces, 4,  Color.Black);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
