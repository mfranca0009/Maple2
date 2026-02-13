using System;
using System.IO;
using System.Xml.Serialization;

namespace Maple2.Tools;

public static class XmlParser {
    public static T? Parse<T>() where T : BaseXmlModel, new() {
        // Trim XML string and also strip the Byte Order Mark (BOM) if present (char. code: 65279 / hex: 0xFEFF)
        string xmlString = M2dParser.ParseM2d(new T().FilePath, new T().XmlTreePath).Trim().Trim('\uFEFF', '\u200B');

        if (string.IsNullOrWhiteSpace(xmlString)) return null;

        var serializer = new XmlSerializer(typeof(T));
        using var stringReader = new StringReader(xmlString);
        var config = (T?) serializer.Deserialize(stringReader);
        config?.Initialize();
        return config;
    }
}
