using ChristmasProject.Applicazione.Code.Models;

namespace ChristmasProject.Applicazione.Code.Manager
{
    public class ThemeManager
    {
        public List<Themes> Themes { get; private set; }
        public Themes SelectedTheme { get; set; }
        public Themes DefaultTheme { get; } = new Themes("starwars", "StarWars");

        public ThemeManager() 
        {
            Themes = new List<Themes>()
            {
                new Themes("starwars", "StarWars")
            };
        }

        public Themes GetThemeFromName(string name)
        {
            return Themes.Find(theme => theme.Name == name);
        }
 
    }
}
