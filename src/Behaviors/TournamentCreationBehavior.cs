﻿using System;
using System.Collections.Generic;

using TaleWorlds.CampaignSystem;

using TournamentsEnhanced.Behaviors.Abstract;
using TournamentsEnhanced.Builders;
using TournamentsEnhanced.Random;
using TournamentsEnhanced.Wrappers.CampaignSystem;
using TournamentsEnhanced.Wrappers.Core;

namespace TournamentsEnhanced.Behaviors
{
  class TournamentCreationBehavior : MBEncounterGameMenuBehavior
  {
    public override void RegisterEvents()
    {
      MBCampaignEvents.DailyTickEvent
        .AddNonSerializedListener(this, new Action(this.DailyTick));
      MBCampaignEvents.MakePeace
        .AddNonSerializedListener(this, new Action<IFaction, IFaction>(this.OnMakePeace));
      MBCampaignEvents.HeroesMarried
        .AddNonSerializedListener(this, new Action<Hero, Hero, bool>(this.OnHeroesMarried));
      MBCampaignEvents.OnGivenBirthEvent
        .AddNonSerializedListener(this, new Action<Hero, List<Hero>, int>(this.OnGivenBirth));
    }

    private void DailyTick()
    {
      TryCreateTournaments();
    }

    private void TryCreateTournaments()
    {
      TryCreateProsperityTournament();
      TryCreateHighbornTournament();
      TryCreateInvitationTournament();
    }

    private void TryCreateProsperityTournament()
    {
      if (!Lottery.IsWinner(TournamentType.Prosperity))
      {
        return;
      }

      var result = TournamentBuilder.TryCreateProsperityTournament();

      if (result.Succeeded)
      {
        MBInformationManagerFacade.DisplayAsLogEntry($"Local nobles at {result.HostSettlement.Name} have called a tournament due to high prosperity");
      }
    }

    private void TryCreateHighbornTournament()
    {
      if (!Lottery.IsWinner(TournamentType.Highborn))
      {
        return;
      }

      var result = TournamentBuilder.TryCreateHighbornTournament();

      if (result.Succeeded)
      {
        MBInformationManagerFacade.DisplayAsQuickBanner($"{result.Payor.Name} invites you to a Highborn tournament at {result.HostSettlement.Name}");
      }
    }

    private static void TryCreateInvitationTournament()
    {
      if (!Lottery.IsWinner(TournamentType.Invitation) &&
          MBHero.MainHero.Clan.Renown >= Settings.Instance.MaxRenownForInvitationTournaments)
      {
        return;
      }

      var result = TournamentBuilder.TryCreateInvitationTournament();

      if (result.Succeeded)
      {
        MBInformationManagerFacade.DisplayAsQuickBanner("A local lord is looking for tournament contestants at " + result.HostSettlement.Name);
      }
    }

    private void OnMakePeace(IFaction a, IFaction b)
    {
      var factionA = a.ToIMBFaction();
      var factionB = b.ToIMBFaction();

      TryCreatePeaceTournaments(factionA, factionB);
    }

    private void TryCreatePeaceTournaments(IMBFaction factionA, IMBFaction factionB)
    {
      var resultsA = TournamentBuilder.TryCreatePeaceTournamentForFaction(factionA);
      var resultsB = TournamentBuilder.TryCreatePeaceTournamentForFaction(factionB);

      if (!Settings.Instance.PeaceNotification ||
         (resultsA.Failed && resultsB.Failed))
      {
        return;
      }

      string hostTownNames;
      if (resultsA.Succeeded && resultsB.Succeeded)
      {
        hostTownNames = $"{resultsA.HostSettlement.Name} and {resultsB.HostSettlement.Name}";
      }
      else
      {
        hostTownNames = resultsA.Succeeded ? $"{resultsA.HostSettlement.Name}" : $"{resultsB.HostSettlement.Name}";
      }

      MBInformationManagerFacade.DisplayAsLogEntry(
        $"To celebrate the peace of { factionA.Name } and { factionB.Name }, faction leaders have called a tournament at { hostTownNames }");
    }

    private void OnHeroesMarried(Hero firstHero, Hero secondHero, bool showNotification)
    {
      var result = TournamentBuilder.TryCreateWeddingTournament(firstHero, secondHero);

      if (result.Succeeded)
      {
        MBInformationManagerFacade.DisplayAsQuickBanner(
          $"To celebrate the wedding of {firstHero.Name} and {secondHero.Name}, local nobles have called a tournament at {result.HostSettlement.Name}");
      }
    }

    private void OnGivenBirth(Hero mother, List<Hero> aliveChildren, int stillBornCount)
    {
      var result = TournamentBuilder.TryMakeBirthTournament(mother);

      MBInformationManagerFacade.DisplayAsQuickBanner(
        $"To celebrate the birth of {mother.Name} and {mother.Spouse.Name}'s child, local nobles have called a tournament at {result.Settlement.Name}");
    }
  }
}
