using TaleWorlds.CampaignSystem;

using TournamentsEnhanced.Finder.Abstract;
using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Finder
{
  public class FindHeroResult
    : FindResultBase<FindHeroResult, MBHero, MBHeroList, Hero>
  {
    public FindHeroResult() { }

    public new static FindHeroResult Failure()
      => new FindHeroResult() { Status = ResultStatus.Failure };
    public new static FindHeroResult Success(MBHero hero)
      => new FindHeroResult() { Status = ResultStatus.Failure, Nominee = hero };
  }
}
