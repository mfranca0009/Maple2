using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maple2.Tools;

public class XmlParser {
    private M2dParser m2dParser;

    public XmlParser() {
        m2dParser = new M2dParser();
    }

    public void Parse(string m2dFilePath, string xmlTreePath) {
        string xmlString = m2dParser.ParseM2d(m2dFilePath, xmlTreePath);

    }
}
