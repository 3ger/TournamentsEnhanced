using System.Collections.Generic;

using TaleWorlds.CampaignSystem.GameMenus;

using TournamentsEnhanced.Wrappers.Abstract;

using static TaleWorlds.CampaignSystem.GameMenus.GameMenuOption;

namespace TournamentsEnhanced.Wrappers
{
  public class MBGameMenuOption : CachedWrapperBase<MBGameMenuOption, GameMenuOption>
  {
    public static implicit operator GameMenuOption(MBGameMenuOption wrapper) => wrapper.UnwrapedObject;
    public static implicit operator MBGameMenuOption(GameMenuOption obj) => MBGameMenuOption.GetWrapperFor(obj);
  }

  public class MBGameMenuOptionList : List<MBGameMenuOption>
  {
    public static implicit operator List<GameMenuOption>(MBGameMenuOptionList wrapperList) => wrapperList.Unwrap<MBGameMenuOption, GameMenuOption>();
    public static implicit operator MBGameMenuOptionList(List<GameMenuOption> objectList) => (MBGameMenuOptionList)objectList.Wrap<MBGameMenuOption, GameMenuOption>();
  }
}
