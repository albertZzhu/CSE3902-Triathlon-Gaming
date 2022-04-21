using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Collision
{
	class CollisionManager
	{
		private CollisionHandlerDict collisionDict;

		private Player2BlockHandler player2Block;
		private Player2DoorHandler player2Door;
		private Player2MoveableBlockHandler player2Moveable;
		private Player2EnemyHandler player2Enemy;
		private Player2ProjectileHandler player2Proj;
		private Player2ItemHandler player2item;

		private NPC2BlockHandler enemy2Block;
		private NPC2ProjectileHandler enemy2Proj;

		private Projectile2BlockHandler proj2Blcok;

		private MoveableBlock2BlockHandler block2Block;

		private PlayerCollisionDetection playerDetect;
		private NPCCollisionDetection npcDetect;
		private ProjectileCollisionDetection projDetect;

		private ResetCom resetCommand;
		private SwitchRoomBackwardCom roomBackCommand;
		private SwitchRoomForwardCom roomForwardComand;
		private SwitchRoomUpwardCom roomUpwardComand;
		private SwitchRoomDownwardCom roomDownwardComand;


		public CollisionManager()
		{
			collisionDict = new CollisionHandlerDict();
		}

		public void Initialize(string playerName, string enemyName, string projectileName, Level level1)
		{
			collisionDict.Initialize();

			resetCommand = new ResetCom(level1);

			roomBackCommand = new SwitchRoomBackwardCom(level1);
			roomForwardComand = new SwitchRoomForwardCom(level1);
			roomUpwardComand = new SwitchRoomUpwardCom(level1);
			roomDownwardComand = new SwitchRoomDownwardCom(level1);

			player2Block = new Player2BlockHandler();
			player2Door = new Player2DoorHandler(roomBackCommand, roomForwardComand, roomUpwardComand, roomDownwardComand);
			player2Moveable = new Player2MoveableBlockHandler();
			player2Enemy = new Player2EnemyHandler(resetCommand);
			player2Proj = new Player2ProjectileHandler(resetCommand);
			player2item = new Player2ItemHandler();

			enemy2Block = new NPC2BlockHandler();
			enemy2Proj = new NPC2ProjectileHandler();

			proj2Blcok = new Projectile2BlockHandler();

			block2Block = new MoveableBlock2BlockHandler();

			collisionDict.AddHandler(playerName, player2Block);
			collisionDict.AddHandler(playerName, player2Door);
			collisionDict.AddHandler(playerName, player2Moveable);
			collisionDict.AddHandler(playerName, player2Enemy);
			collisionDict.AddHandler(playerName, player2Proj);
			collisionDict.AddHandler(playerName, player2item);

			collisionDict.AddHandler(enemyName, enemy2Block);
			collisionDict.AddHandler(enemyName, enemy2Proj);

			collisionDict.AddHandler(projectileName, proj2Blcok);

			collisionDict.AddHandler(playerName, block2Block);

			playerDetect = new PlayerCollisionDetection(playerName, collisionDict);
			npcDetect = new NPCCollisionDetection(enemyName, collisionDict);
			projDetect = new ProjectileCollisionDetection(projectileName, collisionDict);
		}

		public void Update(Level level)
		{
			playerDetect.Detect(level.GetRoom().GetPlayerObj(), level.GetRoom().GetNPCProjObj(), 
				level.GetRoom().GetNpcObj(), level.GetRoom().GetBlockObj(), level.GetRoom().GetItemObj());

			foreach (NPC1 npc in level.GetRoom().GetNpcObj())
			{
				npcDetect.Detect(npc, level.GetRoom().GetPlayerObj().GetSeqList().ToArray(), level.GetRoom().GetBlockObj());
			}

			foreach (IProjectile p in level.GetRoom().GetPlayerObj().GetSeqList().ToArray())
			{
				projDetect.Detect(p, level.GetRoom().GetBlockObj());
			}
			foreach (IProjectile p in level.GetRoom().GetNPCProjObj())
			{
				projDetect.Detect(p, level.GetRoom().GetBlockObj());
			}
		}
	}
}
