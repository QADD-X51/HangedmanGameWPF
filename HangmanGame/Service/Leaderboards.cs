using HangmanGame.Commands;
using HangmanGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Service
{
    public class Leaderboards: INotifyPropertyChanged
    {
        public ObservableCollection<Player> NormalLeaderboard;
        public ObservableCollection<Player> TimedLeaderboard = new ObservableCollection<Player>();

        public Leaderboards()
        {
            List<Player>  NormalList = PlayersService.Players.ToList();
            List<Player> TimedList = PlayersService.Players.ToList();

            SortNormal sortNorm = new SortNormal();
            NormalList.Sort(sortNorm);

            SortTimed sortTime = new SortTimed();
            TimedList.Sort(sortTime);

            NormalLeaderboard = new ObservableCollection<Player>(NormalList);
            TimedLeaderboard = new ObservableCollection<Player>(TimedList);
        }

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
