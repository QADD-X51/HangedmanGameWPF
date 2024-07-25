using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Models
{
    public class Player : INotifyPropertyChanged
    {
        private string _name;
        private int _wins;
        private int _winsHard;
        public string Name 
        { 
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int AvatarIndex { get; set; }
        public int Wins 
        {
            get
            {
                return _wins;
            }

            set
            {
                _wins = value;
                OnPropertyChanged("Wins");
            }
        }
        public int TotalGames { get; set; }
        public int WinsHard
        {
            get
            {
                return _winsHard;
            }

            set
            {
                _winsHard = value;
                OnPropertyChanged("WinsHard");
            }
        }
        public int TotalHardGames { get; set; }
        public int CorrectGuesses { get; set; }
        public int TotalGuesses { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
