
namespace ChristmasProject.Applicazione.Code.Utils
{
    public class FileUtils
    {
        public static string AppDirectory = Path.Combine(FileSystem.Current.AppDataDirectory, "Memory");
        public static string ThemeDirectory = Path.Combine(AppDirectory, "Themes");
    }
}
