using Microsoft.Xna.Framework;

namespace Sprint4
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
			else
			{
				npc.die();
			}
		}

		public void ChangeFacing(int facing)
		{
			this.facing = facing;
		}

		public void Update(GameTime gameTime)
		{
			npc.SetNpc(SpriteFactory.GetSprite(npc.npcHolder[facing]));
		}
	}
}
