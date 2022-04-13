using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Game_Object_Classes
{
    class MapMarker
    {
        //each room number has a corresponding location on the map
        //this implementation will probably be very limited and for the current data: must be refactored

        Dictionary<int, Vector2> roomLocations = new Dictionary<int, Vector2>();
        Vector2 currentLocation;
        ISprite sprite;

        //could have level number be a param but that would become obsolete pretty fast
        public MapMarker()
        {
            sprite = SpriteFactory.GetSprite("mapmarker");
            roomLocations.Add(1, new Vector2(90, 590));
            roomLocations.Add(2, new Vector2(140, 590));
            roomLocations.Add(3, new Vector2(140, 620));
            roomLocations.Add(4, new Vector2(250, 620));
            roomLocations.Add(5, new Vector2(305, 620));
            roomLocations.Add(6, new Vector2(90, 655));
            roomLocations.Add(7, new Vector2(140, 655));
            roomLocations.Add(8, new Vector2(195, 655));
            roomLocations.Add(9, new Vector2(250, 655));
            roomLocations.Add(10, new Vector2(90, 685));
            roomLocations.Add(11, new Vector2(140, 685));
            roomLocations.Add(12, new Vector2(195, 685));
            roomLocations.Add(13, new Vector2(140, 720));
            roomLocations.Add(14, new Vector2(90, 750));
            roomLocations.Add(15, new Vector2(140, 750));
            roomLocations.Add(16, new Vector2(195, 750));
            currentLocation = roomLocations[1];
        }

        public void Update(int roomNum)
        {
            currentLocation = roomLocations[roomNum];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, currentLocation);
        }

    }
}
