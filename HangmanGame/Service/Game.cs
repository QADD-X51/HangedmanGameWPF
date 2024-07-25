using HangmanGame.Commands;
using HangmanGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HangmanGame.Service
{
    public class Game : INotifyPropertyChanged
    {
        private int totalGuesses;
        private int totalMistakes;

        DispatcherTimer threadCountdown = new DispatcherTimer();
        public Game()
        {
            threadCountdown.Interval = TimeSpan.FromSeconds(1);
            threadCountdown.Tick += CountDown;
        }

        private void CountDown(object sender, EventArgs e)
        {
            if(--SecondsLeft == 0)
            {
                faces.DeathAnimation();
                GameOver(false);
            }
        }

        static public int gameState = 0;

        private int _secondsLeft;
        public int SecondsLeft
        {
            get
            {
                return _secondsLeft;
            }
            set
            {
                _secondsLeft = value;
                OnPropertyChanged("SecondsLeft");          
            }
        }

        static public int _mistakes = 0;
        public int Mistake
        {
            get
            {
                return _mistakes;
            }
            set
            {
                _mistakes = value;
                OnPropertyChanged("Mistake");
            }
        }

        public GameService GameLogic { get; set; }

        public int CategorySelected { get; set; } = 0;

        static private string _currentDisplayedWord;
        public string CurrentDisplayedWord
        {
            get
            {
                return _currentDisplayedWord;
            }
            set
            {
                _currentDisplayedWord = value;
                OnPropertyChanged("CurrentDisplayedWord");
            }
        }


        private ICommand checkLetter;
        public ICommand CheckLetter
        {
            get
            {
                if (checkLetter == null)
                {
                    checkLetter = new RelayCommand(LetterCheck);
                }
                return checkLetter;
            }
        }

        public void LetterCheck(object INPUT)
        {
            if (gameState == 0)
                return;

            char input = ((string)INPUT)[0];
            int result = GameLogic.CheckLetter(input);
            ++totalGuesses;

            if (result == 1)
            {
                CurrentDisplayedWord = GameLogic.currentWordDisplay;
                faces.YeahAnimation();
                MainGame.CorrectButton(input);
                return;
            }

            if(result == 2)
            {
                CurrentDisplayedWord = GameLogic.currentWordDisplay;
                faces.YeahAnimation();
                if (GameLogic.WordIndex == Constants.MaxWordsPerRound)
                {
                    GameOver(true);
                    return;
                }
                MainGame.ResetAllButtons();
                Mistake = 0;
                SecondsLeft += Constants.TimerAddAfterRound;
                return;
            }

            MainGame.WrongButton(input);
            ++totalMistakes;

            if(++Mistake == Constants.MaxMistakesPerRound)
            {
                faces.DeathAnimation();
                GameOver(false);
                return;
            }
            faces.HurtAnimation();

        }

        private Faces faces = new Faces();

        public Faces Face
        {
            get 
            {
                return faces;
            }
            set
            {
                faces = value;
                OnPropertyChanged("Face");
            }
        }
        
        private void GameOver(bool win, bool showMessage = true)
        {
            bool timed = gameState == 1 ? false : true;

            gameState = 0;
            threadCountdown.Stop();

            if (timed) ++PlayersService.Players[PlayersService.currentPlayerIndex].TotalHardGames;
            else ++PlayersService.Players[PlayersService.currentPlayerIndex].TotalGames;

            PlayersService.Players[PlayersService.currentPlayerIndex].TotalGuesses += totalGuesses;
            PlayersService.Players[PlayersService.currentPlayerIndex].CorrectGuesses += totalGuesses - totalMistakes;

            if (win)
            {
                if (timed) ++PlayersService.Players[PlayersService.currentPlayerIndex].WinsHard;
                else ++PlayersService.Players[PlayersService.currentPlayerIndex].Wins;

                PlayersService.GenerateSaveFileForCurrentPlayer();
                if(showMessage) MessageBox.Show("You're winner!", "Congratiutations!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            PlayersService.GenerateSaveFileForCurrentPlayer();
            if(showMessage) MessageBox.Show("You get nothing! You lose! Good day, sir!", "Ded", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void GameAbandoned()
        {
            if (gameState == 0)
                return;

            GameOver(false, false);
        }

        public void NewGame(bool timed)
        {
            if(gameState > 0)
            {
                if (MessageBox.Show("Are you sure you want to satrt a new game? Your previous game will be counted as lost.", "Warrning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    return;
                GameOver(false, false);
            }
            gameState = timed == false ?  1 : 2;
            totalGuesses = 0;
            totalMistakes = 0;
            Mistake = 0;
            SecondsLeft = Constants.InitialTimer;

            MainGame.ResetAllButtons();
            faces.IdleStart();

            GameLogic = new GameService(CategorySelected);
            CurrentDisplayedWord = GameLogic.currentWordDisplay;

            if (timed) threadCountdown.Start();
        }

        private bool canExecuteCommand = true;
        public bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }

            set
            {
                if (canExecuteCommand == value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
