using HangmanGame.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HangmanGame
{
    /// <summary>
    /// Interaction logic for LeaderboardWindow.xaml
    /// </summary>
    public partial class LeaderboardWindow : Window
    {
        private Leaderboards leaderboards;
        public LeaderboardWindow()
        {
            InitializeComponent();
            leaderboards = new Leaderboards();

            NormalBoard.ItemsSource = leaderboards.NormalLeaderboard;
            TimedBoard.ItemsSource = leaderboards.TimedLeaderboard;
        }
    }
}
