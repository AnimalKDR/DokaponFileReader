using System.IO;
using System.Text;

namespace DokaponFileReader
{
    public enum HeaderType
    {
        FileName = 0x01,
        Unknown_03 = 0x03,
        StageFile = 0x05,
        EndOfFile = 0x0F,
        Unknown_17 = 0x17,
        Unknown_1C = 0x1C,
        Unknown_1D = 0x1D,
        Unknown_1E = 0x1E,
        JobFile2 = 0x29,
        TextureFileName = 0x2A,
        Unknown_2B = 0x2B,
        Unknown_2C = 0x2C,
        Unknown_2D = 0x2D,
        JobSalary = 0x2E,
        Unknown_2F = 0x2F,
        Location = 0x37,
        Unknown_38 = 0x38,
        Unknown_39 = 0x39,
        CPUNames = 0x3A,
        JobLevelAndMastery = 0x3B,
        JobBattleSkill = 0x3C,
        JobDescription = 0x3D,
        JobLevelUpRequirement = 0x3E,
        Unknown_3F = 0x3F,
        JobStartingStats = 0x40,
        JobUnknownInfo1 = 0x41,
        JobName = 0x42,
        JobUnknownInfo2 = 0x43,
        JobItemSpace = 0x44,
        JobFile1 = 0x45,
        Unknown_46 = 0x46,
        Unknown_47 = 0x47,
        Unknown_48 = 0x48,
        Unknown_49 = 0x49,
        DialogList = 0x4A,
        DialogPointerList = 0x4B,
        Unknown_4C = 0x4C,
        Unknown_4D = 0x4D,
        Unknown_4E = 0x4E,
        Unknown_4F = 0x4F,
        Monster = 0x50,
        MonsterUnknownInfo = 0x51,
        Unknown_52 = 0x52,
        MonsterItemDrop = 0x53,
        Unknown_54 = 0x54,
        NPCName = 0x55,
        NPCUnknownInfo = 0x56,
        NPCFileInfo = 0x57,
        Weapon = 0x58,
        WeaponUnknownInfo = 0x59,
        WeaponDescription = 0x5A,
        MonsterType = 0x5B,
        Unknown_5C = 0x5C,
        EtcFileName = 0x5D,
        Shield = 0x5E,
        ShieldUnknownInfo = 0x5F,
        ShieldDescription = 0x60,
        MonsterFileInfo = 0x61,
        MonsterAITable = 0x62,
        WeaponBonusDescription = 0x63,
        Accessory = 0x64,
        AccessoryDescription = 0x65,
        Unknown_66 = 0x66,
        TempleName = 0x67,
        Unknown_68 = 0x68,
        BagItem = 0x69,
        BagItemDescription = 0x6A,
        Unknown_6B = 0x6B,
        LocalItem = 0x6C,
        TownCastleName = 0x6D,
        Unknown_6E = 0x6E,
        CastleUnknownInfo = 0x6F,
        OffensiveMagic = 0x70,
        OffensiveMagicDescription = 0x71,
        DefensiveMagic = 0x72,
        DefensiveMagicDescription = 0x73,
        FieldMagic = 0x74,
        FieldMagicDescription = 0x75,
        Unknown_76 = 0x76,
        Unknown_77 = 0x77,
        Unknown_78 = 0x78,
        Unknown_79 = 0x79,
        BattleSkill = 0x7A,
        JobSkill = 0x7B,
        MonsterDescription = 0x7C,
        BattleSkillDescription = 0x7D,
        JobSkillDescription = 0x7E,
        RandomLoot = 0x7F,
        EffectName1 = 0x81,
        EffectName2 = 0x82,
        EffectName3 = 0x83,
        Unknown_84 = 0x84,
        RandomLootList_85 = 0x85,
        RandomEffect = 0x86,
        SpaceName = 0x87,
        SpaceDescription = 0x88,
        BagItemTypeName = 0x89,
        BattleMagicTypeName = 0x8A,
        FieldMagicTypeName = 0x8B,
        Unknown_8C = 0x8C,
        Unknown_8E = 0x8E,
        Unknown_8F = 0x8F,
        Unknown_93 = 0x93,
        RandomLootList_94 = 0x94,
        HairstyleDescription = 0x95,
        Hairstyle = 0x96,
        HairstyleUnknownInfo = 0x97,
        Unknown_9A = 0x9A,
        Unknown_9B = 0x9B,
        Unknown_9C = 0x9C,
        Unknown_9D = 0x9D,
        Unknown_9E = 0x9E,
        Unknown_9F = 0x9F,
        Unknown_A0 = 0xA0,
        Unknown_A1 = 0xA1,
        Unknown_A2 = 0xA2,
        Unknown_A3 = 0xA3,
        Unknown_A4 = 0xA4,
        Unknown_A5 = 0xA5,
        IGBFileList = 0xAC,
        Unknown_AD = 0xAD,
        Unknown_AE = 0xAE,
        Unknown_AF = 0xAF,
        Unknown_B0 = 0xB0,
        Unknown_B1 = 0xB1,
        Unknown_B2 = 0xB2,
        Unknown_B3 = 0xB3,
        Unknown_B4 = 0xB4,
        Unknown_B5 = 0xB5,
        Unknown_B6 = 0xB6,
        HitFormula = 0xB7,
        AttackFormula = 0xB8,
        MagicFormula = 0xB9,
        StrikeFormula = 0xBA,
        CounterFormula = 0xBB,
        SelfAttackFormula = 0xBC,
        Unknown_BD = 0xBD,
        Unknown_BE = 0xBE,
        PrankName = 0xBF,
        InstructionsList = 0xC0,
        Unknown_D0 = 0xD0,
        Unknown_D1 = 0xD1,
        Unknown_D2 = 0xD2,
        Unknown_D3 = 0xD3,
        Unknown_D4 = 0xD4,
        Unknown_D5 = 0xD5,
        JobRequirement = 0xD6,
        Unknown_D7 = 0xD7,
        DarkArtDescription = 0xD8,
        DarkArt = 0xD9,
        Unknown_DB = 0xDB,
        Unknown_DA = 0xDA,
        Unknown_DF = 0xDF,
        Unknown_E0 = 0xE0,
        Unknown_E1 = 0xE1,
        Unknown_E2 = 0xE2
    }

    public enum IconType
    {
        Unknown_01 = 0x01,
        SpellBook = 0x02,
        BlueCrystal = 0x03,
        RainbowCrystal = 0x04,
        Spinner = 0x05,
        Feather = 0x06,
        BluePotion = 0x07,
        YellowPotion = 0x08,
        GreenPotion = 0x09,
        OrangePotion = 0x0A,
        RedPotion = 0x0B,
        PurplePotion = 0x0C,
        BuffPotion = 0x0E,
        Mop = 0x0F,
        Serum = 0x10,
        WhiteGem = 0x11,
        YellowGem = 0x12,
        BlueGem = 0x13,
        GreenGem = 0x14,
        Key = 0x15,
        Mirror = 0x16,
        Mattock = 0x17,
        Rock = 0x18,
        Trap = 0x19,
        Trickster = 0x1A,
        Arrow = 0x1B,
        GoldBug = 0x1C,
        BlackBug = 0x1D,
        Disguise = 0x1E,
        License = 0x1F,
        Contract = 0x20,
        Wings = 0x21,
        Ticket = 0x22,
        Tablet = 0x23,
        Blackmail = 0x24,
        Passport = 0x25,
        Antidote = 0x26,
        RoyalRing = 0x27,
        Orb = 0x28,
        PiggyBank = 0x29,
        Wabbit = 0x2A,
        DogPicture = 0x2B,
        SalamanderBug = 0x2C,
        Magazine = 0x2D,
        Flower = 0x2E,
        RedBook = 0x2F,
        BlueBook = 0x30,
        YellowBook = 0x31,
        OrangeBook = 0x32,
        Poisoned = 0x33,
        Plagued = 0x34,
        Footsore = 0x35,
        Asleep = 0x36,
        Paralyzed = 0x37,
        Afraid = 0x38,
        BagSealed = 0x39,
        Reaper = 0x3A,
        ActionSealed = 0x3B,
        Confused = 0x3C,
        Cursse = 0x3D,
        Blind = 0x3E,
        Criminal = 0x3F,
        AttackDown = 0x40,
        DefenseDown = 0x41,
        MagicDown = 0x42,
        SpeedDown = 0x43,
        AllDown = 0x44,
        AttackUp = 0x45,
        DefenseUp = 0x46,
        MagicUp = 0x47,
        SpeedUp = 0x48,
        AllUp = 0x49,
        Blade = 0x4A,
        Axe = 0x4B,
        Wand = 0x4C,
        Mace = 0x4D,
        Spear = 0x4E,
        Fist = 0x4F,
        Bow = 0x50,
        Shield = 0x51,
        Gloves = 0x52,
        Ring = 0x53,
        Bracelet = 0x54,
        Necklace = 0x55,
        Footwear = 0x56,
        Bandana = 0x57,
        Badge = 0x58,
        Earring = 0x59,
        Crown = 0x5A,
        OffensiveMagic = 0x5B,
        DefensiveMagic = 0x5C,
        Hairstyle = 0x68,
        DriedKusaya = 0x80,
        Ningyoyaki = 0x81,
        Natto = 0x82,
        XishanDuck = 0x83,
        SharkFinSoup = 0x84,
        Kimchi = 0x85,
        DolsotBibimbap = 0x86,
        DriendMango = 0x87,
        KhanCombo = 0x88,
        PotatoJuice = 0x88,
        Caviar = 0x89,
        BeefStroganoff = 0x8A,
        Borscht = 0x8B,
        Kebab = 0x8C,
        Pierogi = 0x8D,
        HolyCurry = 0x8F,
        GaronneWine = 0x90,
        CerdoLoko = 0x91,
        Truffles = 0x92,
        Pizza = 0x93,
        Tiramisu = 0x94,
        FoieGras = 0x95,
        BlueCheese = 0x96,
        Pistachio = 0x97,
        Sachertorte = 0x98,
        Bagel = 0x99,
        Frankfurters = 0x9A,
        RoastBeef = 0x9B,
        PickledHerring = 0x9C,
        SewardSalmon = 0x9D,
        RawOysters = 0x9E,
        KingsBurger = 0x9F,
        FifthStreetBun = 0xA0,
        CornOnTheCob = 0xA1,
        HotDog = 0xA2,
        AstronautFood = 0xA3,
        SevenSevenSevenSteak = 0xA4,
        Avocado = 0xA5,
        Taco = 0xA6,
        CanalBanana = 0xA7,
        WormCandy = 0xA8,
        DriedOranges = 0xA9,
        Churrasco = 0xAA,
        Soybeans = 0xAB,
        MateTea = 0xAC,
        ChichaMorada = 0xAD,
        SzechuanShrimp = 0xAE,
        QuetzalCola = 0xAF,
        Piranha = 0xB0,
        Saltena = 0xB1,
        PolarSoup = 0xB2,
        SmokedBird = 0xB3,
        Kiviak = 0xB4,
        PenguinTread = 0xB5,
        CongoCurry = 0xB6,
        PyramidBread = 0xB7,
        FriedScorpion = 0xB8,
        OasisWater = 0xB9,
        OstrichSoup = 0xBA,
        FruitJuice = 0xBB,
        WhiteAnt = 0xBC,
        LagenesCake = 0xBD,
        CapeCatsup = 0xBE,
        MeatOfHope = 0xBF,
        KoalaCookies = 0xC0,
        UluDumplings = 0xC1,
        TropicalJuice = 0xC2,
        TorochicaJuice = 0xC3,
        AyersCandy = 0xC4,
        RiceNoodles = 0xC5,
        Bonbon = 0xC6,
        GrayTroutSushi = 0xC7,
        Jade = 0xC8,
        Ruby = 0xC9,
        Sapphire = 0xCA,
        Emerald = 0xCB,
        Tourmaline = 0xCC,
        Diamond = 0xCD,
        Opal = 0xCE,
        BlackDiamond = 0xCF
    }

    public enum EffectType
    {
        Poison = 0x0200,
        Curse = 0x0204,
        Asleep = 0x0300,
        SealOM = 0x0301,
        SealOMDM = 0x0302,
        Stun = 0x0305,
        SealATCT = 0x0306,
        Blind = 0x0309,
        AttackDown50 = 0x030F,
        DefenseDown50 = 0x0310,
        MagicDown50 = 0x0311,
        SpeedDown50 = 0x0312,
        AllDown50 = 0x0313,
        AttackDown25 = 0x0315,
        DefenseDown25 = 0x0316,
        MagicDown25 = 0x0317,
        SpeedDown25 = 0x0318,
        AttackUp = 0x0319,
        DefenseUp = 0x031A,
        MagicUp = 0x031B,
        SpeedUp = 0x031C,
        AllUp = 0x031D,
        Footsore = 0x0405,
        Paralyze = 0x0406,
        Afraid = 0x0407,
        SealBag = 0x0408,
        Doom = 0x040A
    }

    public enum ItemType
    {
        None = 0,
        Weapon = 1,
        Shield = 2,
        Accessory = 3,
        Hairstyle = 4,
        BagItem = 5,
        OffensiveMagic = 6,
        DefensiveMagic = 7,
        FieldMagic = 8,
        BattleSkill = 9
    }

    public partial class Header
    {
        public HeaderType headerType;
        public long headerStart;

        public Header(HeaderType headerType, long headerStart)
        {
            this.headerType = headerType;
            this.headerStart = headerStart - 4;
        }

        public void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            headerStart = stageFile.Position();
            stageFile.Write((UInt32)headerType);
        }
    }

    public class FileNameHeader : Header
    {
        public UInt16 index;
        public UInt16 unknownUint16;
        public string fileName;

        public FileNameHeader(long headerStart) : base(HeaderType.FileName, headerStart)
        {
            fileName = string.Empty;
        }

        public static FileNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new FileNameHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.unknownUint16 = stageFile.GetUInt16();
            header.fileName = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        { 
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownUint16);
            if (fileName == "\0\0\0\0")
            {
                stageFile.Write((UInt32)0);
                stageFile.Write((UInt32)0);
                stageFile.Write((UInt32)0);
            }
            else
            {
                stageFile.WriteString(fileName);
            }
        }

        public void WriteHeaderBlockWithPosition(DokaponFileWriter stageFile)
        {
            WriteHeaderBlock(stageFile);
            UInt32 currentPosition = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart + 4);
            stageFile.Write(currentPosition);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_03 : Header
    {
        public UInt32 endOfData;
        public UInt32 unknownUint;

        public UnknownHeader_03(long headerStart) : base(HeaderType.Unknown_03, headerStart)
        {
        }

        public static UnknownHeader_03 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_03(stageFile.Position());

            header.endOfData = stageFile.GetUInt32();
            header.unknownUint = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(endOfData);
            stageFile.Write(unknownUint);
        }

        public void WriteEndDataBlock(DokaponFileWriter stageFile)
        {
            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class StageFileHeader : Header
    {
        public UInt32 index;
        public UInt32 filePointer;
        public string fileName;

        public StageFileHeader(long headerStart) : base(HeaderType.StageFile, headerStart)
        {
            fileName = string.Empty;
        }

        public static StageFileHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new StageFileHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.filePointer = stageFile.GetUInt32();
            header.fileName = stageFile.GetStringAtPosition(header.filePointer, 4, true);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(filePointer);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            filePointer = (UInt32)stageFile.Position();
            stageFile.WriteString(fileName);
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }

        public void WriteBlockAddress(DokaponFileWriter stageFile, UInt32 address)
        {
            filePointer = address;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class EndOfFileHeader : Header
    {
        public EndOfFileHeader(long headerStart) : base(HeaderType.EndOfFile, headerStart)
        {
        }

        public static EndOfFileHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EndOfFileHeader(stageFile.Position());
            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
        }
    }

    public class UnknownHeader_17 : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_17(long headerStart) : base(HeaderType.Unknown_17, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_17 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_17(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_1C : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_1C(long headerStart) : base(HeaderType.Unknown_1C, headerStart)
        {
            unknownBytes = new byte[4];
        }

        public static UnknownHeader_1C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_1C(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_1D : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_1D(long headerStart) : base(HeaderType.Unknown_1D, headerStart)
        {
            unknownBytes = new byte[4];
        }

        public static UnknownHeader_1D ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_1D(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_1E : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_1E(long headerStart) : base(HeaderType.Unknown_1E, headerStart)
        {
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_1E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_1E(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class JobFileHeader2 : Header
    {
        public byte index;
        public byte sex;
        public UInt16 filler;
        public string[] jobFiles;


        public JobFileHeader2(long headerStart) : base(HeaderType.JobFile2, headerStart)
        {
            jobFiles = new string[4];
        }

        public static JobFileHeader2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobFileHeader2(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();

            for (int i = 0; i < header.jobFiles.Length; i++)
                header.jobFiles[i] = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(filler);

            for (int i = 0; i < jobFiles.Length; i++)
                stageFile.WriteString(jobFiles[i]);
        }
    }

    public class TextureFileNameHeader : Header
    {
        public byte index;
        public byte[] unknownBytes;
        public string name;

        public TextureFileNameHeader(long headerStart) : base(HeaderType.TextureFileName, headerStart)
        {
            unknownBytes = new byte[3];
            name = String.Empty;
        }

        public static TextureFileNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new TextureFileNameHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
            stageFile.WriteString(name);
        }
    }

    public class UnknownHeader_2B : Header
    {
        public UInt16 index;
        public UInt16 unknownShort1;
        public UInt16 unknownShort2;
        public UInt16 unknownShort3;

        public UnknownHeader_2B(long headerStart) : base(HeaderType.Unknown_2B, headerStart)
        {
        }

        public static UnknownHeader_2B ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_2B(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.unknownShort1 = stageFile.GetUInt16();
            header.unknownShort2 = stageFile.GetUInt16();
            header.unknownShort3 = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownShort1);
            stageFile.Write(unknownShort2);
            stageFile.Write(unknownShort3);
        }
    }

    public class UnknownHeader_2C : Header
    {
        public UInt32 unknownUint;

        public UnknownHeader_2C(long headerStart) : base(HeaderType.Unknown_2C, headerStart)
        {
        }

        public static UnknownHeader_2C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_2C(stageFile.Position());

            header.unknownUint = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUint);
        }
    }

    public class UnknownHeader_2D : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_2D(long headerStart) : base(HeaderType.Unknown_2D, headerStart)
        {
            unknownBytes = new byte[16];
        }

        public static UnknownHeader_2D ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_2D(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class JobSalaryHeader : Header
    {
        public byte index;
        public byte sex;
        public byte bonusRequirementCount;
        public byte classIndex;
        public UInt32 startingSalary;
        public UInt16 levelUpSalaryMultiplier; // times 100
        public UInt16 bonusMultiplier; // times 100

        public JobSalaryHeader(long headerStart) : base(HeaderType.JobSalary, headerStart)
        {
        }

        public static JobSalaryHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobSalaryHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.bonusRequirementCount = stageFile.GetByte();
            header.classIndex = stageFile.GetByte();
            header.startingSalary = stageFile.GetUInt32();
            header.levelUpSalaryMultiplier = stageFile.GetUInt16();
            header.bonusMultiplier = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(bonusRequirementCount);
            stageFile.Write(classIndex);
            stageFile.Write(startingSalary);
            stageFile.Write(levelUpSalaryMultiplier);
            stageFile.Write(bonusMultiplier);
        }
    }

    public class UnknownHeader_2F : Header
    {
        public byte unknownByte1;
        public byte unknownByte2;
        public byte unknownByte3;
        public byte unknownByte4;

        public UnknownHeader_2F(long headerStart) : base(HeaderType.Unknown_2F, headerStart)
        {
        }

        public static UnknownHeader_2F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_2F(stageFile.Position());

            header.unknownByte1 = stageFile.GetByte();
            header.unknownByte2 = stageFile.GetByte();
            header.unknownByte3 = stageFile.GetByte();
            header.unknownByte4 = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownByte1);
            stageFile.Write(unknownByte2);
            stageFile.Write(unknownByte3);
            stageFile.Write(unknownByte4);
        }
    }

    public class LocationHeader : Header
    {
        public UInt32 index;
        public string name;

        public LocationHeader(long headerStart) : base(HeaderType.Location, headerStart)
        {
            name = string.Empty;
        }

        public static LocationHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new LocationHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class UnknownHeader_38 : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_38(long headerStart) : base(HeaderType.Unknown_38, headerStart)
        {
            unknownBytes = new byte[7];
        }

        public static UnknownHeader_38 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_38(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_39 : Header
    {
        public UInt32 index;
        public UInt32 startOfData;
        public List<UInt16> unknownList;

        public UnknownHeader_39(long headerStart) : base(HeaderType.Unknown_39, headerStart)
        {
            unknownList = new List<UInt16>();
        }

        public static UnknownHeader_39 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_39(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.startOfData = stageFile.GetUInt32();
            header.unknownList = stageFile.GetUInt16ListAtPosition(header.startOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(startOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in unknownList)
                stageFile.Write(v);

            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class CPUNamesHeader : Header
    {
        public UInt32 sex;
        public UInt32 startOfData;
        public List<string> names;

        public CPUNamesHeader(long headerStart) : base(HeaderType.CPUNames, headerStart)
        {
            names = new List<string>();
        }

        public static CPUNamesHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new CPUNamesHeader(stageFile.Position());

            header.sex = stageFile.GetUInt32();
            header.startOfData = stageFile.GetUInt32();
            header.names = stageFile.GetStringListAtPosition(header.startOfData, 2);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(sex);
            stageFile.Write(startOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var name in names)
                stageFile.WriteString(name);

            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class JobLevelAndMasteryHeader : Header
    {
        public byte index;
        public byte sex;
        public UInt16 levelUpAttack;
        public UInt16 levelUpDefense;
        public UInt16 levelUpMagic;
        public UInt16 levelUpSpeed;
        public UInt16 levelUpHP;
        public UInt16 masteryAttack;
        public UInt16 masteryDefense;
        public UInt16 masteryMagic;
        public UInt16 masterySpeed;
        public UInt16 masteryHP;
        public UInt16 filler;

        public JobLevelAndMasteryHeader(long headerStart) : base(HeaderType.JobLevelAndMastery, headerStart)
        {
        }

        public static JobLevelAndMasteryHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobLevelAndMasteryHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.levelUpAttack = stageFile.GetUInt16();
            header.levelUpDefense = stageFile.GetUInt16();
            header.levelUpMagic = stageFile.GetUInt16();
            header.levelUpSpeed = stageFile.GetUInt16();
            header.levelUpHP = stageFile.GetUInt16();
            header.masteryAttack = stageFile.GetUInt16();
            header.masteryDefense = stageFile.GetUInt16();
            header.masteryMagic = stageFile.GetUInt16();
            header.masterySpeed = stageFile.GetUInt16();
            header.masteryHP = stageFile.GetUInt16();
            header.filler = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write((UInt32)headerType);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(levelUpAttack);
            stageFile.Write(levelUpDefense);
            stageFile.Write(levelUpMagic);
            stageFile.Write(levelUpSpeed);
            stageFile.Write(levelUpHP);
            stageFile.Write(masteryAttack);
            stageFile.Write(masteryDefense);
            stageFile.Write(masteryMagic);
            stageFile.Write(masterySpeed);
            stageFile.Write(masteryHP);
            stageFile.Write(filler);
        }
    }

    public class JobBattleSkillHeader : Header
    {
        public byte index;
        public byte sex;
        public byte jobIndex;
        public byte firstBattleSkillIndex;
        public byte secondBattleSkillIndex;
        public byte[] unknownBytes;

        public JobBattleSkillHeader(long headerStart) : base(HeaderType.JobBattleSkill, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static JobBattleSkillHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobBattleSkillHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.jobIndex = stageFile.GetByte();
            header.firstBattleSkillIndex = stageFile.GetByte();
            header.secondBattleSkillIndex = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(jobIndex);
            stageFile.Write(firstBattleSkillIndex);
            stageFile.Write(secondBattleSkillIndex);
            stageFile.Write(unknownBytes);
        }
    }

    public class JobDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public JobDescriptionHeader(long headerStart) : base(HeaderType.JobDescription, headerStart)
        {
            description = new List<string>();
        }

        public static JobDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_3F : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_3F(long headerStart) : base(HeaderType.Unknown_3F, headerStart)
        {
            unknownBytes = new byte[4];
        }

        public static UnknownHeader_3F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_3F(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class JobLevelUpRequirementHeader : Header
    {
        public byte index;
        public byte sex;
        public UInt16 battlesToLevel;

        public JobLevelUpRequirementHeader(long headerStart) : base(HeaderType.JobLevelUpRequirement, headerStart)
        {
        }

        public static JobLevelUpRequirementHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobLevelUpRequirementHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.battlesToLevel = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(battlesToLevel);
        }
    }

    public class JobStartingStatsHeader : Header
    {
        public byte index;
        public byte sex;
        public UInt16 attack;
        public UInt16 defense;
        public UInt16 magic;
        public UInt16 speed;
        public UInt16 hp;

        public JobStartingStatsHeader(long headerStart) : base(HeaderType.JobStartingStats, headerStart)
        {
        }

        public static JobStartingStatsHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobStartingStatsHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.attack = stageFile.GetUInt16();
            header.defense = stageFile.GetUInt16();
            header.magic = stageFile.GetUInt16();
            header.speed = stageFile.GetUInt16();
            header.hp = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(attack);
            stageFile.Write(defense);
            stageFile.Write(magic);
            stageFile.Write(speed);
            stageFile.Write(hp);
        }
    }

    public class JobUnknownInfoHeader1 : Header
    {
        public byte index;
        public byte sex;
        public UInt16 unknownUInt16;
        public string name;
        public UInt32 filler;

        public JobUnknownInfoHeader1(long headerStart) : base(HeaderType.JobUnknownInfo1, headerStart)
        {
            name = string.Empty;
        }

        public static JobUnknownInfoHeader1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobUnknownInfoHeader1(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.unknownUInt16 = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.filler = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(unknownUInt16);
            stageFile.WriteString(name);
            stageFile.Write(filler);
        }
    }

    public class JobUnknownInfoHeader2 : Header
    {
        public byte index;
        public byte sex;
        public byte[] unknownBytes;

        public JobUnknownInfoHeader2(long headerStart) : base(HeaderType.JobUnknownInfo2, headerStart)
        {
            unknownBytes = new byte[6];
        }

        public static JobUnknownInfoHeader2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobUnknownInfoHeader2(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(unknownBytes);
        }
    }

    public class JobItemSpacesHeader : Header
    {
        public byte index;
        public byte sex;
        public byte bagItemSpace;
        public byte fieldMagicSpace;

        public JobItemSpacesHeader(long headerStart) : base(HeaderType.JobItemSpace, headerStart)
        {
        }

        public static JobItemSpacesHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobItemSpacesHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.bagItemSpace = stageFile.GetByte();
            header.fieldMagicSpace = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(bagItemSpace);
            stageFile.Write(fieldMagicSpace);
        }
    }

    public class JobFileHeader1 : Header
    {
        public byte index;
        public byte sex;
        public UInt16 filler;
        public string[] jobFiles;


        public JobFileHeader1(long headerStart) : base(HeaderType.JobFile1, headerStart)
        {
            jobFiles = new string[6];
        }

        public static JobFileHeader1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobFileHeader1(stageFile.Position());

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();

            for (int i = 0; i < header.jobFiles.Length; i++)
                header.jobFiles[i] = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(sex);
            stageFile.Write(filler);
            for (int i = 0; i < jobFiles.Length; i++)
                stageFile.WriteString(jobFiles[i]);
        }
    }

    public class UnknownHeader_46 : Header
    {
        public UInt16 index;
        public byte[] unknownBytes;

        public UnknownHeader_46(long headerStart) : base(HeaderType.Unknown_46, headerStart)
        {
            unknownBytes = new byte[6];
        }

        public static UnknownHeader_46 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_46(stageFile.Position());

            header.index = stageFile.GetUInt16();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_47 : Header
    {
        public UInt32 unknownuint32;

        public UnknownHeader_47(long headerStart) : base(HeaderType.Unknown_47, headerStart)
        {
        }

        public static UnknownHeader_47 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_47(stageFile.Position());

            header.unknownuint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownuint32);
        }
    }

    public class UnknownHeader_48 : Header
    {
        public UInt32 index;
        public UInt32 unknownUint32;

        public UnknownHeader_48(long headerStart) : base(HeaderType.Unknown_48, headerStart)
        {
        }

        public static UnknownHeader_48 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_48(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUint32);
        }
    }

    public class UnknownHeader_49 : Header
    {
        public UInt32 index;
        public UInt32 unknownUint32;


        public UnknownHeader_49(long headerStart) : base(HeaderType.Unknown_49, headerStart)
        {
        }

        public static UnknownHeader_49 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_49(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownUint32);
        }
    }

    public class DialogPointerListHeader : Header
    {
        public UInt32 index;
        public List<UInt32> dialogPointer;
        public List<string> dialog;

        public DialogPointerListHeader(long headerStart) : base(HeaderType.DialogPointerList, headerStart)
        {
            dialogPointer = new List<UInt32>();
            dialog = new List<string>();
        }

        public static DialogPointerListHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DialogPointerListHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.dialogPointer = stageFile.GetUInt32List();

            foreach (var pointer in header.dialogPointer)
            {
                if (pointer == 0)
                    continue;

                header.dialog.Add(stageFile.GetStringAtPosition(pointer, 4, true));
            }

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            foreach(var v in dialogPointer)
                stageFile.Write(v);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            for (int i = 0; i < dialog.Count; i ++)
            {
                dialogPointer[i] = (UInt32)stageFile.Position();
                stageFile.WriteString(dialog[i]);
            }

            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class DialogListHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> dialog;

        public DialogListHeader(long headerStart) : base(HeaderType.DialogList, headerStart)
        {
            dialog = new List<string>();
        }

        public static DialogListHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DialogListHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.dialog = stageFile.GetStringListAtSection(header.startOfData, header.endOfData, 4, true);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach (var v in dialog)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_4C : Header
    {
        public UInt16 index;
        public byte[] unknownBytes;

        public UnknownHeader_4C(long headerStart) : base(HeaderType.Unknown_4C, headerStart)
        {
            unknownBytes = new byte[6];
        }

        public static UnknownHeader_4C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_4C(stageFile.Position());

            header.index = stageFile.GetUInt16();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_4D : Header
    {
        public UInt32 listPointer;
        public List<UInt32> dataPointers;
        public List<List<byte>> unknownBytes;


        public UnknownHeader_4D(long headerStart) : base(HeaderType.Unknown_4D, headerStart)
        {
            dataPointers = new List<UInt32>();
            unknownBytes = new List<List<byte>>();
        }

        public static UnknownHeader_4D ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_4D(stageFile.Position());

            header.listPointer = stageFile.GetUInt32();
            header.dataPointers = stageFile.GetUInt32ListAtPosition(header.listPointer);
            foreach (var pointer in header.dataPointers)
            {
                if (pointer == 0)
                    continue;

                header.unknownBytes.Add(stageFile.GetByteListAtPosition(pointer, true));
            }

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(listPointer);
        }

        public void WritePointerData(DokaponFileWriter stageFile)
        {
            listPointer = (UInt32)stageFile.Position();

            foreach (var v in dataPointers)
                stageFile.Write(v);

            var currentPosition = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            for (int i = 0; i < unknownBytes.Count; i++)
            {
                dataPointers[i] = (UInt32)stageFile.Position();
                foreach (var v in unknownBytes[i])
                    stageFile.Write(v);
            }

            var currentPosition = (UInt32)stageFile.Position();
            stageFile.SetPosition(listPointer);
            WritePointerData(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_4E : Header
    {
        public byte index;
        public byte[] unknownBytes;


        public UnknownHeader_4E(long headerStart) : base(HeaderType.Unknown_4E, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_4E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_4E(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_4F : Header
    {
        public UInt32 listPointer;
        public List<UInt32> dataPointers;
        public List<List<byte>> unknownBytes;

        public UnknownHeader_4F(long headerStart) : base(HeaderType.Unknown_4F, headerStart)
        {
            dataPointers = new List<UInt32>();
            unknownBytes = new List<List<byte>>();
        }

        public static UnknownHeader_4F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_4F(stageFile.Position());

            header.listPointer = stageFile.GetUInt32();
            header.dataPointers = stageFile.GetUInt32ListAtPosition(header.listPointer, true);

            foreach (var pointer in header.dataPointers)
            {
                if (pointer == 0)
                    continue;

                header.unknownBytes.Add(stageFile.GetByteListAtPosition(pointer, true));
            }

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(listPointer);
        }

        public void WritePointerData(DokaponFileWriter stageFile)
        {
            listPointer = (UInt32)stageFile.Position();

            foreach (var v in dataPointers)
                stageFile.Write(v);

            var currentPosition = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            for (int i = 0; i < unknownBytes.Count; i++)
            {
                dataPointers[i] = (UInt32)stageFile.Position();
                foreach (var v in unknownBytes[i])
                    stageFile.Write(v);
            }

            var currentPosition = (UInt32)stageFile.Position();
            stageFile.SetPosition(listPointer);
            WritePointerData(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class JobNameHeader : Header
    {
        public UInt32 index;
        public string name;

        public JobNameHeader(long headerStart) : base(HeaderType.JobName, headerStart)
        {
            name = string.Empty;
        }

        public static JobNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobNameHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class MonsterHeader : Header
    {
        public enum SpecialStatType
        {
            Average = 0x80, // second byte is multiplier (divide by 10 and add 1)
            Highest = 0x81, // second byte is multiplier (divide by 10 and add 1)
            Clonus = 0x82, // second byte is player to clone
            Lowest = 0x84  // second byte is multiplier (divide by 10 and add 1)  
        }

        public byte index;
        public byte monsterID;
        public UInt16 level;
        public string name;
        public UInt16 hp;
        public UInt16 attack;
        public UInt16 defense;
        public UInt16 speed;
        public UInt16 magic;
        public UInt16 filler;
        public byte offensiveMagicID;
        public byte defensiveMagicID;
        public UInt16 battleSkillID;
        public UInt16 experience;
        public Int16 gold;


        public MonsterHeader(long headerStart) : base(HeaderType.Monster, headerStart)
        {
            name = string.Empty;
        }

        public static MonsterHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.monsterID = stageFile.GetByte();
            header.level = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.hp = stageFile.GetUInt16();
            header.attack = stageFile.GetUInt16();
            header.defense = stageFile.GetUInt16();
            header.speed = stageFile.GetUInt16();
            header.magic = stageFile.GetUInt16();
            header.filler = stageFile.GetUInt16();
            header.offensiveMagicID = stageFile.GetByte();
            header.defensiveMagicID = stageFile.GetByte();
            header.battleSkillID = stageFile.GetUInt16();
            header.experience = stageFile.GetUInt16();
            header.gold = stageFile.GetInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(monsterID);
            stageFile.Write(level);
            stageFile.WriteString(name);
            stageFile.Write(hp);
            stageFile.Write(attack);
            stageFile.Write(defense);
            stageFile.Write(speed);
            stageFile.Write(magic);
            stageFile.Write(filler);
            stageFile.Write(offensiveMagicID);
            stageFile.Write(defensiveMagicID);
            stageFile.Write(battleSkillID);
            stageFile.Write(experience);
            stageFile.Write(gold);
        }
    }

    public class MonsterUnknownInfoHeader : Header
    {
        public UInt16 index;
        public byte[] unknownBytes;
        public string name;
        public UInt32 filler;

        public MonsterUnknownInfoHeader(long headerStart) : base(HeaderType.MonsterUnknownInfo, headerStart)
        {
            unknownBytes = new byte[6];
            name = string.Empty;
        }

        public static MonsterUnknownInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterUnknownInfoHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();
            header.filler = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
            stageFile.WriteString(name);
            stageFile.Write(filler);
        }
    }

    public class UnknownFilePointer
    {
        public UInt32 type;
        public UInt32 index;
        public UInt32 pointer;
    }

    public class MonsterFileInfoHeader : Header
    {
        public UInt32 index;
        public string F0File;
        public string FG0File;
        public List<UnknownFilePointer> unknownPointers;
        public UInt32 filler;
        public List<List<UInt16>> unknownUInt16s;

        public MonsterFileInfoHeader(long headerStart) : base(HeaderType.MonsterFileInfo, headerStart)
        {
            unknownPointers = new List<UnknownFilePointer>();
            unknownUInt16s = new List<List<UInt16>>();
            F0File = string.Empty;
            FG0File = string.Empty;
        }

        public static MonsterFileInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterFileInfoHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.F0File = stageFile.GetString();
            header.FG0File = stageFile.GetString();

            UnknownFilePointer filePointer;
            do
            {
                filePointer = new UnknownFilePointer { type = stageFile.GetUInt32() };

                if (filePointer.type == 0)
                    continue;

                filePointer.index = stageFile.GetUInt32();
                filePointer.pointer = stageFile.GetUInt32();
                header.unknownPointers.Add(filePointer);

            } while (filePointer.type != 0);

            header.filler = 0;

            foreach (var pointer in header.unknownPointers)
                header.unknownUInt16s.Add(stageFile.GetUInt16ListAtPosition(pointer.pointer));

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(F0File);
            stageFile.WriteString(FG0File);

            foreach (var v in unknownPointers)
            {
                stageFile.Write(v.type);
                stageFile.Write(v.index);
                stageFile.Write(v.pointer);
            }

            stageFile.Write(filler);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            for (int i = 0; i < unknownUInt16s.Count; i++)
            {
                unknownPointers[i].pointer = (UInt32)stageFile.Position();
                foreach (var v in unknownUInt16s[i])
                    stageFile.Write(v);
            }

            var currentPosition = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class MonsterAITableHeader : Header
    {
        public byte index;
        public byte attackRate;
        public byte skillRate;
        public byte strikeRate;
        public byte magicRate;
        public byte defendRate;
        public byte counterRate;
        public byte magicDefendRate;

        public MonsterAITableHeader(long headerStart) : base(HeaderType.MonsterFileInfo, headerStart)
        {
        }

        public static MonsterAITableHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterAITableHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.attackRate = stageFile.GetByte();
            header.skillRate = stageFile.GetByte();
            header.strikeRate = stageFile.GetByte();
            header.magicRate = stageFile.GetByte();
            header.defendRate = stageFile.GetByte();
            header.counterRate = stageFile.GetByte();
            header.magicDefendRate = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(attackRate);
            stageFile.Write(skillRate);
            stageFile.Write(strikeRate);
            stageFile.Write(magicRate);
            stageFile.Write(defendRate);
            stageFile.Write(counterRate);
            stageFile.Write(magicDefendRate);
        }
    }

    public class UnknownHeader_52 : Header
    {
        public UInt32 index;
        public string unknownString;

        public UnknownHeader_52(long headerStart) : base(HeaderType.Unknown_52, headerStart)
        {
            unknownString = String.Empty;
        }

        public static UnknownHeader_52 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_52(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.unknownString = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(unknownString);
        }
    }

    public class MonsterItemDropHeader : Header
    {
        public byte index;
        public byte dropItemChance0;
        public byte dropItemChance1;
        public byte filler;
        public byte indexItem0;
        public byte categoryItem0;
        public byte indexItem1;
        public byte categoryItem1;

        public MonsterItemDropHeader(long headerStart) : base(HeaderType.MonsterItemDrop, headerStart)
        {
        }

        public static MonsterItemDropHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterItemDropHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.dropItemChance0 = stageFile.GetByte();
            header.dropItemChance1 = stageFile.GetByte();
            header.filler = stageFile.GetByte();
            header.indexItem0 = stageFile.GetByte();
            header.categoryItem0 = stageFile.GetByte();
            header.indexItem1 = stageFile.GetByte();
            header.categoryItem1 = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(dropItemChance0);
            stageFile.Write(dropItemChance1);
            stageFile.Write(filler);
            stageFile.Write(indexItem0);
            stageFile.Write(categoryItem0);
            stageFile.Write(indexItem1);
            stageFile.Write(categoryItem1);
        }
    }

    public class UnknownHeader_54 : Header
    {
        public UInt32 unknownUInt32;

        public UnknownHeader_54(long headerStart) : base(HeaderType.Unknown_54, headerStart)
        {
        }

        public static UnknownHeader_54 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_54(stageFile.Position());
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUInt32);
        }
    }

    public class NPCNameHeader : Header
    {
        public UInt32 index;
        public string name;

        public NPCNameHeader(long headerStart) : base(HeaderType.NPCName, headerStart)
        {
            name = string.Empty;
        }

        public static NPCNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new NPCNameHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class NPCUnknownInfoHeader : Header
    {
        public UInt16 index;
        public byte[] unknownBytes;
        public string name;

        public NPCUnknownInfoHeader(long headerStart) : base(HeaderType.NPCUnknownInfo, headerStart)
        {
            unknownBytes = new byte[6];
            name = string.Empty;
        }

        public static NPCUnknownInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new NPCUnknownInfoHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
            stageFile.WriteString(name);
        }
    }

    public class NPCFileInfoHeader : Header
    {
        public UInt32 index;
        public string F0File;
        public string K0File;
        public string FG0File;
        public List<UnknownFilePointer> unknownPointers1;
        public UInt32 filler1;
        public List<UnknownFilePointer> unknownPointers2;
        public UInt32 filler2;
        public List<List<UInt16>> unknownUInt16s1;
        public List<List<UInt16>> unknownUInt16s2;

        public NPCFileInfoHeader(long headerStart) : base(HeaderType.NPCFileInfo, headerStart)
        {
            unknownPointers1 = new List<UnknownFilePointer>();
            unknownPointers2 = new List<UnknownFilePointer>();
            unknownUInt16s1 = new List<List<UInt16>>();
            unknownUInt16s2 = new List<List<UInt16>>();
            F0File = string.Empty;
            K0File = string.Empty;
            FG0File = string.Empty;
        }

        public static NPCFileInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new NPCFileInfoHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.F0File = stageFile.GetString();
            header.K0File = stageFile.GetString();
            header.FG0File = stageFile.GetString();

            UnknownFilePointer filePointer;
            do
            {
                filePointer = new UnknownFilePointer { type = stageFile.GetUInt32() };

                if (filePointer.type == 0)
                    continue;

                filePointer.index = stageFile.GetUInt32();
                filePointer.pointer = stageFile.GetUInt32();
                header.unknownPointers1.Add(filePointer);

            } while (filePointer.type != 0);

            header.filler1 = 0;

            do
            {
                filePointer = new UnknownFilePointer { type = stageFile.GetUInt32() };

                if (filePointer.type == 0)
                    continue;

                filePointer.index = stageFile.GetUInt32();
                filePointer.pointer = stageFile.GetUInt32();
                header.unknownPointers2.Add(filePointer);

            } while (filePointer.type != 0);

            header.filler2 = 0;

            foreach (var pointer in header.unknownPointers1)
                header.unknownUInt16s1.Add(stageFile.GetUInt16ListAtPosition(pointer.pointer, true));

            foreach (var pointer in header.unknownPointers2)
                header.unknownUInt16s2.Add(stageFile.GetUInt16ListAtPosition(pointer.pointer, true));

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(F0File);
            stageFile.WriteString(K0File);
            stageFile.WriteString(FG0File);

            foreach (var v in unknownPointers1)
            {
                stageFile.Write(v.type);
                stageFile.Write(v.index);
                stageFile.Write(v.pointer);
            }

            stageFile.Write(filler1);

            foreach (var v in unknownPointers2)
            {
                stageFile.Write(v.type);
                stageFile.Write(v.index);
                stageFile.Write(v.pointer);
            }

            stageFile.Write(filler2);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            for (int i = 0; i < unknownUInt16s1.Count; i++)
            {
                unknownPointers1[i].pointer = (UInt32)stageFile.Position();
                foreach (var v in unknownUInt16s1[i])
                    stageFile.Write(v);
            }

            for (int i = 0; i < unknownUInt16s2.Count; i++)
            {
                unknownPointers2[i].pointer = (UInt32)stageFile.Position();
                foreach (var v in unknownUInt16s2[i])
                    stageFile.Write(v);
            }

            var currentPosition = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class WeaponHeader : Header
    {
        public enum AnimationType
        {
            Swing = 0x01,
            Poke = 0x02,
            Thrust = 0x03,
            Punch = 0x04,
            Shoot = 0x05
        }

        public enum BonusClass
        {
            None = 0,
            WarriorBased = 0x01,
            MagicianBased = 0x02,
            Thief = 0x03,
            Cleric = 0x04,
            Acrobat = 0x05,
            Monk = 0x06,
            Ninja = 0x07,
            RoboKnight = 0x08
        }

        public UInt16 index;
        public UInt16 iconID;
        public string name;
        public byte attackAnimation;
        public byte bonusClass;
        public byte activationRate;
        public byte unknownByte;
        public UInt32 price;
        public Int16 attack;
        public Int16 defense;
        public Int16 magic;
        public Int16 speed;
        public Int16 hp;
        public byte unknownIndex1; //index to icon or model???
        public byte unknownIndex2; //index to icon or model???

        public WeaponHeader(long headerStart) : base(HeaderType.Weapon, headerStart)
        {
            name = string.Empty;
        }

        public static WeaponHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new WeaponHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.attackAnimation = stageFile.GetByte();
            header.bonusClass = stageFile.GetByte();
            header.activationRate = stageFile.GetByte();
            header.unknownByte = stageFile.GetByte();
            header.price = stageFile.GetUInt32();
            header.attack = stageFile.GetInt16();
            header.defense = stageFile.GetInt16();
            header.magic = stageFile.GetInt16();
            header.speed = stageFile.GetInt16();
            header.hp = stageFile.GetInt16();
            header.unknownIndex1 = stageFile.GetByte();
            header.unknownIndex2 = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(attackAnimation);
            stageFile.Write(bonusClass);
            stageFile.Write(activationRate);
            stageFile.Write(unknownByte);
            stageFile.Write(price);
            stageFile.Write(attack);
            stageFile.Write(defense);
            stageFile.Write(magic);
            stageFile.Write(speed);
            stageFile.Write(hp);
            stageFile.Write(unknownIndex1);
            stageFile.Write(unknownIndex2);
        }
    }

    public class WeaponUnknownInfoHeader : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;
        public string name;

        public WeaponUnknownInfoHeader(long headerStart) : base(HeaderType.WeaponUnknownInfo, headerStart)
        {
            unknownBytes = new byte[24];
            name = String.Empty;
        }

        public static WeaponUnknownInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new WeaponUnknownInfoHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
            stageFile.WriteString(name);
        }
    }

    public class WeaponDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public WeaponDescriptionHeader(long headerStart) : base(HeaderType.WeaponDescription, headerStart)
        {
            description = new List<string>();
        }

        public static WeaponDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new WeaponDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class MonsterTypeHeader : Header
    {
        public enum MonsterType
        {
            Chimpy = 0x00,
            Worm = 0x01,
            Giant = 0x02,
            Beast = 0x03,
            Humanoid = 0x05,
            Human = 0x07,
            Magical = 0x08,
            Spellcaster = 0x0A,
            Demon = 0x0C,
            Wabbit = 0x28,
            Special = 0x64
        }

        public byte index;
        public byte voiceID;
        public byte aiIndex;
        public byte monsterType;

        public MonsterTypeHeader(long headerStart) : base(HeaderType.MonsterType, headerStart)
        {
        }

        public static MonsterTypeHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterTypeHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.voiceID = stageFile.GetByte();
            header.aiIndex = stageFile.GetByte();
            header.monsterType = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(voiceID);
            stageFile.Write(aiIndex);
            stageFile.Write(monsterType);
        }

        public static string GetMonsterType(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.Chimpy: return "Chimpy";
                case MonsterType.Worm: return "Worm";
                case MonsterType.Giant: return "Giant";
                case MonsterType.Beast: return "Beast";
                case MonsterType.Humanoid: return "Humanoid";
                case MonsterType.Human: return "Human";
                case MonsterType.Magical: return "Magical";
                case MonsterType.Spellcaster: return "Spellcaster";
                case MonsterType.Demon: return "Demon";
                case MonsterType.Wabbit: return "Wabbit";
                case MonsterType.Special: return "Special";
                default: return "Unknown";
            }
        }

        public static byte GetMonsterID(string monsterType)
        {
            switch (monsterType)
            {
                case "Chimpy": return (byte)MonsterType.Chimpy;
                case "Worm": return (byte)MonsterType.Worm;
                case "Giant": return (byte)MonsterType.Giant;
                case "Beast": return (byte)MonsterType.Beast;
                case "Humanoid": return (byte)MonsterType.Humanoid;
                case "Human": return (byte)MonsterType.Human;
                case "Magical": return (byte)MonsterType.Magical;
                case "Spellcaster": return (byte)MonsterType.Spellcaster;
                case "Demon": return (byte)MonsterType.Demon;
                case "Wabbit": return (byte)MonsterType.Wabbit;
                case "Special": return (byte)MonsterType.Special;
                default: return 0;
            }
        }
    }

    public class UnknownHeader_5C : Header
    {
        public byte index;
        public byte[] unknownBytes;


        public UnknownHeader_5C(long headerStart) : base(HeaderType.Unknown_5C, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_5C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_5C(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class EtcFileNameHeader : Header
    {
        public byte index;
        public byte[] unknownBytes;
        public string name;

        public EtcFileNameHeader(long headerStart) : base(HeaderType.EtcFileName, headerStart)
        {
            unknownBytes = new byte[3];
            name = string.Empty;
        }

        public static EtcFileNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EtcFileNameHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
            stageFile.WriteString(name);
        }
    }

    public class ShieldHeader : Header
    {
        public UInt16 index;
        public UInt16 iconID;
        public string name;
        public byte activationRate;
        public byte[] unknownBytes;
        public UInt32 price;
        public Int16 defense;
        public Int16 attack;
        public Int16 magic;
        public Int16 speed;
        public Int16 hp;
        public byte unknownIndex1; //index to icon or model???
        public byte unknownIndex2; //index to icon or model???

        public ShieldHeader(long headerStart) : base(HeaderType.Shield, headerStart)
        {
            name = string.Empty;
            unknownBytes = new byte[3];
        }

        public static ShieldHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new ShieldHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.activationRate = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.price = stageFile.GetUInt32();
            header.defense = stageFile.GetInt16();
            header.attack = stageFile.GetInt16();
            header.magic = stageFile.GetInt16();
            header.speed = stageFile.GetInt16();
            header.hp = stageFile.GetInt16();
            header.unknownIndex1 = stageFile.GetByte();
            header.unknownIndex2 = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(activationRate);
            stageFile.Write(unknownBytes);
            stageFile.Write(price);
            stageFile.Write(defense);
            stageFile.Write(attack);
            stageFile.Write(magic);
            stageFile.Write(speed);
            stageFile.Write(hp);
            stageFile.Write(unknownIndex1);
            stageFile.Write(unknownIndex2);
        }
    }

    public class ShieldUnknownInfoHeader : Header
    {
        public UInt32 index;
        public string name;

        public ShieldUnknownInfoHeader(long headerStart) : base(HeaderType.ShieldUnknownInfo, headerStart)
        {
            name = String.Empty;
        }

        public static ShieldUnknownInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new ShieldUnknownInfoHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class ShieldDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public ShieldDescriptionHeader(long headerStart) : base(HeaderType.ShieldDescription, headerStart)
        {
            description = new List<string>();
        }

        public static ShieldDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new ShieldDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class WeaponBonusDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public WeaponBonusDescriptionHeader(long headerStart) : base(HeaderType.WeaponBonusDescription, headerStart)
        {
            description = new List<string>();
        }

        public static WeaponBonusDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new WeaponBonusDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach(var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class AccessoryHeader : Header
    {
        public enum ActivationType
        {
            None = 0x4E,
            Field = 0x46,
            Battle = 0x42,
            Both = 0x41
        }

        public UInt16 index;
        public UInt16 iconID;
        public string name;
        public byte activationRate;
        public byte[] unknownBytes;
        public UInt32 price;
        public Int16 attack;
        public Int16 defense;
        public Int16 magic;
        public Int16 speed;
        public Int16 hp;
        public byte unknownIndex1; //index to icon or model???
        public byte unknownIndex2; //index to icon or model???
        public UInt32 activationType;

        public AccessoryHeader(long headerStart) : base(HeaderType.Accessory, headerStart)
        {
            name = string.Empty;
            unknownBytes = new byte[3];
        }

        public static AccessoryHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new AccessoryHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.activationRate = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.price = stageFile.GetUInt32();
            header.attack = stageFile.GetInt16();
            header.defense = stageFile.GetInt16();
            header.magic = stageFile.GetInt16();
            header.speed = stageFile.GetInt16();
            header.hp = stageFile.GetInt16();
            header.unknownIndex1 = stageFile.GetByte();
            header.unknownIndex2 = stageFile.GetByte();
            header.activationType = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(activationRate);
            stageFile.Write(unknownBytes);
            stageFile.Write(price);
            stageFile.Write(attack);
            stageFile.Write(defense);
            stageFile.Write(magic);
            stageFile.Write(speed);
            stageFile.Write(hp);
            stageFile.Write(unknownIndex1);
            stageFile.Write(unknownIndex2);
            stageFile.Write(activationType);
        }
    }

    public class AccessoryDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public AccessoryDescriptionHeader(long headerStart) : base(HeaderType.AccessoryDescription, headerStart)
        {
            description = new List<string>();
        }

        public static AccessoryDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new AccessoryDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class TempleNameHeader : Header
    {
        public byte index;
        public byte continent;
        public UInt16 mapLocationID;
        public string name;

        public TempleNameHeader(long headerStart) : base(HeaderType.TempleName, headerStart)
        {
            name = string.Empty;
        }

        public static TempleNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new TempleNameHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.continent = stageFile.GetByte();
            header.mapLocationID = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(continent);
            stageFile.Write(mapLocationID);
            stageFile.WriteString(name);
        }
    }

    public class UnknownHeader_66 : Header
    {
        public UInt32 unknownUint;

        public UnknownHeader_66(long headerStart) : base(HeaderType.Unknown_66, headerStart)
        {
        }

        public static UnknownHeader_66 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_66(stageFile.Position());

            header.unknownUint = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUint);
        }
    }

    public class UnknownHeader_68 : Header
    {
        public byte index;
        public byte unknownByte1;
        public byte unknownByte2;
        public byte unknownByte3;
        public UInt32 unknownUint;

        public UnknownHeader_68(long headerStart) : base(HeaderType.Unknown_68, headerStart)
        {
        }

        public static UnknownHeader_68 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_68(stageFile.Position());

            header.index = stageFile.GetByte();
            header.unknownByte1 = stageFile.GetByte();
            header.unknownByte2 = stageFile.GetByte();
            header.unknownByte3 = stageFile.GetByte();
            header.unknownUint = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownByte1);
            stageFile.Write(unknownByte2);
            stageFile.Write(unknownByte3);
            stageFile.Write(unknownUint);
        }
    }

    public class BagItemHeader : Header
    {
        public byte index;
        public byte itemType;
        public UInt16 iconID;
        public string name;
        public UInt32 price;
        public UInt32 unknownUInt32;

        public BagItemHeader(long headerStart) : base(HeaderType.BagItem, headerStart)
        {
            name = string.Empty;
        }

        public static BagItemHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BagItemHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.itemType = stageFile.GetByte();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(itemType);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(price);
            stageFile.Write(unknownUInt32);
        }
    }

    public class BagItemDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public BagItemDescriptionHeader(long headerStart) : base(HeaderType.BagItemDescription, headerStart)
        {
            description = new List<string>();
        }

        public static BagItemDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BagItemDescriptionHeader(stageFile.Position());
            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            // ％ isn't getting read correctly
            for (int i = 0; i < header.description.Count; i++)  
            {
                if (header.description[i].Contains("・・"))
                {
                    header.description[i] = header.description[i].Replace("・・", "％ ");
                }
            }

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_6B : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_6B(long headerStart) : base(HeaderType.Unknown_6B, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_6B ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_6B(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class LocalItemHeader : Header
    {
        public UInt16 index;
        public UInt16 iconID;
        public string name;
        public UInt32 price;
        public Int32 localItemValue;
        public byte spawnRate;
        public byte isCastleItem;
        public byte filler;
        public byte townCastleIndex;

        public LocalItemHeader(long headerStart) : base(HeaderType.LocalItem, headerStart)
        {
            name = string.Empty;
        }

        public static LocalItemHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new LocalItemHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.localItemValue = stageFile.GetInt32();
            header.spawnRate = stageFile.GetByte();
            header.isCastleItem = stageFile.GetByte();
            header.filler = stageFile.GetByte();
            header.townCastleIndex = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(price);
            stageFile.Write(localItemValue);
            stageFile.Write(spawnRate);
            stageFile.Write(isCastleItem);
            stageFile.Write(filler);
            stageFile.Write(townCastleIndex);
        }
    }

    public class TownCastleHeader : Header
    {
        public byte index;
        public byte continent;
        public UInt16 mapLocationID;
        public string name;
        public UInt32 unknownUint1;
        public UInt32 townValue;
        public UInt32 unknownUint2;

        public TownCastleHeader(long headerStart) : base(HeaderType.TownCastleName, headerStart)
        {
            name = string.Empty;
        }

        public static TownCastleHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new TownCastleHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.continent = stageFile.GetByte();
            header.mapLocationID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.unknownUint1 = stageFile.GetUInt32();
            header.townValue = stageFile.GetUInt32();
            header.unknownUint2 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(continent);
            stageFile.Write(mapLocationID);
            stageFile.WriteString(name);
            stageFile.Write(unknownUint1);
            stageFile.Write(townValue);
            stageFile.Write(unknownUint2);
        }
    }

    public class UnknownHeader_6E : Header
    {
        public byte index;
        public byte[] unknownBytes;
        public UInt32 unknownUint1;
        public UInt32 unknownUint2;

        public UnknownHeader_6E(long headerStart) : base(HeaderType.Unknown_6E, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_6E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_6E(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.unknownUint1 = stageFile.GetUInt32();
            header.unknownUint2 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
            stageFile.Write(unknownUint1);
            stageFile.Write(unknownUint2);
        }
    }

    public class UnknownCastleInfo : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownCastleInfo(long headerStart) : base(HeaderType.CastleUnknownInfo, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownCastleInfo ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownCastleInfo(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class OffensiveMagicHeader : Header
    {
        public UInt16 index;
        public UInt16 iconID;
        public string name;
        public UInt32 price;
        public UInt16 power; // multiplied by 100
        public byte magicType;
        public byte sortIndex;
        public UInt16 effectType;
        public UInt16 filler;

        public OffensiveMagicHeader(long headerStart) : base(HeaderType.OffensiveMagic, headerStart)
        {
            name = string.Empty;
        }

        public static OffensiveMagicHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new OffensiveMagicHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.power = stageFile.GetUInt16();
            header.magicType = stageFile.GetByte();
            header.sortIndex = stageFile.GetByte();
            header.effectType = stageFile.GetUInt16();
            header.filler = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(price);
            stageFile.Write(power);
            stageFile.Write(magicType);
            stageFile.Write(sortIndex);
            stageFile.Write(effectType);
            stageFile.Write(filler);
        }
    }

    public class OffensiveMagicDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public OffensiveMagicDescriptionHeader(long headerStart) : base(HeaderType.OffensiveMagicDescription, headerStart)
        {
            description = new List<string>();
        }

        public static OffensiveMagicDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new OffensiveMagicDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class DefensiveMagicHeader : Header
    {
        public UInt16 index;
        public UInt16 iconID;
        public string name;
        public UInt32 price;
        public UInt16 power; // multiplied by 100
        public byte magicType;
        public byte sortIndex;
        public UInt16 effectType;
        public UInt16 filler;

        public DefensiveMagicHeader(long headerStart) : base(HeaderType.DefensiveMagic, headerStart)
        {
            name = string.Empty;
        }

        public static DefensiveMagicHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DefensiveMagicHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.power = stageFile.GetUInt16();
            header.magicType = stageFile.GetByte();
            header.sortIndex = stageFile.GetByte();
            header.effectType = stageFile.GetUInt16();
            header.filler = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(price);
            stageFile.Write(power);
            stageFile.Write(magicType);
            stageFile.Write(sortIndex);
            stageFile.Write(effectType);
            stageFile.Write(filler);
        }
    }

    public class DefensiveMagicDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public DefensiveMagicDescriptionHeader(long headerStart) : base(HeaderType.DefensiveMagicDescription, headerStart)
        {
            description = new List<string>();
        }

        public static DefensiveMagicDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DefensiveMagicDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class FieldMagicHeader : Header
    {
        public UInt16 index;
        public UInt16 iconID;
        public string name;
        public UInt32 price;
        public UInt16 power; // multiplied by 100
        public byte magicType;
        public byte[] unknownBytes;
        public UInt16 effectType;

        public FieldMagicHeader(long headerStart) : base(HeaderType.FieldMagic, headerStart)
        {
            name = string.Empty;
            unknownBytes = new byte[3];
        }

        public static FieldMagicHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new FieldMagicHeader(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.power = stageFile.GetUInt16();
            header.magicType = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.effectType = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(price);
            stageFile.Write(power);
            stageFile.Write(magicType);
            stageFile.Write(unknownBytes);
            stageFile.Write(effectType);
        }
    }

    public class FieldMagicDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public FieldMagicDescriptionHeader(long headerStart) : base(HeaderType.FieldMagicDescription, headerStart)
        {
            description = new List<string>();
        }

        public static FieldMagicDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new FieldMagicDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_76 : Header
    {
        public UInt32 startOfData;
        public UInt32 unknownUint32;
        public UInt32 endOfData;
        public UInt32 filler;
        public List<byte> unknownBytes;

        public UnknownHeader_76(long headerStart) : base(HeaderType.Unknown_76, headerStart)
        {
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_76 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_76(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.unknownUint32 = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.filler = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(unknownUint32);
            stageFile.Write(endOfData);
            stageFile.Write(filler);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in unknownBytes)
                stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_77 : Header
    {
        public UInt32 startOfData;
        public UInt32 unknownUint32;
        public UInt32 endOfData;
        public UInt32 filler;
        public List<byte> unknownBytes;

        public UnknownHeader_77(long headerStart) : base(HeaderType.Unknown_77, headerStart)
        {
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_77 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_77(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.unknownUint32 = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.filler = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(unknownUint32);
            stageFile.Write(endOfData);
            stageFile.Write(filler);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in unknownBytes)
                stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_78 : Header
    {
        public UInt32 index;
        public UInt32 listPointer;
        public List<UInt32> dataPointers;
        public List<List<byte>> unknownBytes;

        public UnknownHeader_78(long headerStart) : base(HeaderType.Unknown_78, headerStart)
        {
            dataPointers = new List<UInt32>();
            unknownBytes = new List<List<byte>>();
        }

        public static UnknownHeader_78 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_78(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.listPointer = stageFile.GetUInt32();
            header.dataPointers = stageFile.GetUInt32ListAtPosition(header.listPointer);

            foreach (var position in header.dataPointers)
            {
                if (position == 0)
                    continue;

                int tokenCount = 3;
                if (header.index == 0x16)
                    tokenCount = 2;
                else if (header.index == 0x17)
                    tokenCount = 1;

                header.unknownBytes.Add(stageFile.GetByteListWithTokenCount(position, 0x00, tokenCount, true));
            }
            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(listPointer);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            listPointer = (UInt32)stageFile.Position();

            foreach (var v in dataPointers)
                stageFile.Write(v);

            for (int i = 0; i < unknownBytes.Count; i++)
            {
                dataPointers[i] = (UInt32)stageFile.Position();

                foreach (var v in unknownBytes[i])
                    stageFile.Write(v);
            }

            while (stageFile.Position() % 4 != 0)
                stageFile.Write((byte)0);

            var currentPosition = stageFile.Position();
            stageFile.SetPosition(listPointer);
            foreach (var v in dataPointers)
                stageFile.Write(v);
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_79 : Header
    {
        public UInt32 unknownUint32;

        public UnknownHeader_79(long headerStart) : base(HeaderType.Unknown_79, headerStart)
        {
        }

        public static UnknownHeader_79 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_79(stageFile.Position());
            header.unknownUint32 = stageFile.GetUInt32();
            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUint32);
        }
    }

    public class BattleSkillHeader : Header
    {
        public byte index;
        public byte activationRate;
        public UInt16 unknownUInt16;
        public string name;

        public BattleSkillHeader(long headerStart) : base(HeaderType.BattleSkill, headerStart)
        {
            name = string.Empty;
        }

        public static BattleSkillHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BattleSkillHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.activationRate = stageFile.GetByte();
            header.unknownUInt16 = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(activationRate);
            stageFile.Write(unknownUInt16);
            stageFile.WriteString(name);
        }
    }

    public class JobSkillHeader : Header
    {
        public byte index;
        public byte activationRate;
        public UInt16 filler;
        public string name;

        public JobSkillHeader(long headerStart) : base(HeaderType.JobSkill, headerStart)
        {
            name = string.Empty;
        }

        public static JobSkillHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobSkillHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.activationRate = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(activationRate);
            stageFile.Write(filler);
            stageFile.WriteString(name);
        }
    }

    public class MonsterDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public MonsterDescriptionHeader(long headerStart) : base(HeaderType.MonsterDescription, headerStart)
        {
            description = new List<string>();
        }

        public static MonsterDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class BattleSkillDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public BattleSkillDescriptionHeader(long headerStart) : base(HeaderType.BattleSkillDescription, headerStart)
        {
            description = new List<string>();
        }

        public static BattleSkillDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BattleSkillDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            // ％ isn't getting read correctly
            for (int i = 0; i < header.description.Count; i++)
            {
                if (header.description[i].Contains("・怒"))
                {
                    header.description[i] = header.description[i].Replace("・怒", "％{");
                }
                if (header.description[i].Contains("・・"))
                {
                    header.description[i] = header.description[i].Replace("・・", "％ ");
                }
            }

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class JobSkillDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public JobSkillDescriptionHeader(long headerStart) : base(HeaderType.JobSkillDescription, headerStart)
        {
            description = new List<string>();
        }

        public static JobSkillDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobSkillDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class RandomLootHeader : Header
    {
        public UInt32 index;
        public UInt32 start;
        public UInt16 length;
        public UInt16 itemPickCount;
        public List<(byte index, byte type)> itemList;

        public RandomLootHeader(long headerStart) : base(HeaderType.RandomLoot, headerStart)
        {
            itemList = new List<(byte index, byte category)>();
        }

        public static RandomLootHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new RandomLootHeader(stageFile.Position());
            header.index = stageFile.GetUInt32();
            header.start = stageFile.GetUInt32();

            var nextHeader = stageFile.Position();

            stageFile.SetPosition(header.start);
            header.length = stageFile.GetUInt16();
            header.itemPickCount = stageFile.GetUInt16();

            for (int i = 0; i < header.length; i++)
                header.itemList.Add((stageFile.GetByte(), stageFile.GetByte()));

            stageFile.SetPosition(nextHeader);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(start);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            start = (UInt32)stageFile.Position();
            length = (UInt16)itemList.Count();
            stageFile.Write(length);
            stageFile.Write(itemPickCount);
            foreach(var v in itemList)
            {
                stageFile.Write(v.index);
                stageFile.Write(v.type);
            }

            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class EffectNameHeader1 : Header
    {
        public UInt16 index;
        public UInt16 iconID;
        public string name;

        public EffectNameHeader1(long headerStart) : base(HeaderType.EffectName1, headerStart)
        {
            name = string.Empty;
        }

        public static EffectNameHeader1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EffectNameHeader1(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
        }
    }

    public class EffectNameHeader2 : Header
    {
        public UInt16 index;
        public UInt16 iconID;
        public byte minDuration;
        public byte maxDuration;
        public UInt16 filler;
        public string name;

        public EffectNameHeader2(long headerStart) : base(HeaderType.EffectName2, headerStart)
        {
            name = string.Empty;
        }

        public static EffectNameHeader2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EffectNameHeader2(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.minDuration = stageFile.GetByte();
            header.maxDuration = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.Write(minDuration);
            stageFile.Write(maxDuration);
            stageFile.Write(filler);
            stageFile.WriteString(name);
        }
    }

    public class EffectNameHeader3 : Header
    {
        public UInt16 index;
        public UInt16 iconID;
        public byte minDuration;
        public byte maxDuration;
        public UInt16 filler;
        public string name;

        public EffectNameHeader3(long headerStart) : base(HeaderType.EffectName3, headerStart)
        {
            name = string.Empty;
        }

        public static EffectNameHeader3 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EffectNameHeader3(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.minDuration = stageFile.GetByte();
            header.maxDuration = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(iconID);
            stageFile.Write(minDuration);
            stageFile.Write(maxDuration);
            stageFile.Write(filler);
            stageFile.WriteString(name);
        }
    }

    public class UnknownHeader_84 : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_84(long headerStart) : base(HeaderType.Unknown_84, headerStart)
        {
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_84 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_84(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class RandomLootList_85 : Header
    {
        public UInt32 startOfData1;
        public UInt32 startOfData2;
        public UInt32 endOfData;
        public List<byte> randomLootList1;
        public List<byte> randomLootList2;

        public RandomLootList_85(long headerStart) : base(HeaderType.RandomLootList_85, headerStart)
        {
            randomLootList1 = new List<byte> { };
            randomLootList2 = new List<byte> { };
        }

        public static RandomLootList_85 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new RandomLootList_85(stageFile.Position());

            header.startOfData1 = stageFile.GetUInt32();
            header.startOfData2 = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.randomLootList1 = stageFile.GetByteListAtSection(header.startOfData1, header.startOfData2 - 1);
            header.randomLootList2 = stageFile.GetByteListAtSection(header.startOfData2, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData1);
            stageFile.Write(startOfData2);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData1 = (UInt32)stageFile.Position();

            foreach (var v in randomLootList1)
                stageFile.Write(v);

            stageFile.Write((byte)0);

            startOfData2 = (UInt32)stageFile.Position();

            foreach (var v in randomLootList2)
                stageFile.Write(v);

            while (stageFile.Position() % 4 != 0)
                stageFile.Write((byte)0);

            endOfData = (UInt32)stageFile.Position();

            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class RandomEffectHeader : Header
    {
        public byte effectType;
        public byte effectTypeIndex;
        public byte unknownByte1;
        public byte unknownByte2;
        public UInt32 effectStatustype;
        public UInt32 effectQuantity;
        public string effectName;

        public enum EffectType
        {
            GainGold = 0x80,
            LoseHP = 0x81,
            Status = 0x82,
            Warp = 0x83,
            Bankrupt = 0x84,
            LoseItem = 0x85,
            LoseMagic = 0x86,
            LoseGold = 0x87
        }

        public enum EffectStatusType
        {
            LoseItem = 0x01,
            LoseMagic = 0x02,
            RandomWarp = 0x06,
            Poison = 0x33,
            Footsore = 0x35,
            Sleep = 0x36,
            Afraid = 0x38,
            Seal = 0x39,
            ATDown = 0x40,
            DFDown = 0x41,
            MGDown = 0x42,
            SPDown = 0x43,
            AllDown = 0x44,
            Gold = 0x70,
            LoseHP = 0x71,
        }

        public RandomEffectHeader(long headerStart) : base(HeaderType.RandomEffect, headerStart)
        {
            effectName = string.Empty;
        }

        public static RandomEffectHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new RandomEffectHeader(stageFile.Position());

            header.effectType = stageFile.GetByte();
            header.effectTypeIndex = stageFile.GetByte();
            header.unknownByte1 = stageFile.GetByte();
            header.unknownByte2 = stageFile.GetByte();
            header.effectStatustype = stageFile.GetUInt32();
            header.effectQuantity = stageFile.GetUInt32();
            header.effectName = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(effectType);
            stageFile.Write(effectTypeIndex);
            stageFile.Write(unknownByte1);
            stageFile.Write(unknownByte2);
            stageFile.Write(effectStatustype);
            stageFile.Write(effectQuantity);
            stageFile.WriteString(effectName);
        }
    }

    public class SpaceNameHeader : Header
    {
        public UInt32 index;
        public string name;

        public SpaceNameHeader(long headerStart) : base(HeaderType.SpaceName, headerStart)
        {
            name = string.Empty;
        }

        public static SpaceNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new SpaceNameHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();
            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class SpaceDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public SpaceDescriptionHeader(long headerStart) : base(HeaderType.SpaceDescription, headerStart)
        {
            description = new List<string>();
        }

        public static SpaceDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new SpaceDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();
            stageFile.WriteStringList(description, 4);
            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class BagItemTypeNameHeader : Header
    {
        public UInt32 index;
        public string name;

        public BagItemTypeNameHeader(long headerStart) : base(HeaderType.BagItemTypeName, headerStart)
        {
            name = String.Empty;
        }

        public static BagItemTypeNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BagItemTypeNameHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class BattleMagicTypeNameHeader : Header
    {
        public UInt32 index;
        public string name;

        public BattleMagicTypeNameHeader(long headerStart) : base(HeaderType.BattleMagicTypeName, headerStart)
        {
            name = String.Empty;
        }

        public static BattleMagicTypeNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BattleMagicTypeNameHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class FieldMagicTypeNameHeader : Header
    {
        public UInt32 index;
        public string name;

        public FieldMagicTypeNameHeader(long headerStart) : base(HeaderType.FieldMagicTypeName, headerStart)
        {
            name = String.Empty;
        }

        public static FieldMagicTypeNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new FieldMagicTypeNameHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class UnknownHeader_8C : Header
    {
        public UInt32 endOfData;
        public List<UInt16> unknownUints;

        public UnknownHeader_8C(long headerStart) : base(HeaderType.Unknown_8C, headerStart)
        {
            unknownUints = new List<UInt16>();
        }

        public static UnknownHeader_8C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_8C(stageFile.Position());

            header.endOfData = stageFile.GetUInt32();
            while (stageFile.Position() < stageFile.fileOffset + header.endOfData)
                header.unknownUints.Add(stageFile.GetUInt16());

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(endOfData);
            
            foreach(var v in unknownUints)
                stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart + 4);
            stageFile.Write(endOfData);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_8E : Header
    {
        public UInt32 index;
        public UInt32 unknownUInt32;

        public UnknownHeader_8E(long headerStart) : base(HeaderType.Unknown_8E, headerStart)
        {
        }

        public static UnknownHeader_8E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_8E(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownUInt32);
        }
    }

    public class UnknownHeader_8F : Header
    {
        public UInt32 index;
        public UInt32 startOfData;
        public List<UInt16> unknownUints;

        public UnknownHeader_8F(long headerStart) : base(HeaderType.Unknown_8F, headerStart)
        {
            unknownUints = new List<UInt16>();
        }

        public static UnknownHeader_8F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_8F(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.startOfData = stageFile.GetUInt32();
            header.unknownUints = stageFile.GetUInt16ListAtPosition(header.startOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(startOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in unknownUints)
                stageFile.Write(v);

            var currentPosition = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_93 : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_93(long headerStart) : base(HeaderType.Unknown_93, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_93 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_93(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class RandomLootList_94 : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<byte> randomLootList;

        public RandomLootList_94(long headerStart) : base(HeaderType.RandomLootList_94, headerStart)
        {
            randomLootList = new List<byte> { };
        }

        public static RandomLootList_94 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new RandomLootList_94(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.randomLootList = stageFile.GetByteListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in randomLootList)
                stageFile.Write(v);

            while (stageFile.Position() % 4 != 0)
                stageFile.Write((byte)0);

            endOfData = (UInt32)stageFile.Position();

            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class HairstyleDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public HairstyleDescriptionHeader(long headerStart) : base(HeaderType.HairstyleDescription, headerStart)
        {
            description = new List<string>();
        }

        public static HairstyleDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new HairstyleDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class HairstyleHeader : Header
    {
        public byte index;
        public byte descriptionIndex;
        public UInt16 iconID;
        public string name;
        public byte unknownByte;
        public byte descriptionID;
        public byte[] unknownBytes;
        public byte hairTypeID; // 0x01 = default unlocked???

        public HairstyleHeader(long headerStart) : base(HeaderType.Hairstyle, headerStart)
        {
            name = string.Empty;
            unknownBytes = new byte[5];
        }

        public static HairstyleHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new HairstyleHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.descriptionIndex = stageFile.GetByte();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.unknownByte = stageFile.GetByte();
            header.descriptionID = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.hairTypeID = stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(descriptionIndex);
            stageFile.Write(iconID);
            stageFile.WriteString(name);
            stageFile.Write(unknownByte);
            stageFile.Write(descriptionID);
            stageFile.Write(unknownBytes);
            stageFile.Write(hairTypeID);
        }
    }

    public class UnknownHairstyleInfoHeader : Header
    {
        public UInt32 index;
        public string name;

        public UnknownHairstyleInfoHeader(long headerStart) : base(HeaderType.HairstyleUnknownInfo, headerStart)
        {
            name = String.Empty;
        }

        public static UnknownHairstyleInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHairstyleInfoHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();
            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class UnknownHeader_9A : Header
    {
        public byte firstIndex;
        public byte secondIndex;
        public byte[] unknownBytes;


        public UnknownHeader_9A(long headerStart) : base(HeaderType.Unknown_9A, headerStart)
        {
            unknownBytes = new byte[6];
        }

        public static UnknownHeader_9A ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9A(stageFile.Position());

            header.firstIndex = stageFile.GetByte();
            header.secondIndex = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(firstIndex);
            stageFile.Write(secondIndex);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_9B : Header
    {
        public byte index;
        public byte[] unknownBytes;


        public UnknownHeader_9B(long headerStart) : base(HeaderType.Unknown_9B, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_9B ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9B(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_9C : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;


        public UnknownHeader_9C(long headerStart) : base(HeaderType.Unknown_9C, headerStart)
        {
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_9C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9C(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_9D : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_9D(long headerStart) : base(HeaderType.Unknown_9D, headerStart)
        {
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_9D ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9D(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_9E : Header
    {

        public UInt32 endOfData;
        public UInt32 endOfHeader;
        public List<byte> unknownBytes;

        public UnknownHeader_9E(long headerStart) : base(HeaderType.Unknown_9E, headerStart)
        {
            unknownBytes = new List<byte> { };
        }

        public static UnknownHeader_9E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9E(stageFile.Position());

            header.endOfData = stageFile.GetUInt32();
            header.endOfHeader = stageFile.GetUInt32();

            while (stageFile.Position() < stageFile.fileOffset + header.endOfHeader)
                header.unknownBytes.Add(stageFile.GetByte());

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(endOfData);
            stageFile.Write(endOfHeader);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            foreach (var v in unknownBytes)
                stageFile.Write(v);

            endOfData = endOfData + (UInt32)stageFile.Position() - endOfHeader;
            endOfHeader = (UInt32)stageFile.Position();

            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfHeader);
        }
    }

    public class UnknownHeader_9F : Header
    {
        public UInt32 unknownUInt32;

        public UnknownHeader_9F(long headerStart) : base(HeaderType.Unknown_9F, headerStart)
        {
        }

        public static UnknownHeader_9F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9F(stageFile.Position());

            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUInt32);
        }
    }

    public class UnknownHeader_A0 : Header
    {
        public UInt32 unknownUInt32;

        public UnknownHeader_A0(long headerStart) : base(HeaderType.Unknown_A0, headerStart)
        {
        }

        public static UnknownHeader_A0 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A0(stageFile.Position());

            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUInt32);
        }
    }

    public class UnknownHeader_A1 : Header
    {
        public byte[] unknownBytes;

        public UnknownHeader_A1(long headerStart) : base(HeaderType.Unknown_A1, headerStart)
        {
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_A1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A1(stageFile.Position());

            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_A2 : Header
    {
        public byte[] unknownBytes;

        public UnknownHeader_A2(long headerStart) : base(HeaderType.Unknown_A2, headerStart)
        {
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_A2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A2(stageFile.Position());

            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_A3 : Header
    {
        public UInt32 unknownUInt32;

        public UnknownHeader_A3(long headerStart) : base(HeaderType.Unknown_A3, headerStart)
        {
        }

        public static UnknownHeader_A3 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A3(stageFile.Position());

            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUInt32);
        }
    }

    public class UnknownHeader_A4 : Header
    {
        public UInt32 unknownUInt32;

        public UnknownHeader_A4(long headerStart) : base(HeaderType.Unknown_A4, headerStart)
        {
        }

        public static UnknownHeader_A4 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A4(stageFile.Position());

            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUInt32);
        }
    }

    public class UnknownHeader_A5 : Header
    {
        public byte[] unknownBytes;

        public UnknownHeader_A5(long headerStart) : base(HeaderType.Unknown_A5, headerStart)
        {
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_A5 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A5(stageFile.Position());

            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownBytes);
        }
    }

    public class IGBListHeader : Header
    {
        public UInt32 index;
        public UInt32 startOfData;
        public byte[] IGBUnknownHeader;
        public List<FileNameHeader> IGBFiles;

        public IGBListHeader(long headerStart) : base(HeaderType.IGBFileList, headerStart)
        {
            IGBUnknownHeader = new byte[32];
            IGBFiles = new List<FileNameHeader>();
        }

        public static IGBListHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new IGBListHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.startOfData = stageFile.GetUInt32();

            var nextHeader = stageFile.Position();
            if (stageFile.PositionAlreadyRead(header.startOfData))
                return header;

            stageFile.SetPosition(header.startOfData);

            stageFile.Read(ref header.IGBUnknownHeader);

            while (stageFile.GetUInt32() == 0x01)
            {
                FileNameHeader fileName = FileNameHeader.ReadHeaderBlock(stageFile);
                header.IGBFiles.Add(fileName);
            }

            int fileHeaderCount = header.IGBFiles.Count();
            for (int i = 0; i < fileHeaderCount - 1; i++)
            {
                stageFile.GetUInt32();
                FileNameHeader fileName = FileNameHeader.ReadHeaderBlock(stageFile);
                header.IGBFiles.Add(fileName);
                stageFile.GetUInt32();
                stageFile.GetUInt32();
            }

            stageFile.GetUInt32();
            stageFile.SetPosition(nextHeader);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(startOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            if (IGBFiles.Count == 0)
                return;

            startOfData = (UInt32)stageFile.Position();

            stageFile.Write(IGBUnknownHeader);

            foreach (var file in IGBFiles)
            {
                if (file.index == 0 && file.fileName == "\0\0\0\0")
                    stageFile.Write((UInt32)0);

                file.WriteHeaderBlock(stageFile);
            }

            stageFile.Write((UInt32)0);

            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }

        public void WriteEndBlockAddresses(DokaponFileWriter stageFile)
        {
            if (IGBFiles.Count != 0)
                return;

            startOfData = (UInt32)stageFile.Position();

            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(startOfData);
        }

        public void WriteEndBlockHeader(DokaponFileWriter stageFile)
        {
            stageFile.Write(IGBUnknownHeader);
        }
    }

    public class UnknownHeader_AD : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<UInt32> unknownPointers;
        public List<byte> unknownBytes;

        public UnknownHeader_AD(long headerStart) : base(HeaderType.Unknown_AD, headerStart)
        {
            unknownPointers = new List<UInt32>();
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_AD ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_AD(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.unknownPointers = stageFile.GetUInt32List();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);

            foreach(var v in unknownPointers)
                stageFile.Write(v);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in unknownBytes)
                stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_AE : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<byte> unknownBytes;

        public UnknownHeader_AE(long headerStart) : base(HeaderType.Unknown_AE, headerStart)
        {
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_AE ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_AE(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in unknownBytes)
                stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_AF : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<byte> unknownBytes;

        public UnknownHeader_AF(long headerStart) : base(HeaderType.Unknown_AF, headerStart)
        {
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_AF ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_AF(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in unknownBytes)
                stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_B0 : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_B0(long headerStart) : base(HeaderType.Unknown_B0, headerStart)
        {
            unknownBytes = new byte[16];
        }

        public static UnknownHeader_B0 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B0(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_B1 : Header
    {
        public UInt32 index;
        public UInt32 unknownUInt32;

        public UnknownHeader_B1(long headerStart) : base(HeaderType.Unknown_B1, headerStart)
        {
        }

        public static UnknownHeader_B1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B1(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownUInt32);
        }
    }

    public class UnknownHeader_B2 : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_B2(long headerStart) : base(HeaderType.Unknown_B2, headerStart)
        {
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_B2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B2(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_B3 : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_B3(long headerStart) : base(HeaderType.Unknown_B3, headerStart)
        {
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_B3 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B3(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_B4 : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_B4(long headerStart) : base(HeaderType.Unknown_B4, headerStart)
        {
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_B4 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B4(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_B5 : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_B5(long headerStart) : base(HeaderType.Unknown_B5, headerStart)
        {
            unknownBytes = new byte[28];
        }

        public static UnknownHeader_B5 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B5(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_B6 : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_B6(long headerStart) : base(HeaderType.Unknown_B6, headerStart)
        {
            unknownBytes = new byte[28];
        }

        public static UnknownHeader_B6 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B6(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class HitFormulaHeader : Header
    {
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public HitFormulaHeader(long headerStart) : base(HeaderType.HitFormula, headerStart)
        {
            formula = String.Empty;
        }

        public static HitFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new HitFormulaHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(formula);
            stageFile.Write(unknownUint32);
        }
    }

    public class AttackFormulaHeader : Header
    {
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public AttackFormulaHeader(long headerStart) : base(HeaderType.AttackFormula, headerStart)
        {
            formula = String.Empty;
        }

        public static AttackFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new AttackFormulaHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(formula);
            stageFile.Write(unknownUint32);
        }
    }

    public class MagicFormulaHeader : Header
    {
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public MagicFormulaHeader(long headerStart) : base(HeaderType.MagicFormula, headerStart)
        {
            formula = String.Empty;
        }

        public static MagicFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MagicFormulaHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(formula);
            stageFile.Write(unknownUint32);
        }
    }

    public class StrikeFormulaHeader : Header
    {
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public StrikeFormulaHeader(long headerStart) : base(HeaderType.StrikeFormula, headerStart)
        {
            formula = String.Empty;
        }

        public static StrikeFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new StrikeFormulaHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(formula);
            stageFile.Write(unknownUint32);
        }
    }

    public class CounterFormulaHeader : Header
    {
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public CounterFormulaHeader(long headerStart) : base(HeaderType.CounterFormula, headerStart)
        {
            formula = String.Empty;
        }

        public static CounterFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new CounterFormulaHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(formula);
            stageFile.Write(unknownUint32);
        }
    }

    public class SelfAttackFormulaHeader : Header
    {
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public SelfAttackFormulaHeader(long headerStart) : base(HeaderType.SelfAttackFormula, headerStart)
        {
            formula = String.Empty;
        }

        public static SelfAttackFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new SelfAttackFormulaHeader(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(formula);
            stageFile.Write(unknownUint32);
        }
    }

    public class UnknownHeader_BD : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_BD(long headerStart) : base(HeaderType.Unknown_BD, headerStart)
        {
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_BD ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_BD(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_BE : Header
    {
        public UInt32 index;
        public UInt32 unknownUInt32;

        public UnknownHeader_BE(long headerStart) : base(HeaderType.Unknown_BE, headerStart)
        {
        }

        public static UnknownHeader_BE ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_BE(stageFile.Position());

            header.index = stageFile.GetUInt32();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownUInt32);
        }
    }

    public class PrankNameHeader : Header
    {
        public UInt32 index;
        public string name;

        public PrankNameHeader(long headerStart) : base(HeaderType.PrankName, headerStart)
        {
            name = String.Empty;
        }

        public static PrankNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new PrankNameHeader(stageFile.Position());
            byte[] wordBuffer = new byte[4];

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.WriteString(name);
        }
    }

    public class InstuctionListHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<UInt32> dataPointers;
        public List<string> instructions;

        public InstuctionListHeader(long headerStart) : base(HeaderType.InstructionsList, headerStart)
        {
            dataPointers = new List<UInt32>();
            instructions = new List<string>();
        }

        public static InstuctionListHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new InstuctionListHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.dataPointers = stageFile.GetUInt32ListAtPosition(header.startOfData);
            header.instructions = stageFile.GetStringListAtSection(header.startOfData + (uint)header.dataPointers.Count * 4, header.endOfData, 4, true);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockPointers(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position();

            foreach(var v in dataPointers)
                stageFile.Write(v);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            WriteBlockPointers(stageFile);

            for (int i = 0; i < instructions.Count; i++)
            {
                dataPointers[i] = (UInt32)stageFile.Position();
                stageFile.WriteString(instructions[i]);
            }

            endOfData = (UInt32)stageFile.Position();
            stageFile.SetPosition(startOfData);
            WriteBlockPointers(stageFile);
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(endOfData);
        }
    }

    public class UnknownHeader_D0 : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_D0(long headerStart) : base(HeaderType.Unknown_D0, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_D0 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D0(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_D1 : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_D1(long headerStart) : base(HeaderType.Unknown_D1, headerStart)
        {
            unknownBytes = new byte[7];
        }

        public static UnknownHeader_D1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D1(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_D2 : Header
    {
        public UInt32 index;

        public UnknownHeader_D2(long headerStart) : base(HeaderType.Unknown_D2, headerStart)
        {
        }

        public static UnknownHeader_D2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D2(stageFile.Position());

            header.index = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
        }
    }

    public class UnknownHeader_D3 : Header
    {
        public UInt32 index;

        public UnknownHeader_D3(long headerStart) : base(HeaderType.Unknown_D3, headerStart)
        {
        }

        public static UnknownHeader_D3 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D3(stageFile.Position());

            header.index = stageFile.GetUInt32();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
        }
    }

    public class UnknownHeader_D4 : Header
    {
        public UInt32 unknownUInt32;
        public UInt32 endOfData;
        public List<byte> unknownBytes;

        public UnknownHeader_D4(long headerStart) : base(HeaderType.Unknown_D4, headerStart)
        {
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_D4 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D4(stageFile.Position());

            header.unknownUInt32 = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();

            while (stageFile.Position() < stageFile.fileOffset + header.endOfData)
                header.unknownBytes.Add(stageFile.GetByte());

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUInt32);
            stageFile.Write(endOfData);

            foreach(var v in unknownBytes)
                stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart + 8);
            stageFile.Write(endOfData);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class JobRequirementHeader : Header
    {
        public Int32 jobIndex;
        public byte itemRequiredIndex;
        public byte[] jobRequirementIndexes;

        public JobRequirementHeader(long headerStart) : base(HeaderType.JobRequirement, headerStart)
        {
            jobRequirementIndexes = new byte[7];
        }

        public static JobRequirementHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobRequirementHeader(stageFile.Position());

            header.jobIndex = stageFile.GetInt32();
            header.itemRequiredIndex = stageFile.GetByte();
            stageFile.Read(ref header.jobRequirementIndexes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(jobIndex);
            stageFile.Write(itemRequiredIndex);

            foreach(var v in jobRequirementIndexes)
                stageFile.Write(v);
        }
    }

    public class UnknownHeader_D5 : Header
    {
        public UInt32 unknownUInt32;
        public UInt32 endOfData;
        public List<byte> unknownBytes;

        public UnknownHeader_D5(long headerStart) : base(HeaderType.Unknown_D5, headerStart)
        {
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_D5 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D5(stageFile.Position());

            header.unknownUInt32 = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32() ;

            while (stageFile.Position() < stageFile.fileOffset + header.endOfData)
                header.unknownBytes.Add(stageFile.GetByte());

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUInt32);
            stageFile.Write(endOfData);

            foreach(var v in unknownBytes)
                stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart + 8);
            stageFile.Write(endOfData);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_D7 : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_D7(long headerStart) : base(HeaderType.Unknown_D7, headerStart)
        {
            unknownBytes = new byte[7];
        }

        public static UnknownHeader_D7 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D7(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class DarkArtDescriptionHeader : Header
    {
        public UInt32 startOfData;
        public UInt32 endOfData;
        public List<string> description;

        public DarkArtDescriptionHeader(long headerStart) : base(HeaderType.DarkArtDescription, headerStart)
        {
            description = new List<string>();
        }

        public static DarkArtDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DarkArtDescriptionHeader(stageFile.Position());

            header.startOfData = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.startOfData, header.endOfData);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(startOfData);
            stageFile.Write(endOfData);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            startOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;

            foreach (var v in description)
                stageFile.WriteString(v);

            endOfData = (UInt32)stageFile.Position() - stageFile.fileOffset;
            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class DarkArtHeader : Header
    {
        public byte index;
        public byte unknownByte;
        public UInt16 pointCost;
        public string name;

        public DarkArtHeader(long headerStart) : base(HeaderType.DarkArt, headerStart)
        {
            name = string.Empty;
        }

        public static DarkArtHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DarkArtHeader(stageFile.Position());

            header.index = stageFile.GetByte();
            header.unknownByte = stageFile.GetByte();
            header.pointCost = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownByte);
            stageFile.Write(pointCost);
            stageFile.WriteString(name);
        }
    }

    public class UnknownHeader_DB : Header
    {
        public UInt32 unknownUint;
        public UInt32 endOfData;
        public UInt32 endOfDataBlock;
        public List<UInt16[]> unknownList;

        public UnknownHeader_DB(long headerStart) : base(HeaderType.Unknown_DB, headerStart)
        {
            unknownList = new List<UInt16[]>();
        }

        public static UnknownHeader_DB ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_DB(stageFile.Position());

            header.unknownUint = stageFile.GetUInt32();
            header.endOfData = stageFile.GetUInt32();
            header.endOfDataBlock = stageFile.GetUInt32();

            while (stageFile.Position() < header.endOfData)
            {
                UInt16[] unknownShorts = new UInt16[8];

                for (int i = 0; i < 8; i++)
                    unknownShorts[i] = stageFile.GetUInt16();

                header.unknownList.Add(unknownShorts);
            }

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(unknownUint);
            stageFile.Write(endOfData);
            stageFile.Write(endOfDataBlock);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            foreach(var list in unknownList)
                foreach (var v in list)
                    stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position();

            while(stageFile.Position() % 4 != 0)
                stageFile.Write((byte)0);

            endOfDataBlock = (UInt32)stageFile.Position();

            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_DA : Header
    {
        public UInt16 index;
        public UInt16 unknownShort;

        public UnknownHeader_DA(long headerStart) : base(HeaderType.Unknown_DA, headerStart)
        {
        }

        public static UnknownHeader_DA ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_DA(stageFile.Position());

            header.index = stageFile.GetUInt16();
            header.unknownShort = stageFile.GetUInt16();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownShort);
        }
    }

    public class UnknownHeader_DF : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_DF(long headerStart) : base(HeaderType.Unknown_DF, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_DF ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_DF(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_E0 : Header
    {
        public UInt32 endOfData;
        public UInt32 endOfDataBlock;
        public List<byte> unknownList;

        public UnknownHeader_E0(long headerStart) : base(HeaderType.Unknown_E0, headerStart)
        {
            unknownList = new List<byte>();
        }

        public static UnknownHeader_E0 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_E0(stageFile.Position());

            header.endOfData = stageFile.GetUInt32();
            header.endOfDataBlock = stageFile.GetUInt32();

            while (stageFile.Position() < header.endOfData)
                header.unknownList.Add(stageFile.GetByte());

            while (stageFile.Position() < header.endOfDataBlock)
                stageFile.GetByte();

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(endOfData);
            stageFile.Write(endOfDataBlock);
        }

        public void WriteBlockData(DokaponFileWriter stageFile)
        {
            foreach (var v in unknownList)
                    stageFile.Write(v);

            endOfData = (UInt32)stageFile.Position();

            while (stageFile.Position() % 4 != 0)
                stageFile.Write((byte)0);

            endOfDataBlock = (UInt32)stageFile.Position();

            var currentPosition = stageFile.Position();
            stageFile.SetPosition(headerStart);
            WriteHeaderBlock(stageFile);
            stageFile.SetPosition(currentPosition);
        }
    }

    public class UnknownHeader_E1 : Header
    {
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_E1(long headerStart) : base(HeaderType.Unknown_E1, headerStart)
        {
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_E1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_E1(stageFile.Position());

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }

    public class UnknownHeader_E2 : Header
    {
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_E2(long headerStart) : base(HeaderType.Unknown_E2, headerStart)
        {
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_E2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_E2(stageFile.Position());

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }

        public new void WriteHeaderBlock(DokaponFileWriter stageFile)
        {
            base.WriteHeaderBlock(stageFile);
            stageFile.Write(index);
            stageFile.Write(unknownBytes);
        }
    }
}
