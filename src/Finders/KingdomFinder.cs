using System.Collections.Generic;

using TaleWorlds.CampaignSystem;

using TournamentsEnhanced.Finder.Abstract;
using TournamentsEnhanced.Finder.Comparers.Kingdom;
using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Finder
{
  public class KingdomFinder
    : FinderBase<FindKingdomResult, FindKingdomOptions, MBKingdom, Kingdom>
  {
    public static FindKingdomResult FindKingdomThatMeetBasicHostRequirements(MBKingdom kingdom)
    {
      var candidiates = new List<MBKingdom>();
      candidiates.Add(kingdom);

      var options = new FindKingdomOptions()
      {
        Candidates = candidiates,
        Comparers = new IComparer<MBKingdom>[]
        {
          BasicHostRequirementsComparer.Instance
        }
      };

      return Find(options);
    }
  }
}
