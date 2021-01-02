using TournamentsEnhanced.Models;
using TournamentsEnhanced.Wrappers;

namespace TournamentsEnhanced.Comparer
{
  public class FriendshipWithTownNobilityComparer : TownComparer
  {
    public override int Compare(MBTown x, MBTown y)
    {
      var xRecord = ModState.TournamentRecords[x];
      var yRecord = ModState.TournamentRecords[y];
      var xFriendlyNobility = x.GetFriendlyNobilityLevel();
      var yFriendlyNobility = y.GetFriendlyNobilityLevel();

      var result = xFriendlyNobility.CompareTo(yFriendlyNobility);

      return xFriendlyNobility.CompareTo(yFriendlyNobility);
    }
  }
}