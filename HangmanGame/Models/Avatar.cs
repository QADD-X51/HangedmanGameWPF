using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HangmanGame.Models
{
    public class Avatar
    {
        static public List<Uri> Avatars { get; set; } = new List<Uri>()
        {
            new Uri("pack://application:,,,/Resorces/Avatars/Edge.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Military.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Lizardman.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Epic Lizardman.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Alexandrion.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Spacedust.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Cephalon QADD.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/QADD Logo.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Gunter MLG.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Stanic Slayer.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/Popa.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/BinChiling.jpg"),
            new Uri("pack://application:,,,/Resorces/Avatars/ZhongXina.jpg")
        };

    }
}
