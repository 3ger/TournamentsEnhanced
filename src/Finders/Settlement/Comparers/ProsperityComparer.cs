using TournamentsEnhanced.Wrappers.CampaignSystem;

namespace TournamentsEnhanced.Finder.Comparers.Settlement
{
  public class ProsperityComparer : ExistingTournamentComparer
  {
    public new static ProsperityComparer Instance { get; } = new ProsperityComparer();
    public new static ProsperityComparer InstanceIncludingExisting { get; } = new ProsperityComparer(false, true);
    public static ProsperityComparer InstanceMinProsperityRequirement { get; } = new ProsperityComparer(true);
    public static ProsperityComparer InstanceMinProsperityRequirementIncludingExisting { get; } = new ProsperityComparer(true, true);

    public virtual bool RequireMinProsperity { get; protected set; }

    protected ProsperityComparer(bool hasProsperityRequirement = false,
                              bool canOverrideExisting = false,
                              MBHero initiatingHero = null) : base(canOverrideExisting, initiatingHero)
    {
      RequireMinProsperity = hasProsperityRequirement;
    }

    public override int Compare(MBSettlement x, MBSettlement y)
    {
      var result = 0;

      if (!TryComparePreconditions(x, y, ref result))
      {
        CompareProsperity(x, y, out result);
      }

      return result;
    }

    protected virtual bool CompareProsperity(MBSettlement x, MBSettlement y, out int result)
    {
      var xIsMoreProsperous = x.Prosperity > y.Prosperity;
      var xIsLessProsperous = x.Prosperity < y.Prosperity;

      result = xIsMoreProsperous ? Constants.Comparer.XOutranksY : xIsLessProsperous ? Constants.Comparer.YOutranksX : Constants.Comparer.BothEqualRank;

      return true;
    }

    protected override bool MeetsRequirements(MBSettlement settlement) =>
      base.MeetsRequirements(settlement) &&
      (!RequireMinProsperity || settlement.Prosperity >= Settings.MinProsperityRequirement);
  }
}