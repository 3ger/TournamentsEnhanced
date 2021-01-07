using System.Collections.Generic;

using TournamentsEnhanced.Finder;
using TournamentsEnhanced.Finder.Comparers.Settlement;
using TournamentsEnhanced.Models.Serializable;
using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Builders
{
  public partial class TournamentBuilder : TournamentBuilderBase
  {
    public static CreateTournamentResult TryCreateWeddingTournament(MBHero firstWeddedHero, MBHero secondWeddedHero)
    {
      var findSettlementResult = SettlementFinder.FindSettlementForWeddingTournament(firstWeddedHero, secondWeddedHero);

      if (!findSettlementResult.Succeeded)
      {
        return CreateTournamentResult.Failure();
      }

      var options = new CreateTournamentOptions(findSettlementResult.Nominee, TournamentType.Wedding, )
      CreateTournament()


      return CreateTournamentResult.Success(findSettlementResult.Nominee, findSettlementResult.Nominee.Town.HasTournament);
    }

    private void OnInterFactionMarriage(Hero firstHero, Hero secondHero, bool showNotification)
    {
      var resultsA = TournamentBuilder.CreateTournamentTypeInTownBelongingToFaction(TournamentType.Wedding, firstHero.MapFaction);
      var resultsB = TournamentBuilder.CreateTournamentTypeInTownBelongingToFaction(TournamentType.Wedding, secondHero.MapFaction);

      if (!resultsA.Succeeded && !resultsB.Succeeded)
      {
        return;
      }

      string hostTownNames;
      if (resultsA.Succeeded && resultsB.Succeeded)
      {
        hostTownNames = $"{resultsA.Town.Name} and {resultsB.Town.Name}";
      }
      else
      {
        hostTownNames = resultsA.Succeeded ? $"{resultsA.Town.Name}" : $"{resultsB.Town.Name}";
      }

      NotificationUtils.DisplayBannerMessage($"To celebrate the wedding of {firstHero.Name} and {secondHero.Name}, local nobles have called a tournament at {hostTownNames}");
    }

    private static FindHostSettlementResult TryFindSettlementForWeddingTournament(IMBFaction faction)
    {
      var payor = new Payor(faction.Leader);
      var candidateSettlements = faction.Settlements;

      var result = FindSettlementForWeddingTournament(candidateSettlements, payor);

      if (result.Failed)
      {
        result = FindSettlementWithExistingForWeddingTournament(candidateSettlements, payor);
      }

      return result;
    }

    private static FindHostSettlementResult FindSettlementForWeddingTournament(MBSettlementList settlements, Payor payor)
    {
      var comparers = new IComparer<MBSettlement>[] {
        new ExistingTournamentComparer(payor, false),
        new ProsperityComparer(payor)};
      var options = new FindHostSettlementOptions() { Candidates = settlements, Comparers = comparers };

      return SettlementFinder.Find(options);
    }

    private static FindHostSettlementResult FindSettlementWithExistingForWeddingTournament(MBSettlementList settlements, Payor payor)
    {
      var comparers = new IComparer<MBSettlement>[] {
        new ExistingTournamentComparer(payor, true),
        new PayorRankComparer(payor),
        new PayorRelationComparer(payor, 50),
        new ProsperityComparer(payor)};
      var options = new FindHostSettlementOptions() { Candidates = settlements, Comparers = comparers };

      return SettlementFinder.Find(options);
    }
  }
}
