using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Player _player;
		public NPC1 _npc;
		public Item _item;
		//set a default sprite?
		//singleton sprite factory 
		//private SpriteFactory _spriteFactory; - should not be needed since its all static
		private KeyboardC _keyboardCon = new KeyboardC();
		private SpriteFactory factory;
		//enemy used varibles start.
		private List<List<int>> movementHolder;
		private List<List<string>> npcHolder;
		private int enemynum;
		private Vector2[] locations;
		//enemy used varibles end.
		private int boundWidth;
		private int boundHeight;

		private string[] blockTypeList;
		Vector2[] blockLocations;
		Block block;

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
			//enemy loading area
			enemynum = NPC1.setEnemyNum(2);
			npcHolder = new List<List<string>>();
			movementHolder = new List<List<int>>();
			locations = new Vector2[enemynum];
			movementHolder = NPC1.loadMap(movementHolder);
			npcHolder = NPC1.loadNpc(npcHolder);
			locations = NPC1.loadLocations(locations);
			//npc loaded over
			_npc = new NPC1(movementHolder, boundWidth, boundHeight, npcHolder, enemynum, locations);
			_player = new Player(boundWidth, boundHeight);
			_item = new Item(boundWidth, boundHeight);
			factory = SpriteFactory.GetFactory();
			_keyboardCon.InitializeController();

			blockLocations = new Vector2[] { new Vector2(200, 200), new Vector2(200, 400), new Vector2(400, 400)};
			blockTypeList = new string[] { "mudBlock", "glassBlock", "ironBlock", "stoneBlock" };
			block = new Block(blockLocations, blockTypeList, 4);

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

			Texture2D mudBlock = Content.Load<Texture2D>("mudBlock");
			Texture2D glassBlock = Content.Load<Texture2D>("glassBlock");
			Texture2D ironBlock = Content.Load<Texture2D>("ironBlock");
			Texture2D stoneBlock = Content.Load<Texture2D>("stoneBlock");


			SpriteFactory.CreateSprite(standFacingRight, 1, 1, 1, "standFacingRight");
			SpriteFactory.CreateSprite(standFacingLeft, 1, 1, 1, "standFacingLeft");
			SpriteFactory.CreateSprite(standFacingUp, 1, 1, 1, "standFacingUp");
			SpriteFactory.CreateSprite(standFacingDown, 1, 1, 1, "standFacingDown");

			//back
			SpriteFactory.CreateSprite(front_move, 1, 2, 2, "front_move");
			SpriteFactory.CreateSprite(side, 1, 2, 2, "side");

			SpriteFactory.CreateSprite(attackRight, 6, 1, 6, "attackRight");
			SpriteFactory.CreateSprite(attackDown, 4, 1, 4, "attackDown");
			SpriteFactory.CreateSprite(attackUp, 4, 1, 4, "attackUp");

			SpriteFactory.CreateSprite(movingRight, 3, 1, 3, "movingRight");
			SpriteFactory.CreateSprite(movingLeft, 3, 1, 3, "movingLeft");
			SpriteFactory.CreateSprite(movingUp, 3, 1, 3, "movingUp");
			SpriteFactory.CreateSprite(movingDown, 3, 1, 3, "movingDown");

			SpriteFactory.CreateSprite(distantAttackRight, 1, 1, 1, "distantAttackRight");

			SpriteFactory.CreateSprite(mudBlock, 1, 1, 1, "mudBlock");
			SpriteFactory.CreateSprite(glassBlock, 1, 1, 1, "glassBlock");
			SpriteFactory.CreateSprite(ironBlock, 1, 1, 1, "ironBlock");
			SpriteFactory.CreateSprite(stoneBlock, 1, 1, 1, "stoneBlock");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here
			_keyboardCon.CompareStates(_player, _item, block, _npc);
			_player.Update(gameTime);
			_npc.Update(gameTime);
			block.Update(gameTime);
			_item.Update(gameTime);
			_item.Update(gameTime);
			block.Update(gameTime);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			_spriteBatch.Begin();
			_player.Draw(_spriteBatch);
			_npc.Draw(_spriteBatch);
			_item.Draw(_spriteBatch);
			block.Draw(_spriteBatch);
			_item.Draw(_spriteBatch);
			block.Draw(_spriteBatch);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
