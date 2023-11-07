using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class cpu
    {
        public void displaycpuHand(List<Card> cpuHand, int cpuSum)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Computer's Hand:");
            foreach (Card c in cpuHand)
                Console.WriteLine($"The Card is the {c.GetCardFace()} " +
                                  $"of {c.GetCardSuit()} with a value " +
                                  $"of {c.GetCardValue()}");
            Console.WriteLine($"Card Sum: {cpuSum}");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
