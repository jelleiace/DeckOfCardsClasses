using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2Y_OOP_2324_ADeckOfCards
{
    //LECTURE NOTES (static and instancing)
    //static things can be called by static and non-static objects
    //static objects cannot be called by non-static things (ex. int, string)
    //constructors are written by applying the class name to the method name
    //constructors are ALWAYS public
    //constructors automatically know what is being called based on the method parameters in method overload

    //  PROG FLOW
    //main menu: insert player name to start
    //ini deck [DONE]
    //ini player1, cpu player 2, dealer [DONE]
    //draw 1 card for p1, p2, dealer (ALL SHOW) [DONE]
    //draw 1 more card for p1, p2, dealer (dealer only: hidden) [DONE]
    //ask each player to hit/stand [DONE]
    //  if hit:
    //  -draw card [DONE]
    //  -get card sum [DONE]
    //  -go back to asking the player [DONE]
    //FOR HIT LOGIC
    //create a checker for comparing card sum total [DONE]

    //  if stand:
    //  -move on to next player [DONE]
    //once p1 and p2 are done, reveal dealer card [DONE]
    //dealer will also hit/stand [DONE]
    //display game winners and losers
    internal class Program
    {
        static void Main(string[] args)
        {
            //initialize game
            player1 p1 = new player1();
            cpu cpu = new cpu();
            dealer d = new dealer();
            DeckOfCards doc = new DeckOfCards(true);
            gameState gs = new gameState();

            string p1Name = "";
            p1Name = p1.player1Name("");

            //drawing cards for each player
            int startCount = 0;
            List<Card> p1Hand = new List<Card>();
            List<Card> cpuHand = new List<Card>();
            List<Card> dealer = new List<Card>();
            List<Card> hand = new List<Card>();
            hand = doc.drawACard(6);
            while (startCount < 2)
            {
                p1Hand.Add(gs.playerHand(hand));
                cpuHand.Add(gs.playerHand(hand));
                dealer.Add(gs.playerHand(hand));
                startCount++;
            }

            //start game
            gs.initializeMessage(p1Name);
            List<string> playerTurn = new List<string> { p1Name, "Computer", "Dealer" };
            List<string> moveHistory = new List<string>();
            string choice = "";
            int x = 0;
            int p1Sum = 0;
            int cpuSum = 0;
            int dealerSum = 0;
            int currPlayerSum = 0;
            bool checkAgain = true;
            bool winFlag = true;
            while (x < playerTurn.Count)
            {
                p1Sum = gs.cardSum(p1Hand);
                cpuSum = gs.cardSum(cpuHand);
                dealerSum = gs.cardSum(dealer);
                //display players' hand
                p1.displayP1Hand(playerTurn[0], p1Hand, p1Sum);
                cpu.displaycpuHand(cpuHand, cpuSum);
                d.displaydealerHand(dealer, dealerSum, playerTurn[x]);

                if (moveHistory.Count != 0)
                    Console.WriteLine(moveHistory[moveHistory.Count - 1]);
                Console.WriteLine("-----------------------------------------------");

                //check player and game state
                if (!gs.checkPlayerState(currPlayerSum))
                {
                    Console.WriteLine($"{playerTurn[x]} busted!");
                    checkAgain = false;
                    break;
                }
                for (int i = 0; i < playerTurn.Count; i++)
                {
                    if (gs.check21Win(p1Sum, cpuSum, dealerSum, playerTurn) == playerTurn[i])
                    {
                        Console.WriteLine($"{playerTurn[i]} won!");
                        checkAgain = false;
                        winFlag = false;
                        break;
                    }
                }
                if (!winFlag)
                    break;
                if (gs.comparePlayerValues(p1Sum, cpuSum, dealerSum, playerTurn) == "None")
                {
                    Console.WriteLine("Push!");
                    checkAgain = false;
                    break;
                }

                //choose which player and asks H/S
                Console.Write($"{playerTurn[x]}, would you like to hit or stand?");
                switch (x)
                {
                    case 0:
                        Console.Write(" [H/S]\n");
                        choice = p1.uInput();
                        break;
                    case 1:
                        choice = gs.hitOrstand(gs.cardSum(cpuHand), playerTurn[x]);
                        break;
                    case 2:
                        choice = gs.hitOrstand(gs.cardSum(dealer), playerTurn[x]);
                        break;
                }

                //H/S logic
                switch (choice)
                {
                    case "H": //hit
                        hand = doc.drawACard(1);
                        switch (x)
                        {
                            case 0:
                                p1Hand.Add(gs.playerHand(hand));
                                currPlayerSum = gs.cardSum(p1Hand);
                                moveHistory.Add($"{playerTurn[x]} decided to hit.");
                                break;
                            case 1:
                                cpuHand.Add(gs.playerHand(hand));
                                currPlayerSum = gs.cardSum(cpuHand);
                                moveHistory.Add($"{playerTurn[x]} decided to hit.");
                                break;
                            case 2:
                                dealer.Add(gs.playerHand(hand));
                                currPlayerSum = gs.cardSum(dealer);
                                moveHistory.Add($"{playerTurn[x]} decided to hit.");
                                break;
                        }
                        break;
                    case "S": //stand
                        moveHistory.Add($"{playerTurn[x]} decided to stand.");
                        x++;
                        choice = ""; ;
                        break;
                }
                Console.Clear();
            }

            while (checkAgain) //scenario: no one went over 21 and no one won yet
            {
                //display players' hand
                p1.displayP1Hand(playerTurn[0], p1Hand, gs.cardSum(p1Hand));
                cpu.displaycpuHand(cpuHand, cpuSum);
                d.displaydealerHand(dealer, gs.cardSum(dealer), playerTurn[2]);

                if (moveHistory.Count != 0)
                    Console.WriteLine(moveHistory[moveHistory.Count - 1]);
                Console.WriteLine("-----------------------------------------------");
                for (int i = 0; i < playerTurn.Count; i++)
                {
                    if (gs.comparePlayerValues(gs.cardSum(p1Hand), gs.cardSum(cpuHand), gs.cardSum(dealer), playerTurn) == playerTurn[i])
                    {
                        Console.WriteLine($"{playerTurn[i]} won!");
                        break;
                    }
                }
                checkAgain = false;
            }
            Console.WriteLine("Press any key to end the game. . .");
            Console.ReadKey();
        }
    }
}
