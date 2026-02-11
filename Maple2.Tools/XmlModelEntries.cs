using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.Tools;

public class EffectGroupEntry {
    [XmlAttribute("groupId")]
    public int GroupId { get; set; }

    [XmlElement("value")]
    public List<EffectValue> Values { get; set; } = [];
}

public class EffectValue {
    [XmlAttribute("effectId")]
    public string EffectId { get; set; }

    [XmlAttribute("effectLevel")]
    public string EffectLevel { get; set; }
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
    [XmlAttribute("MaxProp")]
    public int maxProp { get; set; }
}

public class ConstantsEntry {
    [XmlAttribute("key")]
    public string Key { get; set; }
    [XmlAttribute("value")]
    public string Value { get; set; }
    [XmlAttribute("locale")]
    public string Locale { get; set; }
}
