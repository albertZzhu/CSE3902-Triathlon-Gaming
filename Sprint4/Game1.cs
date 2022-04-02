using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint4.Collision;

namespace Sprint4
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		//not used
		//private SpriteFont font;

		public Level1 level1;

		private KeyboardC _keyboardCon;
		private MouseC mouseCon;

		private int boundWidth;
		private int boundHeight;

		private GameObjectManager gameObjectManager;

		private CollisionManager collisionManager;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;

			collisionManager = new CollisionManager();
		}

		protected override void Initialize()
		{
			//setting  game window
			_graphics.PreferredBackBufferWidth = 800;
			_graphics.PreferredBackBufferHeight = 550;

			_graphics.ApplyChanges();

			boundWidth = Window.ClientBounds.Width;
			boundHeight = Window.ClientBounds.Height;

			SpriteFactory.GetFactory(Content);
			gameObjectManager = new GameObjectManager();

			collisionManager.Initialize("player1", "NPC1", "projectil1");

			level1 = new Level1(gameObjectManager, boundWidth, boundHeight);
			level1.loadRoom();

			_keyboardCon = new KeyboardC(level1.GetRoom().GetPlayerObj());
			_keyboardCon.InitializeController();

			mouseCon = new MouseC(level1);
			mouseCon.InitializeController();

			//this should be encapsulated
			

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			//nothing needs to be done here...?

			//font is not used
			//font = Content.Load<SpriteFont>("coortest");


		}

		protected override void Update(GameTime gameTime)
		{
			_keyboardCon.CompareStates(level1.GetRoom().GetPlayerObj());
			mouseCon.CompareStates(level1.GetRoom().GetPlayerObj());
			
			gameObjectManager.Update((gameTime));

			collisionManager.Update(level1);

			//again, a lot of lines for collision
			

			//x = Mouse.GetState().X;
			//y = Mouse.GetState().Y;
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			//change this to black...?
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin();
			gameObjectManager.Draw(_spriteBatch);
			//_spriteBatch.DrawString(font, "[" + x.ToString() + ", " + y.ToString() + "]", new Vector2(225, 225), Color.Black);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
