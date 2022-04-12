using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.State_Machines
{
    public enum Facing
    {
        RIGHT, LEFT, UP, DOWN, NORTHEAST = 10, SOUTHEAST = -10, NORTHWEST = 11, SOUTHWEST = -9, NNWEST = 12, NNEAST = -8, SSWEST = 13, SSEAST = -7
        //1,2,3,4   10,-10, 11,-9, 12,-8, 13,-7
    }
}
