using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint4.Collision;
using Sprint4.Game_Object_Classes;

namespace Sprint4
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Camera camera;
		private KeyboardC _keyboardCon;

		//Window size
		private int boundWidth;
		private int boundHeight;

		//Object Managers
		private GameObjectManager gameObjectManager;
		private GameButtonManager gameButtonManager;
		private CollisionManager collisionManager;

		//why is this public?
		public bool isPaused;

		public Level1 level1;
		private Win WinState;
		private lose LoseState;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			isPaused = false;

			collisionManager = new CollisionManager();
			gameButtonManager = new GameButtonManager(this);
		}

		protected override void Initialize()
		{
			//setting  game window
			_graphics.PreferredBackBufferWidth = 800;
			_graphics.PreferredBackBufferHeight = 800;

			_graphics.ApplyChanges();

			boundWidth = Window.ClientBounds.Width;
			boundHeight = Window.ClientBounds.Height;

			SpriteFactory.GetFactory(Content);
			gameObjectManager = new GameObjectManager();

			camera = new Camera(800, 550, Content);
			level1 = new Level1(gameObjectManager, boundWidth, boundHeight);
			WinState = new Win("win");
			LoseState = new lose("lose");
			level1.InitializeRoom();

			gameObjectManager.PopulateInventory(Inventory.GetInventory(Content, level1));


			collisionManager.Initialize("player1", "NPC1", "projectil1", level1);
			gameButtonManager.Initialize();

			_keyboardCon = new KeyboardC(level1.GetRoom().GetPlayerObj());
			_keyboardCon.InitializeController();

			UniParam.Initialize(gameObjectManager, level1, this);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			//nothing needs to be done here...?
			SoundManager.Instance.LoadAllSounds(Content);
			//font is not used
			//font = Content.Load<SpriteFont>("coortest");


		}

		protected override void Update(GameTime gameTime)
		{
			gameButtonManager.Update(gameTime);
			//level1.loadRoom();
			if (!isPaused)
			{
				if (!Win.GetWinCondition() && !lose.GetLoseCondition()) {
					if (level1.CheckLock())
					{
						if (level1.CheckLock())
						{
							_keyboardCon.CompareStates(level1.GetRoom().GetPlayerObj());
							gameObjectManager.Update(gameTime);

							collisionManager.Update(level1);
						}
					}
					if (!level1.CheckLock())
					{
						camera.Update(gameTime, level1.currentroom(), level1.futureroom(), level1.GetDoorDoc());
						if (camera.done())
						{
							camera.reset();
							level1.loadRoom();
							level1.setCheckLock(false);
						}
					}
				} else
                {	
					if(Win.GetWinCondition())
                    {
						WinState.Update(gameTime);
					} else LoseState.Update(gameTime);

					if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    {
						Exit();
                    } else if(Keyboard.GetState().IsKeyDown(Keys.R))
                    {	
						
							if(Win.GetWinCondition())
							{
								level1.resetRoom();
							}
						
						lose.SetLoseCondition(false);
						Win.SetWinCondition(false);
						SoundManager.Instance.ThemeMusic();
					}
                }
			}
			
			//x = Mouse.GetState().X;
			//y = Mouse.GetState().Y;
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
			_spriteBatch.Begin();
			if (!Win.GetWinCondition() && !lose.GetLoseCondition()) {
				if (level1.CheckLock()) {
					gameObjectManager.Draw(_spriteBatch);
					//_spriteBatch.DrawString(font, "[" + x.ToString() + ", " + y.ToString() + "]", new Vector2(225, 225), Color.Black);
				} else {
					camera.Draw(_spriteBatch);
				}
			} else
            {
				gameObjectManager.Draw(_spriteBatch);
				if(Win.GetWinCondition())
                {
					WinState.Draw(_spriteBatch);
				} else LoseState.Draw(_spriteBatch);
			}
			gameButtonManager.Draw(gameTime, _spriteBatch);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
