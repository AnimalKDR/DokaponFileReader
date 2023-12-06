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
        public List<TempleNameHeader> TempleNameHeaders;
        public List<UnknownHeader_68> UnknownHeaders_68;
        public List<TownCastleHeader> TownCastleHeaders;
        public List<UnknownHeader_6E> UnknownHeaders_6E;
        public List<UnknownCastleInfo> UnknownCastleInfos;
        public List<UnknownHeader_78> UnknownHeaders_78;
        public List<RandomLootHeader> RandomLootHeaders;
        public RandomLootList_85 UnknownHeader_85;
        public List<RandomEffectHeader> RandomEffectHeaders;
        public List<SpaceNameHeader> SpaceNameHeaders;
        public SpaceDescriptionHeader SpaceDescriptionHeader;
        public List<UnknownHeader_93> UnknownHeaders_93;
        public RandomLootList_94 UnknownHeader_94;
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

            EmptyHeader = new EndOfFileHeader(0);
            UnknownHeader_66 = new UnknownHeader_66(0);
            UnknownHeader_85 = new RandomLootList_85(0);
            UnknownHeader_94 = new RandomLootList_94(0);
            UnknownHeader_DB = new UnknownHeader_DB(0);
            UnknownHeader_E0 = new UnknownHeader_E0(0);
        }

        public void ReadStageBase(DokaponFileReader stageFile)
        {
            byte[] wordBuffer = new byte[4];

            stageFile.Read(ref wordBuffer);
            fileHeader = Encoding.GetEncoding(932).GetString(wordBuffer);
            fileSize = stageFile.GetUInt32();
            headerEnd = stageFile.GetUInt32();
            stageFile.Read(ref filler);


            while (stageFile.Position() < fileSize && stageFile.Read(ref wordBuffer) > 0)
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
                    case HeaderType.RandomLootList_85: UnknownHeader_85 = RandomLootList_85.ReadHeaderBlock(stageFile); break;
                    case HeaderType.SpaceDescription: SpaceDescriptionHeader = SpaceDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.RandomLootList_94: UnknownHeader_94 = RandomLootList_94.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_DB: UnknownHeader_DB = UnknownHeader_DB.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_E0: UnknownHeader_E0 = UnknownHeader_E0.ReadHeaderBlock(stageFile); break;

                    default: Console.WriteLine("Unknown Header!"); break;
                }
            }
        }

        public void WriteStageBase(DokaponFileWriter stageFile)
        {
            stageFile.SetPosition(0);
            stageFile.Write(Encoding.GetEncoding(932).GetBytes(fileHeader));
            stageFile.Write(fileSize); // must update later
            stageFile.Write(headerEnd);

            while (stageFile.Position() < headerEnd)
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

            stageFile.Close();
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

        public (byte, byte) GetEffectTypeAndID(string effectName)
        {
            foreach (var header in RandomEffectHeaders)
            {
                if (header.effectName == effectName)
                    return (header.effectType, header.effectTypeIndex);
            }

            return (0,0);
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

            return (0);
        }
    }
}