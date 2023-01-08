namespace ChristmasProject.Applicazione.Code.Base
{

    public class SettingsManager
    {
        public Dictionary<string, string> SettingsCache { get; private set; }

        public SettingsManager() 
        { 
            SettingsCache = new Dictionary<string, string>();
        }


        public void SetData(string key, string value)
        {
            Preferences.Default.Set(key, value);
            SettingsCache.Add(key, value);
        }

        public string GetData(string key)
        {
            if (SettingsCache.ContainsKey(key))
                return SettingsCache[key];

            string value = Preferences.Get(key, "None");
            SettingsCache.Add(key, value);

            return value;
        }

    }
}
