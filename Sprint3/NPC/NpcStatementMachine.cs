using Microsoft.Xna.Framework;

namespace Sprint3
{
	class NpcStatementMachine
	{
		private Facing facing = Facing.RIGHT;     //facing variable, 0 means right, 1 means left, 2 means upward, 3 means downward
									//private bool attack = false;
		private bool damaged = false;
		private NPC1 npc;

		public NpcStatementMachine(NPC1 npc)
		{
			this.npc = npc;
		}

		public Facing FacingState()
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

		public void ChangeFacing(Facing facing)
		{
			this.facing = facing;
		}

		public void Update(GameTime gameTime)
		{
			switch (facing)
			{
				case Facing.RIGHT:
					if (damaged) { }
					npc.SetNpc(SpriteFactory.GetSprite((npc.npcHolder[npc.index])[0]));
					break;
				case Facing.LEFT:
					if (damaged) { }
					npc.SetNpc(SpriteFactory.GetSprite((npc.npcHolder[npc.index])[1]));
					break;
				case Facing.UP:
					if (damaged) { }
					npc.SetNpc(SpriteFactory.GetSprite((npc.npcHolder[npc.index])[2]));
					break;
				case Facing.DOWN:
					if (damaged) { }
					npc.SetNpc(SpriteFactory.GetSprite((npc.npcHolder[npc.index])[3]));
					break;
				default:
					break;

			}

		}
	}
}
