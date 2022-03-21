using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint3.Collision;

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
		private KeyboardC _keyboardCon = new KeyboardC();
		private SpriteFactory factory;
		private int boundWidth;
		private int boundHeight;
		//private int x;
		//private int y;
		private SpriteFont font;

		private CollisionHandlerDict dict;

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
			dict = new CollisionHandlerDict();
		}

		protected override void Initialize()
		{
			_graphics.PreferredBackBufferWidth = 800;
			_graphics.PreferredBackBufferHeight = 550;

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
			factory = SpriteFactory.GetFactory(Content);
			level1 = new Level1(boundWidth, boundHeight);
			_keyboardCon.InitializeController();
			level1.loadRoom();

			dict.Initialize();


			dict.AddHandler("player1", player2Block);
			dict.AddHandler("player1", player2Enemy);
			dict.AddHandler("player1", player2Proj);
			dict.AddHandler("player1", player2item);

			dict.AddHandler("NPC1", enemy2Block);
			dict.AddHandler("NPC1", enemy2Proj);

			dict.AddHandler("Projectile1", proj2Blcok);


			playerDetect = new PlayerCollisionDetection("player1", dict);

			npcDetect = new NPCCollisionDetection("NPC1", dict);

			projDetect = new ProjectileCollisionDetection("Projectile1", dict);


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
			_keyboardCon.CompareStates(this.level1.GetRoom().GetPlayerObj(), this.level1);
			
			level1.Update((gameTime));
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
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
			level1.Draw(_spriteBatch);
			//_spriteBatch.DrawString(font, "[" + x.ToString() + ", " + y.ToString() + "]", new Vector2(225, 225), Color.Black);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
