using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HighWins.ViewModels
{
    using System.Windows;

    public class MainWindowViewModel : PropertyChangedBase
    {
        string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanDeal);
            }
        }

        public bool CanDeal
        {
            get { return true; }
        }

        public void Deal()
        {
            MessageBox.Show(string.Format("Hello {0}!", Name)); //Don't do this in real life :)
        }
    }
}
