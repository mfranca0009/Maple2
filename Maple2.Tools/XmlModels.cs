using System;
using System.Collections.Generic;
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

    public void Initialize() { }
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
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS_DATA_FOLDER")}/Server.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/Server/BonusGame.xml";

    [XmlElement("game")]
    public List<BonusGameEntry> Entries { get; set; } = [];

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
public class Constants : IXmlModel {
    [XmlIgnore]
    public string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/Xml.m2d";
    [XmlIgnore]
    public string XmlTreePath => "table/constants.xml";

    [XmlElement("v")]
    public List<ConstantsEntry> Entries { get; set; } = [];

    public void Initialize() { }
}
