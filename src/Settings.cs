﻿using System;
using System.Xml.Serialization;

using ModLib.Definitions;
using ModLib.Definitions.Attributes;
using static TournamentsEnhanced.Constants.Settings;

namespace TournamentsEnhanced
{
  public class Settings : SettingsBase
  {
    public static Settings Instance { get; } = (Settings)SettingsDatabase.GetSettings<Settings>() ?? new Settings();
    public override string ModName => Constants.Module.Name;
    public override string ModuleFolderName => Constants.Module.ProductName;

    [XmlElement]
    public override string ID { get; set; } = $"{Constants.Module.ProductName}Settings";

    //Notifications
    [SettingProperty("Prosperity Tournament Notification", "Tell me when prosperity tournaments are announced")]
    [SettingPropertyGroup("Notifications")]
    public virtual bool ProsperityNotification { get; set; } = Default.ProsperityNotification;
    [SettingProperty("Peace Tournament Notification", "Tell me when peace tournaments are announced")]
    [SettingPropertyGroup("Notifications")]
    public virtual bool PeaceNotification { get; set; } = Default.PeaceNotification;
    [SettingProperty("Settlement Stat Change Notification", "Tell me when a tournament affects my settlement's stats")]
    [SettingPropertyGroup("Notifications")]
    public virtual bool SettlementStatNotification { get; set; } = Default.SettlementStatNotification;

    //Tournament Affects
    [SettingProperty("Prosperity Increase", -500.00f, 500.00f, "Prosperity increase for certain tournament types. Negative values decreases prosperity instead.")]
    [SettingPropertyGroup("Tournament affects on Towns")]
    public virtual float ProsperityIncrease { get; set; } = Default.ProsperityIncrease;
    [SettingProperty("Loyalty Increase", -30.00f, 30.00f, "Loyalty increase for certain tournament types. Negative values decreases loyalty instead.")]
    [SettingPropertyGroup("Tournament affects on Towns")]
    public virtual float LoyaltyIncrease { get; set; } = Default.LoyaltyIncrease;
    [SettingProperty("Security Increase", -30.00f, 30.00f, "Security increase for certain tournament types. Negative values decreases security instead.")]
    [SettingPropertyGroup("Tournament affects on Towns")]
    public virtual float SecurityIncrease { get; set; } = Default.SecurityIncrease;
    [SettingProperty("Food Stocks Decrease", -30.00f, 30.00f, "Food stock decrease for certain tournament types. Negative values increase food stock instead.")]
    [SettingPropertyGroup("Tournament affects on Towns")]
    public virtual float FoodStocksDecrease { get; set; } = Default.FoodStocksDecrease;

    //Tournament Cost
    [SettingProperty("Required minimum Prosperity needed for a town to host a Prosperity Tournament", 0, 10000, "The minimum prosperity needed for a Town to be eligible for a prosperity tournament")]
    [SettingPropertyGroup("Tournaments")]
    public virtual float MinProsperityRequirement { get; set; } = Default.MinProsperityRequirement;

    [SettingProperty("Tournament Cost", 0, 10000, "Cost of tournaments")]
    [SettingPropertyGroup("Tournaments")]
    public virtual int TournamentCost { get; set; } = Default.TournamentCost;
    [SettingProperty("Number to Spawn", 0, 20, "Number of tournaments to spawn when starting a new campaign.")]
    [SettingPropertyGroup("Initial Tournaments")]
    public virtual int TournamentInitialSpawnCount { get; set; } = Default.TournamentInitialSpawnCount;
    [SettingProperty("Tournament Win Skill XP", 0, 10000, "Amount of XP gained for targeted skill on a tournament win")]
    [SettingPropertyGroup("Tournaments")]
    public virtual int TournamentSkillXP { get; set; } = Default.TournamentSkillXP;
    [SettingProperty("Tournament Hit Skill XP", 0f, 10f, "XP multiplier for hits in tournaments")]
    [SettingPropertyGroup("Tournaments")]
    public virtual float TournamentHitXP { get; set; } = Default.TournamentHitXP;
    [SettingProperty("Arena Hit Skill XP", 0f, 10f, "XP multiplier for hits in the arena")]
    [SettingPropertyGroup("Tournaments")]
    public virtual float ArenaHitXP { get; set; } = Default.ArenaHitXP;
    [SettingProperty("Tournament Combat AI Difficulty", "I want tournaments harder than normal battles")]
    [SettingPropertyGroup("Tournaments")]
    public virtual bool VeryHardTournaments { get; set; } = Default.VeryHardTournaments;
    [SettingProperty("Maximum of Heroes added", 5, 10, "Max number of faction Heroes added to tournaments (makes them more difficult)")]
    [SettingPropertyGroup("Tournaments")]
    public virtual int UpperBoundHeroesAdded { get; set; } = Default.UpperBoundHeroesAdded;
    [SettingProperty("Renown Reward", 0, 100, "Amount of Renown received for winning a tournament")]
    [SettingPropertyGroup("Tournaments")]
    public virtual int RenownReward { get; set; } = Default.RenownReward;
    [SettingProperty("Bring Companions", "I want my companions to join me in tournaments (on my team when possible)")]
    [SettingPropertyGroup("Tournaments")]
    public virtual bool BringCompanions { get; set; } = Default.BringCompanions;

    [SettingProperty("Hosted Tournament Cooldown", "Minimum number of days between player-hosted tournaments.")]
    [SettingPropertyGroup("Tournaments")]
    public virtual int MinDaysBetweenHostedTournaments { get; set; } = Default.MinDaysBetweenHostedTournaments;
    [SettingProperty("Number of Prizes To Choose From", 1, 25, "How many items to choose from when selecting a tournament prize. If set to 1, the prize selection menu option will be hidden.")]
    [SettingPropertyGroup("Tournaments")]
    public virtual int NumberOfPrizesToChooseFrom { get; set; } = Default.NumberOfPrizesToChooseFrom;
    [SettingProperty("Noble Relation Increase", "Your relation with local nobles will increase by this much when you host a tournament.")]
    [SettingPropertyGroup("Player-Hosted Tournaments")]
    public virtual int NoblesRelationIncrease { get; set; } = Default.NoblesRelationIncrease;
    [SettingProperty("Max Renown For Invitation", "Once your renown is higher than this value, you will be too famous for these tournaments.")]
    [SettingPropertyGroup("Invitation Tournaments")]
    public virtual float MaxRenownForInvitationTournaments { get; set; } = Default.MaxRenownForInvitationTournaments;
  }
}
