using HangmanGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Commands
{
    public class SortTimed : IComparer<Player>
    {
        public int Compare(Player plr1, Player plr2)
        {
            if (plr1.WinsHard < plr2.WinsHard)
                return 1;

            if (plr1.WinsHard == plr2.WinsHard)
                return 0;

            return -1;
        }
    }
}
