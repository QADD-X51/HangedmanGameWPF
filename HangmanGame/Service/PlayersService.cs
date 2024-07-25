using HangmanGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Service
{
    static public class PlayersService
    {
        static public ObservableCollection<Player> Players { get; set; } = new ObservableCollection<Player>();
        static public int currentPlayerIndex;

        static public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        static public void RemovePlayer(int index)
        {
            Players.RemoveAt(index);
        }

        static public List<string> GenerateSaveContentForCurrentPlayer()
        {
            return new List<string>(File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data/" + Players[currentPlayerIndex].Name)).ToList());
        }

        static public void GenerateSaveFileForCurrentPlayer()
        {
            List<string> content = new List<string>()
            {
                Players[currentPlayerIndex].AvatarIndex.ToString(),
                Players[currentPlayerIndex].Wins.ToString(),
                Players[currentPlayerIndex].TotalGames.ToString(),
                Players[currentPlayerIndex].WinsHard.ToString(),
                Players[currentPlayerIndex].TotalHardGames.ToString(),
                Players[currentPlayerIndex].CorrectGuesses.ToString(),
                Players[currentPlayerIndex].TotalGuesses.ToString()
                
            };

            File.WriteAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Player Data/" + Players[currentPlayerIndex].Name), content);
        }

        
    }
}
