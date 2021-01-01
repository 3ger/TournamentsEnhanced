using System.Collections.Generic;

using TaleWorlds.CampaignSystem;

using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.Wrappers
{
  public class MBGameModels : CachedWrapperBase<MBGameModels, GameModels>
  {
    public SettlementAccessModel SettlementAccessModel => UnwrappedObject.SettlementAccessModel;

    public static implicit operator GameModels(MBGameModels wrapper) => wrapper.UnwrappedObject;
    public static implicit operator MBGameModels(GameModels obj) => MBGameModels.GetWrapperFor(obj);
  }

  public class MBGameModelsList : List<MBGameModels>
  {
    public static implicit operator List<GameModels>(MBGameModelsList wrapperList) => wrapperList.Unwrap<MBGameModels, GameModels>();
    public static implicit operator MBGameModelsList(List<GameModels> objectList) => (MBGameModelsList)objectList.Wrap<MBGameModels, GameModels>();
  }
}
