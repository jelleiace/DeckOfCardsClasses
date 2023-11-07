using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class dealer
    {
        public void displaydealerHand(List<Card> dealHand, int dealSum, string playerTurn)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Dealer's Hand:");
            for (int x = 0; x < dealHand.Count; x++)
            {
                if(playerTurn != "Dealer")
                {
                    if (x != dealHand.Count - 1)
                        Console.WriteLine($"The Card is the {dealHand[x].GetCardFace()} of {dealHand[x].GetCardSuit()} " +
                                          $"with a value of {dealHand[x].GetCardValue()}");
                    else
                        Console.WriteLine("The Card is currently hidden.");
                }
                else
                    Console.WriteLine($"The Card is the {dealHand[x].GetCardFace()} of {dealHand[x].GetCardSuit()} " +
                                      $"with a value of {dealHand[x].GetCardValue()}");
            }
            if (playerTurn == "Dealer")
                Console.WriteLine($"Card Sum: {dealSum}");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
