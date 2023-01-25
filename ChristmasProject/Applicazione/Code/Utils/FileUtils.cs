
namespace ChristmasProject.Applicazione.Code.Utils
{
    public class FileUtils
    {
        //public static string TestPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Memory");
        //public static string TestIphone = Path.Combine(FileSystem.Current.AppDataDirectory, "Memory");
        public static string AppDirectory = Path.Combine("/storage/emulated/0/Documents", "Memory");
        public static string ThemeDirectory = Path.Combine(AppDirectory, "Themes");
    }
}
