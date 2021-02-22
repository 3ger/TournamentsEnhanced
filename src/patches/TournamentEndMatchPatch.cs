﻿using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;

namespace TournamentsEnhanced
{
  [HarmonyPatch(typeof(TournamentMatch), "End")]
  class TournamentEndMatchPatch
  {
    static void Postfix()
    {
      Utilities.UnsetDifficulty();
    }
  }
}
