using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Maple2.Tools;

[XmlRoot("ms2")]
public class AdditionalEffectGroup : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/additionalEffectGroup.xml";

    [XmlElement("group")]
    public List<EffectGroupEntry> Entries { get; set; } = [];

    public override void Initialize() {
        foreach (var group in Entries) {
            foreach (var val in group.Values) {
                val.Initialize();
            }
        }
    }
}

[XmlRoot("ms2")]
public class AdventureExpTable : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/AdventureExpTable.xml";

    [XmlElement("exp")]
    public List<AdventureExpEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class AdventureExpIdTable : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/AdventureIDExpTable.xml";

    [XmlElement("exp")]
    public List<AdventureExpEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class ArcadeReward : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/arcadeReward.xml";

    [XmlElement("arcadeGame")]
    public List<ArcadeGameEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class AttendGift : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/AttendGift.xml";

    [XmlElement("attendGift")]
    public List<AttendGiftEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class AttendGiftEvent : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/AttendGiftEvent.xml";

    [XmlElement("attendGiftEvent")]
    public List<AttendGiftEventEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class BonusGame : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/BonusGame.xml";

    [XmlElement("game")]
    public List<BonusGameEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class BonusGameDrop : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/BonusGameDrop.xml";

    [XmlElement("game")]
    public List<BonusGameDropEntry> Entires { get; set; } = [];

    public override void Initialize() { }
}

// Skip table/Server/CN for now

[XmlRoot("ms2")]
public class CombineSpawnGroup : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/combineSpawnGroup.xml";

    [XmlElement("groupData")]
    public List<CombineSpawnGroupEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class CombineSpawnInteractObject : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/combineSpawnInteractObject.xml";

    [XmlElement("spawnInteractObject")]
    public List<CombineSpawnInteractObjectEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class CombineSpawnNpc : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/combineSpawnNpc.xml";

    [XmlElement("spawnNpc")]
    public List<CombineSpawnNpcEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class ServerConstants : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/constants.xml";

    [XmlElement("v")]
    public List<ConstantsEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class DefaultCharacterInfo : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/defaultCharacterInfo.xml";

    [XmlElement("gender")]
    public List<DefaultCharacterInfoGenderData> Entries { get; set; } = [];

    public override void Initialize() {
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
public class DesignersHomeLayout : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => $"table/Server/designersHomeLayout.xml";

    [XmlElement("item")]
    public List<DesignersHomeLayoutItemEntry> ItemEntries { get; set; } = [];

    [XmlElement("category")]
    public List<DesignersHomeLayoutCategoryEntry> CategoryEntries { get; set; } = [];

    public override void Initialize() {
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
public class DungeonScaleStat : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/DungeonScaleStat.xml";

    [XmlElement("DungeonScaleStat")]
    public List<DungeonScaleStatEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class DungeonScoreBonus : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/DungeonScoreBonus.xml";

    [XmlElement("scoreBonus")]
    public List<DungeonScoreBonusEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class EnchantOptionTable : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/enchantOptionTable.xml";

    [XmlElement("option")]
    public List<EnchantOptionEntry> Entries { get; set; } = [];

    public override void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class EnchantScroll : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/enchantScroll.xml";

    [XmlElement("scroll")]
    public List<EnchantScrollEntry> Entries { get; set; } = [];

    public override void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class ExceptEpicRestart2 : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/exceptEpicRestart_2.xml";

    [XmlElement("quest")]
    public List<ExceptEpicRestartEntry> Entries { get; set; } = [];

    public override void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class ExceptEpicRestart : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/exceptEpicRestart.xml";

    [XmlElement("quest")]
    public List<ExceptEpicRestartEntry> Entries { get; set; } = [];

    public override void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class ExploreExpTable : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/exploreExpTable.xml";

    [XmlElement("exp")]
    public List<ExploreExpTableEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class FieldRestrainTable : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/fieldRestrainTable.xml";

    [XmlElement("v")]
    public List<FieldRestrainTableEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}

[XmlRoot("ms2")]
public class Fish : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/fish.xml";

    [XmlElement("fish")]
    public List<FishEntry> Entries { get; set; } = [];

    public override void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class FishingSpot : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/fishingSpot.xml";

    [XmlElement("spot")]
    public List<FishingSpotEntry> Entries { get; set; } = [];

    public override void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class FishLure : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/Server/fishLure.xml";

    [XmlElement("lure")]
    public List<FishLureEntry> Entries { get; set; } = [];

    public override void Initialize() {
        foreach (var entry in Entries) {
            entry.Initialize();
        }
    }
}

[XmlRoot("ms2")]
public class GlobalDropItemBoxFinal : BaseXmlModel {
    [XmlIgnore]
    public override string FilePath => Path.Join(base.FilePath, "Server.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/globalDropItemBox_Final.xml";

    // TODO

    public override void Initialize() {
        throw new NotImplementedException();
    }
}

[XmlRoot("ms2")]
public class Constants : BaseXmlModel {
    [XmlIgnore]
    public string FilePath => Path.Join(((BaseXmlModel)this).FilePath, "Xml.m2d");
    [XmlIgnore]
    public override string XmlTreePath => "table/constants.xml";

    [XmlElement("v")]
    public List<ConstantsEntry> Entries { get; set; } = [];

    public override void Initialize() { }
}
