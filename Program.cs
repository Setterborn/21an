using System;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        // Presenting and manages the menu
        {
            
            string lastWinner = "None";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select from menu below\n" +
                "1 - Play TewntyOne\n" +
                "2 - Show last winner\n" +
                "3 - Read rules\n" +
                "4 - Exit program");
                bool sucess = int.TryParse(Console.ReadLine(), out int menuInput);
                if (sucess && menuInput > 0 && menuInput <= 4)
                {
                    switch (menuInput)
                    {
                        case 1:
                            lastWinner = Game();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine($"Last winner was {lastWinner}\n\nPress any key to continue");
                            Console.ReadKey();
                            break;
                        case 3:
                            Rules();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 4:
                            Environment.Exit(1);
                            break;
                    }
                }
            }
        }
        static int Card(int numberOfCards)
        // Returns the total score of the inserted number of cards
        {
            int cards = 0;
            Random rnd = new Random();
            for (int i = 0; i < numberOfCards; i++)
            {
                cards += rnd.Next(1, 11);
            }
            return cards;
        }
        static string Game()
        // Runns the game and returns name of winner
        {
            bool running = true;
            string playerName;
            string winner;
            int playerScore;
            int compScore;
            Console.WriteLine("Whats your name?");
            playerName = Console.ReadLine();
            Console.WriteLine("Two card will be drawn by each player");
            playerScore = Card(2);
            compScore = Card(2);
            while (running || playerScore <21 || compScore <21) 
            {
                Console.Clear();
                Console.WriteLine($"----------\n{playerName} has {playerScore} points\n----------");
                Console.WriteLine($"----------\nComputer has {compScore} points\n----------");
                Console.WriteLine("Would you like to draw another card? Y/N");
                char.TryParse(Console.ReadLine().ToLower(), out char answer);
                switch(answer)
                {
                    case 'y':
                        int newCard = Card(1);
                        playerScore += newCard;
                        Console.WriteLine($"----------\nYour card was worth {newCard} points");
                        if (compScore < 16) { compScore += Card(1); }
                        break;
                    case 'n':
                        if (compScore < 16) { compScore += Card(1); }
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                if (answer == 'n' || playerScore >21 || compScore > 21) { break; }
            }
            Console.WriteLine($"----------\n{playerName} has {playerScore} points\n----------");
            Console.WriteLine($"----------\nComputer has {compScore} points\n----------");
            if (playerScore == compScore)
            {
                Console.WriteLine("\n\nIt's a draw!\n\n");
                winner = "None";
            }
            else if (playerScore == 21)
            {
                Console.WriteLine("\n\nYou won!\n\n");
                winner = playerName;
            }
            else if (playerScore > compScore && playerScore < 21 || playerScore < compScore && compScore > 21)
            {
                Console.WriteLine("\n\nYou won!\n\n");
                winner = playerName;
            }
            else
            {
                Console.WriteLine("\n\nYou lost!\n\n");
                winner = "Computer";
            }
            return winner;
        }
        static void Rules()
        // Writes the rules 
        {
            Console.WriteLine("----------\nRULES\n----------\n" +
                "1 - You draw as many card as you want\n" +
                "2 - The computer draws if under 16 points\n" +
                "3 - The one who gets over 21 points looses\n" +
                "4 - Closest to 21 wins!\n");
        }

        
    }
}
