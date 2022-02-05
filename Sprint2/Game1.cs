using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        //singleton sprite factory here
        //private SpriteFactory _spriteFactory; - should not be needed since its all static

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            SpriteFactory.GetFactory();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //how should we implement this?
            // TODO: use this.Content to load your game content here
            //player class should hold all sprites for it?
            //sprite factory????????
            //_player.sprite = factory creates player sprite

            Texture2D front_still = Content.Load<Texture2D>("front_still");
            //need backwards walk as well
            Texture2D front_move = Content.Load<Texture2D>("front_move");
            Texture2D side = Content.Load<Texture2D>("side");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _player.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}
