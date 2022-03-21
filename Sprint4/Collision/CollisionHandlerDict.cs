using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Collision
{
	class CollisionHandlerDict
	{
		private Dictionary<string, Player2EnemyHandler> player2NPCList;
		private Dictionary<string, Player2BlockHandler> player2BlockList;
		private Dictionary<string, Player2ProjectileHandler> player2ProjectileList;
		private Dictionary<string, Player2ItemHandler> player2ItemList;
		private Dictionary<string, NPC2BlockHandler> NPC2BlockList;
		private Dictionary<string, NPC2ProjectileHandler> NPC2ProjectileList;
		private Dictionary<string, Projectile2BlockHandler> projectile2BlockList;

		public CollisionHandlerDict()
		{

		}

		public void Initialize()
		{
			player2NPCList = new Dictionary<string, Player2EnemyHandler>();
			player2BlockList = new Dictionary<string, Player2BlockHandler>();
			player2ProjectileList = new Dictionary<string, Player2ProjectileHandler>();
			player2ItemList = new Dictionary<string, Player2ItemHandler>();
			NPC2BlockList = new Dictionary<string, NPC2BlockHandler>();
			NPC2ProjectileList = new Dictionary<string, NPC2ProjectileHandler>();
			projectile2BlockList = new Dictionary<string, Projectile2BlockHandler>();
		}

		public void AddHandler(string playerName, Player2EnemyHandler handler)
		{
			player2NPCList.Add(playerName, handler);
		}

		public void AddHandler(string playerName, Player2BlockHandler handler)
		{
			player2BlockList.Add(playerName, handler);
		}

		public void AddHandler(string playerName, Player2ItemHandler handler)
		{
			player2ItemList.Add(playerName, handler);
		}

		public void AddHandler(string playerName, Player2ProjectileHandler handler)
		{
			player2ProjectileList.Add(playerName, handler);
		}

		public void AddHandler(string NPCname, NPC2BlockHandler handler)
		{
			NPC2BlockList.Add(NPCname, handler);
		}

		public void AddHandler(string NPCname, NPC2ProjectileHandler handler)
		{
			NPC2ProjectileList.Add(NPCname, handler);
		}

		public void AddHandler(string Projectilename, Projectile2BlockHandler handler)
		{
			projectile2BlockList.Add(Projectilename, handler);
		}


		public Player2EnemyHandler GetPlayer2NPC(string name)
		{
			return player2NPCList[name];
		}

		public Player2BlockHandler GetPlayer2Block(string name)
		{
			return player2BlockList[name];
		}

		public Player2ProjectileHandler GetPlayer2Projectile(string name)
		{
			return player2ProjectileList[name];
		}

		public Player2ItemHandler GetPlayer2Item(string name)
		{
			return player2ItemList[name];
		}

		public NPC2BlockHandler GetNPC2Block(string name)
		{
			return NPC2BlockList[name];
		}

		public NPC2ProjectileHandler GetNPC2Projectile(string name)
		{
			return NPC2ProjectileList[name];
		}

		public Projectile2BlockHandler GetProjectile2Block(string name)
		{
			return projectile2BlockList[name];
		}
	}
}