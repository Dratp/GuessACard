using System;
using System.Dynamic;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace OOPDay1
{
    class Program
    {
       static void Main(string[] args)
        {
            GuesstheCard game = new GuesstheCard();
            game.StartGame();
        }
    }
}
