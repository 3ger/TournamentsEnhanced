﻿using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;

namespace TournamentsEnhanced.TeamTournament
{
  public static class TeamTournamentHelpers
  {
    /// <summary>
    /// Returns all found characters which are heroes inside a settlement.
    /// </summary>
    /// <param name="settlement">Settlement to find the heroes in</param>
    /// <returns>List of all found hero characters inside the settlement</returns>
    public static IEnumerable<CharacterObject> GetHeroesInSettlement(this Settlement settlement)
    {
      return settlement.LocationComplex
        .GetListOfCharacters()
        .Where(x =>
            x != null
            && x.Character.IsHero
            && !x.IsHidden)
        .Select(sel => sel.Character);
    }

    public static IEnumerable<Hero> AllLivingRelatedHeroes(this Hero inHero)
    {
      if (inHero.Father != null && !inHero.Father.IsDead)
        yield return inHero.Father;

      if (inHero.Mother != null && !inHero.Mother.IsDead)
        yield return inHero.Mother;

      if (inHero.Spouse != null && !inHero.Spouse.IsDead)
        yield return inHero.Spouse;

      foreach (Hero hero in inHero.Children)
      {
        if (!hero.IsDead)
          yield return hero;
      }
      foreach (Hero hero2 in inHero.Siblings)
      {
        if (!hero2.IsDead)
          yield return hero2;
      }
      foreach (Hero hero3 in inHero.ExSpouses)
      {
        if (!hero3.IsDead)
          yield return hero3;
      }
    }
  }
}