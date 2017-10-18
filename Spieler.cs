using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Fingerübung
{
    //Spielerklasse erbt von INotifyPropertyChanged, da die Poperty Wins an die GUI gebunden ist. 
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
                OnPropertyChanged("Wins"); //Änderung des Wertes anzeigen
            }

        }

        public string Zeichen
        {
            get
            {
                return zeichen;
            }
        }

        //Property Changed Event, damit die gebunde GUI den Wert aktualisiert
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
