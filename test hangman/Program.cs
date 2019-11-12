using System;
using System.Collections.Generic;
using System.Text;

namespace test_hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            string[] wordBank = { "Blue", "Black", "Yellow", "Orange", "Green", "Purple", "Rainbow", "Grey", "Pink", "Red", "White" };

            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length); //måste fixa så man kan se sina ord man har gissat. frågan är vad i koden
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();
            //måste fixa så man kan gissa hela ord, och kanse så det inte tar upp mer än en liv, frågan är var i kode
            int lives = 10;
            Console.WriteLine(" your max guess: " + lives + "\n");
            Console.WriteLine("click 1 to guess on word or click 2 to guess whole word and enter");
            bool won = false;
            int lettersRevealed = 0;
            // displaya liv mängd. fixa då så visa fel orden.
            string input;
            char guess;
            var choose = Console.ReadLine();
            if (choose == "1")
            {
                while (!won && lives > 0)
                {
                    Console.Write("Guess a letter: ");

                    input = Console.ReadLine().ToUpper();
                    guess = input[0];

                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                        continue;
                    }

                    if (wordToGuessUppercase.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                            }
                        }

                        if (lettersRevealed == wordToGuess.Length)
                            won = true;
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);

                        Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                        lives--;
                        Console.WriteLine(" guess left: " + lives + "\n");
                    }

                    Console.WriteLine(displayToPlayer.ToString());
                }

                if (won)
                    Console.WriteLine("You won!");
                else
                    Console.WriteLine("You lost! It was '{0}'", wordToGuess);

                Console.Write("Press ENTER to exit...");
                Console.ReadLine();  // här under kommer för hela ordet gissning!
            }
            else if (choose == "2") 
            {
                while (!won && lives > 0)
                {
                    Console.WriteLine("guess the word");

                    input = Console.ReadLine().ToUpper();
                    guess = input[0];

                    //if ()
                }
            }
        }
            
    }
}