using System;
using System.Collections.Generic;

using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;

using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.Wrappers.CampaignSystem
{

  public class MBTournamentManager : MBWrapperBase<MBTournamentManager, TournamentManager>
  {
    public void AddLeaderboardEntry(MBHero hero) => UnwrappedObject.AddLeaderboardEntry(hero);

    public void AddTournament(MBTournamentGame game) => UnwrappedObject.AddTournament(game);

    public void DeleteLeaderboardEntry(MBHero hero) => UnwrappedObject.DeleteLeaderboardEntry(hero);

    public MBHero GetLeaderBoardLeader() => UnwrappedObject.GetLeaderBoardLeader();

    public MBTournamentGame GetTournamentGame(Town town) => UnwrappedObject.GetTournamentGame(town);

    public void InitializeLeaderboardEntry(MBHero hero, int initialVictories = 0) => UnwrappedObject.InitializeLeaderboardEntry(hero, initialVictories);

    public void OnPlayerJoinMatch(Type gameType) => UnwrappedObject.OnPlayerJoinMatch(gameType);

    public void OnPlayerJoinTournament(Type gameType, Settlement settlement) => UnwrappedObject.OnPlayerJoinTournament(gameType, settlement);

    public void OnPlayerWatchTournament(Type gameType, Settlement settlement) => UnwrappedObject.OnPlayerWatchTournament(gameType, settlement);

    public void OnPlayerWinMatch(Type gameType) => UnwrappedObject.OnPlayerWinMatch(gameType);

    public void OnPlayerWinTournament(Type gameType) => UnwrappedObject.OnPlayerWinTournament(gameType);

    public void ResolveTournament(TournamentGame tournament, Town town) => UnwrappedObject.ResolveTournament(tournament, town);

    public static implicit operator TournamentManager(MBTournamentManager wrapper) => wrapper.UnwrappedObject;
    public static implicit operator MBTournamentManager(TournamentManager obj) => GetWrapper(obj);
  }
}
