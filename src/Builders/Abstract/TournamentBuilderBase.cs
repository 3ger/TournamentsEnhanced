using System;

using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
using TaleWorlds.Core;

using TournamentsEnhanced.Finder;
using TournamentsEnhanced.Wrappers.CampaignSystem;
using TournamentsEnhanced.Wrappers.Core;

namespace TournamentsEnhanced.Builders.Abstract
{
  public abstract class TournamentBuilderBase
  {
    protected TournamentBuilder TournamentBuilder { get; set; } = TournamentBuilder.Instance;
    protected HeroFinder HeroFinder { get; set; } = HeroFinder.Instance;
    protected FactionFinder FactionFinder { get; set; } = FactionFinder.Instance;
    protected SettlementFinder SettlementFinder { get; set; } = SettlementFinder.Instance;
    protected Settings Settings { get; set; } = Settings.Instance;
    protected MBHero MBHero { get; set; } = MBHero.Instance;


    protected CreateTournamentResult CreateTournament(CreateTournamentOptions options)
    {
      var settlement = options.Settlement;
      var type = options.Type;
      var townHadExistingTournament = settlement.Town.HasTournament;


      if (!townHadExistingTournament)
      {
        InstantiateTournament(settlement);
        ApplyHostingEffects(type, settlement);
        ApplyRelationsGain(type, settlement);
      }

      var result = CreateTournamentResult.Success(settlement, townHadExistingTournament);
      var payor = result.Payor;

      if (result.HasPayor)
      {
        PayTournamentFee(result.Payor, settlement);
      }

      if (payor.IsHumanPlayerCharacter)
      {
        MBInformationManagerFacade.DisplayAsQuickBanner($"You've spent {Settings.TournamentCost.ToString()} gold on hosting a Tournament at {settlement.Name}");
      }

      return result;
    }

    private void InstantiateTournament(MBSettlement settlement)
    {
      var tournament = new FightTournamentGame(settlement.Town);
      MBCampaign.Current.TournamentManager.AddTournament(tournament);
    }


    private void ApplyHostingEffects(TournamentType type, MBSettlement settlement)
    {
      if (type == TournamentType.Initial)
      {
        return;
      }

      settlement.Prosperity += Settings.ProsperityIncrease;
      settlement.Town.Loyalty += Settings.LoyaltyIncrease;
      settlement.Town.Security += Settings.SecurityIncrease;
      settlement.Town.FoodStocks -= Settings.FoodStocksDecrease;

      if (settlement.Town.MapFaction.Leader.IsHumanPlayerCharacter && Settings.SettlementStatNotification)
      {
        MBInformationManagerFacade.DisplayAsLogEntry($"{settlement.Name}'s prosperity, loyalty and security have increased and food stocks have decreased");
      }
    }

    private void PayTournamentFee(MBHero payor, MBSettlement settlement)
    {
      var tournamentCost = Settings.TournamentCost;

      payor.ChangeHeroGold(-tournamentCost);
      settlement.Town.ChangeGold(tournamentCost);
    }

    public void ApplyRelationsGain(TournamentType type, MBSettlement settlement)
    {
      if (type != TournamentType.PlayerInitiated)
      {
        return;
      }

      var mainHero = MBHero.MainHero;
      int newRelation;

      foreach (var notable in settlement.Notables)
      {
        if (notable == mainHero)
        {
          continue;
        }

        newRelation = notable.GetBaseHeroRelation(mainHero) + Settings.NoblesRelationIncrease;

        notable.SetPersonalRelation(mainHero, newRelation);
      }

      MBInformationManagerFacade.DisplayAsQuickBanner($"Your relationship with local notables at {settlement.Name} has improved");
    }

    public ValueTuple<SkillObject, int> TournamentSkillXpGain(MBHero winner)
    {
      float randomFloat = MBRandom.DeterministicRandom.NextFloat();
      SkillObject item = (randomFloat < 0.2f) ? DefaultSkills.OneHanded : ((randomFloat < 0.4f) ? DefaultSkills.TwoHanded : ((randomFloat < 0.6f) ? DefaultSkills.Polearm : ((randomFloat < 0.8f) ? DefaultSkills.Riding : DefaultSkills.Athletics)));
      int item2 = Settings.TournamentSkillXp;
      return new ValueTuple<SkillObject, int>(item, item2);
    }
  }
}
