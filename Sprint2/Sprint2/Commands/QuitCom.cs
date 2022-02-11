﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class QuitCom : ICommand
    {
        public void Execute(Player player, ISprite item, ISprite block, ISprite enemy)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}