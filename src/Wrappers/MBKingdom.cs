using System.Collections.Generic;

using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.Wrappers
{
  public class MBKingdom : CachedWrapperBase<MBKingdom, Kingdom>
  {
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

    public IEnumerable<StanceLink> Stances => UnwrappedObject.Stances;

    public int TributeWallet { get => UnwrappedObject.TributeWallet; set => UnwrappedObject.TributeWallet = value; }

    public float MainHeroCrimeRating { get => UnwrappedObject.MainHeroCrimeRating; set => UnwrappedObject.MainHeroCrimeRating = value; }

    public float DailyCrimeRatingChange => UnwrappedObject.DailyCrimeRatingChange;

    public float Aggressiveness => UnwrappedObject.Aggressiveness;

    public bool IsEliminated => UnwrappedObject.IsEliminated;

    public StatExplainer DailyCrimeRatingChangeExplained => UnwrappedObject.DailyCrimeRatingChangeExplained;

    public CampaignTime NotAttackableByPlayerUntilTime { get => UnwrappedObject.NotAttackableByPlayerUntilTime; set => UnwrappedObject.NotAttackableByPlayerUntilTime = value; }

    public StanceLink GetStanceWith(IFaction other) => UnwrappedObject.GetStanceWith(other);

    public bool IsAtWarWith(IFaction other) => UnwrappedObject.IsAtWarWith(other);

    public static implicit operator Kingdom(MBKingdom wrapper) => wrapper.UnwrappedObject;
    public static implicit operator MBKingdom(Kingdom obj) => MBKingdom.GetWrapperFor(obj);
  }

  public class MBKingdomList : List<MBKingdom>
  {
    public static implicit operator List<Kingdom>(MBKingdomList wrapperList) => wrapperList.Unwrap<MBKingdom, Kingdom>();
    public static implicit operator MBKingdomList(List<Kingdom> objectList) => (MBKingdomList)objectList.Wrap<MBKingdom, Kingdom>();
  }
}