using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;
using Maple2.Tools.Common;
using Maple2.Tools.Crypto.Common;
using Maple2.Tools.Crypto.Stream;
using static Maple2.Tools.Crypto.CryptoMan;

namespace Maple2.Tools;

internal class M2dParser {
    private MemoryMappedFile pDataMappedMemFile;
    private PackNodeList pNodeList;
    private string headerFilePath;
    private string dataFilePath;

    public M2dParser() {
        headerFilePath = string.Empty;
        dataFilePath = string.Empty;
    }

    public string ParseM2d(string m2dFilePath, string xmlTreePath) {
        dataFilePath = Dir_BackSlashToSlash(m2dFilePath);
        string[] xmlTreePathPieces = Dir_BackSlashToSlash(xmlTreePath).Split('/');
        int documentIndex = xmlTreePathPieces.Length-1;
        int totalKeys = xmlTreePathPieces.Length - 1;
        int foundKeyCounter = 0;

        if (!SetHeaderUOL()) {
            return string.Empty;
        }

        InitializeStream(dataFilePath);

        PackFileEntry? packFileEntry = ParseChildren(pNodeList, xmlTreePathPieces, foundKeyCounter, totalKeys);

        var pFileHeader = packFileEntry?.FileHeader ?? null;
        byte[]? xmlBytes = null;
        if (pFileHeader != null) {
            xmlBytes = DecryptData(pFileHeader, pDataMappedMemFile);
        }

        // convert bytes into string
        return Encoding.UTF8.GetString(xmlBytes);
    }

    private PackFileEntry? ParseChildren(PackNodeList pckNodeList, string[] xmlTreePieces, int keyCounter, int totalKeys) {
        PackFileEntry? packFileEntry = null;
        foreach (KeyValuePair<string, PackNodeList> packNodeListPair in pckNodeList.Children) {
            if (packNodeListPair.Key == Path.Join(xmlTreePieces[keyCounter], "/")) {
                if (keyCounter == totalKeys-1) {
                    return ParseEntries(packNodeListPair.Value.Entries, xmlTreePieces, totalKeys);
                }
                keyCounter++;
                packFileEntry = ParseChildren(packNodeListPair.Value, xmlTreePieces, keyCounter, totalKeys);
            }
        }
        return packFileEntry;
    }

    private PackFileEntry? ParseEntries(Dictionary<string, PackFileEntry> packFileEntries, string[] xmlTreePieces, int totalKeys) {
        PackFileEntry? packFileEntry = null;
        foreach(KeyValuePair<string,PackFileEntry> packFileEntryPair in packFileEntries) {
            if (packFileEntryPair.Key == xmlTreePieces[totalKeys]) {
                packFileEntry = packFileEntryPair.Value;
                break;
            }
        }
        return packFileEntry;
    }

    private bool SetHeaderUOL() {
        headerFilePath = dataFilePath.Replace(".m2d", ".m2h");
        return File.Exists(headerFilePath);
    }

    private void InitializeStream(string sDataUOL) {
        IPackStreamVerBase pStream;
        using (BinaryReader pHeader = new BinaryReader(File.OpenRead(headerFilePath))) {
            // Construct a new packed stream from the header data
            pStream = PackVer.CreatePackVer(pHeader);

            // Insert a collection containing the file list information [index,hash,name]
            pStream.GetFileList().Clear();
            pStream.GetFileList().AddRange(PackFileEntry.CreateFileList(Encoding.UTF8.GetString(DecryptFileString(pStream, pHeader.BaseStream))));
            // Make the collection of files sorted by their FileIndex for easy fetching
            pStream.GetFileList().Sort();

            // Load the file allocation table and assign each file header to the entry within the list
            byte[] pFileTable = DecryptFileTable(pStream, pHeader.BaseStream);
            using MemoryStream pTableStream = new MemoryStream(pFileTable);
            using BinaryReader pReader = new BinaryReader(pTableStream);
            IPackFileHeaderVerBase pFileHeader;

            switch (pStream.GetVer()) {
                case PackVer.MS2F:
                    for (ulong i = 0; i < pStream.GetFileListCount(); i++) {
                        pFileHeader = new PackFileHeaderVer1(pReader);
                        pStream.GetFileList()[pFileHeader.GetFileIndex() - 1].FileHeader = pFileHeader;
                    }

                    break;
                case PackVer.NS2F:
                    for (ulong i = 0; i < pStream.GetFileListCount(); i++) {
                        pFileHeader = new PackFileHeaderVer2(pReader);
                        pStream.GetFileList()[pFileHeader.GetFileIndex() - 1].FileHeader = pFileHeader;
                    }

                    break;
                case PackVer.OS2F:
                case PackVer.PS2F:
                    for (ulong i = 0; i < pStream.GetFileListCount(); i++) {
                        pFileHeader = new PackFileHeaderVer3(pStream.GetVer(), pReader);
                        pStream.GetFileList()[pFileHeader.GetFileIndex() - 1].FileHeader = pFileHeader;
                    }

                    break;
            }
        }

        pDataMappedMemFile = MemoryMappedFile.CreateFromFile(sDataUOL);

        InitializeTree(pStream);
    }

    private void InitializeTree(IPackStreamVerBase pStream) {
        // Insert the root node (file)
        string[] aPath = headerFilePath.Replace(".m2h", "").Split('/');
        // pTreeView.Nodes.Add(new PackNode(pStream, aPath[^1]));

        pNodeList?.InternalRelease();
        pNodeList = new PackNodeList("/");

        foreach (PackFileEntry pEntry in pStream.GetFileList()) {
            if (pEntry.Name.Contains('/')) {
                string sPath = pEntry.Name;
                PackNodeList pCurList = pNodeList;

                while (sPath.Contains('/')) {
                    string sDir = sPath[..(sPath.IndexOf('/') + 1)];
                    if (!pCurList.Children.TryGetValue(sDir, out PackNodeList value)) {
                        value = new PackNodeList(sDir);
                        pCurList.Children.Add(sDir, value);
                        if (pCurList == pNodeList) {
                            // pTreeView.Nodes[0].Nodes.Add(new PackNode(pCurList.Children[sDir], sDir));
                        }
                    }

                    pCurList = value;

                    sPath = sPath[(sPath.IndexOf('/') + 1)..];
                }

                pEntry.TreeName = sPath;
                pCurList.Entries.Add(sPath, pEntry);
                continue;
            }

            pEntry.TreeName = pEntry.Name;

            pNodeList.Entries.Add(pEntry.Name, pEntry);
           // pTreeView.Nodes[0].Nodes.Add(new PackNode(pEntry, pEntry.Name));
        }

        // Sort all nodes
        // pTreeView.Sort();
        // pTreeView.Nodes[0].Expand();
    }

    private static string Dir_BackSlashToSlash(string sDir) {
        return sDir.Replace("\\", "/");
    }
}
