using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint5.Collision;
using Sprint5.Game_Object_Classes;

namespace Sprint5
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

		public Level level1;
		private Win WinState;
		private Lose LoseState;
		//remove later
		//private int x, y;

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
			//_graphics.IsFullScreen = true;
			_graphics.ApplyChanges();

			boundWidth = Window.ClientBounds.Width;
			boundHeight = Window.ClientBounds.Height;

			SpriteFactory.GetFactory(Content);
			gameObjectManager = new GameObjectManager();

			camera = new Camera(800, 550, Content);
			level1 = new Level1(gameObjectManager, boundWidth, boundHeight);
			WinState = new Win("win");
			LoseState = new Lose("lose");
			level1.InitializeRoom();

			gameObjectManager.PopulateInventory(Inventory.GetInventory(Content, level1));


			collisionManager.Initialize("player1", "NPC1", "projectil1", level1);
			gameButtonManager.Initialize();

			_keyboardCon = new KeyboardC(level1.GetRoom().GetPlayerObj(), level1);
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
			if (!isPaused)
			{
				if (!Win.GetWinCondition() && !Lose.GetLoseCondition()) {
					if (level1.CheckLock())
					{
							_keyboardCon.CompareStates(level1.GetRoom().GetPlayerObj());
							gameObjectManager.Update(gameTime);
							collisionManager.Update(level1);
					}
					if (!level1.CheckLock())
					{
						if (level1.futureroom() != "level2" && level1.futureroom() != "level1") {
							camera.Update(gameTime, level1.currentroom(), level1.futureroom(), level1.GetDoorDoc());
							if (camera.done())
							{
								camera.reset();
								level1.loadRoom();
								level1.setCheckLock(false);
							}
						} else
                        {
							if (level1.futureroom() == "level2")
                            {
								this.level1 = this.renewToLevel2(this._graphics, this.gameObjectManager, this.boundWidth, this.boundHeight);
							} else if (level1.futureroom() == "level1")
                            {
								this.level1 = renewToLevel1(this._graphics, this.gameObjectManager, this.boundWidth, this.boundHeight);
							}
						}
					}
				} else
                {	
					if(Win.GetWinCondition())
                    {
						WinState.Update(gameTime);
					} else LoseState.Update(gameTime);
					_keyboardCon.CompareStates(level1.GetRoom().GetPlayerObj());
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
			if (!Win.GetWinCondition() && !Lose.GetLoseCondition()) {
				if (level1.CheckLock()) {
					gameObjectManager.Draw(_spriteBatch);
					//_spriteBatch.DrawString(font, "[" + x.ToString() + ", " + y.ToString() + "]", new Vector2(225, 225), Color.Black);
				} else {
					if (level1.futureroom() != "level2" && level1.futureroom() != "level1") {
						camera.Draw(_spriteBatch);
					}
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

		private Level renewToLevel2(GraphicsDeviceManager _graphics, GameObjectManager gameObjectManager, int boundWidth, int boundHeight)
        {
			_graphics.PreferredBackBufferWidth = 1600;
			_graphics.PreferredBackBufferHeight = 1100;
			//this._graphics.IsFullScreen = true;
			_graphics.ApplyChanges();
			boundWidth = Window.ClientBounds.Width;
			boundHeight = Window.ClientBounds.Height;
			Level level = new Level2(gameObjectManager, boundWidth, boundHeight);
			level.InitializeRoom();
			level.loadRoom();
			return level;
		}

		private Level renewToLevel1(GraphicsDeviceManager _graphics, GameObjectManager gameObjectManager, int boundWidth, int boundHeight)
		{
			_graphics.PreferredBackBufferWidth = 800;
			_graphics.PreferredBackBufferHeight = 800;
			this._graphics.IsFullScreen = false;
			_graphics.ApplyChanges();
			boundWidth = Window.ClientBounds.Width;
			boundHeight = Window.ClientBounds.Height;
			Level level = new Level1(gameObjectManager, boundWidth, boundHeight);
			level.InitializeRoom();
			level.setRoom(5);
			return level;
		}
	}
}
