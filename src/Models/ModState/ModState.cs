using TournamentsEnhanced.Models.Serializable;

namespace TournamentsEnhanced.Models.ModState
{
  public class ModState
  {
    public static DaysSinceTracker<TournamentType> DaysSince => _state.daysSince;
    public static TournamentRecordDictionary TournamentRecords => _state.tournamentRecords;

    public static int LotteryWinners
    {
      get => _state.dailyLotteryWinners;
      set => _state.dailyLotteryWinners = value;
    }

    public static void DailyTick()
    {
      DaysSince.DailyTick();
    }

    private static void Initialize()
    {
      _state.tournamentRecords = new TournamentRecordDictionary();
      _state.daysSince = new DaysSinceTracker(Constants.DaysSince.TournamentTypes);
      DaysSince.
    }

    public static void Reset()
    {
      _state = default(SerializableModState);
    }

    private static SerializableModState _state;

    public static SerializableModState SerializableObject { get => _state; set => _state = value; }

    static ModState() => Initialize();
  }
}