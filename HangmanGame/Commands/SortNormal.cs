using HangmanGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Commands
{
    public class SortNormal: IComparer<Player>
    {
        public int Compare(Player plr1, Player plr2)
        {
            if (plr1.Wins < plr2.Wins)
                return 1;

            if (plr1.Wins == plr2.Wins)
                return 0;

            return -1;
        }
    }
}
