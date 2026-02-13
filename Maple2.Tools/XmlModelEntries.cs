using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Serialization;

namespace Maple2.Tools;

public class EffectGroupEntry {
    [XmlAttribute("groupId")]
    public int GroupId { get; set; }
    [XmlElement("value")]
    public List<EffectValue> Values { get; set; } = [];
}

public record Effect(int Id, int Level);
public class EffectValue {
    [XmlAttribute("effectId")]
    public string EffectIdRaw { get; set; }
    [XmlAttribute("effectLevel")]
    public string EffectLevelRaw { get; set; }
    [XmlIgnore]
    public List<Effect> Effects { get; set; } = [];

    public void Initialize() {
        var ids = ParseIntArray(EffectIdRaw);
        var levels = ParseIntArray(EffectLevelRaw);

        // Zips the two arrays into a single list of Effect objects
        // If one array is shorter, Zip stops at the end of the shortest one
        Effects = ids.Zip(levels, (id, lvl) => new Effect(id, lvl)).ToList();
    }

    private int[] ParseIntArray(string raw) {
        if (string.IsNullOrWhiteSpace(raw)) return Array.Empty<int>();
        return raw.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
    }
}

public class AdventureExpEntry {
    [XmlAttribute("type")]
    public string Type { get; set; }
    [XmlAttribute("value")]
    public string Value { get; set; }
}

public class AdventureIdExpEntry {
    [XmlAttribute("id")]
    public string Id { get; set; }
    [XmlAttribute("value")]
    public string Value { get; set; }
    [XmlAttribute("expType")]
    public string ExpType { get; set; }
}

public class ArcadeGameEntry {
    [XmlAttribute("arcadeId")]
    public string ArcadeId { get; set; }
    [XmlElement("reward")]
    public List<ArcadeGameReward> arcadeGameRewards { get; set; } = [];
}

public class ArcadeGameReward {
    [XmlAttribute("round")]
    public int Round { get; set; }
    [XmlAttribute("expRate")]
    public float ExpRate { get; set; }
    [XmlAttribute("meso")]
    public int Meso { get; set; }
}

public class AttendGiftEntry {
    [XmlAttribute("attendEventID")]
    public int AttendEventId { get; set; }
    [XmlAttribute("attendIndex")]
    public int AttendIndex { get; set; }
    [XmlAttribute("special")]
    public bool Special { get; set; }
    [XmlAttribute("systemMailID")]
    public int SystemMailId { get; set; }
    [XmlAttribute("messageTextID")]
    public int MessageTextId { get; set; }
    [XmlAttribute("giftIcon")]
    public string GiftIcon { get; set; }
    [XmlAttribute("tooltipTextID")]
    public int TooltipTextId { get; set; }
    [XmlElement("item")]
    public List<AttendGiftItem> AttendGiftItems { get; set; } = [];
}

public class AttendGiftItem {
    [XmlAttribute("itemID")]
    public int ItemId { get; set; }
    [XmlAttribute("count")]
    public int Count { get; set; }
    [XmlAttribute("grade")]
    public int Grade { get; set; }
}

public class AttendGiftEventEntry {
    [XmlAttribute("attendEventID")]
    public int AttendEventId { get; set; }
    [XmlAttribute("startDate")]
    public DateTime StartDate { get; set; }
    [XmlAttribute("endDate")]
    public DateTime EndDate { get; set; }
}

public class BonusGameEntry {
    [XmlAttribute("gameType")]
    public int GameType { get; set; }
    [XmlAttribute("gameID")]
    public int GameId { get; set; }
    [XmlAttribute("consumeItemID")]
    public int ConsumeItemId { get; set; }
    [XmlAttribute("consumeItemCount")]
    public int ConsumeItemCount { get; set; }
    [XmlAttribute("locale")]
    public string Locale { get; set; }

    [XmlElement("slot")]
    public List<BonusGameSlot> Slots { get; set; } = [];
}

public class BonusGameSlot {
    [XmlAttribute("minProp")]
    public int MinProp { get; set; }
    [XmlAttribute("maxProp")]
    public int maxProp { get; set; }
}

public class BonusGameDropEntry {
    [XmlAttribute("gameType")]
    public int GameType { get; set; }
    [XmlAttribute("gameID")]
    public int GameId { get; set; }
    [XmlAttribute("locale")]
    public string Locale { get; set; }
    [XmlAttribute("feature")]
    public string Feature { get; set; }
    [XmlElement("item")]
    public List<BonusGameDropItem> Items { get; set; } = [];
}

public class BonusGameDropItem {
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("rank")]
    public int Rank { get; set; }
    [XmlAttribute("count")]
    public int Count { get; set; }
    [XmlAttribute("prop")]
    public int Prop { get; set; }
    [XmlAttribute("notice")]
    public bool Notice { get; set; }
}

public class CombineSpawnGroupEntry {
    [XmlAttribute("groupId")]
    public int GroupId { get; set; }
    [XmlAttribute("groupType")]
    public string GroupType { get; set; }
    [XmlAttribute("combineCount")]
    public int CombineCount { get; set; }
    [XmlAttribute("resetTick")]
    public int ResetTick { get; set; }
    [XmlAttribute("fieldId")]
    public int FieldId { get; set; }
    [XmlAttribute("feature")]
    public string Feature { get; set; }
}

public class CombineSpawnInteractObjectEntry {
    [XmlAttribute("combineId")]
    public int CombineId { get; set; }
    [XmlAttribute("groupId")]
    public int GroupId { get; set; }
    [XmlAttribute("weight")]
    public int Weight { get; set; }
    [XmlAttribute("regionSpawnId")]
    public int RegionSpawnId { get; set; }
    [XmlAttribute("interactId")]
    public int InteractId { get; set; }
    [XmlAttribute("model")]
    public string Model { get; set; }
    [XmlAttribute("asset")]
    public string Asset { get; set; }
    [XmlAttribute("normal")]
    public string Normal { get; set; }
    [XmlAttribute("reactable")]
    public string Reactable { get; set; }
    [XmlAttribute("scale")]
    public float Scale { get; set; }
    [XmlAttribute("feature")]
    public string Feature { get; set; }
}

public class CombineSpawnNpcEntry {
    [XmlAttribute("combineId")]
    public int CombineId { get; set; }
    [XmlAttribute("groupId")]
    public int GroupId { get; set; }
    [XmlAttribute("weight")]
    public int Weight { get; set; }
    [XmlAttribute("spawnId")]
    public int SpawnId { get; set; }
    [XmlAttribute("feature")]
    public string Feature { get; set; }
}

public class ConstantsEntry {
    [XmlAttribute("key")]
    public string Key { get; set; }
    [XmlAttribute("value")]
    public string Value { get; set; }
    [XmlAttribute("locale")]
    public string Locale { get; set; }
}

public class DefaultCharacterInfoGenderData {
    [XmlAttribute("value")]
    public int Value { get; set; }
    [XmlElement("skin")]
    public DefaultCharacterInfoSkinData Skin { get; set; }
    [XmlArray("items")]
    [XmlArrayItem("item")]
    public List<DefaultCharacterInfoItem> Items { get; set; } = [];
}

public class DefaultCharacterInfoSkinData {
    [XmlAttribute("colorPaletteID")]
    public int ColorPaletteId { get; set; }
    [XmlAttribute("colorSN")]
    public int ColorSn { get; set; }
}

public class DefaultCharacterInfoItem {
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("slotHint")]
    public string SlotHint { get; set; }
    [XmlAttribute("colorPaletteID")]
    public int ColorPaletteId { get; set; }
    [XmlAttribute("colorSN")]
    public int ColorSn { get; set; }
    [XmlArray("controls")]
    [XmlArrayItem("control")]
    public List<DefaultCharacterInfoItemControl> Controls { get; set; } = [];
}

public class DefaultCharacterInfoItemControl {
    [XmlAttribute("index")]
    public int Index { get; set; }
    [XmlAttribute("scale")]
    public double Scale { get; set; }
    [XmlAttribute("position")]
    public string PositionRaw { get; set; }
    [XmlAttribute("rotation")]
    public string RotationRaw { get; set; }
    [XmlIgnore]
    public Vector3 Position { get; set; }
    [XmlIgnore]
    public Vector3 Rotation { get; set; }

    public void Initialize() {
        Position = ParseVector(PositionRaw);
        Rotation = ParseVector(RotationRaw);
    }

    private Vector3 ParseVector(string raw) {
        if (string.IsNullOrWhiteSpace(raw)) return Vector3.Zero;

        var parts = raw.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3) return Vector3.Zero;

        return new Vector3(
            float.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
            float.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
            float.Parse(parts[2].Trim(), CultureInfo.InvariantCulture)
        );
    }
}

public class DesignersHomeLayoutItemEntry {
    [XmlAttribute("sn")]
    public int Sn { get; set; }
    [XmlAttribute("index")]
    public int Index { get; set; }
    [XmlAttribute("visible")]
    public bool Visible { get; set; }
    [XmlAttribute("category")]
    public bool Category { get; set; }
    [XmlIgnore]
    public DesignersHomeLayoutCategoryEntry ParentCategory { get; set; }
}

public class DesignersHomeLayoutCategoryEntry {
    [XmlAttribute("stringId")]
    public int StringId { get; set; }
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("colorIndex")]
    public int ColorIndex { get; set; }
    [XmlAttribute("indexes")]
    public string IndexesRaw { get; set; }
    [XmlIgnore]
    public int[] IndexList { get; private set; }
    [XmlIgnore]
    public List<DesignersHomeLayoutItemEntry> LinkedItems { get; set; } = [];

    public void Initialize() {
        if (!string.IsNullOrWhiteSpace(IndexesRaw)) {
            IndexList = IndexesRaw.Split(',')
                .Select(s => int.Parse(s.Trim()))
                .ToArray();
        } else {
            IndexList = Array.Empty<int>();
        }
    }
}

public class DungeonScaleStatEntry {
    [XmlAttribute("dungeonScaleStatID")]
    public int DungeonScaleStatId { get; set; }
    [XmlAttribute("scaleStatRate")]
    public float ScaleStatRate { get; set; }
    [XmlAttribute("scaleBaseTap")]
    public int ScaleBaseTap { get; set; }
    [XmlAttribute("scaleBaseDef")]
    public int ScaleBaseDef { get; set; }
    [XmlAttribute("scaleBaseSpaRate")]
    public float ScaleBaseSpaRate { get; set; }
}

public class DungeonScoreBonusEntry {
    [XmlAttribute("bonusId")]
    public int BonusId { get; set; }
    [XmlAttribute("requireScore")]
    public int RequireScore { get; set; }
    [XmlAttribute("itemId")]
    public int ItemId { get; set; }
    [XmlAttribute("count")]
    public int Count { get; set; }
}

public class EnchantOptionEntry {
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("slot")]
    public int Slot { get; set; }
    [XmlAttribute("grade")]
    public int Grade { get; set; }
    [XmlAttribute("rank")]
    public int Rank { get; set; }
    [XmlAttribute("rate")]
    public float Rate { get; set; }
    [XmlAttribute("minLv")]
    public int MinLv { get; set; }
    [XmlAttribute("maxLv")]
    public int MaxLv { get; set; }
    [XmlAttribute("option")]
    public string OptionRaw { get; set; }
    [XmlIgnore]
    public int[] Options { get; set; } = [];

    public void Initialize() {
        if (!string.IsNullOrWhiteSpace(OptionRaw)) {
            Options = OptionRaw.Split(',')
                .Select(s => int.Parse(s.Trim()))
                .ToArray();
        }
    }
}

public class EnchantScrollEntry {
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("scrollType")]
    public int ScrollType { get; set; }
    [XmlAttribute("grade")]
    public string GradeRaw { get; set; }
    [XmlIgnore]
    public int[] Grade { get; set; }
    [XmlAttribute("successProp")]
    public string SuccessPropRaw { get; set; }
    [XmlIgnore]
    public int[] SuccessProp { get; set; }
    [XmlAttribute("minLv")]
    public int MinLv { get; set; }
    [XmlAttribute("maxLv")]
    public int MaxLv { get; set; }
    [XmlAttribute("minGrade")]
    public string MinGradeRaw {
        get => MinGrade.ToString();
        set => MinGrade = string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value);
    }
    [XmlIgnore]
    public int MinGrade { get; set; }
    [XmlAttribute("maxGrade")]
    public string MaxGradeRaw {
        get => MaxGrade.ToString();
        set => MaxGrade = string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value);
    }
    [XmlIgnore]
    public int MaxGrade { get; set; }
    [XmlAttribute("slot")]
    public string SlotRaw { get; set; }
    [XmlIgnore]
    public int[] Slot { get; set; }
    [XmlAttribute("rank")]
    public string RankRaw { get; set; }
    [XmlIgnore]
    public int[] Rank { get; set; }
    [XmlAttribute("isLockTrade")]
    public string IsLockTradeRaw { get; set; }
    [XmlIgnore]
    public bool IsLockTrade { get; set; }
    [XmlAttribute("disableBreak")]
    public bool DisableBreak { get; set; }
    [XmlAttribute("feature")]
    public string Feature { get; set; }
    [XmlAttribute("locale")]
    public string Locale { get; set; }

    public void Initialize() {
        Grade = ParseIntArray(GradeRaw);
        SuccessProp = ParseIntArray(SuccessPropRaw);
        Slot = ParseIntArray(SlotRaw);
        Rank = ParseIntArray(RankRaw);

        IsLockTrade = IsLockTradeRaw == "True";
    }

    private int[] ParseIntArray(string raw) {
        if (string.IsNullOrWhiteSpace(raw)) return [];
        return raw.Split(',')
                  .Select(s => int.Parse(s.Trim()))
                  .ToArray();
    }
}

public class ExceptEpicRestartEntry {
    [XmlAttribute("questID")]
    public string QuestIdRaw { get; set; }

    [XmlIgnore]
    public int MinQuestId { get; private set; }

    [XmlIgnore]
    public int MaxQuestId { get; private set; }

    [XmlIgnore]
    public bool IsRange => MinQuestId != MaxQuestId;

    public void Initialize() {
        var questIdTuple = ParseRange(QuestIdRaw);
        MinQuestId = questIdTuple.Item1;
        MaxQuestId = questIdTuple.Item2;
    }

    public bool Contains(int id) => id >= MinQuestId && id <= MaxQuestId;

    private Tuple<int, int> ParseRange(string raw) {
        string[]? parts = null;
        int min = 0;
        int max = 0;
        if (!string.IsNullOrWhiteSpace(raw)) {
            if (raw.Contains('-')) {
                parts = raw.Split('-');
                if (parts.Length == 2) {
                    min = int.Parse(parts[0].Trim());
                    max = int.Parse(parts[1].Trim());
                }
            } else {
                min = max = int.Parse(raw.Trim());
            }
        }

        return new Tuple<int, int>(min, max);
    }
}

public class ExploreExpTableEntry {	
    [XmlAttribute("level")]
    public int Level { get; set; }
    [XmlAttribute("mapCommon")]
    public int MapCommon { get; set; }
    [XmlAttribute("mapHidden")]
    public int MapHidden { get; set; }
    [XmlAttribute("taxi")]
    public int Taxi { get; set; }
    [XmlAttribute("telescope")]
    public int Telescope { get; set; }
    [XmlAttribute("rareChestFirst")]
    public int RareChestFirst { get; set; }
    [XmlAttribute("rareChest")]
    public int RareChest { get; set; }
    [XmlAttribute("normalChest")]
    public int NormalChest { get; set; }
    [XmlAttribute("expDrop")]
    public int ExpDrop { get; set; }
    [XmlAttribute("musicMastery1")]
    public int MusicMastery1;
    [XmlAttribute("musicMastery2")]
    public int MusicMastery2;
    [XmlAttribute("musicMastery3")]
    public int MusicMastery3;
    [XmlAttribute("musicMastery4")]
    public int MusicMastery4;
    [XmlAttribute("arcade")]
    public int Arcade { get; set; }
    [XmlAttribute("fishing")]
    public int Fishing { get; set; }
}

public class FieldRestrainTableEntry {
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("reduceRate")]
    public int ReduceRate { get; set; }
    [XmlElement("setItem")]
    public List<FieldRestrainTableSetItem> FieldRestrainTableSetItems { get; set; } = [];
}

public class FieldRestrainTableSetItem {
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlElement("v")]
    public List<FieldRestrainTableSetItemAccRate> AccRates { get; set; } = [];
}

public class FieldRestrainTableSetItemAccRate {
    [XmlAttribute("accRate")]
    public int AccRate { get; set; }
}

public class FishEntry {
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("fishingBook")]
    public int FishingBook { get; set; }
    [XmlAttribute("companion")]
    public int Companion { get; set; }
    [XmlAttribute("habitat")]
    public string Habitat { get; set; }
    [XmlAttribute("fishMastery")]
    public int FishMastery { get; set; }
    [XmlAttribute("lv")]
    public int Lv { get; set; }
    [XmlAttribute("rank")]
    public int Rank { get; set; }
    [XmlAttribute("pointCount")]
    public int PointCount { get; set; }
    [XmlAttribute("masteryPoint")]
    public int MasteryPoint { get; set; }
    [XmlAttribute("exp")]
    public int Exp { get; set; }
    [XmlAttribute("fishingTime")]
    public int FishingTime { get; set; }
    [XmlAttribute("catchProp")]
    public int CatchProp { get; set; }
    [XmlAttribute("baitProp")]
    public int BaitProp { get; set; }
    [XmlAttribute("smallSize")]
    public string SmallSizeRaw { get; set; }

    [XmlIgnore]
    public int MinSmallSize { get; set; }
    [XmlIgnore]
    public int MaxSmallSize { get; set; }
    [XmlAttribute("bigSize")]
    public string BigSizeRaw { get; set; }
    [XmlIgnore]
    public int MinBigSize { get; set; }
    [XmlIgnore]
    public int MaxBigSize { get; set; }
    [XmlAttribute("bait")]
    public string BaitRaw { get; set; }
    [XmlIgnore]
    public int[] Bait { get; set; }
    [XmlAttribute("individualDropBoxID")]
    public int IndividualDropBoxId { get; set; }
    [XmlAttribute("ignoreSpotMastery")]
    public bool IgnoreSpotMastery { get; set; }
    [XmlAttribute("feature")]
    public string Feature { get; set; }

    public void Initialize() {
        var smallSizeTuple = ParseRange(SmallSizeRaw);
        MinSmallSize = smallSizeTuple.Item1;
        MaxSmallSize = smallSizeTuple.Item2;

        var bigSizeTuple = ParseRange(BigSizeRaw);
        MinBigSize = bigSizeTuple.Item1;
        MaxBigSize = bigSizeTuple.Item2;
    }
    private Tuple<int, int> ParseRange(string raw) {
        string[]? parts = null;
        int min = 0;
        int max = 0;
        if (!string.IsNullOrWhiteSpace(raw)) {
            if (raw.Contains('-')) {
                parts = raw.Split('-');
                if (parts.Length == 2) {
                    min = int.Parse(parts[0].Trim());
                    max = int.Parse(parts[1].Trim());
                }
            } else {
                min = max = int.Parse(raw.Trim());
            }
        }

        return new Tuple<int, int>(min, max);
    }
}

public class FishingSpotEntry {
    [XmlAttribute("id")]
    public string Id { get; set; }      // All IDs have a leading zero, not sure if it's important or not, storing as string to retain the leading zero for now.
    [XmlAttribute("liquidType")]
    public string LiquidTypeRaw { get; set; }
    [XmlIgnore]
    public string[] LiquidType { get; set; }
    [XmlAttribute("minMastery")]
    public int MinMastery { get; set; }
    [XmlAttribute("maxMastery")]
    public int MaxMastery { get; set; }
    [XmlAttribute("globalFishBoxID")]
    public int GlobalFishBoxId { get; set; }
    [XmlAttribute("individualFishBoxID")]
    public string IndividualFishBoxIdRaw { get; set; }
    [XmlIgnore]
    public int IndividualFishBoxId { get; set; }
    [XmlAttribute("globalDropBoxId")]
    public int GlobalDropBoxId { get; set; }
    // [XmlAttribute("individualDropBoxId")]    // Listed on every entry but always has an empty string
    // public string IndividualDropBoxId { get; set; }
    [XmlAttribute("spotLevel")]
    public int SpotLevel { get; set; }
    [XmlAttribute("spotDropRank")]
    public int SpotDropRank { get; set; }
    [XmlAttribute("feature")]
    public string Feature { get; set; }

    public void Initialize() {
        IndividualFishBoxId = ParseOptionalInt(IndividualFishBoxIdRaw);
        //IndividualDropBoxId = ParseOptionalInt(IndividualDropBoxIdRaw);

        LiquidType = LiquidTypeRaw.Split(',');
    }

    private int ParseOptionalInt(string raw) {
        if (string.IsNullOrWhiteSpace(raw)) return 0;

        return int.TryParse(raw, out int result) ? result : 0;
    }
}

public class FishLureEntry {
    [XmlAttribute("additionalEffectCode")]
    public int AdditionalEffectCode { get; set; }
    [XmlAttribute("additionalEffectLevel")]
    public int AdditionalEffectLevel { get; set; }
    // [XmlAttribute("fishCode")]       // Always blank in fishLure.xml
    // public string FishCode { get; set; }
    [XmlAttribute("catchRank")]
    public string CatchRankRaw { get; set; }
    [XmlIgnore]
    public int[] CatchRank { get; set; }
    [XmlAttribute("catchProp")]
    public string CatchPropRaw { get; set; }
    [XmlIgnore]
    public int[] CatchProp { get; set; }
    [XmlAttribute("spawnRank")]
    public string SpawnRankRaw { get; set; }
    [XmlIgnore]
    public int[] SpawnRank { get; set; }
    [XmlAttribute("spawnProp")]
    public string SpawnPropRaw { get; set; }
    [XmlIgnore]
    public int[] SpawnProp { get; set; }
    [XmlAttribute("spawnFish")]
    public string SpawnFishRaw { get; set; }
    [XmlIgnore]
    public int[] SpawnFish { get; set; }
    [XmlAttribute("spawnFishRate")]
    public string SpawnFishRateRaw { get; set; }
    [XmlIgnore]
    public int[] SpawnFishRate { get; set; }
    [XmlAttribute("fishSize")]
    public string FishSizeRaw { get; set; }
    [XmlIgnore]
    public int FishSize { get; set; }
    [XmlAttribute("fishSizeProp")]
    public string FishSizePropRaw { get; set; }
    [XmlIgnore]
    public int FishSizeProp { get; set; }
    [XmlAttribute("globalDropBoxID")]
    public string GlobalDropBoxIdRaw { get; set; }
    [XmlIgnore]
    public int GlobalDropBoxId { get; set; }
    [XmlAttribute("globalDropRank")]
    public string GlobalDropRankRaw { get; set; }
    [XmlIgnore]
    public int GlobalDropRank { get; set; }
    [XmlAttribute("globalDropFishingSpotMastery")]
    public string GlobalDropFishingSpotMasteryRaw { get; set; }
    [XmlIgnore]
    public int MinGlobalDropFishingSpotMastery { get; set; }
    [XmlIgnore]
    public int MaxGlobalDropFishingSpotMastery { get; set; }
    [XmlAttribute("individualDropBoxID")]
    public string IndividualDropBoxIdRaw { get; set; }
    [XmlIgnore]
    public int IndividualDropBoxId { get; set; }
    // [XmlAttribute("individualDropRank")]         // Always blank in fishLure.xml
    // public string IndividualDropRank { get; set; }
    [XmlAttribute("individualDropFishingSpotMastery")]
    public string IndividualDropFishingSpotMasteryRaw { get; set; }
    [XmlIgnore]
    public int MinIndividualDropFishingSpotMastery { get; set; }
    [XmlIgnore]
    public int MaxIndividualDropFishingSpotMastery { get; set; }
    [XmlAttribute("feature")]
    public string Feature { get; set; }

    public void Initialize() {
        CatchRank = ParseIntArray(CatchRankRaw);
        CatchProp = ParseIntArray(CatchPropRaw);
        SpawnRank = ParseIntArray(SpawnRankRaw);
        SpawnProp = ParseIntArray(SpawnPropRaw);
        SpawnFish = ParseIntArray(SpawnFishRaw);
        SpawnFishRate = ParseIntArray(SpawnFishRateRaw);

        FishSize = ParseOptionalInt(FishSizeRaw);
        FishSizeProp = ParseOptionalInt(FishSizePropRaw);
        GlobalDropBoxId = ParseOptionalInt(GlobalDropBoxIdRaw);
        GlobalDropRank = ParseOptionalInt(GlobalDropRankRaw);
        IndividualDropBoxId = ParseOptionalInt(IndividualDropBoxIdRaw);

        var globalDropFishingSpotMasteryTuple = ParseRange(GlobalDropFishingSpotMasteryRaw);
        MinGlobalDropFishingSpotMastery = globalDropFishingSpotMasteryTuple.Item1;
        MaxGlobalDropFishingSpotMastery = globalDropFishingSpotMasteryTuple.Item2;

        var individualDropFishingSpotMasteryTuple = ParseRange(IndividualDropFishingSpotMasteryRaw);
        MinIndividualDropFishingSpotMastery = individualDropFishingSpotMasteryTuple.Item1;
        MaxIndividualDropFishingSpotMastery = individualDropFishingSpotMasteryTuple.Item2;
    }

    private int[] ParseIntArray(string raw) {
        if (string.IsNullOrWhiteSpace(raw)) return [];
        return raw.Split(',')
            .Select(s => int.Parse(s.Trim()))
            .ToArray();
    }

    private int ParseOptionalInt(string raw) {
        if (string.IsNullOrWhiteSpace(raw)) return 0;

        return int.TryParse(raw, out int result) ? result : 0;
    }

    private Tuple<int, int> ParseRange (string raw) {
        string[]? parts = null;
        int min = 0;
        int max = 0;
        if (!string.IsNullOrWhiteSpace(raw)) {
            if (raw.Contains('-')) {
                parts = raw.Split('-');
                if (parts.Length == 2) {
                    min = int.Parse(parts[0].Trim());
                    max = int.Parse(parts[1].Trim());
                }
            } else {
                min = max = int.Parse(raw.Trim());
            }
        }

        return new Tuple<int, int>(min, max);
    }
}
