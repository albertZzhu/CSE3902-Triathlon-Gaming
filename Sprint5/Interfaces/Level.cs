using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
    public interface Level
    {
        public void loadRoom();
        public void InitializeRoom();
        public IRoom GetRoom();
        public String currentroom();
        public String futureroom();
        public bool CheckLock();
        public bool LoadLock();
        public void setCheckLock(bool value);
        public void SwitchRoom(int doorposition);
        public void resetRoom();
        public int GetIndex();
        public int GetDoorDoc();
        public void setRoom(int i);
    }
}
