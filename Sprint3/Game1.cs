using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint3
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Level1 level1;
		//set a default sprite?
		//singleton sprite factory 
		//private SpriteFactory _spriteFactory; - should not be needed since its all static
		//private KeyboardC _keyboardCon = new KeyboardC();
		private SpriteFactory factory;
		private int boundWidth;
		private int boundHeight;
		private int x;
		private int y;
		private SpriteFont font;
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			_graphics.PreferredBackBufferWidth = 800;
			_graphics.PreferredBackBufferHeight = 550;
			_graphics.ApplyChanges();
			boundWidth = Window.ClientBounds.Width;
			boundHeight = Window.ClientBounds.Height;
			factory = SpriteFactory.GetFactory(Content);
			level1 = new Level1(boundWidth, boundHeight);
			//_keyboardCon.InitializeController();
			level1.loadRoom();
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			//how should we implement this?
			//player class should hold all sprites for it?
			//sprite factory????????
			//_player.sprite = factory creates player sprite
			font = Content.Load<SpriteFont>("coortest");


		}

		protected override void Update(GameTime gameTime)
		{
			//_keyboardCon.CompareStates(_player, _item, block, _npc);
			if (Keyboard.GetState().IsKeyDown(Keys.NumPad4))
			{
				level1.switchPre();
				level1.loadRoom();
            }
			else if (Keyboard.GetState().IsKeyDown(Keys.NumPad6))
            {
				level1.switchNext();
				level1.loadRoom();
			}
			level1.Update((gameTime));
			x = Mouse.GetState().X;
			y = Mouse.GetState().Y;
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
			level1.Draw(_spriteBatch);
			_spriteBatch.DrawString(font, "[" + x.ToString() + ", " + y.ToString() + "]", new Vector2(225, 225), Color.Black);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
