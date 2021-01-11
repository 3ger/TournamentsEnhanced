using TournamentsEnhanced.Builders.Abstract;
using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Builders
{
  public partial class TournamentBuilder : TournamentBuilderBase
  {

    public static void CreateInitialTournaments()
    {
      var townsWithExisting = MBTown.AllTownsWithTournaments;
      var townsWithoutExisting = MBTown.AllTownsWithoutTournaments;
      var numExisting = townsWithExisting.Count;
      var maxPossible = townsWithoutExisting.Count;
      var numRequested = Settings.Instance.TournamentInitialSpawnCount - numExisting;
      var numToCreate = (numRequested <= maxPossible) ? numRequested : maxPossible;

      CreateTournamentOptions options;
      foreach (var town in townsWithExisting)
      {
        options = new CreateTournamentOptions()
        {
          Settlement = town.Settlement,
          Type = TournamentType.Initial
        };

        CreateTournament(options);
      }

      var numCreated = 0;
      foreach (var town in townsWithoutExisting.DeterministicShuffle())
      {
        if (numCreated >= numToCreate)
        {
          break;
        }

        options = new CreateTournamentOptions()
        {
          Settlement = town.Settlement,
          Type = TournamentType.Initial,
        };

        CreateTournament(options);

        numCreated++;
      }
    }
  }
}
