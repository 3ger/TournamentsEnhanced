using System.Collections.Generic;

using TaleWorlds.CampaignSystem;

using TournamentsEnhanced.Wrappers.Abstract;

using static TaleWorlds.CampaignSystem.SettlementComponent;

namespace TournamentsEnhanced.Wrappers
{

  public interface IMBTown
  {
    int DaysAtUnrest { get; }
    List<MBBuilding> Buildings { get; }
    int BoostBuildingProcess { get; }
    bool InRebelliousState { get; }
    IFaction MapFaction { get; }
    float MilitiaChange { get; }
    float Construction { get; }
    MBClan OwnerClan { get; set; }
    float Security { get; set; }
    float Loyalty { get; set; }
    MBWorkshop[] Workshops { get; }
    MBBuilding CurrentBuilding { get; }
    bool IsUnderSiege { get; }
    MBBuilding CurrentDefaultBuilding { get; }
    int TradeTaxAccumulated { get; set; }
    MBHero Governor { get; set; }
    MBClan LastCapturedBy { get; set; }
    IReadOnlyList<Village> Villages { get; }
    MBMobileParty MilitiaParty { get; }
    MBTownMarketData MarketData { get; }
    float SecurityChange { get; }
    float LoyaltyChange { get; }
    bool HasTournament { get; }
    float FoodChange { get; }
    int GarrisonChange { get; }
    float ProsperityChange { get; }
    MBCultureObject Culture { get; }
    bool AfterSneakFight { get; set; }

    int FoodStocksUpperLimit();
    float GetItemCategoryPriceIndex(MBItemCategory itemCategory, bool isSellingToTown = false);
    int GetItemPrice(MBEquipmentElement itemRosterElement, MBMobileParty tradingParty = null, bool isSelling = false);
    int GetItemPrice(MBItemObject item, MBMobileParty tradingParty = null, bool isSelling = false);
    ProsperityLevel GetProsperityLevel();
    int GetWallLevel();

  }
  public class MBTown : CachedWrapperBase<MBTown, Town>, IMBTown
  {
    public static List<MBTown> AllFiefs { get; }
    public static List<MBTown> AllCastles { get; }
    public static List<MBTown> AllTownsWithoutTournaments => AllTowns.WrapAll<MBTown, Town>();
    public static List<MBTown> AllTownsWithTournaments => AllTowns.ToList().FindAll((town) => town.HasTournament);
    public static List<MBTown> AllTowns => Town.AllTowns.ToList().Wrap();

    public int DaysAtUnrest => UnwrappedObject.DaysAtUnrest;

    public List<MBBuilding> Buildings => UnwrappedObject.Buildings.ToList().Wrap<MBBuilding>();

    public int BoostBuildingProcess => UnwrappedObject.BoostBuildingProcess;

    public bool InRebelliousState => UnwrappedObject.InRebelliousState;

    public IFaction MapFaction => UnwrappedObject.MapFaction;

    public float MilitiaChange => UnwrappedObject.MilitiaChange;

    public float Construction => UnwrappedObject.Construction;

    public MBClan OwnerClan { get => UnwrappedObject.OwnerClan; set => UnwrappedObject.OwnerClan = value; }
    public float Security { get => UnwrappedObject.Security; set => UnwrappedObject.Security = value; }
    public float Loyalty { get => UnwrappedObject.Loyalty; set => UnwrappedObject.Loyalty = value; }

    public MBWorkshop[] Workshops => throw new System.NotImplementedException();

    public MBBuilding CurrentBuilding => throw new System.NotImplementedException();

    public bool IsUnderSiege => throw new System.NotImplementedException();

    public MBBuilding CurrentDefaultBuilding => throw new System.NotImplementedException();

    public int TradeTaxAccumulated { get => UnwrappedObject.TradeTaxAccumulated; set => UnwrappedObject.TradeTaxAccumulated = value; }
    public MBHero Governor { get => UnwrappedObject.Governor; set => UnwrappedObject.Governor = value; }
    public MBClan LastCapturedBy { get => UnwrappedObject.LastCapturedBy; set => UnwrappedObject.LastCapturedBy = value; }

    public IReadOnlyList<Village> Villages => throw new System.NotImplementedException();

    public MBMobileParty MilitiaParty => throw new System.NotImplementedException();

    public MBTownMarketData MarketData => throw new System.NotImplementedException();

    public float SecurityChange => throw new System.NotImplementedException();

    public float LoyaltyChange => throw new System.NotImplementedException();

    public bool HasTournament => throw new System.NotImplementedException();

    public float FoodChange => throw new System.NotImplementedException();

    public int GarrisonChange => throw new System.NotImplementedException();

    public float ProsperityChange => throw new System.NotImplementedException();

    public MBCultureObject Culture => throw new System.NotImplementedException();

    public bool AfterSneakFight { get => UnwrappedObject.AfterSneakFight; set => UnwrappedObject.AfterSneakFight = value; }

    public int FoodStocksUpperLimit() => UnwrappedObject.FoodStocksUpperLimit();

    public float GetItemCategoryPriceIndex(MBItemCategory itemCategory, bool isSellingToTown = false) => UnwrappedObject.GetItemCategoryPriceIndex(itemCategory, isSellingToTown);

    public int GetItemPrice(MBEquipmentElement itemRosterElement, MBMobileParty tradingParty = null, bool isSelling = false) => UnwrappedObject.GetItemPrice(itemRosterElement, tradingParty, isSelling);

    public int GetItemPrice(MBItemObject item, MBMobileParty tradingParty = null, bool isSelling = false) => UnwrappedObject.GetItemPrice(item, tradingParty, isSelling);

    public ProsperityLevel GetProsperityLevel() => UnwrappedObject.GetProsperityLevel();

    public int GetWallLevel() => UnwrappedObject.GetWallLevel();

    public static implicit operator Town(MBTown wrapper) => wrapper.UnwrappedObject;
    public static implicit operator MBTown(Town obj) => MBTown.GetWrapperFor(obj);
  }
}
