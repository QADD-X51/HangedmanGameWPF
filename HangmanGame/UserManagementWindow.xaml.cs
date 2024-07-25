using HangmanGame.Models;
using HangmanGame.Service;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangmanGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UserManagementWindow : Window
    {
        int currentAvatar;

        public UserManagementWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void LoadPlayers()
        {
            DirectoryInfo dir = new DirectoryInfo(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data"));
            foreach (var file in dir.GetFiles())
            {
                PlayersBox.Items.Add(file.Name);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlayersBox.ItemsSource = PlayersService.Players;
        }

        private void Button_NewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow window = new NewUserWindow();
            this.Close();
            window.Show();
        }

        bool PlayerDeleteSafeguard = false;

        /*private void PlayersBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PlayerDeleteSafeguard)
            {
                PlayerDeleteSafeguard = false;
                NameBlock.Text = string.Empty;
                NormalStatsBlock.Text = string.Empty;
                TimedStatsBlock.Text = string.Empty;
                PlayerAvatar.Source = new BitmapImage();
                return;
            }

            DeletePlayerButton.IsEnabled = true;
            EditPlayerButton.IsEnabled = true;
            PlayButton.IsEnabled = true;

            string player = PlayersBox.SelectedItem.ToString();
            NameBlock.Text = player;

            List<string> playerStats = new List<string>();
            playerStats = File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data/" + player)).ToList();

            float winRate = 0f;
            float winRateTimed = 0f;
            float guessRate = 0f;

            if (float.Parse(playerStats[2]) != 0)
            {
                winRate = 100 * (float.Parse(playerStats[1]) / float.Parse(playerStats[2]));
            }

            if (float.Parse(playerStats[4]) != 0)
            {
                winRateTimed = 100 * (float.Parse(playerStats[3]) / float.Parse(playerStats[4]));
            }

            if (float.Parse(playerStats[6]) != 0)
            {
                guessRate = 100 * (float.Parse(playerStats[5]) / float.Parse(playerStats[6]));
            }

            currentAvatar = Int32.Parse(playerStats[0]);

            PlayerAvatar.Source = new BitmapImage(Avatar.Avatars[currentAvatar]);

            NormalStatsBlock.Text = "Wins: " + playerStats[1] + "\nTotal Games: " + playerStats[2] + "\nWinrate: " + winRate.ToString("0.00") + "%\nCorrect guess rate: " + guessRate.ToString("0.00") + "%";

            TimedStatsBlock.Text = "Timed Wins: " + playerStats[3] + "\nTotal Timed Games: " + playerStats[4] + "\nTimed Winrate: " + winRateTimed.ToString("0.00") + "%";
        }*/


        private void PlayersBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PlayerDeleteSafeguard)
            {
                PlayerDeleteSafeguard = false;
                NameBlock.Text = string.Empty;
                NormalStatsBlock.Text = string.Empty;
                TimedStatsBlock.Text = string.Empty;
                PlayerAvatar.Source = new BitmapImage();
                return;
            }

            DeletePlayerButton.IsEnabled = true;
            EditPlayerButton.IsEnabled = true;
            PlayButton.IsEnabled = true;

            NameBlock.Text = (PlayersBox.SelectedItem as Player).Name;
            currentAvatar = (PlayersBox.SelectedItem as Player).AvatarIndex;

            PlayerAvatar.Source = new BitmapImage(Avatar.Avatars[currentAvatar]);

            float winRate = 0f;
            float winRateTimed = 0f;
            float guessRate = 0f;

            if ((PlayersBox.SelectedItem as Player).TotalGames != 0)
            {
                winRate = 100 * (float)(PlayersBox.SelectedItem as Player).Wins / (PlayersBox.SelectedItem as Player).TotalGames;
            }

            if ((PlayersBox.SelectedItem as Player).TotalHardGames != 0)
            {
                winRateTimed = 100 * (float)(PlayersBox.SelectedItem as Player).WinsHard / (PlayersBox.SelectedItem as Player).TotalHardGames;
            }

            if ((PlayersBox.SelectedItem as Player).TotalGuesses != 0)
            {
                guessRate = 100 * (float)(PlayersBox.SelectedItem as Player).CorrectGuesses / (PlayersBox.SelectedItem as Player).TotalGuesses;
            }

            NormalStatsBlock.Text = "Wins: " + (PlayersBox.SelectedItem as Player).Wins + 
                "\nTotal Games: " + (PlayersBox.SelectedItem as Player).TotalGames + 
                "\nWinrate: " + winRate.ToString("0.00") + 
                "%\nCorrect guess rate: " + guessRate.ToString("0.00") + "%";

            TimedStatsBlock.Text = "Timed Wins: " + (PlayersBox.SelectedItem as Player).WinsHard + 
                "\nTotal Timed Games: " + (PlayersBox.SelectedItem as Player).TotalHardGames + 
                "\nTimed Winrate: " + winRateTimed.ToString("0.00") + "%";
        }

        private void DeletePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if(System.Windows.MessageBox.Show("Are you sure you want to delete player \"" + (PlayersBox.SelectedItem as Player).Name + "\" ?", "Delete confirmation.", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }

            PlayerDeleteSafeguard = true;

            File.Delete(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data/" + (PlayersBox.SelectedItem as Player).Name));
            PlayersService.RemovePlayer(PlayersBox.SelectedIndex);

            DeletePlayerButton.IsEnabled = false;
            EditPlayerButton.IsEnabled = false;
            PlayButton.IsEnabled = false;
            
        }

        private void EditPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            PlayersService.currentPlayerIndex = PlayersBox.SelectedIndex;

            NewUserWindow window = new NewUserWindow(true, PlayersService.Players[PlayersService.currentPlayerIndex].Name, currentAvatar);
            window.Show();
            this.Close();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            PlayersService.currentPlayerIndex = PlayersBox.SelectedIndex;

            MainGameWindow window = new MainGameWindow();
            window.Show();
            this.Close();
        }
    }
}
