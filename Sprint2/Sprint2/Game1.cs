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
			_npc = new NPC1(boundWidth, boundHeight);
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

			Texture2D npcAttackRight = Content.Load<Texture2D>("kirito_right_attack");
			Texture2D npcAttackFront = Content.Load<Texture2D>("kirito_front_attack");
			Texture2D npcAttackBack = Content.Load<Texture2D>("kirito_back_attack");

			SpriteFactory.CreateSprite(npcAttackRight, 6, 1, 6, "kirito_right_attack");
			SpriteFactory.CreateSprite(npcAttackFront, 4, 1, 4, "kirito_front_attack");
			SpriteFactory.CreateSprite(npcAttackBack, 4, 1, 4, "kirito_back_attack");

			Texture2D npcMoveRight = Content.Load<Texture2D>("kirito_move_right");
			Texture2D npcMoveLeft = Content.Load<Texture2D>("kirito_move_left");
			Texture2D npcMoveBack = Content.Load<Texture2D>("kirito_back_move");
			Texture2D npcMoveFront = Content.Load<Texture2D>("kirito_move_front");

			SpriteFactory.CreateSprite(npcMoveRight, 3, 1, 3, "kirito_move_right");
			SpriteFactory.CreateSprite(npcMoveLeft, 3, 1, 3, "kirito_move_left");
			SpriteFactory.CreateSprite(npcMoveBack, 3, 1, 3, "kirito_back_move");
			SpriteFactory.CreateSprite(npcMoveFront, 3, 1, 3, "kirito_move_front");

			//can rotate this in draw
			Texture2D projectileRight = Content.Load<Texture2D>("right_projectile");
			Texture2D projectileUp = Content.Load<Texture2D>("up_projectile");
			Texture2D projectileLeft = Content.Load<Texture2D>("left_projectile");
			Texture2D projectileDown = Content.Load<Texture2D>("down_projectile");
			Texture2D fireballright = Content.Load<Texture2D>("fireball_right");
			Texture2D fireballleft = Content.Load<Texture2D>("fireball_Left");
			Texture2D fireballup = Content.Load<Texture2D>("fireball_up");
			Texture2D fireballdown = Content.Load<Texture2D>("fireball_down");

			Texture2D npcStillRight = Content.Load<Texture2D>("kirito_right_still");
			Texture2D npcStillLeft = Content.Load<Texture2D>("kirito_left_still");
			Texture2D npcStillBack = Content.Load<Texture2D>("kirito_back_still");
			Texture2D npcStillFront = Content.Load<Texture2D>("kirito_front_still");

			SpriteFactory.CreateSprite(npcStillRight, 1, 1, 1, "kirito_right_still");
			SpriteFactory.CreateSprite(npcStillLeft, 1, 1, 1, "kirito_left_still");
			SpriteFactory.CreateSprite(npcStillBack, 1, 1, 1, "kirito_back_still");
			SpriteFactory.CreateSprite(npcStillFront, 1, 1, 1, "kirito_front_still");

			Texture2D attackRight = Content.Load<Texture2D>("right_throw");
			Texture2D attackLeft = Content.Load<Texture2D>("left_throw");
			Texture2D attackFront = Content.Load<Texture2D>("front_throw");
			Texture2D attackBack = Content.Load<Texture2D>("back_throw");

			SpriteFactory.CreateSprite(attackRight, 2, 3, 6, "right_throw");
			SpriteFactory.CreateSprite(attackLeft, 2, 3, 6, "left_throw");
			SpriteFactory.CreateSprite(attackFront, 2, 3, 5, "front_throw");
			SpriteFactory.CreateSprite(attackBack, 3, 2, 6, "back_throw");

			Texture2D moveRight = Content.Load<Texture2D>("right_move");
			Texture2D moveLeft = Content.Load<Texture2D>("left_move");
			Texture2D moveBack = Content.Load<Texture2D>("back_move");
			Texture2D moveFront = Content.Load<Texture2D>("front_move");

			SpriteFactory.CreateSprite(moveRight, 3, 3, 8, "right_move");
			SpriteFactory.CreateSprite(moveLeft, 3, 3, 8, "left_move");
			SpriteFactory.CreateSprite(moveFront, 3, 2, 4, "back_move");
			SpriteFactory.CreateSprite(moveBack, 4, 2, 6, "front_move");

			Texture2D stillRight = Content.Load<Texture2D>("right_still");
			Texture2D stillLeft = Content.Load<Texture2D>("left_still");
			Texture2D stillBack = Content.Load<Texture2D>("back_still");
			Texture2D stillFront = Content.Load<Texture2D>("front_still");

			SpriteFactory.CreateSprite(stillRight, 1, 1, 1, "right_still");
			SpriteFactory.CreateSprite(stillLeft, 1, 1, 1, "left_still");
			SpriteFactory.CreateSprite(stillFront, 1, 1, 1, "back_still");
			SpriteFactory.CreateSprite(stillBack, 1, 1, 1, "front_still");

			Texture2D mudBlock = Content.Load<Texture2D>("mudBlock");
			Texture2D glassBlock = Content.Load<Texture2D>("glassBlock");
			Texture2D ironBlock = Content.Load<Texture2D>("ironBlock");
			Texture2D stoneBlock = Content.Load<Texture2D>("stoneBlock");

			SpriteFactory.CreateSprite(projectileRight, 2, 2, 1, "projectileRight");
			SpriteFactory.CreateSprite(projectileLeft, 2, 2, 1, "projectileLeft");
			SpriteFactory.CreateSprite(projectileUp, 2, 2, 1, "projectileUp");
			SpriteFactory.CreateSprite(projectileDown, 2, 2, 1, "projectileDown");
			SpriteFactory.CreateSprite(fireballright, 8, 1, 1, "fireballright");
			SpriteFactory.CreateSprite(fireballleft, 8, 1, 1, "fireballleft");
			SpriteFactory.CreateSprite(fireballup, 8, 1, 1, "fireballup");
			SpriteFactory.CreateSprite(fireballdown, 8, 1, 1, "fireballdown");

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
