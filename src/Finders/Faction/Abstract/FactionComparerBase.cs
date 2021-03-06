using TournamentsEnhanced.Finder.Comparers.Abstract;
using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Finder.Comparers
{
  public abstract class FactionComparerBase : ComparerBase<MBFaction>
  {
    protected FactionComparerBase(MBHero initiatingHero = null) : base(initiatingHero) { }
  }
}