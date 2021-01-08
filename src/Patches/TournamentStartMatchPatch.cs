﻿using HarmonyLib;

using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;

using TournamentsEnhanced.Models;

namespace TournamentsEnhanced.Patches
{
  [HarmonyPatch(typeof(TournamentMatch), "Start")]
  class TournamentStartMatchPatch
  {

    static void Postfix()
    {
      if (Settings.Instance.VeryHardTournaments)
      {
        CampaignModel.NonTournamentDifficulty = CampaignOptions.CombatAIDifficulty;
        CampaignOptions.CombatAIDifficulty = CampaignOptions.Difficulty.Realistic;
      }
    }
  }
}
