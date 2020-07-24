using System;
using System.Collections.Generic;
using System.Text;

namespace OOPDay1
{
    class GuesstheCard
    {
        public void StartGame()
        {

            Console.Write("What is your name player: ");
            string name = Console.ReadLine();
            Player player1 = new Player(name);
            Console.Clear();
            string playagain = "";

            do
            {
                Card mycard = new Card();
                Console.WriteLine($"A playing card has been set before you {player1.Name}");
                mycard.DisplayCard();
                PlayGame(player1, mycard);
                if (player1.Gold > 0)
                {
                    playagain = GetYesOrNo("Do you want to play again? y/n");
                }
                else
                {
                    playagain = "N";
                }
            } while (playagain == "Y");

        }

        static void PlayGame(Player player1, Card secretcard)
        {
            const int colorGuessCost = 20;
            const int suitGuessCost = 11;
            const int valueGuessCost = 7;
            bool win = false;
            do
            {
                Console.WriteLine("");
                player1.DisplayPlayer();
                DisplayMenu(colorGuessCost, suitGuessCost, valueGuessCost);
                Console.Write($"Would you like to buy a hint? or guess the card? (C/S/V/G) ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C":
                        Console.Clear();
                        GuessColor(secretcard, player1, colorGuessCost);
                        break;
                    case "S":
                        Console.Clear();
                        GuessSuit(secretcard, player1, suitGuessCost);
                        break;
                    case "V":
                        Console.Clear();
                        GuessValue(secretcard, player1, valueGuessCost);
                        break;
                    case "G":
                        Console.Clear();
                        win = GuessCard(secretcard);
                        if (win)
                        {
                            Console.WriteLine("You won, Doubling your gold as promised");
                            player1.Gold = player1.Gold * 2;
                        }
                        else
                        {
                            Console.WriteLine("That is not the Card!");
                            if (player1.Gold > 33)
                            {
                                player1.Gold = player1.Gold / 2;
                            }
                            else
                            {
                                player1.Gold = 0;
                            }
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Your talking gibberish that is not a choice...\n I am taking 2g from you for wasting my time");
                            player1.Gold = player1.Gold - 2;
                            break;
                        }
                }

            } while (!win && player1.Gold > 0);

            if (player1.Gold <= 0)
            {
                Console.WriteLine("Seems like you have run out of gold; Without that you can no longer play...");
            }

            secretcard.FlipCard();
            secretcard.DisplayCard();
            player1.DisplayPlayer();
        }

        static string GetYesOrNo(string question)
        {
            while (true)
            {
                Console.Write(question);
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y" || answer == "N" || answer == "YES" || answer == "NO")
                {
                    return answer;
                }
                else
                {
                    Console.WriteLine("That was not a valid input");
                }
            }

        }    // Takes a question prints it out and returns only a "Y" or a "N" from the user

        static bool GuessCard(Card secretcard)
        {
            bool correct = false;
            string suit;
            string value;
            Console.WriteLine("Ahh you think you know the card...");
            Console.Write("Suite: ");
            suit = Console.ReadLine();
            Console.Write("Value: ");
            value = Console.ReadLine();
            int valuenum = ConvertGuessToValue(value);
            if (secretcard.GuessSuit(suit) && secretcard.GuessValue(valuenum))
            {
                correct = true;
            }
            return correct;
        }

        static bool CheckAfford(Player activeplayer, int cost)
        {
            if (activeplayer.Gold >+cost)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Seems like your ambition does not match your coin!");
                return false;
            }
        }

        static void GuessColor(Card secretcard, Player activeplayer, int cost)
        {
            if (CheckAfford(activeplayer, cost)) 
            {
                activeplayer.Gold = activeplayer.Gold - cost;
                Console.WriteLine("A hint about color a card can be black or red, guess a color and I will tell you if a card is that color");
                Console.Write("Red or Black: ");
                string colorguess = Console.ReadLine();
                if (secretcard.GuessColor(colorguess))
                {
                    Console.WriteLine($"The card is {colorguess}");
                }
                else
                {
                    Console.WriteLine($"The card is not {colorguess}");
                }
            }
            
        }

        static void GuessSuit(Card secretcard, Player activeplayer, int cost)
        {
            if (CheckAfford(activeplayer, cost))
            {
                activeplayer.Gold = activeplayer.Gold - cost;
                Console.WriteLine("Diamonds\nClubs\nHearts\nSpades");
                Console.Write("Guess a suit and I will tell you if a card is that Suit: ");
                string suitguess = Console.ReadLine();
                if (secretcard.GuessSuit(suitguess))
                {
                    Console.WriteLine($"The card is {suitguess}");
                }
                else
                {
                    Console.WriteLine($"The card is not {suitguess}");
                }
            }
        }

        static void DisplayMenu(int color, int suit, int value)
        {
            Console.WriteLine($"C = Color Hint cost {color}g");
            Console.WriteLine($"S = Suit Hint cost {suit}g");
            Console.WriteLine($"V = Value Hint cost {value}g");
            Console.WriteLine($"G = Guess the card if correct double your gold...");
            Console.WriteLine($"      but if wrong lose 33g or half your gold which ever is more.");
        }

        static void GuessValue(Card secretcard, Player activeplayer, int cost)
        {
            if (CheckAfford(activeplayer, cost))
            {
                activeplayer.Gold = activeplayer.Gold - cost;
                Console.WriteLine("A hint about the Value of the card... \nA card Can be A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K");
                Console.Write("Guess a value and I will tell you higher or lower: ");
                string valueguess = Console.ReadLine();
                int num = ConvertGuessToValue(valueguess);
                CompareGuessToValue(num, secretcard, valueguess);
            }

        }

        static int ConvertGuessToValue(string guess)
        {
            int num = 0;
            bool isValid = false;
            if (guess == "K")
            {
                num = 13;
            }
            else if (guess == "Q")
            {
                num = 12;
            }
            else if (guess == "J")
            {
                num = 11;
            }
            else if (guess == "A")
            {
                num = 1;
            }
            else
            {
                isValid = int.TryParse(guess, out num);
                if (!isValid)
                {
                    num = 0;
                }
            }
            return num;
        }

        static void CompareGuessToValue(int guess, Card secretcard, string userguess)
        {
            if (guess == 0)
            {
                Console.WriteLine($"The card is not {userguess} as that does not even make sense");
            }
            else if (guess > secretcard.Value)
            {
                Console.WriteLine($"The Card is less than {userguess}");
            }
            else if (guess == secretcard.Value)
            {
                Console.WriteLine($"The card is a {userguess}");
            }
            else
            {
                Console.WriteLine($"The Card is more than {userguess}");
            }
        }
    }
}
