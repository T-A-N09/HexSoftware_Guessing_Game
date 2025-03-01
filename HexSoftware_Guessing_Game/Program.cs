using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexSoftware_Guessing_Game
{
    class Program
    {
        private static Random Guess = new Random();
        static void Main(string[] args)
        {
            char cOption;

            do
            {
                //The title method
                TitleMenu();

                //User prompt
                Console.Write("Option : ");
                cOption = char.Parse(Console.ReadLine().ToUpper());

                //Difficulty method 
                Difficulty(cOption);

            } while (cOption != 'X'); //Program will keep running until user enters 'X'

            //Exit message
            Console.Write("Thank you for playing our game.\nPress any key to exit...");
            Console.ReadKey();
        }

        //Displays the title as well as the gaming options to choose from 
        private static void TitleMenu()
        {
            Console.WriteLine("".PadLeft(30, '-') + "Welcome to the Guessing Game" + "".PadRight(30, '-'));

            Console.WriteLine("Choose the difficulty of this game you wish to play");
            Console.WriteLine("\tEasy - E");
            Console.WriteLine("\tNormal - N");
            Console.WriteLine("\tHard - H");
            Console.WriteLine("\tVery Hard - V");
            Console.WriteLine("\tImpossible - I");
            Console.WriteLine("\tExit - X");
        }

        private static void Difficulty(char cOption)
        {
            int iAdapt;
            int iLimit;

            switch (cOption)
            {
                case 'E':
                    iAdapt = EasyMode() + 0; //Random variable set to range from 1-10
                    iLimit = 10; //Easy mode gives you 10 attempts to guess the right number

                    Console.WriteLine("You have 10 attempts to guess the number.");
                    Console.WriteLine("Your number is between 1-10");
                    Play(iAdapt, iLimit);
                    break;
                case 'N':
                    iAdapt = NormalMode() + 0; //Random variable set to range from 1-25
                    iLimit = 9; //Normal mode gives you 9 attempts to guess the right number

                    Console.WriteLine("You have 9 attempts to guess the number.");
                    Console.WriteLine("Your number is between 1-25");
                    Play(iAdapt, iLimit);
                    break;
                case 'H':
                    iAdapt = HardMode() + 0; //Random variable set to range from 1-50
                    iLimit = 8; //Hard mode gives you 8 attempts to guess the right number

                    Console.WriteLine("You have 8 attempts to guess the number.");
                    Console.WriteLine("Your number is between 1-50");
                    Play(iAdapt, iLimit);
                    break;
                case 'V':
                    iAdapt = VeryHardMode() + 0; //Random variable set to range from 1-75
                    iLimit = 7; //Very hard mode gives you 7 attempts to guess the right number

                    Console.WriteLine("You have 7 attempts to guess the number.");
                    Console.WriteLine("Your number is between 1-75");
                    Play(iAdapt, iLimit);
                    break;
                case 'I':
                    iAdapt = ImpossibleMode() + 0; //Random variable set to range from 1-100
                    iLimit = 5; //Impossible mode gives you 5 attempts to guess the right number

                    Console.WriteLine("You have 5 attempts to guess the number.");
                    Console.WriteLine("Your number is between 1-100");
                    Play(iAdapt, iLimit);
                    break;
            }
        }

        private static int EasyMode()
        {
            return Guess.Next(1, 10);
        } //Easy mode method

        private static int NormalMode()
        {
            return Guess.Next(1, 25);
        } //Normal mode method

        private static int HardMode()
        {
            return Guess.Next(1, 50);
        } //Hard mode method

        private static int VeryHardMode()
        {
            return Guess.Next(1, 75);
        } //Very hard mode method

        private static int ImpossibleMode()
        {
            return Guess.Next(1, 100);
        } //Impossible mode method

        private static void Play(int iAdapt, int iLimit)
        {
            int iGuess;
            int iAttempt = 0;

            Console.Clear();
            Console.WriteLine("The random number is : " + iAdapt);

            do
            {
                Console.WriteLine("Attempts: {0} ", iLimit);

                //If you get 3 tries wrong
                if (iAttempt >= 3)
                {
                    Console.WriteLine("Enter '1000' if you give up...");
                }
                
                //User prompt
                Console.Write("Enter your guess: ");
                iGuess = int.Parse(Console.ReadLine());

                //If you did not entered '1000' to give up on your game
                if (iGuess != 1000)
                {
                    System(iGuess, iAdapt);

                    //For every attempt taken, your attempt decrease
                    iLimit--;
                }
                else //If you entered '1000' to give up on your game
                {
                    Console.WriteLine("You could have won, you know...");
                }

                //If you ran out of attempts
                if (iLimit == 0) 
                {
                    Console.WriteLine();
                    Console.WriteLine("You are out of attempts.");
                    Console.WriteLine("Your number was " + iAdapt);
                }

                Console.WriteLine();

                //For every attempt taken, your tries increase
                iAttempt++;

            } while (iGuess != iAdapt && iGuess != 1000 && iLimit != 0);
        }

        //Method of prompts displayed depending on the gap between you and the right number
        private static void System(int i, int iAdapt) 
        {
            if (i > iAdapt && i - iAdapt >= 40) //If gap is 40 and above
            {
                Console.WriteLine("You are extremely high, try again.");
            }
            else if (i > iAdapt && i - iAdapt >= 30) //If gap is 30 - 39 above it
            {
                Console.WriteLine("You are very high, go at it again.");
            }
            else if (i > iAdapt && i - iAdapt >= 15) //If gap is 15 - 29 above it
            {
                Console.WriteLine("You are high, but not that far.");
            }
            else if (i > iAdapt && i - iAdapt >= 10) //If gap is 10 - 14 above it
            {
                Console.WriteLine("You are close, keep trying.");
            }
            else if (i > iAdapt && i - iAdapt >= 5) //If gap is 5 - 9 above it
            {
                Console.WriteLine("You are very close, keep trying.");
            }
            else if (i > iAdapt && i - iAdapt >= 1) //If gap is 1 - 4 above it
            {
                Console.WriteLine("You are extremely close, don't give up!");
            }
            else if (i < iAdapt && i - iAdapt >= -1) //If gap is 1 - 4 below it
            {
                Console.WriteLine("You are extremely close, try again.");
            }
            else if (i < iAdapt && i - iAdapt >= -5) //If gap is 5 - 9 below it
            {
                Console.WriteLine("You are very close, keep trying.");
            }
            else if (i < iAdapt && i - iAdapt >= -10) //If gap is 10 - 14 below it
            {
                Console.WriteLine("You are close, keep trying.");
            }
            else if (i < iAdapt && i - iAdapt >= -15) //If gap is 15 - 29 below it
            {
                Console.WriteLine("You are low, but not that far.");
            }
            else if (i < iAdapt && i - iAdapt >= -30) //If gap is 30 - 39 below it
            {
                Console.WriteLine("You are very low, keep trying.");
            }
            else if (i < iAdapt && i - iAdapt >= -40) //If gap is 40 and below
            {
                Console.WriteLine("You are extremely low, try again.");
            }
            else if (i == iAdapt) // If your guess is correct
            {
                Console.WriteLine("Congratulations...");
            }
        }
    }
}
