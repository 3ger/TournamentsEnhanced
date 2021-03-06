using TournamentsEnhanced.Builders.Abstract;
using TournamentsEnhanced.Finder;

namespace TournamentsEnhanced.Builders
{
  public partial class TournamentBuilder : TournamentBuilderBase
  {
    public static TournamentBuilder Instance { get; } = new TournamentBuilder();

    public TournamentBuilder() { }
  }
}
