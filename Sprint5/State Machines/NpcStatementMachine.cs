using Microsoft.Xna.Framework;
using Sprint5;
using Sprint5.State_Machines;

namespace Sprint5
{
    class NpcStatementMachine
    {
        private FacingEnum facing = FacingEnum.RIGHT;     //FacingEnum variable, 0 means right, 1 means left, 2 means upward, 3 means downward
                                                  //private bool attack = false;
        private INPC npc;
        private int health;

        public NpcStatementMachine(INPC npc)
        {
            this.npc = npc;
        }

        public FacingEnum FacingState()
        {
            return facing;
        }

        public void Damaged()
        {
            if (health > 1)
            {
                health--;
            }
            else
            {
                npc.die();
            }
        }

        public void ChangeFacing(FacingEnum facing)
        {
            this.facing = facing;
        }

        public void Update(GameTime gameTime)
        {
            //have to change FacingEnum to an int here...S
            npc.SetNpc(SpriteFactory.GetSprite(npc.GetNPCHolder()[(int)facing]));
        }

        public string NPCType()
        {
            return npc.GetNPCHolder()[(int)facing];
        }

        public void SetHealth()
        {
            if (NPCType().Contains("dragon"))
            {
                health = 6;
            }
            else
            {
                health = 3;
            }
        }

        public int GetHealth()
        {
            return health;
        }
    }
}
