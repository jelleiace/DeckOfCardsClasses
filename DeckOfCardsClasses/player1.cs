using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class player1
    {
        public string player1Name(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Card game 21.");
            Console.ResetColor();
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello, Player 1! please enter your name: ");
            Console.ResetColor();
            name = Console.ReadLine();
            Console.Clear();
            return name;
        }
        public void displayP1Hand(string p1Name, List<Card> p1Hand, int p1Sum)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{p1Name}'s Hand:");
            foreach (Card c in p1Hand)
                Console.WriteLine($"The Card is the {c.GetCardFace()} of {c.GetCardSuit()} with a value of {c.GetCardValue()}");
            Console.WriteLine($"Card Sum: {p1Sum}");
            Console.WriteLine();
            Console.ResetColor();
        }
        public string uInput()
        {
            string input = "";
            while (true)
            {
                input = Console.ReadLine().ToUpper();
                if (input == "H" || input == "S")
                    break;
                else
                    Console.WriteLine("Invalid input. Please input a valid move.");
            }

            return input;
        }
    }
}
