using System.ComponentModel;
using System.Diagnostics;
using ChristmasProject.Applicazione.Code.Utils;
using ChristmasProject.Applicazione.Code.Manager;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ChristmasProject.Applicazione.Code.Models
{
    public partial class Themes : INotifyPropertyChanged
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public ImageSource[] imageSources { get; private set; } = new ImageSource[6];
        public ImageSource Icon { get; private set; }

        private bool _isBought = false;
        public bool IsBought
        {
            get { return _isBought; }
            set { _isBought = value; NotifyPropertyChanged("Prize"); }
        }

        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; NotifyPropertyChanged("Prize"); }
        } 

        public string _prize;
        public string Prize
        {
            get
            {
                if (IsSelected) return "Equipped";
                if (IsBought) return "Select";
                return _prize;
            }

            set { _prize = value; NotifyPropertyChanged("Prize"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Themes(string name, string directoryName) 
        {
            _prize = "20";
            Name = name;
            Task.Run(() => load(directoryName));
            //load(directoryName);
        }

        private void load(string directory)
        {
            string path = Path.Combine(FileUtils.ThemeDirectory, directory);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                Debug.Print("Non esiste e lo crea");
                directoryInfo.Create();
                IsActive = false;
                return;
            }

            int count = 0;
            foreach (var file in directoryInfo.GetFiles())
            {
                Debug.Print("File: " + file.Name);
                imageSources[count] = ImageSource.FromFile(file.FullName);
                count++;
            }

            //Cambiare al massimo
            Icon = imageSources[0];

            IsActive = count != 0;
        }

        public void BuyTheme()
        {
            //App.Current.MainPage.DisplayAlert("yey", "ha funzionato", "ok");

            this.IsBought = true;

            //Controllare qui
            ThemeManager themeManager = App.instance.ThemeManager;
            themeManager.SelectedTheme = this;
        }
    }
}
