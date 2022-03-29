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
		//private SpriteFactory factory;
		//private SpriteFont font;

		public Level1 level1;

		private KeyboardC _keyboardCon;
		private MouseC mouseCon;

		private int boundWidth;
		private int boundHeight;

		private GameObjectManager gameObjectManager;

		//collision
		private CollisionHandlerDict collisionDict;

		private Player2BlockHandler player2Block;
		private Player2EnemyHandler player2Enemy;
		private Player2ProjectileHandler player2Proj;
		private Player2ItemHandler player2item;

		private NPC2BlockHandler enemy2Block;
		private NPC2ProjectileHandler enemy2Proj;

		private Projectile2BlockHandler proj2Blcok;

		private PlayerCollisionDetection playerDetect;
		private NPCCollisionDetection npcDetect;
		private ProjectileCollisionDetection projDetect;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			collisionDict = new CollisionHandlerDict();
		}

		protected override void Initialize()
		{
			//setting  game window
			_graphics.PreferredBackBufferWidth = 800;
			_graphics.PreferredBackBufferHeight = 550;

			//collison items : this should be handled by something... game obj manager?
			player2Block = new Player2BlockHandler();
			player2Enemy = new Player2EnemyHandler();
			player2Proj = new Player2ProjectileHandler();
			player2item = new Player2ItemHandler();

			enemy2Block = new NPC2BlockHandler();
			enemy2Proj = new NPC2ProjectileHandler();

			proj2Blcok = new Projectile2BlockHandler();

			_graphics.ApplyChanges();

			boundWidth = Window.ClientBounds.Width;
			boundHeight = Window.ClientBounds.Height;

			//factory is never used anywhere
			/*factory = */SpriteFactory.GetFactory(Content);

			gameObjectManager = new GameObjectManager();

			level1 = new Level1(gameObjectManager, boundWidth, boundHeight);
			
			level1.loadRoom();

			_keyboardCon = new KeyboardC(level1.GetRoom().GetPlayerObj());
			_keyboardCon.InitializeController();

			mouseCon = new MouseC(level1);
			mouseCon.InitializeController();

			//this should be encapsulated
			collisionDict.Initialize();

			collisionDict.AddHandler("player1", player2Block);
			collisionDict.AddHandler("player1", player2Enemy);
			collisionDict.AddHandler("player1", player2Proj);
			collisionDict.AddHandler("player1", player2item);

			collisionDict.AddHandler("NPC1", enemy2Block);
			collisionDict.AddHandler("NPC1", enemy2Proj);

			collisionDict.AddHandler("Projectile1", proj2Blcok);

			playerDetect = new PlayerCollisionDetection("player1", collisionDict);
			npcDetect = new NPCCollisionDetection("NPC1", collisionDict);
			projDetect = new ProjectileCollisionDetection("Projectile1", collisionDict);

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
			

			//again, a lot of lines for collision
			playerDetect.Detect(level1.GetRoom().GetPlayerObj(), this.level1.GetRoom().GetNPCProjObj(), this.level1.GetRoom().GetNpcObj(), this.level1.GetRoom().GetBlockObj(), this.level1.GetRoom().GetItemObj());

			foreach (NPC1 npc in this.level1.GetRoom().GetNpcObj())
			{
				npcDetect.Detect(npc, this.level1.GetRoom().GetPlayerObj().GetSeqList().ToArray(), this.level1.GetRoom().GetBlockObj());
			}

			foreach (IProjectile p in this.level1.GetRoom().GetPlayerObj().GetSeqList().ToArray())
			{
				projDetect.Detect(p, this.level1.GetRoom().GetBlockObj());
			}
			foreach(IProjectile p in this.level1.GetRoom().GetNPCProjObj()) {
				projDetect.Detect(p, this.level1.GetRoom().GetBlockObj());
			}

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
