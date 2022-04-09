using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Game_Object_Classes
{
    public class UniParam
    {   //...static? filled on game initialization? singleton?
        //have a list? or a list of lists?
        //player
        //level
        //Game
        //ItemSelect
        //Inventory?
        private GameObjectManager gom;
        private Level1 level;
        private Game1 game;
        private static UniParam uniparam;

        //I cant really remember how static constructors work...
        //you make static methods and those can be accessed!
        private UniParam(GameObjectManager gameom, Level1 level1, Game1 game1)
        {
            gom = gameom;
            level = level1;
            game = game1;
        }

        //but this is an instance method.............
        public static void Initialize(GameObjectManager gameom, Level1 level1, Game1 game1)
        {
            uniparam = new UniParam(gameom, level1, game1);
        }
    }
}
