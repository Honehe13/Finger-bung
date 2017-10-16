using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Fingerübung
{
    class Spieler : INotifyPropertyChanged
    {
        private int wins = 0;
        private string zeichen;
        private bool amZug = false;

        public Spieler(bool Startspieler, string XoderO)
        {
            amZug = Startspieler;
            zeichen = XoderO;
        }

        public bool AmZug
        {
            get
            { 
                return amZug;
            }
            set
            {
                amZug = value;
            }
        }

        public int Wins
        {
            get
            {
                return wins;
            }
            set
            {
                wins = value;
                OnPropertyChanged("Wins");
            }

        }

        public string Zeichen
        {
            get
            {
                return zeichen;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
}
