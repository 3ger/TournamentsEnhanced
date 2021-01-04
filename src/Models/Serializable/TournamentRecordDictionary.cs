using System.Collections.Generic;

using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Models.Serializable
{
  public class TournamentRecordDictionary : Dictionary<string, TournamentRecord>
  {
    public TournamentRecord this[MBSettlement settlement]
    {
      get
      {
        var settlementId = settlement.StringId;

        return ContainsKey(settlementId) ? this[settlementId] : default(TournamentRecord);
      }

      set
      {
        if (settlement == MBSettlement.Null)
        {
          return;
        }

        this[settlement.StringId] = value;
      }
    }

    public TournamentRecord ForCurrentTown()
    {
      return this[MBHero.MainHero.CurrentSettlement.Settlement];
    }

    public bool ContainsSettlement(MBSettlement settlement) => ContainsKey(settlement.StringId);

    public void AddOrUpdate(TournamentRecord record) => this[record.hostSettlementId] = record;

    public void Remove(MBSettlement settlement) => Remove(settlement.StringId);
  }
}
