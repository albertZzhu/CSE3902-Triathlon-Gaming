using Microsoft.Xna.Framework;
using Sprint5;
using Sprint5.State_Machines;

namespace Sprint5
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
            else
            {
                npc.die();
            }
        }

        public void ChangeFacing(Facing facing)
        {
            this.facing = facing;
        }

        public void Update(GameTime gameTime)
        {
            //have to change facing to an int here...S
            npc.SetNpc(SpriteFactory.GetSprite(npc.npcHolder[(int)facing]));
        }
    }
}
