using System;
using System.Dynamic;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace OOPDay1
{
    class Player
    {
        private string _name;
        private int _gold;
        private int _wins;
        const int startingGold = 100;

        public Player(string input)
        {
            _name = input;
            _gold = startingGold;
            _wins = 0;
        }

        public string Name
        {
            get 
            {
                return _name;
            }
        }

        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
            }
        }
        public int Wins
        {
            get
            {
                return _wins;
            }
        }

        public void AddWin()
        {
            _wins++;
        }

        public void DisplayPlayer()
        {
            Console.WriteLine($"Player: {_name}  Gold: {_gold}" );
        }

    }
    class Card
    {
        Random rand = new Random();
        
        private int _value;
        private string _suit;
        private bool isVisibile;
        private string backart;
        private string color;
        
        public Card(int num)
        {
            _value = num;
            int tempsuite = rand.Next(1, 5);
            switch (tempsuite)
            {
                case 1:
                    _suit = "Spades";
                    break;
                case 2:
                    _suit = "Hearts";
                    break;
                case 3:
                    _suit = "Clubs";
                    break;
                case 4:
                    _suit = "Diamonds";
                    break;
            }
            isVisibile = false;
            backart = "The scales of fate";
            if (_suit == "Spades" || _suit == "Clubs")
            {
                color = "Black";
            }
            else
            {
                color = "Red";
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
        }

        public string Suit
        {
            get
            {
                return _suit;
            }
        }
            

        public Card(string type)
        {
            _value = rand.Next(1, 14);
            _suit = type;
            isVisibile = false;
            backart = "The scales of fate";
            if (_suit == "Spades" || _suit == "Clubs")
            {
                color = "Black";
            }
            else
            {
                color = "Red";
            }
        }

        public Card()
        {
            _value = rand.Next(1, 14);
            int tempsuite = rand.Next(1, 5);
            switch (tempsuite)
            {
                case 1:
                    _suit = "Spades";
                    break;
                case 2:
                    _suit = "Hearts";
                    break;
                case 3:
                    _suit = "Clubs";
                    break;
                case 4:
                    _suit = "Diamonds";
                    break;
            }
            isVisibile = false;
            backart = "The scales of fate";
            if (_suit == "Spades" || _suit == "Clubs")
            {
                color = "Black";
            }
            else
            {
                color = "Red";
            }
        }

        public void DisplayCard()
        {
            if (isVisibile)
            {
                if (_value == 13)
                {
                    Console.WriteLine($"Your card is the King of {_suit}");
                }
                else if (_value == 12)
                {
                    Console.WriteLine($"Your card is the Queen of {_suit}");
                }
                else if (_value == 11)
                {
                    Console.WriteLine($"Your card is the Jack of {_suit}");
                }
                else if (_value == 1)
                {
                    Console.WriteLine($"Your card is the Ace of {_suit}");
                }
                else
                {
                    Console.WriteLine($"Your card is the {_value} of {_suit}");
                }
            }
            else
            {
                Console.WriteLine($"You only see the art on the back of the card which is {backart}");
            }
        }

        public void FlipCard()
        {
            if (isVisibile)
            {
                isVisibile = false;
            }
            else
            {
                isVisibile = true;
            }
        }

        public bool GuessColor(string guess)
        {
            if(guess == color)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GuessSuit(string guess)
        {
            if (guess == _suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GuessValue(int guess)
        {
            if (guess == _value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
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
                if(player1.Gold > 0)
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
            const int suitGuessCost = 15;
            const int valueGuessCost = 8;
            bool win = false;
            do
            {
                Console.WriteLine("");
                player1.DisplayPlayer();
                DisplayMenu(colorGuessCost,suitGuessCost, valueGuessCost);
                Console.Write($"Would you like to buy a hint? or guess the card? (C/S/V/G) ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C":
                        GuessColor(secretcard, player1, colorGuessCost);
                        break;
                    case "S":
                        GuessSuit(secretcard, player1, suitGuessCost);
                        break;
                    case "V":
                        GuessValue(secretcard, player1, valueGuessCost);
                        break;
                    case "G":
                        win = GuessCard(secretcard);
                        if (win)
                        {
                            player1.Gold = player1.Gold * 2;
                        }
                        else
                        {
                            if(player1.Gold > 33)
                            {
                                player1.Gold = player1.Gold / 2;
                            }
                            else
                            {
                                player1.Gold = 0;
                            }
                        }
                        break;
                }
            } while (!win || player1.Gold > 0);

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

        static void GuessColor(Card secretcard, Player activeplayer, int cost)
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

        static void GuessSuit(Card secretcard, Player activeplayer, int cost)
        {
            activeplayer.Gold = activeplayer.Gold - cost;
            Console.WriteLine("A hint about the Suit a card can be Diamons, Clubs, Heartsor Spades guess a suit and I will tell you if a card is that Suit");
            Console.Write("Diamons, Clubs, Hearts or Spades: ");
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
            activeplayer.Gold = activeplayer.Gold - cost;
            Console.WriteLine("A hint about the Value of the card a card Can be A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K guess a value and I will tell you higher or lower");
            Console.Write("A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K: ");
            string valueguess = Console.ReadLine();
            int num = ConvertGuessToValue(valueguess);
            CompareGuessToValue(num, secretcard);
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

        static void CompareGuessToValue(int guess, Card secretcard)
        {
            if (guess > secretcard.Value)
            {
                Console.WriteLine($"The Card is less than {guess}");
            }
            else if (guess == secretcard.Value)
            {
                Console.WriteLine($"The card is a {guess}");
            }
            else
            {
                Console.WriteLine($"The Card is more than {guess}");
            }
        }

    }
}
