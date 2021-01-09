using TournamentsEnhanced.Builders.Abstract;
using TournamentsEnhanced.Finder;

namespace TournamentsEnhanced.Builders
{
  public partial class TournamentBuilder : TournamentBuilderBase
  {
    public static CreateTournamentResult TryCreateInvitationTournament()
    {
      var findSettlementResult = SettlementFinder.FindForInvitationTournament();

      if (findSettlementResult.Failed)
      {
        return CreateTournamentResult.Failure;
      }

      var createTournamentOptions = new CreateTournamentOptions()
      {
        InitiatingHero = findSettlementResult.InitiatingHero,
        Settlement = findSettlementResult.Nominee,
        Type = TournamentType.Peace
      };

      return CreateTournament(createTournamentOptions);
    }
  }
}
