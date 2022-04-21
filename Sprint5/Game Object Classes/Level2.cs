using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
    public class Level2 : Level
    {
        private string futureRoom;
        private IRoom room;
        private string currentRoom;
        private bool pass;
        public GameObjectManager gom;
        private int boundWidth;
        private int boundHeight;

        public Level2(GameObjectManager gom, int boundWidth, int boundHeight)
        {
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            this.gom = gom;
            this.futureRoom = "level1";
        }
        public bool CheckLock()
        {
            return !this.pass;
        }
        public string currentroom()
        {
            return this.currentRoom;
        }

        public string futureroom()
        {
            return this.futureRoom;
        }

        public IRoom GetRoom()
        {
            return room;
        }

        public void InitializeRoom()
        {
            room = new Room2("room", gom, boundWidth, boundHeight);
            this.currentRoom = "room";
            setCheckLock(false);
        }

        public void loadRoom()
        {
            room = new Room2("room", gom, boundWidth, boundHeight, room.GetPlayerObj());
            this.currentRoom = "room";
        }

        public void resetRoom()
        {
            InitializeRoom();
        }

        public void setCheckLock(bool value)
        {
            this.pass = value;
        }



        //not use, place holder
        public void setRoom(int i)
        {
            loadRoom();
        }

        public void SwitchRoom(int doorposition)
        {
        }
        public int GetDoorDoc()
        {
            return 0;
        }

        public int GetIndex()
        {
            return 0;
        }
        public bool LoadLock()
        {
            return true;
        }
    }
}
