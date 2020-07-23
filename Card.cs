using System;

namespace OOPDay1
{
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
            if (guess == color)
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

}
