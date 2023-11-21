using System.Text;

namespace DokaponFileReader
{
    public class StageBaseFile
    {
        public string fileHeader;
        public UInt32 fileSize;
        public UInt32 headerSize;
        public byte[] filler;

        public List<FileNameHeader> FileNameHeaders;
        public List<UnknownHeader_03> UnknownHeaders_03;
        public List<StageFileHeader> StageFileHeaders;
        public List<EndOfFileHeader> EmptyHeaders;
        public List<UnknownHeader_2B> UnknownHeaders_2B;
        public List<UnknownHeader_2F> UnknownHeaders_2F;
        public List<LocationHeader> LocationHeaders;
        public List<UnknownHeader_66> UnknownHeaders_66;
        public List<TempleNameHeader> TempleNameHeaders;
        public List<UnknownHeader_68> UnknownHeaders_68;
        public List<TownCastleHeader> TownCastleHeaders;
        public List<UnknownHeader_6E> UnknownHeaders_6E;
        public List<UnknownCastleInfo> UnknownCastleInfos;
        public List<UnknownHeader_78> UnknownHeaders_78;
        public List<RandomLootHeader> RandomLootHeaders;
        public List<UnknownHeader_85> UnknownHeaders_85;
        public List<RandomEffectHeader> RandomEffectHeader;
        public List<SpaceNameHeader> SpaceNameHeaders;
        public List<SpaceDescriptionHeader> SpaceDescriptionHeaders;
        public List<UnknownHeader_93> UnknownHeaders_93;
        public List<UnknownHeader_94> UnknownHeaders_94;
        public List<IGBListHeader> IGBListHeaders;
        public List<UnknownHeader_DB> UnknownHeaders_DB;
        public List<UnknownHeader_DA> UnknownHeaders_DA;
        public List<UnknownHeader_E0> UnknownHeaders_E0;

        public StageBaseFile()
        {
            fileHeader = String.Empty;
            filler = new byte[36];
            FileNameHeaders = new List<FileNameHeader>();
            UnknownHeaders_03 = new List<UnknownHeader_03>();
            StageFileHeaders = new List<StageFileHeader>();
            EmptyHeaders = new List<EndOfFileHeader>();
            UnknownHeaders_2B = new List<UnknownHeader_2B>();
            UnknownHeaders_2F = new List<UnknownHeader_2F>();
            LocationHeaders = new List<LocationHeader>();
            UnknownHeaders_66 = new List<UnknownHeader_66>();
            TempleNameHeaders = new List<TempleNameHeader>();
            UnknownHeaders_68 = new List<UnknownHeader_68>();
            TownCastleHeaders = new List<TownCastleHeader>();
            UnknownHeaders_6E = new List<UnknownHeader_6E>();
            UnknownCastleInfos = new List<UnknownCastleInfo>();
            UnknownHeaders_78 = new List<UnknownHeader_78>();
            RandomLootHeaders = new List<RandomLootHeader>();
            UnknownHeaders_85 = new List<UnknownHeader_85>();
            RandomEffectHeader = new List<RandomEffectHeader>();
            SpaceNameHeaders = new List<SpaceNameHeader>();
            SpaceDescriptionHeaders = new List<SpaceDescriptionHeader>();
            UnknownHeaders_93 = new List<UnknownHeader_93>();
            UnknownHeaders_94 = new List<UnknownHeader_94>();
            IGBListHeaders = new List<IGBListHeader>();
            UnknownHeaders_DB = new List<UnknownHeader_DB>();
            UnknownHeaders_DA = new List<UnknownHeader_DA>();
            UnknownHeaders_E0 = new List<UnknownHeader_E0>();
        }

        public void ReadStageBase(DokaponFileReader stageFile)
        {
            byte[] wordBuffer = new byte[4];

            stageFile.Read(ref wordBuffer);
            fileHeader = Encoding.ASCII.GetString(wordBuffer);
            fileSize = stageFile.GetUInt32();
            headerSize = stageFile.GetUInt32();
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
                    case HeaderType.EndOfFile: EmptyHeaders.Add(EndOfFileHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_2B: UnknownHeaders_2B.Add(UnknownHeader_2B.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_2F: UnknownHeaders_2F.Add(UnknownHeader_2F.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Location: LocationHeaders.Add(LocationHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_66: UnknownHeaders_66.Add(UnknownHeader_66.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.TempleName: TempleNameHeaders.Add(TempleNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_68: UnknownHeaders_68.Add(UnknownHeader_68.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.TownCastleName: TownCastleHeaders.Add(TownCastleHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_6E: UnknownHeaders_6E.Add(UnknownHeader_6E.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.CastleUnknownInfo: UnknownCastleInfos.Add(UnknownCastleInfo.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_78: UnknownHeaders_78.Add(UnknownHeader_78.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.RandomLoot: RandomLootHeaders.Add(RandomLootHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_85: UnknownHeaders_85.Add(UnknownHeader_85.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.RandomEffect: RandomEffectHeader.Add(global::DokaponFileReader.RandomEffectHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.SpaceName: SpaceNameHeaders.Add(SpaceNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.SpaceDescription: SpaceDescriptionHeaders.Add(SpaceDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_93: UnknownHeaders_93.Add(UnknownHeader_93.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_94: UnknownHeaders_94.Add(UnknownHeader_94.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.IGBFileList: IGBListHeaders.Add(IGBListHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_DB: UnknownHeaders_DB.Add(UnknownHeader_DB.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_DA: UnknownHeaders_DA.Add(UnknownHeader_DA.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_E0: UnknownHeaders_E0.Add(UnknownHeader_E0.ReadHeaderBlock(stageFile)); break;

                    default: Console.WriteLine("Unknown Header!"); break;
                }
            }
        }

        public string GetEffectName(int type, int id)
        {
            foreach (var header in RandomEffectHeader)
            {
                if (header.effectType != type)
                    continue;
                if (header.effectTypeIndex != id)
                    continue;

                return header.effectName;
            }

            return ("None");
        }
    }
}