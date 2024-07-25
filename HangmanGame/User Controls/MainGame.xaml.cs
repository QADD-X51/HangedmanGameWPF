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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangmanGame
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : UserControl
    {
        public Game game;
        private static Dictionary<char, Button> LetterMapping = new Dictionary<char, Button>();
        public MainGame()
        {
            InitializeComponent();
            if(LetterMapping.Count == 0)
                DictionaryBuilder();
            game = new Game();
            MainGameGrid.DataContext = game;
        }

        private void DictionaryBuilder()
        {
            LetterMapping.Add('Q', QButton);
            LetterMapping.Add('W', WButton);
            LetterMapping.Add('E', EButton);
            LetterMapping.Add('R', RButton);
            LetterMapping.Add('T', TButton);
            LetterMapping.Add('Y', YButton);
            LetterMapping.Add('U', UButton);
            LetterMapping.Add('I', IButton);
            LetterMapping.Add('O', OButton);
            LetterMapping.Add('P', PButton);

            LetterMapping.Add('A', AButton);
            LetterMapping.Add('S', SButton);
            LetterMapping.Add('D', DButton);
            LetterMapping.Add('F', FButton);
            LetterMapping.Add('G', GButton);
            LetterMapping.Add('H', HButton);
            LetterMapping.Add('J', JButton);
            LetterMapping.Add('K', KButton);
            LetterMapping.Add('L', LButton);

            LetterMapping.Add('Z', ZButton);
            LetterMapping.Add('X', XButton);
            LetterMapping.Add('C', CButton);
            LetterMapping.Add('V', VButton);
            LetterMapping.Add('B', BButton);
            LetterMapping.Add('N', NButton);
            LetterMapping.Add('M', MButton);
        }

        static private Button LetterButton(char input)
        {
            return LetterMapping[input];
        }

        static public void ResetAllButtons()
        {
            for(char chara = 'A'; chara <='Z'; ++chara)
            {
                LetterButton(chara).Foreground = Brushes.Black;
                LetterButton(chara).IsEnabled = true;
            }
        }

        static public void CorrectButton(char input)
        {
            LetterButton(input).Foreground = Brushes.Cyan;
            LetterButton(input).IsEnabled = false;
        }

        static public void WrongButton(char input)
        {
            LetterButton(input).Foreground = Brushes.OrangeRed;
            LetterButton(input).IsEnabled = false;
        }
    }
}
