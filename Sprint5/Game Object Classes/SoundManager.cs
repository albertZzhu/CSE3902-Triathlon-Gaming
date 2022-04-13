using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Sprint5
{
    class SoundManager
    {
        public Dictionary<string, SoundEffect> soundEffectDictionary = new Dictionary<string, SoundEffect>();
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
            soundEffectDictionary.Add("SwordSlash", content.Load<SoundEffect>("SwordSlash"));
            soundEffectDictionary.Add("EnemyHit", content.Load<SoundEffect>("EnemyHit"));
            soundEffectDictionary.Add("GetItem", content.Load<SoundEffect>("GetItem"));
            soundEffectDictionary.Add("PlayerDamaged", content.Load<SoundEffect>("PlayerDamaged"));
            soundEffectDictionary.Add("Fireball", content.Load<SoundEffect>("Fireball"));
            soundEffectDictionary.Add("Boomerang", content.Load<SoundEffect>("BoomerangThrow"));
            soundEffectDictionary.Add("Spear", content.Load<SoundEffect>("Spear"));

            backgroundMusic.Add("DungeonTheme", content.Load<Song>("DungeonTheme"));
            backgroundMusic.Add("WinMusic", content.Load<Song>("zelda_theme_snes-cut-mp3"));
            backgroundMusic.Add("LoseMusic", content.Load<Song>("Game_Over"));


            MediaPlayer.Play(backgroundMusic["DungeonTheme"]);
        }

        public SoundManager()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
        }

        public void PlaySound(string name)
        {
            if (soundEffectDictionary.ContainsKey(name))
                soundEffectDictionary[name].Play();
            else
                MediaPlayer.Play(backgroundMusic[name]);
        }
        public void PauseSound(string name)
        {
            MediaPlayer.Pause();
        }

        public void ThemeMusic()
        {
            MediaPlayer.Play(backgroundMusic["DungeonTheme"]);
        }

        public void WinMusic()
        {
            MediaPlayer.Play(backgroundMusic["WinMusic"]);
        }

        public void LoseMusic()
        {
            MediaPlayer.Play(backgroundMusic["LoseMusic"]);
        }
    }
}