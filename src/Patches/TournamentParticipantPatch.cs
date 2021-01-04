﻿using System.Collections.Generic;

using HarmonyLib;

using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

using TournamentsEnhanced.Models.ModState;

namespace TournamentsEnhanced
{
  [HarmonyPatch(typeof(TournamentGame), "GetParticipantCharacters")]
  class TournamentParticipantPatch
  {
    static void Postfix(ref List<CharacterObject> __result, Settlement settlement, int maxParticipantCount, bool includePlayer = true, bool includeHeroes = true)
    {
      if (!includePlayer)
      {
        return;
      }

      if (ModState.TournamentRecords.ForCurrentTown().tournamentType == TournamentType.Lord)
      {
        IEnumerable<Hero> list = settlement.OwnerClan.MapFaction.Heroes;
        for (int i = 0; i < 15; i++)
        {
          CharacterObject potentialParticipant = list.GetRandomElement().CharacterObject;
          bool exists = false;
          for (int t = 0; t < __result.Count; t++)
          {
            if (__result[t].Name.Equals(potentialParticipant.Name) || potentialParticipant.IsPlayerCharacter || potentialParticipant.Age < 18.00)
            {
              exists = true;
              break;
            }
          }
          if (!exists)
          {
            __result[__result.Count - 1 - i] = potentialParticipant;

          }
        }
      }
      else if (includePlayer)
      {
        int numAddedHeroes = MBRandom.RandomInt(4, Settings.Instance.UpperBoundHeroesAdded);
        IEnumerable<Hero> list = settlement.OwnerClan.MapFaction.Heroes;
        for (int i = 0; i <= numAddedHeroes; i++)
        {
          CharacterObject potentialParticipant = list.GetRandomElement().CharacterObject;
          bool exists = false;
          for (int t = 0; t < __result.Count; t++)
          {
            if (__result[t].Name.Equals(potentialParticipant.Name) || potentialParticipant.IsPlayerCharacter || potentialParticipant.Age < 18.00)
            {
              exists = true;
              break;
            }
          }
          if (!exists)
          {
            __result[__result.Count - 1 - i] = potentialParticipant;
          }
        }
      }
      //If the player wants to bring companions with him
      if (includePlayer && Settings.Instance.BringCompanions)
      {
        IEnumerable<Hero> companions = Hero.MainHero.CompanionsInParty;
        List<Hero> companionList = companions.ToList();
        if (
            Hero.MainHero.Spouse != null &&
            Hero.MainHero.Spouse.CurrentSettlement.Name.Equals(settlement.Name))
        {
          companionList.Add(Hero.MainHero.Spouse);
        }
        List<Hero>.Enumerator companionEnumerator = companionList.GetEnumerator();

        int i = 1;
        while (companionEnumerator.MoveNext())
        {
          bool exists = false;
          for (int t = 0; t < __result.Count; t++)
          {
            if (__result[t].Name.Equals(companionEnumerator.Current.CharacterObject.Name) || companionEnumerator.Current.CharacterObject.IsPlayerCharacter || companionEnumerator.Current.CharacterObject.Age < 18.00)
            {
              exists = true;
              break;
            }
          }
          if (!exists)
          {
            Hero[] companionArray = companionList.ToArray();
            for (int y = 0; y < __result.Count - 1; y++)
            {
              if (__result[i].Name.Equals(companionArray[y].CharacterObject.Name))
              {
                i++;
              }
              else
              {
                break;
              }
            }
            __result[i] = companionEnumerator.Current.CharacterObject;
            i++;
          }

          if (i >= 10)
          {
            break;
          }
        }
      }
    }
  }
}
