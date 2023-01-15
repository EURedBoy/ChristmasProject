using System.Diagnostics;
using System.Windows.Input;
using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Code.Utils;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace ChristmasProject.Applicazione.Code.Manager
{
    public partial class ThemeManager
    {
        public List<Themes> Themes { get; private set; } = new List<Themes>();

        private Themes selectedThemes;
        public Themes SelectedTheme
        {
            get => selectedThemes;

            set
            {
                if (defaultTheme != null) defaultTheme.IsSelected = false;
                if (selectedThemes != null) selectedThemes.IsSelected = false;

                selectedThemes = value;

                if (selectedThemes != null)
                {
                    selectedThemes.IsSelected = true;
                    selectedThemes.IsBought = true;
                }
            }
        }

        private Themes defaultTheme;
        public Themes DefaultTheme
        {
            get => defaultTheme;
            set
            {
                defaultTheme = value;
                if (defaultTheme == null) return;

                defaultTheme.IsSelected = true;
                defaultTheme.IsBought = true;
            }
        }

        public ThemeManager() 
        {
            DirectoryInfo themeDirectory = new DirectoryInfo(FileUtils.ThemeDirectory);

            if (!themeDirectory.Exists) themeDirectory.Create();

            foreach (DirectoryInfo directory in themeDirectory.GetDirectories())
            {
                Themes.Add(new Themes(directory.Name, directory.Name));
            }

            DefaultTheme = GetThemeFromName("Pokemon");
            init();

            Debug.Print(DefaultTheme.Name);
        }

        private void init()
        {
            SelectedTheme = GetSelectedThemes();

            if(SelectedTheme != null) 
                SelectedTheme.IsBought = true;

            App.instance.SettingsManager
                .DeSerializeTheme()
                .ForEach(des =>
                {
                    Themes theme = GetThemeFromName(des);
                    if (theme == null) return;
                    theme.IsBought = true;
                });
        }

        private Themes GetSelectedThemes()
        {
            return GetThemeFromName(Preferences.Get("selected_themes", "Pokemon"));
        }

        public Themes GetThemeFromName(string name)
        {
            return Themes.Find(theme => theme.Name == name);
        }
    }
}
