using HangmanGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Service
{
    public class GameService
    {
        private List<string> wordsToFind;
        public int WordIndex { get; set; }

        private Dictionary<char, bool> lettersFound;

        public string currentWordDisplay { get; set; }

        public GameService(int categorySelect = 0)
        {
            WordIndex = 0;
            wordsToFind = Words.PickWords(categorySelect);
            lettersFound = LetterDictionaryBuilder();
            DisplayWordUpdate();
        }

        public int CheckLetter(char input)
        {
            if(lettersFound.ContainsKey(input))
            {
                if(!lettersFound[input])
                {
                    DisplayWordUpdate(input);
                    lettersFound[input] = true;
                }

                foreach(var chara in lettersFound)
                {
                    if (!chara.Value)
                        return 1;
                }

                ++WordIndex;
                if(WordIndex!=Constants.MaxWordsPerRound)
                {
                    lettersFound = LetterDictionaryBuilder();
                    DisplayWordUpdate();
                }
                return 2;
            }
            return 0;
        }

        public string GetCurrentWord()
        {
            return wordsToFind[WordIndex];
        }

        private void DisplayWordUpdate(char input = '.')
        {
            if(input == '.')
            {
                currentWordDisplay = "";
                foreach(var chara in wordsToFind[WordIndex])
                {
                    if(chara == ' ')
                    {
                        currentWordDisplay += "  ";
                        continue;
                    }
                    currentWordDisplay += "- ";
                }
                return;
            }

            StringBuilder newString = new StringBuilder(currentWordDisplay);

            for (int index = 0; index < wordsToFind[WordIndex].Length; ++index)
            {
                if(wordsToFind[WordIndex][index] == input)
                {
                    newString[index * 2] = input;
                }
            }

            currentWordDisplay = newString.ToString();
        }

        private Dictionary<char,bool> LetterDictionaryBuilder()
        {
            Dictionary<char, bool> returned = new Dictionary<char, bool>();
            foreach(var chara in wordsToFind[WordIndex])
            {
                if(!returned.ContainsKey(chara) && chara != ' ')
                {
                    returned.Add(chara, false);
                }
            }
            return returned;
        }
    }
}
