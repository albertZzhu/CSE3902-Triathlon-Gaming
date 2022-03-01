using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.PlayerFiles
{
    class PlayerFacingMachine
    {
        private Facing facing = Facing.RIGHT;
        public void SetFacing(String newFacing)
        {
            if (newFacing.ToUpper().Equals("RIGHT"))
                facing = Facing.RIGHT;
            if (newFacing.ToUpper().Equals("LEFT"))
                facing = Facing.LEFT;
            if (newFacing.ToUpper().Equals("UP"))
                facing = Facing.UP;
            if (newFacing.ToUpper().Equals("DOWN"))
                facing = Facing.DOWN;
        }

        public Facing GetFacing()
        {
            return facing;
        }
    }
}
