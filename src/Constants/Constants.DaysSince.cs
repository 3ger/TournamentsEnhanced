namespace TournamentsEnhanced
{
  public static partial class Constants
  {
    public static class DaysSinceTracker
    {
      public static class Default
      {
        public static readonly int KeyValue = int.MaxValue;
      }

      public static readonly TournamentType[] TournamentTypes =
      {
        TournamentType.Highborn,
        TournamentType.Invitation,
        TournamentType.PlayerInitiated,
        TournamentType.Prosperity,
      };
    }
  }
}
