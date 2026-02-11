using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Maple2.Tools;

public static class XmlParser {
    public static T? Parse<T>() where T : class, IXmlModel, new() {
        var xmlString = M2dParser.ParseM2d(new T().FilePath, new T().XmlTreePath).Trim();
        var doc = XDocument.Parse(xmlString);

        if (string.IsNullOrWhiteSpace(xmlString)) return null;

        var serializer = new XmlSerializer(typeof(T));
        using (var reader = new StringReader(xmlString)) {
            var config = (T?) serializer.Deserialize(reader);
            config?.Initialize();
            return config;
        }
    }
}
