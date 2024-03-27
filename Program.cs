using NGLottery.Models;

namespace NGLottery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlayers = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Enter the number of players you want to generate:");

                if (int.TryParse(Console.ReadLine(), out numberOfPlayers) && numberOfPlayers > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive integer.");
                }
            }

            List<Player> players = Player.GeneratePlayers(numberOfPlayers);

            bool qualifiedPlayersExist = false;

            Console.WriteLine("Players qualified for a bonus:");

            foreach (var player in players)
            {
                if (BonusModule.IsPlayerQualifiedForBonus(player))
                {
                    Console.WriteLine($"Player ID: {player.PlayerID}");
                    qualifiedPlayersExist = true;
                }
            }

            if (!qualifiedPlayersExist)
            {
                Console.WriteLine("No players qualified.");
            }
        }
    }
}
