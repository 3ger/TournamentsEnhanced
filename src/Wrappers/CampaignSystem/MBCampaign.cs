using System.Collections.Generic;

using TaleWorlds.CampaignSystem;

using TournamentsEnhanced.Wrappers.Abstract;
using TournamentsEnhanced.Wrappers.Localization;

using static TaleWorlds.CampaignSystem.SettlementAccessModel;

namespace TournamentsEnhanced.Wrappers.CampaignSystem
{
  public class MBCampaign : MBWrapperBase<MBCampaign, Campaign>
  {
    public static bool CanMainHeroJoinTournamentAtCurrentSettlement(out bool shouldBeDisabled, out MBTextObject disabledText)
    {
      return Current.Models.SettlementAccessModel
                      .CanMainHeroDoSettlementAction(
                                                     MBSettlement.CurrentSettlement.UnwrappedObject,
                                                     SettlementAction.JoinTournament,
                                                     out shouldBeDisabled,
                                                     out disabledText
                                                    );
    }

    public static MBCampaign Current => Campaign.Current;
    public MBTournamentManager TournamentManager => (MBTournamentManager)UnwrappedObject.TournamentManager;
    public MBGameModels Models => UnwrappedObject.Models;

    public static implicit operator Campaign(MBCampaign wrapper) => wrapper.UnwrappedObject;
    public static implicit operator MBCampaign(Campaign obj) => GetWrapper(obj);
  }
}
