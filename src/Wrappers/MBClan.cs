using System.Collections.Generic;

using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.Wrappers
{

  public interface IMBFaction
  {
    MBHeroList Lords { get; }
    MBMobilePartyList WarParties { get; }
    bool IsBanditFaction { get; }
    bool IsMinorFaction { get; }
    bool IsKingdomFaction { get; }
    bool IsRebelClan { get; }
    bool IsClan { get; }
    bool IsOutlaw { get; }
    bool IsMapFaction { get; }
    IFaction MapFaction { get; }
    float TotalStrength { get; }
    Vec2 FactionMidPoint { get; }
    MBStanceLinkList Stances { get; }
    int TributeWallet { get; set; }
    float MainHeroCrimeRating { get; set; }
    float DailyCrimeRatingChange { get; }
    float Aggressiveness { get; }
    bool IsEliminated { get; }
    MBMobilePartyList AllParties { get; }
    MBHeroList Heroes { get; }
    CampaignTime NotAttackableByPlayerUntilTime { get; set; }
    MBTownList Fiefs { get; }
    MBTextObject Name { get; }
    string StringId { get; }
    MBTextObject InformalName { get; }
    string EncyclopediaLink { get; }
    MBTextObject EncyclopediaLinkWithName { get; }
    MBTextObject EncyclopediaText { get; }
    MBCultureObject Culture { get; }
    MBStatExplainer DailyCrimeRatingChangeExplained { get; }
    Vec2 InitialPosition { get; }
    uint Color { get; }
    uint Color2 { get; }
    uint AlternativeColor { get; }
    uint AlternativeColor2 { get; }
    MBCharacterObject BasicTroop { get; }
    MBHero Leader { get; }
    MBBanner Banner { get; }
    MBSettlementList Settlements { get; }
    uint LabelColor { get; }

    MBStanceLink GetStanceWith(IFaction other);
    bool IsAtWarWith(IFaction other);
  }

  public class MBClan : CachedWrapperBase<MBClan, Clan>, IMBFaction
  {
    public float Renown => UnwrappedObject.Renown;

    public MBTextObject Name => UnwrappedObject.Name;

    public string StringId => UnwrappedObject.StringId;

    public MBTextObject InformalName => UnwrappedObject.InformalName;

    public string EncyclopediaLink => UnwrappedObject.EncyclopediaLink;

    public MBTextObject EncyclopediaLinkWithName => UnwrappedObject.EncyclopediaLinkWithName;

    public MBTextObject EncyclopediaText => UnwrappedObject.EncyclopediaText;

    public MBCultureObject Culture => UnwrappedObject.Culture;

    public Vec2 InitialPosition => UnwrappedObject.InitialPosition;

    public uint LabelColor => UnwrappedObject.LabelColor;

    public uint Color => UnwrappedObject.Color;

    public uint Color2 => UnwrappedObject.Color2;

    public uint AlternativeColor => UnwrappedObject.AlternativeColor;

    public uint AlternativeColor2 => UnwrappedObject.AlternativeColor2;

    public MBCharacterObject BasicTroop => UnwrappedObject.BasicTroop;

    public MBHero Leader => UnwrappedObject.Leader;

    public MBBanner Banner => UnwrappedObject.Banner;

    public MBSettlementList Settlements => UnwrappedObject.Settlements.ToList();

    public MBTownList Fiefs => UnwrappedObject.Fiefs.ToList();

    public MBHeroList Lords => UnwrappedObject.Lords.ToList();

    public MBHeroList Heroes => UnwrappedObject.Heroes.ToList();

    public MBMobilePartyList AllParties => UnwrappedObject.AllParties.ToList();

    public MBMobilePartyList WarParties => UnwrappedObject.WarParties.ToList();

    public bool IsBanditFaction => UnwrappedObject.IsBanditFaction;

    public bool IsMinorFaction => UnwrappedObject.IsMinorFaction;

    public bool IsKingdomFaction => UnwrappedObject.IsKingdomFaction;

    public bool IsRebelClan => UnwrappedObject.IsRebelClan;

    public bool IsClan => UnwrappedObject.IsClan;

    public bool IsOutlaw => UnwrappedObject.IsOutlaw;

    public bool IsMapFaction => UnwrappedObject.IsMapFaction;

    public IFaction MapFaction => UnwrappedObject.MapFaction;

    public float TotalStrength => UnwrappedObject.TotalStrength;

    public Vec2 FactionMidPoint => UnwrappedObject.FactionMidPoint;

    public MBStanceLinkList Stances => UnwrappedObject.Stances.ToList();

    public int TributeWallet { get => UnwrappedObject.TributeWallet; set => UnwrappedObject.TributeWallet = value; }

    public float MainHeroCrimeRating { get => UnwrappedObject.MainHeroCrimeRating; set => UnwrappedObject.MainHeroCrimeRating = value; }

    public float DailyCrimeRatingChange => UnwrappedObject.DailyCrimeRatingChange;

    public float Aggressiveness => UnwrappedObject.Aggressiveness;

    public bool IsEliminated => UnwrappedObject.IsEliminated;

    public MBStatExplainer DailyCrimeRatingChangeExplained => UnwrappedObject.DailyCrimeRatingChangeExplained;

    public CampaignTime NotAttackableByPlayerUntilTime { get => UnwrappedObject.NotAttackableByPlayerUntilTime; set => UnwrappedObject.NotAttackableByPlayerUntilTime = value; }


    public MBStanceLink GetStanceWith(IFaction other) => UnwrappedObject.GetStanceWith(other);

    public bool IsAtWarWith(IFaction other) => UnwrappedObject.IsAtWarWith(other);

    public static implicit operator Clan(MBClan wrapper) => wrapper.UnwrappedObject;
    public static implicit operator MBClan(Clan obj) => MBClan.GetWrapperFor(obj);
  }

  public class MBClanList : List<MBClan>
  {
    public static implicit operator List<Clan>(MBClanList wrapperList) => wrapperList.Unwrap<MBClan, Clan>();
    public static implicit operator MBClanList(List<Clan> objectList) => (MBClanList)objectList.Wrap<MBClan, Clan>();
  }
}
