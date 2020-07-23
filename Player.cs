using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine($"Player: {_name}  Gold: {_gold}");
        }

    }
}
