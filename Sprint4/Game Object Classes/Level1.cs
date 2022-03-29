using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
    public class Level1
    {
        private Dictionary<int, String> rooms;
        public Room room;
        public GameObjectManager gom;
        private int boundWidth;
        private int boundHeight;
        private int index;
        public Level1(GameObjectManager gom, int boundWidth, int boundHeight)
        {
            index = 1;
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            this.gom = gom;
            rooms = new Dictionary<int, String>();

            rooms.Add(1, "room1");
            rooms.Add(2, "room2");
            rooms.Add(3, "room3");
            rooms.Add(4, "room4");
            rooms.Add(5, "room5");
            rooms.Add(6, "room6");
            rooms.Add(7, "room7");
            rooms.Add(8, "room8");
            rooms.Add(9, "room9");
            rooms.Add(10, "room10");
            rooms.Add(11, "room11");
            rooms.Add(12, "room12");
            rooms.Add(13, "room13");
            rooms.Add(14, "room14");
            rooms.Add(15, "room15");
            rooms.Add(16, "room16");
            rooms.Add(17, "room17");
        }
        //mouse pressed might need to call this func to initiate different room classes.
        public void loadRoom()
        {
            room = new Room(rooms[index], gom, boundWidth, boundHeight);
        }

        public Room GetRoom()
        {
            return room;
        }

        public void switchPre()
        {
            index--;
            if (index < 1)
            {
                index = 16;
            }
        }

        public void switchNext()
        {
            index++;
            if (index > 16)
            {
                index = 1;
            }
        }
    }
}
