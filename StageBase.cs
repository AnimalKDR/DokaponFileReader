using System.Text;

namespace DokaponFileReader
{
    public class StageBaseFile
    {
        public string fileHeader;
        public UInt32 fileSize;
        public UInt32 headerEnd;
        public byte[] filler;

        public List<FileNameHeader> FileNameHeaders;
        public List<UnknownHeader_03> UnknownHeaders_03;
        public List<StageFileHeader> StageFileHeaders;
        public EndOfFileHeader EmptyHeader;
        public List<UnknownHeader_2B> UnknownHeaders_2B;
        public List<UnknownHeader_2F> UnknownHeaders_2F;
        public List<LocationHeader> LocationHeaders;
        public UnknownHeader_66 UnknownHeader_66;
        public UnknownHeader_79 UnknownHeader_79;
        public List<TempleNameHeader> TempleNameHeaders;
        public List<UnknownHeader_68> UnknownHeaders_68;
        public List<TownCastleHeader> TownCastleHeaders;
        public List<UnknownHeader_6E> UnknownHeaders_6E;
        public List<UnknownCastleInfo> UnknownCastleInfos;
        public List<UnknownHeader_78> UnknownHeaders_78;
        public List<RandomLootHeader> RandomLootHeaders;
        public RandomLootList_85 RandomLootListHeader_85;
        public List<RandomEffectHeader> RandomEffectHeaders;
        public List<SpaceNameHeader> SpaceNameHeaders;
        public SpaceDescriptionHeader SpaceDescriptionHeader;
        public List<UnknownHeader_93> UnknownHeaders_93;
        public RandomLootList_94 RandomLootListHeader_94;
        public List<IGBListHeader> IGBListHeaders;
        public UnknownHeader_DB UnknownHeader_DB;
        public List<UnknownHeader_DA> UnknownHeaders_DA;
        public UnknownHeader_E0 UnknownHeader_E0;

        public StageBaseFile()
        {
            fileHeader = String.Empty;
            filler = new byte[36];
            FileNameHeaders = new List<FileNameHeader>();
            UnknownHeaders_03 = new List<UnknownHeader_03>();
            StageFileHeaders = new List<StageFileHeader>();
            UnknownHeaders_2B = new List<UnknownHeader_2B>();
            UnknownHeaders_2F = new List<UnknownHeader_2F>();
            LocationHeaders = new List<LocationHeader>();
            TempleNameHeaders = new List<TempleNameHeader>();
            UnknownHeaders_68 = new List<UnknownHeader_68>();
            TownCastleHeaders = new List<TownCastleHeader>();
            UnknownHeaders_6E = new List<UnknownHeader_6E>();
            UnknownCastleInfos = new List<UnknownCastleInfo>();
            UnknownHeaders_78 = new List<UnknownHeader_78>();
            
            RandomLootHeaders = new List<RandomLootHeader>();
            RandomEffectHeaders = new List<RandomEffectHeader>();
            SpaceNameHeaders = new List<SpaceNameHeader>();
            SpaceDescriptionHeader = new SpaceDescriptionHeader(0);
            UnknownHeaders_93 = new List<UnknownHeader_93>();
            IGBListHeaders = new List<IGBListHeader>();
            UnknownHeaders_DA = new List<UnknownHeader_DA>();

            EmptyHeader = new EndOfFileHeader(4);
            UnknownHeader_66 = new UnknownHeader_66(4);
            UnknownHeader_79 = new UnknownHeader_79(4);
            RandomLootListHeader_85 = new RandomLootList_85(4);
            RandomLootListHeader_94 = new RandomLootList_94(4);
            UnknownHeader_DB = new UnknownHeader_DB(4);
            UnknownHeader_E0 = new UnknownHeader_E0(4);
        }

        public void ReadStageBase(DokaponFileReader stageFile)
        {
            byte[] wordBuffer = new byte[4];

            stageFile.Read(ref wordBuffer);
            fileHeader = Encoding.GetEncoding(932).GetString(wordBuffer);
            fileSize = stageFile.GetUInt32();
            headerEnd = stageFile.GetUInt32();
            stageFile.Read(ref filler);


            while (stageFile.GetPosition() < fileSize && stageFile.Read(ref wordBuffer) > 0)
            {
                var header = BitConverter.ToUInt32(wordBuffer);

                switch ((HeaderType)header)
                {
                    case 0x00: break;
                    case HeaderType.FileName: FileNameHeaders.Add(FileNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_03: UnknownHeaders_03.Add(UnknownHeader_03.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.StageFile: StageFileHeaders.Add(StageFileHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_2B: UnknownHeaders_2B.Add(UnknownHeader_2B.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_2F: UnknownHeaders_2F.Add(UnknownHeader_2F.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Location: LocationHeaders.Add(LocationHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.TempleName: TempleNameHeaders.Add(TempleNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_68: UnknownHeaders_68.Add(UnknownHeader_68.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.TownCastleName: TownCastleHeaders.Add(TownCastleHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_6E: UnknownHeaders_6E.Add(UnknownHeader_6E.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.CastleUnknownInfo: UnknownCastleInfos.Add(UnknownCastleInfo.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_78: UnknownHeaders_78.Add(UnknownHeader_78.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.RandomLoot: RandomLootHeaders.Add(RandomLootHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.RandomEffect: RandomEffectHeaders.Add(RandomEffectHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.SpaceName: SpaceNameHeaders.Add(SpaceNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_93: UnknownHeaders_93.Add(UnknownHeader_93.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.IGBFileList: IGBListHeaders.Add(IGBListHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_DA: UnknownHeaders_DA.Add(UnknownHeader_DA.ReadHeaderBlock(stageFile)); break;

                    case HeaderType.EndOfFile: EmptyHeader = EndOfFileHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_66: UnknownHeader_66 = UnknownHeader_66.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_79: UnknownHeader_79 = UnknownHeader_79.ReadHeaderBlock(stageFile); break;
                    case HeaderType.RandomLootList_85: RandomLootListHeader_85 = RandomLootList_85.ReadHeaderBlock(stageFile); break;
                    case HeaderType.SpaceDescription: SpaceDescriptionHeader = SpaceDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.RandomLootList_94: RandomLootListHeader_94 = RandomLootList_94.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_DB: UnknownHeader_DB = UnknownHeader_DB.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_E0: UnknownHeader_E0 = UnknownHeader_E0.ReadHeaderBlock(stageFile); break;

                    default: Console.WriteLine("Unknown Header!"); break;
                }
            }
            /*
            SpaceNameHeaders[92].name = "????";
            SpaceDescriptionHeader.description[45] = "Entrance to the Spring Cave. ";
            RandomEffectHeaders[35].effectName = "fear";
            RandomEffectHeaders[36].effectName = "seal";

            FileNameHeader fileheader1 = new FileNameHeader(0);
            fileheader1.fileName = "B09_Anim.IGB";
            fileheader1.index = 4;
            fileheader1.unknownUint16 = 0;
            IGBListHeaders[9].IGBFiles.Insert(5, fileheader1);

            FileNameHeader fileheader2 = new FileNameHeader(0);
            fileheader2.fileName = "B09_Anim2.IGB";
            fileheader2.index = 9;
            fileheader2.unknownUint16 = 0;
            IGBListHeaders[9].IGBFiles.Insert(10, fileheader2);

            FileNameHeader fileheader3 = new FileNameHeader(0);
            fileheader3.fileName = "\0\0\0\0";
            fileheader3.index = 4;
            fileheader3.unknownUint16 = 256;
            IGBListHeaders[9].IGBFiles.Insert(16, fileheader3);

            FileNameHeader fileheader4 = new FileNameHeader(0);
            fileheader4.fileName = "\0\0\0\0";
            fileheader4.index = 9;
            fileheader4.unknownUint16 = 256;
            IGBListHeaders[9].IGBFiles.Insert(21, fileheader4);

            UnknownHeader_79.headerStart = 0x1000;
            UnknownHeader_79.unknownUint32 = 0x73;*/
        }

        public void WriteStageBase(DokaponFileWriter stageFile)
        {
            stageFile.SetPosition(0);
            stageFile.Write(Encoding.GetEncoding(932).GetBytes(fileHeader));
            stageFile.Write(fileSize);
            stageFile.Write(headerEnd);

            while (stageFile.GetPosition() < headerEnd)
                stageFile.Write((byte)0);

            FileNameHeaders[0].WriteHeaderBlock(stageFile);

            foreach (var header in StageFileHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_6E)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in LocationHeaders)
                header.WriteHeaderBlock(stageFile);

            SpaceDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in SpaceNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in TempleNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_68)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_66.WriteHeaderBlock(stageFile);
            foreach (var header in TownCastleHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownCastleInfos)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_93)
                header.WriteHeaderBlock(stageFile);
            UnknownHeaders_03[0].WriteHeaderBlock(stageFile);
            SpaceDescriptionHeader.WriteBlockData(stageFile);
            UnknownHeaders_03[0].WriteEndDataBlock(stageFile);

            foreach (var header in UnknownHeaders_2B)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_DB.WriteHeaderBlock(stageFile);
            UnknownHeader_DB.WriteBlockData(stageFile);
            foreach (var header in UnknownHeaders_DA)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_E0.WriteHeaderBlock(stageFile);
            UnknownHeader_E0.WriteBlockData(stageFile);
            foreach (var header in UnknownHeaders_2F)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in RandomEffectHeaders)
                header.WriteHeaderBlock(stageFile);

            foreach (var header in RandomLootHeaders)
                header.WriteHeaderBlock(stageFile);
            RandomLootListHeader_94.WriteHeaderBlock(stageFile);
            RandomLootListHeader_94.WriteBlockData(stageFile);
            RandomLootListHeader_85.WriteHeaderBlock(stageFile);
            RandomLootListHeader_85.WriteBlockData(stageFile);
            foreach (var header in UnknownHeaders_78)
                header.WriteHeaderBlock(stageFile);
            UnknownHeaders_03[1].WriteHeaderBlock(stageFile);
            foreach (var header in RandomLootHeaders)
                header.WriteBlockData(stageFile);
            bool b = true;
            foreach (var header in UnknownHeaders_78)
            {
                header.WriteBlockData(stageFile);
                if (b)
                {
                    stageFile.Write((UInt32)0);
                    b = false;
                }
            }
            stageFile.Write((UInt32)0);
            UnknownHeaders_03[1].WriteEndDataBlock(stageFile);

            foreach (var header in IGBListHeaders)
                header.WriteHeaderBlock(stageFile);
            UnknownHeaders_03[2].WriteHeaderBlock(stageFile);
            foreach (var header in IGBListHeaders)
                header.WriteBlockData(stageFile);
            foreach (var header in IGBListHeaders)
                header.WriteEndBlockAddresses(stageFile);
            foreach (var header in IGBListHeaders)
            {
                if (header.IGBFiles.Count == 0)
                {
                    header.WriteEndBlockHeader(stageFile);
                    break;
                }
            }
            stageFile.Write((UInt32)0);
            stageFile.Write((UInt32)0);
            UnknownHeaders_03[2].WriteEndDataBlock(stageFile);

            FileNameHeaders[1].WriteHeaderBlockWithPosition(stageFile);
            if (UnknownHeader_79.headerStart > 0)
                UnknownHeader_79.WriteHeaderBlock(stageFile);
            EmptyHeader.WriteHeaderBlock(stageFile);
            for (int i = 0; i < StageFileHeaders.Count; i++)
            {
                if (i <= 23)
                    StageFileHeaders[i].WriteBlockData(stageFile);
                else
                    StageFileHeaders[i].WriteBlockAddress(stageFile, StageFileHeaders[23].filePointer);
            }

            var currentPosition = stageFile.GetPosition();
            fileSize = stageFile.GetRelativePosition();
            stageFile.SetPosition(stageFile.fileOffset + 4);
            stageFile.Write(fileSize);
            stageFile.SetPosition(currentPosition);

            while (stageFile.GetPosition() % 16 != 0)
                stageFile.Write((byte)0);
        }

        public string GetEffectName(int type, int id)
        {
            foreach (var header in RandomEffectHeaders)
            {
                if (header.effectType != type)
                    continue;
                if (header.effectTypeIndex != id)
                    continue;

                return header.effectName;
            }

            return ("None");
        }

        public byte GetEffectTypeIndex(string effectName)
        {
            foreach (var header in RandomEffectHeaders)
            {
                if (header.effectName == effectName)
                    return (header.effectTypeIndex);
            }

            return (0xFF);
        }

        public string GetLocationName(byte locationIndex)
        {
            foreach (var location in LocationHeaders)
            {
                if (locationIndex != location.index)
                    continue;

                return location.name;
            }

            return ("None");
        }

        public byte GetLocationIndex(string locationName)
        {
            foreach (var location in LocationHeaders)
            {
                if (locationName != location.name)
                    continue;

                return (byte)location.index;
            }

            return 0;
        }

        public string GetTownCastleName(byte townCastleIndex)
        {
            foreach (var townCastle in TownCastleHeaders)
            {
                if (townCastle.index == townCastleIndex)
                    return townCastle.name;
            }

            return ("None");
        }

        public byte GetTownCastleIndex(string townCastlename)
        {
            foreach (var townCastle in TownCastleHeaders)
            {
                if (townCastle.name == townCastlename)
                    return townCastle.index;
            }

            return (0xFF);
        }
    }
}