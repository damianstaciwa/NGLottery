namespace NGLottery.Models
{
    public class Player
    {
        public int PlayerID { get; private set; }
        public double Balance { get; private set; }
        public List<DBRecord> BetRecords { get; private set; }

        private static int nextPlayerID = 1;
        readonly Random random = new Random();

        public Player()
        {
            PlayerID = nextPlayerID++;
            BetRecords = GeneratePlayerBetsRecords();
        }

        private List<DBRecord> GeneratePlayerBetsRecords()
        {
            var betRecords = new List<DBRecord>();
            double balance = Balance;

            int numberOfRecords = random.Next(1, 51);

            for (int i = 0; i < numberOfRecords; i++)
            {
                var record = new DBRecord();
                record.betID = i + 1;
                record.BetAmount = random.Next(10, 101);

                bool isWin = random.Next(0, 2) == 1;
                if (isWin)
                {
                    record.WinAmount = random.Next(0, (int)record.BetAmount);
                    balance += record.WinAmount;
                }
                else
                {
                    record.WinAmount = 0;
                    balance -= record.BetAmount;
                }

                record.BalanceBeforeBet = balance - record.WinAmount;
                record.BalanceAfterBet = balance;

                betRecords.Add(record);
            }

            return betRecords;
        }

        public static List<Player> GeneratePlayers(int numberOfPlayers)
        {
            var players = new List<Player>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player();
                players.Add(player);
            }
            return players;
        }
    }
}
