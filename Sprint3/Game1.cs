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
			boundWidth = Window.ClientBounds.Width;
			boundHeight = Window.ClientBounds.Height;
			_npc = new NPC1(boundWidth, boundHeight);
			_player = new Player(boundWidth, boundHeight);
			_item = new Item(boundWidth, boundHeight);
			factory = SpriteFactory.GetFactory(Content);
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
			//player class should hold all sprites for it?
			//sprite factory????????
			//_player.sprite = factory creates player sprite

		}

		protected override void Update(GameTime gameTime)
		{
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
