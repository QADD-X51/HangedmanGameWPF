using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Models
{
    static public class Words
    {
        static public List<string> CarsWords = File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Words Data/Cars.txt")).ToList();
        static public List<string> CountriesWords = File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Words Data/Countries.txt")).ToList();
        static public List<string> GamesWords = File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Words Data/Games.txt")).ToList();
        static public List<string> HouseItemsWords = File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Words Data/House Items.txt")).ToList();
        static public List<string> MiscWords = File.ReadAllLines(System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Data/Words Data/Others.txt")).ToList();

        static public List<string> PickWords(int choice = 0)
        {
            List<string> returned = new List<string>();
            Dictionary<int, bool> usedWord;
            Random random = new Random();
            int wordToPick;
            int size;
            int wordsAdded = 0;

            switch(choice)
            {
                case 1: //Cars
                    size = CarsWords.Count;
                    usedWord = DirectoryBuilder(size);

                    while (wordsAdded != Constants.MaxWordsPerRound)
                    {
                        if (wordsAdded == size)
                            break;

                        wordToPick = random.Next(0, size);

                        if (usedWord[wordToPick])
                        {
                            usedWord[wordToPick] = false;
                            returned.Add(CarsWords[wordToPick].ToUpper());
                            ++wordsAdded;
                            continue;
                        }

                        for (int index = wordToPick + 1; wordToPick != index; ++index)
                        {
                            if (index == size)
                                index = 0;

                            if (usedWord[index])
                            {
                                usedWord[index] = false;
                                returned.Add(CarsWords[index].ToUpper());
                                ++wordsAdded;
                                break;
                            }
                        }
                    }
                    break;
                case 2:  //Country
                    size = CountriesWords.Count;
                    usedWord = DirectoryBuilder(size);

                    while (wordsAdded != Constants.MaxWordsPerRound)
                    {
                        if (wordsAdded == size)
                            break;

                        wordToPick = random.Next(0, size);

                        if (usedWord[wordToPick])
                        {
                            usedWord[wordToPick] = false;
                            returned.Add(CountriesWords[wordToPick].ToUpper());
                            ++wordsAdded;
                            continue;
                        }

                        for (int index = wordToPick + 1; wordToPick != index; ++index)
                        {
                            if (index == size)
                                index = 0;

                            if (usedWord[index])
                            {
                                usedWord[index] = false;
                                returned.Add(CountriesWords[index].ToUpper());
                                ++wordsAdded;
                                break;
                            }
                        }
                    }
                    break;
                case 3:  //Games
                    size = GamesWords.Count;
                    usedWord = DirectoryBuilder(size);

                    while (wordsAdded != Constants.MaxWordsPerRound)
                    {
                        if (wordsAdded == size)
                            break;

                        wordToPick = random.Next(0, size);

                        if (usedWord[wordToPick])
                        {
                            usedWord[wordToPick] = false;
                            returned.Add(GamesWords[wordToPick].ToUpper());
                            ++wordsAdded;
                            continue;
                        }

                        for (int index = wordToPick + 1; wordToPick != index; ++index)
                        {
                            if (index == size)
                                index = 0;

                            if (usedWord[index])
                            {
                                usedWord[index] = false;
                                returned.Add(GamesWords[index].ToUpper());
                                ++wordsAdded;
                                break;
                            }
                        }
                    }
                    break;
                case 4:  //HouseItems
                    size = HouseItemsWords.Count;
                    usedWord = DirectoryBuilder(size);

                    while (wordsAdded != Constants.MaxWordsPerRound)
                    {
                        if (wordsAdded == size)
                            break;

                        wordToPick = random.Next(0, size);

                        if (usedWord[wordToPick])
                        {
                            usedWord[wordToPick] = false;
                            returned.Add(HouseItemsWords[wordToPick].ToUpper());
                            ++wordsAdded;
                            continue;
                        }

                        for (int index = wordToPick + 1; wordToPick != index; ++index)
                        {
                            if (index == size)
                                index = 0;

                            if (usedWord[index])
                            {
                                usedWord[index] = false;
                                returned.Add(HouseItemsWords[index].ToUpper());
                                ++wordsAdded;
                                break;
                            }
                        }
                    }
                    break;
                case 5:  // Misc
                    size = MiscWords.Count;
                    usedWord = DirectoryBuilder(size);

                    while (wordsAdded != Constants.MaxWordsPerRound)
                    {
                        if (wordsAdded == size)
                            break;

                        wordToPick = random.Next(0, size);

                        if (usedWord[wordToPick])
                        {
                            usedWord[wordToPick] = false;
                            returned.Add(MiscWords[wordToPick].ToUpper());
                            ++wordsAdded;
                            continue;
                        }

                        for (int index = wordToPick + 1; wordToPick != index; ++index)
                        {
                            if (index == size)
                                index = 0;

                            if (usedWord[index])
                            {
                                usedWord[index] = false;
                                returned.Add(MiscWords[index].ToUpper());
                                ++wordsAdded;
                                break;
                            }
                        }
                    }
                    break;
                default: //All
                    size = MiscWords.Count + CountriesWords.Count + CarsWords.Count + HouseItemsWords.Count + GamesWords.Count;
                    usedWord = DirectoryBuilder(size);

                    while (wordsAdded != Constants.MaxWordsPerRound)
                    {
                        if (wordsAdded == size)
                            break;

                        wordToPick = random.Next(0, size);

                        if (usedWord[wordToPick])
                        {
                            usedWord[wordToPick] = false;
                            returned.Add(AddWordAll(wordToPick).ToUpper());
                            ++wordsAdded;
                            continue;
                        }

                        for (int index = wordToPick + 1; wordToPick != index; ++index)
                        {
                            if (index == size)
                                index = 0;

                            if (usedWord[index])
                            {
                                usedWord[index] = false;
                                returned.Add(AddWordAll(index).ToUpper());
                                ++wordsAdded;
                                break;
                            }
                        }
                    }
                    break;
            }

            return returned;
        }

        static private Dictionary<int, bool> DirectoryBuilder(int size)
        {
            Dictionary<int, bool> returned = new Dictionary<int, bool>();

            for(int index=0;index<size;++index)
            {
                returned.Add(index, true);
            }

            return returned;
        }

        static private string AddWordAll(int index)
        {
            int prev_size = 0;
            int size = CarsWords.Count;
            if (index < size)
                return CarsWords[index];

            prev_size = size;
            size += CountriesWords.Count;
            if (index < size)
                return CountriesWords[index - prev_size];

            prev_size = size;
            size += GamesWords.Count;
            if (index < size)
                return GamesWords[index - prev_size];

            prev_size = size;
            size += HouseItemsWords.Count;
            if (index < size)
                return HouseItemsWords[index - prev_size];

            return MiscWords[index - size];
        }
    }
}
