using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class gameState
    {
        public void initializeMessage(string p1Name)
        {
            Console.WriteLine($"Hello, {p1Name}! The game will start in a while. . .");
            Console.WriteLine("Initializing deck. . .");
            Thread.Sleep(2500);
            Console.WriteLine("Initializing players. . .");
            Thread.Sleep(2500);
            Console.WriteLine("Drawing cards for the players. . .");
            Thread.Sleep(2500);
            Console.Clear();
        }
        public Card playerHand(List<Card> cardHand)
        {
            Card playHand = cardHand[0];
            cardHand.RemoveAt(0);
            return playHand;
        }
        public int cardSum(List<Card> cardHand)
        {
            int playerSum = 0;
            for (int x = 0; x < cardHand.Count; x++)
                playerSum += cardHand[x].GetCardValue();

            return playerSum;
        }
        public string hitOrstand(int playerSum, string player)
        {
            string choice = "";
            if (playerSum > 16)
                choice = "S";
            else
                choice = "H";
            Console.WriteLine($"\n{player} is thinking. . .");
            Thread.Sleep(3000);
            return choice;
        }
        public bool checkPlayerState(int playerSum)
        {
            bool winFlag = true;
            if (playerSum > 21)
                winFlag = false;
            return winFlag;
        }
        public string check21Win(int p1Sum, int cpuSum, int dealSum, List<string> players)
        {
            string winner = "";
            if (p1Sum == 21) //player 1 win
                winner = players[0];
            else if (cpuSum == 21) //dealer win
                winner = players[1];
            else if (dealSum == 21) //dealer win
                winner = players[2];
            return winner;
        }
        public string comparePlayerValues(int p1Sum, int cpuSum, int dealSum, List<string> players)
        {
            string winner = "";
            if (p1Sum > dealSum && p1Sum > cpuSum) //player 1 win
                winner = players[0];
            else if (cpuSum > dealSum && cpuSum > p1Sum) //computer win
                winner = players[1];
            else if (dealSum > p1Sum && dealSum > cpuSum) //dealer win
                winner = players[2];
            else if (p1Sum == dealSum && cpuSum == dealSum && cpuSum == p1Sum)
                winner = "None";
            return winner;
        }
    }
}
