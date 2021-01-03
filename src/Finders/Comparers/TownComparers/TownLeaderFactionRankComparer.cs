using TournamentsEnhanced.Models;
using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Finder.Comparer
{
  public class TownLeaderFactionRankComparer : TownComparerBase
  {
    public override int Compare(MBTown x, MBTown y)
    {
      var xRecord = ModState.TournamentRecords[x];
      var yRecord = ModState.TournamentRecords[y];
      var xLeaderFactionRank = x.GetLeaderFactionRankLevel();
      var yLeaderFactionRank = y.GetLeaderFactionRankLevel();

      var result = xLeaderFactionRank.CompareTo(yLeaderFactionRank);

      return xLeaderFactionRank.CompareTo(yLeaderFactionRank);
    }
  }
}