using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Maple2.Tools;

[XmlRoot("ms2")]
public class AdditionalEffectGroup : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/additionalEffectGroup.xml";

    [XmlElement("group")]
    public List<EffectGroupEntry> Entries { get; set; } = [];

    public void Initialize() {
        foreach (var group in Entries) {
            foreach (var val in group.Values) {
                val.Initialize();
            }
        }
    }
}

[XmlRoot("ms2")]
public class AdventureExpTable : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/AdventureExpTable.xml";

    [XmlElement("exp")]
    public List<AdventureExpEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class AdventureExpIdTable : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/AdventureIDExpTable.xml";

    [XmlElement("exp")]
    public List<AdventureExpEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class ArcadeReward : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/arcadeReward.xml";

    [XmlElement("arcadeGame")]
    public List<ArcadeGameEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class AttendGift : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/AttendGift.xml";

    [XmlElement("attendGift")]
    public List<AttendGiftEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class AttendGiftEvent : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/AttendGiftEvent.xml";

    [XmlElement("attendGiftEvent")]
    public List<AttendGiftEventEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class BonusGame : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/BonusGame.xml";

    [XmlElement("game")]
    public List<BonusGameEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class BonusGameDrop : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/BonusGameDrop.xml";

    [XmlElement("game")]
    public List<BonusGameDropEntry> Entires { get; set; } = [];

    public void Initialize() { }
}

// Skip table/Server/CN for now

[XmlRoot("ms2")]
public class CombineSpawnGroup : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/combineSpawnGroup.xml";

    [XmlElement("groupData")]
    public List<CombineSpawnGroupEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class CombineSpawnInteractObject : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/combineSpawnInteractObject.xml";

    [XmlElement("spawnInteractObject")]
    public List<CombineSpawnInteractObjectEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class CombineSpawnNpc : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/combineSpawnNpc.xml";

    [XmlElement("spawnNpc")]
    public List<CombineSpawnNpcEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class ServerConstants : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/constants.xml";

    [XmlElement("v")]
    public List<ConstantsEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class DefaultCharacterInfo : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/defaultCharacterInfo.xml";

    [XmlElement("gender")]
    public List<DefaultCharacterInfoGenderData> Entries { get; set; } = [];

    public void Initialize() {
        foreach (var gender in Entries) {
            foreach (var item in gender.Items) {
                foreach (var control in item.Controls) {
                    control.Initialize();
                }
            }
        }

    }
}

[XmlRoot("ms2")]
public class DesignersHomeLayout : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => $"table/Server/designersHomeLayout.xml";

    [XmlElement("item")]
    public List<DesignersHomeLayoutItemEntry> ItemEntries { get; set; } = [];

    [XmlElement("category")]
    public List<DesignersHomeLayoutCategoryEntry> CategoryEntries { get; set; } = [];

    public void Initialize() {
        // Create a fast lookup map for all items based on their 'Index' property
        var itemMap = ItemEntries.ToDictionary(i => i.Index, i => i);

        foreach (var category in CategoryEntries) {
            // Parse index list string
            category.Initialize();

            foreach (int idx in category.IndexList) {
                if (itemMap.TryGetValue(idx, out var item)) {
                    // Link Category to Item
                    category.LinkedItems.Add(item);

                    // Link Item to Category
                    item.ParentCategory = category;
                }
            }
        }
    }
}

[XmlRoot("ms2")]
public class DungeonScaleStat : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/DungeonScaleStat.xml";

    [XmlElement("DungeonScaleStat")]
    public List<DungeonScaleStatEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class DungeonScoreBonus : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/DungeonScoreBonus.xml";

    [XmlElement("scoreBonus")]
    public List<DungeonScoreBonusEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class EnchantOptionTable : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/enchantOptionTable.xml";

    [XmlElement("option")]
    public List<EnchantOptionEntry> Entries { get; set; } = [];

    public void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class EnchantScroll : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/enchantScroll.xml";

    [XmlElement("scroll")]
    public List<EnchantScrollEntry> Entries { get; set; } = [];

    public void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class ExceptEpicRestart2 : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/exceptEpicRestart_2.xml";

    [XmlElement("quest")]
    public List<ExceptEpicRestartEntry> Entries { get; set; } = [];

    public void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class ExceptEpicRestart : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/exceptEpicRestart.xml";

    [XmlElement("quest")]
    public List<ExceptEpicRestartEntry> Entries { get; set; } = [];

    public void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class ExploreExpTable : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/exploreExpTable.xml";

    [XmlElement("exp")]
    public List<ExploreExpTableEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class FieldRestrainTable : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/fieldRestrainTable.xml";

    [XmlElement("v")]
    public List<FieldRestrainTableEntry> Entries { get; set; } = [];

    public void Initialize() { }
}

[XmlRoot("ms2")]
public class Fish : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/fish.xml";

    [XmlElement("fish")]
    public List<FishEntry> Entries { get; set; } = [];

    public void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class FishingSpot : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/fishingSpot.xml";

    [XmlElement("spot")]
    public List<FishingSpotEntry> Entries { get; set; } = [];

    public void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class Constants : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Xml.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/constants.xml";

    [XmlElement("v")]
    public List<ConstantsEntry> Entries { get; set; } = [];

    public void Initialize() { }
}
