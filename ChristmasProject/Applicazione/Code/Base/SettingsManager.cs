using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Code.Manager;
using Microsoft.Maui.Storage;
using Plugin.Maui.Audio;

namespace ChristmasProject.Applicazione.Code.Base
{

    public class SettingsManager
    {
        public Dictionary<string, string> SettingsCache { get; private set; }
        private IAudioManager audioManager { get; set; } = AudioManager.Current;
        public IAudioPlayer audioPlayer { get; private set; }

        public SettingsManager() 
        {
            //init(); 
            SettingsCache = new Dictionary<string, string>();
        }

        private async Task init()
        {
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("background_music.mp3"));
            audioPlayer.Play();

            audioPlayer.Loop = true;
        }
        
        //TODO Magari usare i generic
        public void SetData(string key, string value)
        {
            Preferences.Default.Set(key, value);
            if (SettingsCache.ContainsKey(key)) SettingsCache[key] = value;
            else SettingsCache.Add(key, value);
        }

        public string GetData(string key)
        {
            if (SettingsCache.ContainsKey(key))
                return SettingsCache[key];

            string value = Preferences.Get(key, "None");
            if (SettingsCache.ContainsKey(key)) SettingsCache[key] = value;
            else SettingsCache.Add(key, value);

            return value;
        }

        public void SerializeTheme(List<Themes> themes)
        {
            StringBuilder serialize = new StringBuilder();
            themes.ForEach(theme => serialize.Append(theme.Name + ";"));

            SetData("theme_bought", serialize.ToString());
        }

        public List<string> DeSerializeTheme()
        {
            ThemeManager manager = App.instance.ThemeManager;
            String deserialize = GetData("theme_bought");

            return deserialize.Split(";").ToList();
        }

    }
}
