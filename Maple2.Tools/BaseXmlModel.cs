using System;

namespace Maple2.Tools;

public abstract class BaseXmlModel {
    public virtual string FilePath => $"{Environment.GetEnvironmentVariable("MS2_DATA_FOLDER")}/";
    public virtual string XmlTreePath { get; }
    public virtual void Initialize() { }
}
