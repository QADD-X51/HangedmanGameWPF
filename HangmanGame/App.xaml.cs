using HangmanGame.Models;
using HangmanGame.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HangmanGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DirectoryInfo dir = new DirectoryInfo(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data"));
            foreach (var file in dir.GetFiles())
            {
                List<string> playerContent = File.ReadAllLines(file.FullName).ToList();

                Player newPlayer = new Player()
                {
                    Name = file.Name,
                    AvatarIndex = Int32.Parse(playerContent[0]),
                    Wins = Int32.Parse(playerContent[1]),
                    TotalGames = Int32.Parse(playerContent[2]),
                    WinsHard = Int32.Parse(playerContent[3]),
                    TotalHardGames = Int32.Parse(playerContent[4]),
                    CorrectGuesses = Int32.Parse(playerContent[5]),
                    TotalGuesses = Int32.Parse(playerContent[6])
                };

                PlayersService.AddPlayer(newPlayer);
            }
        }
    }
}
