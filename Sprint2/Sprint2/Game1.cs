using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Player _player;
        //set a default sprite?
        //singleton sprite factory 
        //private SpriteFactory _spriteFactory; - should not be needed since its all static
        private KeyboardC _keyboardCon = new KeyboardC();
        private SpriteFactory factory;

        private int boundWidth;
        private int boundHeight;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            boundWidth = Window.ClientBounds.Width;
            boundHeight = Window.ClientBounds.Height;

            _player = new Player(boundWidth, boundHeight);
            factory = SpriteFactory.GetFactory();
            _keyboardCon.InitializeController();
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

            Texture2D attackRight = Content.Load<Texture2D>("KiritoAttactRight");
            Texture2D attackDown = Content.Load<Texture2D>("Sword_Facing_down");
            Texture2D attackUp = Content.Load<Texture2D>("Sword_Facing_up");

            Texture2D movingRight = Content.Load<Texture2D>("KiritoMovingRight");
            Texture2D movingLeft = Content.Load<Texture2D>("KiritoMovingLeft");
            Texture2D movingUp = Content.Load<Texture2D>("KiritoMovingUp");
            Texture2D movingDown = Content.Load<Texture2D>("KiritoMovingDown");

            Texture2D distantAttackRight = Content.Load<Texture2D>("DistantAttackRight");

            Texture2D standFacingRight = Content.Load<Texture2D>("StandFacingRight");
            Texture2D standFacingLeft = Content.Load<Texture2D>("standFacingLeft");
            Texture2D standFacingUp = Content.Load<Texture2D>("standFacingUp");
            Texture2D standFacingDown = Content.Load<Texture2D>("standFacingDown");


            SpriteFactory.CreateSprite(standFacingRight, 1, 1, 1, "standFacingRight");
            SpriteFactory.CreateSprite(standFacingLeft, 1, 1, 1, "standFacingLeft");
            SpriteFactory.CreateSprite(standFacingUp, 1, 1, 1, "standFacingUp");
            SpriteFactory.CreateSprite(standFacingDown, 1, 1, 1, "standFacingDown");

            //back
            SpriteFactory.CreateSprite(front_move, 1, 2, 2, "front_move");
            SpriteFactory.CreateSprite(side, 1 ,2, 2, "side");

            SpriteFactory.CreateSprite(attackRight, 6, 1, 6, "attackRight");
            SpriteFactory.CreateSprite(attackDown, 4, 1, 4, "attackDown");
            SpriteFactory.CreateSprite(attackUp, 4, 1, 4, "attackUp");

            SpriteFactory.CreateSprite(movingRight, 3, 1, 3, "movingRight");
            SpriteFactory.CreateSprite(movingLeft, 3, 1, 3, "movingLeft");
            SpriteFactory.CreateSprite(movingUp, 3, 1, 3, "movingUp");
            SpriteFactory.CreateSprite(movingDown, 3, 1, 3, "movingDown");

            SpriteFactory.CreateSprite(distantAttackRight, 1, 1, 1, "distantAttackRight");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _keyboardCon.CompareStates(_player, _player.GetSprite(), _player.GetSprite(), _player.GetSprite());
            _player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
