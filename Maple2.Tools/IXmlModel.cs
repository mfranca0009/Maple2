namespace Maple2.Tools;

public interface IXmlModel {
    string FilePath { get; }
    string XmlTreePath { get; }
    void Initialize();
}
