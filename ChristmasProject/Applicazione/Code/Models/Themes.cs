using ChristmasProject.Applicazione.Code.Utils;

namespace ChristmasProject.Applicazione.Code.Models
{
    public class Themes
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public ImageSource[] imageSources { get; private set; } = new ImageSource[6]; 

        public Themes(string name, string directoryName) 
        {
            Name = name;
            Task.Run(() => load(directoryName));
        }

        private void load(string directory)
        {
            string path = Path.Combine(FileUtils.ThemeDirectory, directory);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                IsActive = false;
                return;
            }
            int count = 0;
            foreach (var file in directoryInfo.GetFiles())
            {
                imageSources[count] = ImageSource.FromFile(file.FullName);
                count++;
            }
            IsActive = true;
        }
    }
}
