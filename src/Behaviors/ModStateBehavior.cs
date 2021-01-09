using System;

using TaleWorlds.CampaignSystem;

using TournamentsEnhanced.Models.ModState;
using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Behaviors
{
  public class ModStateBehavior : MBCampaignBehaviorBase
  {
    public override void RegisterEvents()
    {
      MBCampaignEvents.DailyTickEvent.AddNonSerializedListener(this, new Action(ModState.DailyTick));
      MBCampaignEvents.DailyTickEvent.AddNonSerializedListener(this, new Action(ModState.DailyTick));
    }
  }
}