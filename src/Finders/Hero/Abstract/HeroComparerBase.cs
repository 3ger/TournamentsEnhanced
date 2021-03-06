using TournamentsEnhanced.Finder.Comparers.Abstract;
using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Finder.Comparers
{
  public abstract class HeroComparerBase : ComparerBase<MBHero>
  {
    protected HeroComparerBase(MBHero initiatingHero = null) : base(initiatingHero) { }
  }
}