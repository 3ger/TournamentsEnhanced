using System.Collections.Generic;

using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

using TournamentsEnhanced.Wrappers.Abstract;
using TournamentsEnhanced.Wrappers.Core;
using TournamentsEnhanced.Wrappers.Localization;

namespace TournamentsEnhanced.Wrappers.CampaignSystem
{
  public class MBKingdom : CachedWrapperBase<MBKingdom, Kingdom>
  {
    public static MBKingdomList All => Kingdom.All.ToList();
    public MBTextObject Name => UnwrapedObject.Name;

    public string StringId => UnwrapedObject.StringId;

    public MBTextObject InformalName => UnwrapedObject.InformalName;

    public string EncyclopediaLink => UnwrapedObject.EncyclopediaLink;

    public MBTextObject EncyclopediaLinkWithName => UnwrapedObject.EncyclopediaLinkWithName;

    public MBTextObject EncyclopediaText => UnwrapedObject.EncyclopediaText;

    public MBCultureObject Culture => UnwrapedObject.Culture;

    public Vec2 InitialPosition => UnwrapedObject.InitialPosition;

    public uint LabelColor => UnwrapedObject.LabelColor;

    public uint Color => UnwrapedObject.Color;

    public uint Color2 => UnwrapedObject.Color2;

    public uint AlternativeColor => UnwrapedObject.AlternativeColor;

    public uint AlternativeColor2 => UnwrapedObject.AlternativeColor2;

    public MBCharacterObject BasicTroop => UnwrapedObject.BasicTroop;

    public MBHero Leader => UnwrapedObject.Leader;

    public MBBanner Banner => UnwrapedObject.Banner;

    public MBSettlementList Settlements => UnwrapedObject.Settlements.ToList();

    public MBTownList Fiefs => UnwrapedObject.Fiefs.ToList();

    public MBHeroList Lords => UnwrapedObject.Lords.ToList();

    public MBHeroList Heroes => UnwrapedObject.Heroes.ToList();

    public MBMobilePartyList AllParties => UnwrapedObject.AllParties.ToList();

    public MBMobilePartyList WarParties => UnwrapedObject.WarParties.ToList();

    public bool IsBanditFaction => UnwrapedObject.IsBanditFaction;

    public bool IsMinorFaction => UnwrapedObject.IsMinorFaction;

    public bool IsKingdomFaction => UnwrapedObject.IsKingdomFaction;

    public bool IsRebelClan => UnwrapedObject.IsRebelClan;

    public bool IsClan => UnwrapedObject.IsClan;

    public bool IsOutlaw => UnwrapedObject.IsOutlaw;

    public bool IsMapFaction => UnwrapedObject.IsMapFaction;

    public IFaction MapFaction => UnwrapedObject.MapFaction;

    public float TotalStrength => UnwrapedObject.TotalStrength;

    public Vec2 FactionMidPoint => UnwrapedObject.FactionMidPoint;

    public IEnumerable<StanceLink> Stances => UnwrapedObject.Stances;

    public int TributeWallet { get => UnwrapedObject.TributeWallet; set => UnwrapedObject.TributeWallet = value; }

    public float MainHeroCrimeRating { get => UnwrapedObject.MainHeroCrimeRating; set => UnwrapedObject.MainHeroCrimeRating = value; }

    public float DailyCrimeRatingChange => UnwrapedObject.DailyCrimeRatingChange;

    public float Aggressiveness => UnwrapedObject.Aggressiveness;

    public bool IsEliminated => UnwrapedObject.IsEliminated;

    public StatExplainer DailyCrimeRatingChangeExplained => UnwrapedObject.DailyCrimeRatingChangeExplained;

    public CampaignTime NotAttackableByPlayerUntilTime { get => UnwrapedObject.NotAttackableByPlayerUntilTime; set => UnwrapedObject.NotAttackableByPlayerUntilTime = value; }

    public StanceLink GetStanceWith(IFaction other) => UnwrapedObject.GetStanceWith(other);

    public bool IsAtWarWith(IFaction other) => UnwrapedObject.IsAtWarWith(other);

    public static implicit operator Kingdom(MBKingdom wrapper) => wrapper.UnwrapedObject;
    public static implicit operator MBKingdom(Kingdom obj) => MBKingdom.GetWrapperFor(obj);
  }

  public class MBKingdomList : List<MBKingdom>
  {
    public static implicit operator List<Kingdom>(MBKingdomList wrapperList) => wrapperList.Unwrap<MBKingdom, Kingdom>();
    public static implicit operator MBKingdomList(List<Kingdom> objectList) => (MBKingdomList)objectList.Wrap<MBKingdom, Kingdom>();
  }
}
