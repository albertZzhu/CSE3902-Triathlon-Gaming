using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace Project2
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ISprite sprite;
        private SpriteFont font;
        public Texture2D texture;
        public int row;
        public int columns;
        public Viewport viewport;
        public int height;
        public int width;
        private KeyboardController keyboardController;
        private MouseController mouseController;
        private spriteText spritetext;

        private Vector2 position;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            keyboardController = new KeyboardController(this);
            mouseController = new MouseController(this);
            row = 1;
            columns = 6;
           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            viewport = _graphics.GraphicsDevice.Viewport;

            height = _graphics.GraphicsDevice.Viewport.Height;
            width = _graphics.GraphicsDevice.Viewport.Width;

            position.X = width / 2;
            position.Y = height / 2;

           font = Content.Load<SpriteFont>("Credits");

            texture = Content.Load<Texture2D>("1");

            sprite = new NmovNaniSprite(texture,row,columns,height,width);
            
            spritetext = new spriteText(font);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            keyboardController.update();
            mouseController.update();    

            sprite.update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            sprite.draw(_spriteBatch, position);

            spritetext.draw(_spriteBatch, position);

            base.Draw(gameTime);
        }

         internal void setSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        

    }

    
}
