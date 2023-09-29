namespace NGLottery.Models
{
    public class BonusModule
    {
        public static bool IsPlayerQualifiedForBonus(Player player)
        {
            List<DBRecord> winRounds = player.BetRecords.Where(record => record.WinAmount > 0).ToList();

            if (winRounds.Count >= 10)
            {
                double totalBetAmount = player.BetRecords.Sum(record => record.BetAmount);
                double totalWinAmount = winRounds.Sum(record => record.WinAmount);

                bool allBetsGreaterThanWins = player.BetRecords.All(record => record.BetAmount > record.WinAmount);

                bool winsEqualHalfOfBets = totalWinAmount == (totalBetAmount / 2.0);

                return allBetsGreaterThanWins && winsEqualHalfOfBets;
            }

            return false;
        }
    }
}
