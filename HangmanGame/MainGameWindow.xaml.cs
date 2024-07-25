using HangmanGame.Models;
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
    /// Interaction logic for MainGameWindow.xaml
    /// </summary>
    public partial class MainGameWindow : Window
    {
        
        public MainGameWindow()
        {
            InitializeComponent();
            PlayerAvatar.Source = new BitmapImage(Avatar.Avatars[PlayersService.Players[PlayersService.currentPlayerIndex].AvatarIndex]);
            PlayerName.Content = PlayersService.Players[PlayersService.currentPlayerIndex].Name;
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow window = new AboutWindow();
            window.Show();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            Game.game.NewGame(false);
            Game.TimeLabel.Visibility = Visibility.Hidden;
            Game.SecondsLabel.Visibility = Visibility.Hidden;
        }

        private void NewTimedGameButton_Click(object sender, RoutedEventArgs e)
        {
            Game.game.NewGame(true);
            Game.TimeLabel.Visibility = Visibility.Visible;
            Game.SecondsLabel.Visibility = Visibility.Visible;
        }

        private void CarsCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            if (!CarsCategoryMenu.IsChecked)
            {
                CarsCategoryMenu.IsChecked = true;
                return;
            }  
            UncheckAllCategories();
            CarsCategoryMenu.IsChecked = true;
            Game.game.CategorySelected = 1;
        }

        private void CountryCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            if (!CountryCategoryMenu.IsChecked)
            {
                CountryCategoryMenu.IsChecked = true;
                return;
            }
            UncheckAllCategories();
            CountryCategoryMenu.IsChecked = true;
            Game.game.CategorySelected = 2;
        }

        private void GamesCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            if (!GamesCategoryMenu.IsChecked)
            {
                GamesCategoryMenu.IsChecked = true;
                return;
            }
            UncheckAllCategories();
            GamesCategoryMenu.IsChecked = true;
            Game.game.CategorySelected = 3;
        }

        private void HouseItemsCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            if (!HouseItemsCategoryMenu.IsChecked)
            {
                HouseItemsCategoryMenu.IsChecked = true;
                return;
            }
            UncheckAllCategories();
            HouseItemsCategoryMenu.IsChecked = true;
            Game.game.CategorySelected = 4;
        }

        private void OthersCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            if (!OthersCategoryMenu.IsChecked)
            {
                OthersCategoryMenu.IsChecked = true;
                return;
            }
            UncheckAllCategories();
            OthersCategoryMenu.IsChecked = true;
            Game.game.CategorySelected = 5;
        }

        private void AllCategoryMenu_Click(object sender, RoutedEventArgs e)
        {
            if (!AllCategoryMenu.IsChecked)
            {
                AllCategoryMenu.IsChecked = true;
                return;
            }
            UncheckAllCategories();
            AllCategoryMenu.IsChecked = true;
            Game.game.CategorySelected = 0;
        }

        private void UncheckAllCategories()
        {
            CarsCategoryMenu.IsChecked = false;
            CountryCategoryMenu.IsChecked = false;
            GamesCategoryMenu.IsChecked = false;
            HouseItemsCategoryMenu.IsChecked = false;
            OthersCategoryMenu.IsChecked = false;
            AllCategoryMenu.IsChecked = false;
        }

        private void ChangePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Game.game.GameAbandoned();
            UserManagementWindow window = new UserManagementWindow();
            window.Show();
            this.Close();
        }

        private void LeaderboardButton_Click(object sender, RoutedEventArgs e)
        {
            LeaderboardWindow window = new LeaderboardWindow();
            window.Show();
        }
    }
}
