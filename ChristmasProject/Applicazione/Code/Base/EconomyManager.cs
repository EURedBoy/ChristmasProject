using System;
using System.ComponentModel;

namespace ChristmasProject.Applicazione.Code.Base
{
	public partial class EconomyManager : INotifyPropertyChanged
    {
        private long _money;
        public long Money {
            get { return _money; }
            private set { _money = value; NotifyPropertyChanged("Money"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public EconomyManager()
		{
            Money = Preferences.Default.Get("money", (long)0);
		}

        public void AddMoney(long value)
        {
            Money += value;
            Preferences.Default.Set("money", Money);
        }

        public void RemoveMoney(long value)
        {
            if (Money <= 0) return;

            Money -= value;
            Preferences.Default.Set("money", Money);
        }
    }
}

