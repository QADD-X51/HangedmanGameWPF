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
using System.Windows.Shapes;

namespace HangmanGame
{
    /// <summary>
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        int avatarIndex;
        bool editPlayer;
        string originalPlayerName;
        public NewUserWindow(bool edit = false, string playerName = "", int playerAvatar = 0)
        {
            InitializeComponent();
            editPlayer = edit;
            this.Title = "New Player";
            CreateButton.Content = "Create Player";
            if(editPlayer)
            {
                CreateButton.Content = "Edit Player";
                this.Title = "Edit Player \"" + playerName + "\""; 
            }
            avatarIndex = playerAvatar;
            PlayerNameBox.Text = playerName;
            originalPlayerName = playerName;
            AvatarSelect.Source = new BitmapImage(Avatar.Avatars[avatarIndex]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserManagementWindow window = new UserManagementWindow();
            window.Show();
        }

        private void PreviousAvatar_Click(object sender, RoutedEventArgs e)
        {
            --avatarIndex;
            if(avatarIndex == -1)
            {
                avatarIndex = Avatar.Avatars.Count - 1;
            }
            AvatarSelect.Source = new BitmapImage(Avatar.Avatars[avatarIndex]);
        }

        private void NextAvatar_Click(object sender, RoutedEventArgs e)
        {
            ++avatarIndex;
            if(avatarIndex == Avatar.Avatars.Count)
            {
                avatarIndex = 0;
            }
            AvatarSelect.Source = new BitmapImage(Avatar.Avatars[avatarIndex]);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = PlayerNameBox.Text;

            if(String.IsNullOrWhiteSpace(name))
            {
                System.Windows.MessageBox.Show("The name cannot be blank.", "Invalid name.");
                return;
            }

            foreach(char chara in "\\/:?<>|*\"")
            {
                if(name.Contains(chara))
                {
                    System.Windows.MessageBox.Show("The characters \\/:?<>|*\" are not permited.", "Invalid name.");
                    return;
                }
                
            }

            if(File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data/" + name)) && name != originalPlayerName)
            {
                System.Windows.MessageBox.Show("The name is taken.", "Invalid name.");
                return;
            }

            if(editPlayer)
            {
                List<string> originalContents = PlayersService.GenerateSaveContentForCurrentPlayer();

                List<string> newContents = new List<string>();
                newContents.Add(avatarIndex.ToString());

                bool ignoreFirst = true;
                foreach(var line in originalContents)
                {
                    if(ignoreFirst)
                    {
                        ignoreFirst = false;
                        continue;
                    }
                    newContents.Add(line);
                }

                File.Delete(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data/" + originalPlayerName));

                File.WriteAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data/" + name), newContents);
                PlayersService.Players[PlayersService.currentPlayerIndex].Name = name;
                PlayersService.Players[PlayersService.currentPlayerIndex].AvatarIndex = avatarIndex;
                this.Close();

                return;
            }

            List<string> contentLines = new List<string>()
            {
                avatarIndex.ToString() ,
                "0",
                "0",
                "0",
                "0",
                "0",
                "0"
            };

            File.WriteAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data/" + name), contentLines);
            Player newPlayer = new Player()
            {
                Name = name,
                AvatarIndex = avatarIndex,
                Wins = 0,
                TotalGames = 0,
                WinsHard = 0,
                TotalHardGames = 0,
                CorrectGuesses = 0,
                TotalGuesses = 0
            };

            PlayersService.AddPlayer(newPlayer);
            this.Close();

        }

    }
}
