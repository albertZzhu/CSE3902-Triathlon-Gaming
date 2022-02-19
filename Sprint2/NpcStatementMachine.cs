using Microsoft.Xna.Framework;

namespace Sprint2
{
	class NpcStatementMachine
	{
		private int facing = 0;     //facing variable, 0 means right, 1 means left, 2 means upward, 3 means downward
									//private bool attack = false;
		private bool damaged = false;
		private NPC1 npc;

		public NpcStatementMachine(NPC1 npc)
		{
			this.npc = npc;
		}

		public int FacingState()
		{
			return facing;
		}

		public void Damaged()
		{
			if (damaged == false)
			{
				damaged = true;
			}
		}

		public void ChangeFacing(int facing)
		{
			this.facing = facing;
		}

		public void Update(GameTime gameTime)
		{
			switch (facing)
			{
				case 0:
					if (damaged) { }
					npc.SetNpc(SpriteFactory.GetSprite((npc.npcHolder[npc.index])[0]));
					break;
				case 1:
					if (damaged) { }
					npc.SetNpc(SpriteFactory.GetSprite((npc.npcHolder[npc.index])[1]));
					break;
				case 2:
					if (damaged) { }
					npc.SetNpc(SpriteFactory.GetSprite((npc.npcHolder[npc.index])[2]));
					break;
				case 3:
					if (damaged) { }
					npc.SetNpc(SpriteFactory.GetSprite((npc.npcHolder[npc.index])[3]));
					break;
				default:
					break;

			}

		}
	}
}
