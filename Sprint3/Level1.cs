using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    class Level1 : Level
    {
        private Dictionary<int, String> rooms;
        private Room room;
        private int boundWidth;
        private int boundHeight;
        public Level1(int boundWidth, int boundHeight)
        {
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            this.rooms = new Dictionary<int, String>();
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
            rooms.Add(12, "room12");
            rooms.Add(13, "room13");
            rooms.Add(14, "room14");
            rooms.Add(15, "room15");
            rooms.Add(16, "room16");
            rooms.Add(17, "room17");
        }
        //mouse pressed might need to call this func to initiate different room classes.
        public void loadRoom(int i)
        {
            this.room = new Room(this.rooms[i], boundWidth, boundHeight);
        }

        public Room GetRoom()
        {
            return this.room;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.room.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            this.room.Update(gameTime);
        }
    }
}
