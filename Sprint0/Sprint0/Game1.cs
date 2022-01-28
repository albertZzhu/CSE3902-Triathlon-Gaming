using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Sprites;

namespace Sprint0
{ //in the main game class, use the interfaces to animate/update the current sprite.
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //controllers, input devices
        private KeyboardC _keyboardCon = new KeyboardC();
        private MouseC _mouseCon = new MouseC();
        //sprites, graphics
        //non-moving, non-animated sprite
        private NMNASprite _NMNA = new NMNASprite();
        //moving, non-animated sprite
        private MNASprite _MNA = new MNASprite();
        //non-moving, animated sprite
        private NMASprite _NMA;
        //moving, animated sprite
        private MASprite _MA;
        private TextSprite _credits;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {   //initialize states of kb and mouse into respective controllers
            //issues with interface between these two methods... do I overload the method?
            _mouseCon.InitializeController(Window.ClientBounds.Width, Window.ClientBounds.Height);
            _keyboardCon.InitializeController();
            base.Initialize();
        }

        protected override void LoadContent()
        {   //I think game-pertanent data should go in the game class.
            //ie, sprites for this game go here and general rules for sprites go in the classes
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //should i put these into the sprite classes?
            //do i need to unload at all?
            Texture2D NonAnimated = Content.Load<Texture2D>("snow-cat-1");
            _NMNA.SetSprite(NonAnimated);
            _MNA.SetSprite(NonAnimated);
            Texture2D Animated = Content.Load<Texture2D>("snow-cat");
            //i think this should be more consistent w/ _nmna and _mna
            _NMA = new NMASprite(Animated, 5, 4, 5, 17);
            _MA = new MASprite(Animated, 5, 4, 5, 17);

            //text goes here
            SpriteFont Text = Content.Load<SpriteFont>("Credits");
            _credits = new TextSprite(Text);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _keyboardCon.CompareStates(_NMNA, _MNA, _NMA, _MA);
            _mouseCon.CompareStates(_NMNA, _MNA, _NMA, _MA);

            _NMA.Update();
            _MA.Update();
            _MNA.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MidnightBlue);

            _spriteBatch.Begin();
            Vector2 pos = new Vector2(400, 200);
            _NMNA.Draw(_spriteBatch, pos);
            _MNA.Draw(_spriteBatch, pos);
            _NMA.Draw(_spriteBatch, pos);
            _MA.Draw(_spriteBatch, pos);
            _credits.Draw(_spriteBatch, new Vector2(0, 400), " Credits\n Programming and Sprites by Leigh Lynch");

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
