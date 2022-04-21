using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
    public interface IRoom
    {
        public Vector2 playerPositionTransition(Vector2 location);
        public IBlock[] GetBlockObj();
        public IBlock[] getMovableBlock();
        public IProjectile[] GetNPCProjObj();
        public Item[] GetItemObj();
        public NPC1[] GetNpcObj();
        public KeyValuePair<IBlock, String>[] GetDoorPair();
        public IBlock[] GetWaterObj();
        public IBlock[] GetSandObj();
        public Player GetPlayerObj();
    }
}
