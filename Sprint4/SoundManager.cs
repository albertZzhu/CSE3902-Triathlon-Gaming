using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Sprint4
{
    class SoundManager
    {
        public Dictionary<string, SoundEffect> soundEffecrDictionary = new Dictionary<string, SoundEffect>();
        private Dictionary<string, Song> backgroundMusic = new Dictionary<string, Song>();
        private static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllSounds(ContentManager content)
        {
            soundEffecrDictionary.Add("SwordSlash", content.Load<SoundEffect>("SwordSlash"));
            soundEffecrDictionary.Add("EnemyHit", content.Load<SoundEffect>("EnemyHit"));
            soundEffecrDictionary.Add("GetItem", content.Load<SoundEffect>("GetItem"));
            soundEffecrDictionary.Add("PlayerDamaged", content.Load<SoundEffect>("PlayerDamaged"));

            backgroundMusic.Add("DungeonTheme", content.Load<Song>("DungeonTheme"));


            MediaPlayer.Play(backgroundMusic["DungeonTheme"]);
        }

        public SoundManager()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
        }

        public void PlaySound(string Name)
        {
            soundEffecrDictionary[Name].Play();
        }

        public void ThemeMusic()
        {
            MediaPlayer.Play(backgroundMusic["DungeonTheme"]);
        }
    }
}