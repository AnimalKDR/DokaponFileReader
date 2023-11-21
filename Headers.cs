using System.IO;
using System.Text;

namespace DokaponFileReader
{
    public class DokaponFileReader
    {
        public FileStream fileStream;
        public bool[] byteRead;
        public UInt32 fileOffset;

        public DokaponFileReader(string path)
        {
            fileStream = File.Open(path, FileMode.Open);
            byteRead = new bool[fileStream.Length];
            fileOffset = 0;
        }

        public int Read(ref byte[] buffer, bool reread = false)
        {
            while (!reread && fileStream.Position < fileStream.Length && byteRead[fileStream.Position] == true)
                fileStream.Position++;

            if (fileStream.Position >= fileStream.Length)
                return 0;

            var currentPosition = fileStream.Position;
            var result = fileStream.Read(buffer);

            for (int i = 0; i < buffer.Length; i++)
                byteRead[currentPosition + i] = true;

            return result;
        }

        public byte GetByte(bool reread = false)
        {
            byte[] buffer = new byte[1];
            Read(ref buffer, reread);

            return buffer[0];
        }

        public UInt16 GetUInt16(bool reread = false)
        {
            byte[] buffer = new byte[2];
            Read(ref buffer, reread);

            return BitConverter.ToUInt16(buffer);
        }

        public Int16 GetInt16(bool reread = false)
        {
            byte[] buffer = new byte[2];
            Read(ref buffer, reread);

            return BitConverter.ToInt16(buffer);
        }

        public UInt32 GetUInt32(bool reread = false)
        {
            byte[] buffer = new byte[4];
            Read(ref buffer, reread);

            return BitConverter.ToUInt32(buffer);
        }

        public Int32 GetInt32(bool reread = false)
        {
            byte[] buffer = new byte[4];
            Read(ref buffer, reread);

            return BitConverter.ToInt32(buffer);
        }

        public string GetString(int bytesToRead = 4, bool reread = false)
        {
            byte[] buffer = new byte[bytesToRead];
            string result = String.Empty;

            do
            {
                Read(ref buffer, reread);
                result += Encoding.ASCII.GetString(buffer);
            } while (!buffer.ToList().Contains(0));

            return result;
        }
        public string GetStringAtPosition(UInt32 position, int bytesToRead = 4, bool reread = false)
        {
            var currentPosition = Position();

            SetPosition(position + fileOffset);
            string result = GetString(bytesToRead, reread);
            SetPosition(currentPosition);

            return result;
        }

        public List<string> GetStringListAtPosition(UInt32 position, int bytesToRead = 4, bool reread = false)
        {
            List<string> result = new List<string>();
            byte[] buffer = new byte[bytesToRead];

            var currentPosition = Position();
            SetPosition(position + fileOffset);
            do
            {
                result.Add(GetString(2, reread));
            } while (result.Last().Length > bytesToRead);

            while (Position() % 4 != 0)
                Read(ref buffer, reread);

            SetPosition(currentPosition);

            return result;
        }

        public List<string> GetStringListAtSection(UInt32 setctionStart, UInt32 sectionEnd, int bytesToRead = 4, bool reread = false)
        {
            List<string> result = new List<string>();

            var currentPosition = Position();
            SetPosition(setctionStart + fileOffset);

            while (Position() < sectionEnd + fileOffset)
                result.Add(GetString(bytesToRead, reread));

            SetPosition(currentPosition);

            return result;
        }

        public List<byte> GetByteList(bool reread = false)
        {
            List<byte> result = new List<byte>();

            do
            {
                result.Add(GetByte(reread));
            } while (result.Last() != 0xFF);

            while (Position() % 4 != 0)
                GetByte(reread);

            return result;
        }

        public List<byte> GetByteListWithTokenCount(UInt32 position, byte endToken, int tokenCount, bool reread = false)
        {
            List<byte> result = new List<byte>();
            int count = 0;
            var currentPosition = Position();
            SetPosition(position + fileOffset);

            do
            {
                result.Add(GetByte(reread));

                if (result.Last() == endToken)
                    count++;

            } while (count < tokenCount);

            while (Position() % 4 != 0)
                GetByte();

            SetPosition(currentPosition);

            return result;
        }

        public List<byte> GetByteListAtPosition(UInt32 position, bool reread = false)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);

            List<byte> result = GetByteList(reread);

            SetPosition(currentPosition);

            return result;
        }

        public List<byte> GetByteListAtSection(UInt32 setctionStart, UInt32 sectionEnd, bool reread = false)
        {
            List<byte> result = new List<byte>();

            var currentPosition = Position();
            SetPosition(setctionStart + fileOffset);

            while (Position() < sectionEnd + fileOffset)
                result.Add(GetByte(reread));

            while (Position() % 4 != 0)
                GetByte(reread);

            SetPosition(currentPosition);

            return result;
        }

        public List<UInt16> GetUInt16List( bool reread = false)
        {
            List<UInt16> result = new List<UInt16>();

            do
            {
                result.Add(GetUInt16(reread));
            } while (((byte)result.Last()) != 0xFF);

            while (Position() % 4 != 0)
                result.Add(GetUInt16(reread));

            return result;
        }

        public List<UInt16> GetUInt16ListAtPosition(UInt32 position, bool reread = false)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);

            List<UInt16> result = GetUInt16List(reread);

            SetPosition(currentPosition);

            return result;
        }

        public List<UInt32> GetUInt32List(bool reread = false)
        {
            List<UInt32> result = new List<UInt32>();

            do
            {
                result.Add(GetUInt32(reread));
            } while (result.Last() != 0);

            return result;
        }

        public List<UInt32> GetUInt32ListAtPosition(UInt32 position, bool reread = false)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);

            List<UInt32> result = GetUInt32List(reread);

            SetPosition(currentPosition);

            return result;
        }

        public void Close()
        {
            fileStream.Close();
        }

        public long Position()
        {
            return fileStream.Position;
        }

        public void SetPosition(long position)
        {
            fileStream.Position = position;
        }

        public bool PositionAlreadyRead(long position)
        {
            if (position < 0 || position > byteRead.Length)
                return true;

            return byteRead[position];
        }
    }
    
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
        Unknown_85 = 0x85,
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
        Unknown_94 = 0x94,
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
        RoyalRing= 0x27,
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
        Poison        = 0x0200,
        Curse         = 0x0204,
        Asleep        = 0x0300,
        SealOM        = 0x0301,
        SealOMDM      = 0x0302,
        Stun          = 0x0305,
        SealATCT      = 0x0306,
        Blind         = 0x0309,
        AttackDown50  = 0x030F,
        DefenseDown50 = 0x0310,
        MagicDown50   = 0x0311,
        SpeedDown50   = 0x0312,
        AllDown50     = 0x0313,
        AttackDown25  = 0x0315,
        DefenseDown25 = 0x0316,
        MagicDown25   = 0x0317,
        SpeedDown25   = 0x0318,
        AttackUp      = 0x0319,
        DefenseUp     = 0x031A,
        MagicUp       = 0x031B,
        SpeedUp       = 0x031C,
        AllUp         = 0x031D,
        Footsore      = 0x0405,
        Paralyze      = 0x0406,
        Afraid        = 0x0407,
        SealBag       = 0x0408,
        Doom          = 0x040A
    }

    public enum ItemType
    {
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

    public class FileNameHeader
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 unknownUint16;
        public string fileName;

        public FileNameHeader()
        {
            headerType = (UInt32)HeaderType.FileName;
            fileName = string.Empty;
        }

        public static FileNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new FileNameHeader();

            header.index = stageFile.GetUInt16();
            header.unknownUint16 = stageFile.GetUInt16();
            header.fileName = stageFile.GetString();

            return header;
        }
    }

    public class UnknownHeader_03
    {
        public UInt32 headerType;
        public UInt32 unknownPointer;
        public UInt32 unknownUint;

        public UnknownHeader_03()
        {
            headerType = (UInt32)HeaderType.Unknown_03;
        }

        public static UnknownHeader_03 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_03();

            header.unknownPointer = stageFile.GetUInt32();
            header.unknownUint = stageFile.GetUInt32();

            return header;
        }
    }

    public class StageFileHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 fileOffset;
        public string fileName;

        public StageFileHeader()
        {
            headerType = (UInt32)HeaderType.StageFile;
            fileName = string.Empty;
        }

        public static StageFileHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new StageFileHeader();

            header.index = stageFile.GetUInt32();
            header.fileOffset = stageFile.GetUInt32();
            header.fileName = stageFile.GetStringAtPosition(header.fileOffset, 4, true);

            return header;
        }
    }

    public class EndOfFileHeader
    {
        public UInt32 headerType;

        public EndOfFileHeader()
        {
            headerType = (UInt32)HeaderType.EndOfFile;
        }

        public static EndOfFileHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EndOfFileHeader();
            return header;
        }
    }

    public class UnknownHeader_17
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_17()
        {
            headerType = (UInt32)HeaderType.Unknown_17;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_17 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_17();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_1C
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_1C()
        {
            headerType = (UInt32)HeaderType.Unknown_1C;
            unknownBytes = new byte[4];
        }

        public static UnknownHeader_1C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_1C();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_1D
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_1D()
        {
            headerType = (UInt32)HeaderType.Unknown_1D;
            unknownBytes = new byte[4];
        }

        public static UnknownHeader_1D ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_1D();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_1E
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_1E()
        {
            headerType = (UInt32)HeaderType.Unknown_1E;
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_1E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_1E();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class JobFileHeader2
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public UInt16 filler;
        public string[] jobFiles;


        public JobFileHeader2()
        {
            headerType = (UInt32)HeaderType.JobFile2;
            jobFiles = new string[4];
        }

        public static JobFileHeader2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobFileHeader2();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();

            for (int i = 0; i < header.jobFiles.Length; i++)
                header.jobFiles[i] = stageFile.GetString();

            return header;
        }
    }

    public class TextureFileNameHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;
        public string name;


        public TextureFileNameHeader()
        {
            headerType = (UInt32)HeaderType.TextureFileName;
            unknownBytes = new byte[3];
            name = String.Empty;
        }

        public static TextureFileNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new TextureFileNameHeader();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class UnknownHeader_2B
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 unknownShort1;
        public UInt16 unknownShort2;
        public UInt16 unknownShort3;

        public UnknownHeader_2B()
        {
            headerType = (UInt32)HeaderType.Unknown_2B;
        }

        public static UnknownHeader_2B ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_2B();

            header.index = stageFile.GetUInt16();
            header.unknownShort1 = stageFile.GetUInt16();
            header.unknownShort2 = stageFile.GetUInt16();
            header.unknownShort3 = stageFile.GetUInt16();

            return header;
        }
    }

    public class UnknownHeader_2C
    {
        public UInt32 headerType;
        public UInt32 unknownUint;

        public UnknownHeader_2C()
        {
            headerType = (UInt32)HeaderType.Unknown_2C;
        }

        public static UnknownHeader_2C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_2C();

            header.unknownUint = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_2D
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_2D()
        {
            headerType = (UInt32)HeaderType.Unknown_2D;
            unknownBytes = new byte[16];
        }

        public static UnknownHeader_2D ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_2D();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class JobSalaryHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public byte bonusRequirementCount;
        public byte classIndex;
        public UInt32 startingSalary;
        public UInt16 salaryMultiplier; // times 100
        public UInt16 bonusMultiplier; // times 100

        public JobSalaryHeader()
        {
            headerType = (UInt32)HeaderType.JobSalary;
        }

        public static JobSalaryHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobSalaryHeader();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.bonusRequirementCount = stageFile.GetByte();
            header.classIndex = stageFile.GetByte();
            header.startingSalary = stageFile.GetUInt32();
            header.salaryMultiplier = stageFile.GetUInt16();
            header.bonusMultiplier = stageFile.GetUInt16();

            return header;
        }
    }

    public class UnknownHeader_2F
    {
        public UInt32 headerType;
        public byte unknownByte1;
        public byte unknownByte2;
        public byte unknownByte3;
        public byte unknownByte4;

        public UnknownHeader_2F()
        {
            headerType = (UInt32)HeaderType.Unknown_2F;
        }

        public static UnknownHeader_2F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_2F();

            header.unknownByte1 = stageFile.GetByte();
            header.unknownByte2 = stageFile.GetByte();
            header.unknownByte3 = stageFile.GetByte();
            header.unknownByte4 = stageFile.GetByte();

            return header;
        }
    }

    public class LocationHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public LocationHeader()
        {
            headerType = (UInt32)HeaderType.Location;
            name = string.Empty;
        }

        public static LocationHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new LocationHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class UnknownHeader_38
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_38()
        {
            headerType = (UInt32)HeaderType.Unknown_38;
            unknownBytes = new byte[7];
        }

        public static UnknownHeader_38 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_38();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_39
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 startOfList;
        public List<UInt16> unknownList;

        public UnknownHeader_39()
        {
            headerType = (byte)HeaderType.Unknown_39;
            unknownList = new List<UInt16>();
        }

        public static UnknownHeader_39 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_39();

            header.index = stageFile.GetUInt32();
            header.startOfList = stageFile.GetUInt32();
            header.unknownList = stageFile.GetUInt16ListAtPosition(header.startOfList);

            return header;
        }
    }

    public class CPUNamesHeader
    {
        public UInt32 headerType;
        public UInt32 sex;
        public UInt32 nameStart;
        public List<string> names;

        public CPUNamesHeader()
        {
            headerType = (byte)HeaderType.CPUNames;
            names = new List<string>();
        }

        public static CPUNamesHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new CPUNamesHeader();

            header.sex = stageFile.GetUInt32();
            header.nameStart = stageFile.GetUInt32();
            header.names = stageFile.GetStringListAtPosition(header.nameStart, 2);

            return header;
        }
    }

    public class JobLevelAndMasteryHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public UInt16 attackLevelUp;
        public UInt16 defenseLevelUp;
        public UInt16 magicLevelUp;
        public UInt16 speedLevelUp;
        public UInt16 hpLevelUp;
        public UInt16 attackMastery;
        public UInt16 defenseMastery;
        public UInt16 magicMastery;
        public UInt16 speedMastery;
        public UInt16 hpMastery;
        public UInt16 filler;

        public JobLevelAndMasteryHeader()
        {
            headerType = (UInt32)HeaderType.JobLevelAndMastery;
        }

        public static JobLevelAndMasteryHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobLevelAndMasteryHeader();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.attackLevelUp = stageFile.GetUInt16();
            header.defenseLevelUp = stageFile.GetUInt16();
            header.magicLevelUp = stageFile.GetUInt16();
            header.speedLevelUp = stageFile.GetUInt16();
            header.hpLevelUp = stageFile.GetUInt16();
            header.attackMastery = stageFile.GetUInt16();
            header.defenseMastery = stageFile.GetUInt16();
            header.magicMastery = stageFile.GetUInt16();
            header.speedMastery = stageFile.GetUInt16();
            header.hpMastery = stageFile.GetUInt16();
            header.filler = stageFile.GetUInt16();

            return header;
        }
    }

    public class JobBattleSkillHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public byte jobIndex;
        public byte firstBattleSkillIndex;
        public byte secondBattleSkillIndex;
        public byte[] unknownBytes;

        public JobBattleSkillHeader()
        {
            headerType = (UInt32)HeaderType.JobBattleSkill;
            unknownBytes = new byte[3];
        }

        public static JobBattleSkillHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobBattleSkillHeader();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.jobIndex = stageFile.GetByte();
            header.firstBattleSkillIndex = stageFile.GetByte();
            header.secondBattleSkillIndex = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class JobDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public JobDescriptionHeader()
        {
            headerType = (byte)HeaderType.JobDescription;
            description = new List<string>();
        }

        public static JobDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class UnknownHeader_3F
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_3F()
        {
            headerType = (UInt32)HeaderType.Unknown_3F;
            unknownBytes = new byte[4];
        }

        public static UnknownHeader_3F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_3F();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class JobLevelUpRequirementHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public UInt16 battlesToLevel;

        public JobLevelUpRequirementHeader()
        {
            headerType = (UInt32)HeaderType.JobLevelUpRequirement;
        }

        public static JobLevelUpRequirementHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobLevelUpRequirementHeader();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.battlesToLevel = stageFile.GetUInt16();

            return header;
        }
    }

    public class JobStartingStatsHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public UInt16 attack;
        public UInt16 defense;
        public UInt16 magic;
        public UInt16 speed;
        public UInt16 hp;

        public JobStartingStatsHeader()
        {
            headerType = (UInt32)HeaderType.JobStartingStats;
        }

        public static JobStartingStatsHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobStartingStatsHeader();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.attack = stageFile.GetUInt16();
            header.defense = stageFile.GetUInt16();
            header.magic = stageFile.GetUInt16();
            header.speed = stageFile.GetUInt16();
            header.hp = stageFile.GetUInt16();

            return header;
        }
    }

    public class JobUnknownInfoHeader1
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public UInt16 unknownUInt16;
        public string name;
        public UInt32 filler;

        public JobUnknownInfoHeader1()
        {
            headerType = (UInt32)HeaderType.JobUnknownInfo1;
            name = string.Empty;
        }

        public static JobUnknownInfoHeader1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobUnknownInfoHeader1();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.unknownUInt16 = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.filler = stageFile.GetUInt32();

            return header;
        }
    }

    public class JobUnknownInfoHeader2
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public byte[] unknownBytes;

        public JobUnknownInfoHeader2()
        {
            headerType = (UInt32)HeaderType.JobUnknownInfo2;
            unknownBytes = new byte[6];
        }

        public static JobUnknownInfoHeader2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobUnknownInfoHeader2();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class JobItemSpacesHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public byte bagItemSpace;
        public byte fieldMagicSpace;

        public JobItemSpacesHeader()
        {
            headerType = (UInt32)HeaderType.JobItemSpace;
        }

        public static JobItemSpacesHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobItemSpacesHeader();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.bagItemSpace = stageFile.GetByte();
            header.fieldMagicSpace = stageFile.GetByte();

            return header;
        }
    }

    public class JobFileHeader1
    {
        public UInt32 headerType;
        public byte index;
        public byte sex;
        public UInt16 filler;
        public string[] jobFiles;


        public JobFileHeader1()
        {
            headerType = (UInt32)HeaderType.JobFile1;
            jobFiles = new string[6];
        }

        public static JobFileHeader1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobFileHeader1();

            header.index = stageFile.GetByte();
            header.sex = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();

            for (int i = 0; i < header.jobFiles.Length; i++)
                header.jobFiles[i] = stageFile.GetString();

            return header;
        }
    }

    public class UnknownHeader_46
    {
        public UInt32 headerType;
        public UInt16 index;
        public byte[] unknownBytes;

        public UnknownHeader_46()
        {
            headerType = (UInt32)HeaderType.Unknown_46;
            unknownBytes = new byte[6];
        }

        public static UnknownHeader_46 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_46();

            header.index = stageFile.GetUInt16();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_47
    {
        public UInt32 headerType;
        public UInt32 unknownuint32;

        public UnknownHeader_47()
        {
            headerType = (byte)HeaderType.Unknown_47;
        }

        public static UnknownHeader_47 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_47();

            header.unknownuint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_48
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 unknownUint32;

        public UnknownHeader_48()
        {
            headerType = (UInt32)HeaderType.Unknown_48;
        }

        public static UnknownHeader_48 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_48();

            header.index = stageFile.GetUInt32();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_49
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 unknownUint32;


        public UnknownHeader_49()
        {
            headerType = (byte)HeaderType.Unknown_49;
        }

        public static UnknownHeader_49 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_49();

            header.index = stageFile.GetUInt32();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class DialogPointerListHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public List<UInt32> pointer;
        public List<string> dialog;

        public DialogPointerListHeader()
        {
            headerType = (byte)HeaderType.DialogPointerList;
            pointer = new List<UInt32>();
            dialog = new List<string>();
        }

        public static DialogPointerListHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DialogPointerListHeader();

            header.index = stageFile.GetUInt32();
            header.pointer = stageFile.GetUInt32List();

            foreach(var pointer in header.pointer)
            {
                if (pointer == 0)
                    continue;

                header.dialog.Add(stageFile.GetStringAtPosition(pointer, 4, true));
            }

            return header;
        }
    }

    public class DialogListHeader
    {
        public UInt32 headerType;
        public UInt32 dialogStart;
        public UInt32 dialogEnd;
        public List<string> dialog;

        public DialogListHeader()
        {
            headerType = (byte)HeaderType.DialogList;
            dialog = new List<string>();
        }

        public static DialogListHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DialogListHeader();

            header.dialogStart = stageFile.GetUInt32();
            header.dialogEnd = stageFile.GetUInt32();
            header.dialog = stageFile.GetStringListAtSection(header.dialogStart, header.dialogEnd, 4, true);

            return header;
        }
    }

    public class UnknownHeader_4C
    {
        public UInt32 headerType;
        public UInt16 index;
        public byte[] unknownBytes;

        public UnknownHeader_4C()
        {
            headerType = (UInt32)HeaderType.Unknown_4C;
            unknownBytes = new byte[6];
        }

        public static UnknownHeader_4C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_4C();

            header.index = stageFile.GetUInt16();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_4D
    {
        public UInt32 headerType;
        public UInt32 pointer;
        public List<UInt32> pointers;
        public List<List<byte>> unknownBytes;


        public UnknownHeader_4D()
        {
            headerType = (byte)HeaderType.Unknown_4D;
            pointers = new List<UInt32>();
            unknownBytes = new List<List<byte>>();
        }

        public static UnknownHeader_4D ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_4D();

            header.pointer = stageFile.GetUInt32();
            header.pointers = stageFile.GetUInt32ListAtPosition(header.pointer);
            foreach (var pointer in header.pointers)
            {
                if (pointer == 0)
                    continue;

                header.unknownBytes.Add(stageFile.GetByteListAtPosition(pointer, true));
            }

            return header;
        }
    }

    public class UnknownHeader_4E
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;


        public UnknownHeader_4E()
        {
            headerType = (byte)HeaderType.Unknown_4E;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_4E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_4E();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_4F
    {
        public UInt32 headerType;
        public UInt32 pointer;
        public List<UInt32> pointers;
        public List<List<byte>> unknownBytes;

        public UnknownHeader_4F()
        {
            headerType = (byte)HeaderType.Unknown_4F;
            pointers = new List<UInt32>();
            unknownBytes = new List<List<byte>>();
        }

        public static UnknownHeader_4F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_4F();

            header.pointer = stageFile.GetUInt32();
            header.pointers = stageFile.GetUInt32ListAtPosition(header.pointer, true);

            foreach (var pointer in header.pointers)
            {
                if (pointer == 0)
                    continue;

                header.unknownBytes.Add(stageFile.GetByteListAtPosition(pointer, true));
            }

            return header;
        }
    }

    public class JobNameHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public JobNameHeader()
        {
            headerType = (UInt32)HeaderType.JobName;
            name = string.Empty;
        }

        public static JobNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobNameHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class MonsterHeader
    {
        public enum SpecialStatType
        {
            Average = 0x80, // second byte is multiplier (divide by 10 and add 1)
            Highest = 0x81, // second byte is multiplier (divide by 10 and add 1)
            Clonus = 0x82, // second byte is player to clone
            Lowest = 0x84  // second byte is multiplier (divide by 10 and add 1)  
        }

        public UInt32 headerType;
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
        public UInt16 gold;

        public MonsterHeader()
        {
            headerType = (UInt32)HeaderType.Monster;
            name = string.Empty;
        }

        public static MonsterHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterHeader();

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
            header.gold = stageFile.GetUInt16();

            return header;
        }
    }

    public class MonsterUnknownInfoHeader
    {
        public UInt32 headerType;
        public UInt16 index;
        public byte[] unknownBytes;
        public string name;
        public UInt32 filler;

        public MonsterUnknownInfoHeader()
        {
            headerType = (UInt32)HeaderType.MonsterUnknownInfo;
            unknownBytes = new byte[6];
            name = string.Empty;
        }

        public static MonsterUnknownInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterUnknownInfoHeader();

            header.index = stageFile.GetUInt16();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();
            header.filler = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownFilePointer
    {
        public UInt32 type;
        public UInt32 index;
        public UInt32 pointer;
    }

    public class MonsterFileInfoHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string F0File;
        public string FG0File;
        public List<UnknownFilePointer> unknownPointers;
        public UInt32 filler;
        public List<List<UInt16>> unknownUInt16s;

        public MonsterFileInfoHeader()
        {
            headerType = (UInt32)HeaderType.MonsterFileInfo;
            unknownPointers = new List<UnknownFilePointer>();
            unknownUInt16s = new List<List<UInt16>>();
            F0File = string.Empty;
            FG0File = string.Empty;
        }

        public static MonsterFileInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterFileInfoHeader();

            header.index = stageFile.GetUInt32();
            header.F0File = stageFile.GetString();
            header.FG0File = stageFile.GetString();

            UnknownFilePointer filePointer;
            do
            {
                filePointer = new UnknownFilePointer{ type = stageFile.GetUInt32() };

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
    }

    public class MonsterAITableHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte attackRate;
        public byte skillRate;
        public byte strikeRate;
        public byte magicRate;
        public byte defendRate;
        public byte counterRate;
        public byte magicDefendRate;

        public MonsterAITableHeader()
        {
            headerType = (UInt32)HeaderType.MonsterFileInfo;
        }

        public static MonsterAITableHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterAITableHeader();

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
    }

    public class UnknownHeader_52
    {
        public UInt32 headerType;
        public UInt32 index;
        public string unknownString;

        public UnknownHeader_52()
        {
            headerType = (UInt32)HeaderType.Unknown_52;
            unknownString = String.Empty;
        }

        public static UnknownHeader_52 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_52();

            header.index = stageFile.GetUInt32();
            header.unknownString = stageFile.GetString();

            return header;
        }
    }

    public class MonsterItemDropHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte dropRateItem1;
        public byte dropRateItem2;
        public byte filler;
        public byte indexItem1;
        public byte categoryItem1;
        public byte indexItem2;
        public byte categoryItem2;


        public MonsterItemDropHeader()
        {
            headerType = (UInt32)HeaderType.MonsterItemDrop;
        }

        public static MonsterItemDropHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterItemDropHeader();

            header.index = stageFile.GetByte();
            header.dropRateItem1 = stageFile.GetByte();
            header.dropRateItem2 = stageFile.GetByte();
            header.filler = stageFile.GetByte();
            header.indexItem1 = stageFile.GetByte();
            header.categoryItem1 = stageFile.GetByte();
            header.indexItem2 = stageFile.GetByte();
            header.categoryItem2 = stageFile.GetByte();

            return header;
        }
    }

    public class UnknownHeader_54
    {
        public UInt32 headerType;
        public UInt32 unknownUInt32;

        public UnknownHeader_54()
        {
            headerType = (UInt32)HeaderType.Unknown_54;
        }

        public static UnknownHeader_54 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_54();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class NPCNameHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public NPCNameHeader()
        {
            headerType = (UInt32)HeaderType.NPCName;
            name = string.Empty;
        }

        public static NPCNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new NPCNameHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class NPCUnknownInfoHeader
    {
        public UInt32 headerType;
        public UInt16 index;
        public byte[] unknownBytes;
        public string name;

        public NPCUnknownInfoHeader()
        {
            headerType = (UInt32)HeaderType.NPCUnknownInfo;
            unknownBytes = new byte[6];
            name = string.Empty;
        }

        public static NPCUnknownInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new NPCUnknownInfoHeader();

            header.index = stageFile.GetUInt16();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class NPCFileInfoHeader
    {
        public UInt32 headerType;
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

        public NPCFileInfoHeader()
        {
            headerType = (UInt32)HeaderType.NPCFileInfo;
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
            var header = new NPCFileInfoHeader();

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
    }

    public class WeaponHeader
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

        public UInt32 headerType;
        public UInt16 index;
        public UInt16 objectType;
        public string name;
        public byte animationIndex;
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

        public WeaponHeader()
        {
            headerType = (UInt32)HeaderType.Weapon;
            name = string.Empty;
        }

        public static WeaponHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new WeaponHeader();

            header.index = stageFile.GetUInt16();
            header.objectType = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.animationIndex = stageFile.GetByte();
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
    }

    public class WeaponUnknownInfoHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;
        public string name;

        public WeaponUnknownInfoHeader()
        {
            headerType = (byte)HeaderType.WeaponUnknownInfo;
            unknownBytes = new byte[24];
            name = String.Empty;
        }

        public static WeaponUnknownInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new WeaponUnknownInfoHeader();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class WeaponDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public WeaponDescriptionHeader()
        {
            headerType = (byte)HeaderType.WeaponDescription;
            description = new List<string>();
        }

        public static WeaponDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new WeaponDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class MonsterTypeHeader
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

        public UInt32 headerType;
        public byte index;
        public byte modelID;
        public byte aiIndex;
        public byte monsterType;

        public MonsterTypeHeader()
        {
            headerType = (UInt32)HeaderType.MonsterType;
        }

        public static MonsterTypeHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterTypeHeader();

            header.index = stageFile.GetByte();
            header.modelID = stageFile.GetByte();
            header.aiIndex = stageFile.GetByte();
            header.monsterType = stageFile.GetByte();

            return header;
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
    }

    public class UnknownHeader_5C
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;


        public UnknownHeader_5C()
        {
            headerType = (byte)HeaderType.Unknown_5C;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_5C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_5C();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class EtcFileNameHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;
        public string name;

        public EtcFileNameHeader()
        {
            headerType = (UInt32)HeaderType.EtcFileName;
            unknownBytes = new byte[3];
            name = string.Empty;
        }

        public static EtcFileNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EtcFileNameHeader();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class ShieldHeader
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 objectType;
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

        public ShieldHeader()
        {
            headerType = (UInt32)HeaderType.Shield;
            name = string.Empty;
            unknownBytes = new byte[3];
        }

        public static ShieldHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new ShieldHeader();

            header.index = stageFile.GetUInt16();
            header.objectType = stageFile.GetUInt16();
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
    }

    public class ShieldUnknownInfoHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public ShieldUnknownInfoHeader()
        {
            headerType = (byte)HeaderType.ShieldUnknownInfo;
            name = String.Empty;
        }

        public static ShieldUnknownInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new ShieldUnknownInfoHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class ShieldDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public ShieldDescriptionHeader()
        {
            headerType = (byte)HeaderType.ShieldDescription;
            description = new List<string>();
        }

        public static ShieldDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new ShieldDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class WeaponBonusDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public WeaponBonusDescriptionHeader()
        {
            headerType = (byte)HeaderType.WeaponBonusDescription;
            description = new List<string>();
        }

        public static WeaponBonusDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new WeaponBonusDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class AccessoryHeader
    {
        public enum ActivationType
        {
            None = 0x4E,
            Field = 0x46,
            Battle = 0x42,
            Both = 0x41
        }

        public UInt32 headerType;
        public UInt16 index;
        public UInt16 objectType;
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

        public AccessoryHeader()
        {
            headerType = (UInt32)HeaderType.Accessory;
            name = string.Empty;
            unknownBytes = new byte[3];
        }

        public static AccessoryHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new AccessoryHeader();

            header.index = stageFile.GetUInt16();
            header.objectType = stageFile.GetUInt16();
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
    }

    public class AccessoryDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public AccessoryDescriptionHeader()
        {
            headerType = (byte)HeaderType.AccessoryDescription;
            description = new List<string>();
        }

        public static AccessoryDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new AccessoryDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class TempleNameHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte continent;
        public UInt16 mapLocationID;
        public string name;

        public TempleNameHeader()
        {
            headerType = (UInt32)HeaderType.TempleName;
            name = string.Empty;
        }

        public static TempleNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new TempleNameHeader();

            header.index = stageFile.GetByte();
            header.continent = stageFile.GetByte();
            header.mapLocationID = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class UnknownHeader_66
    {
        public UInt32 headerType;
        public UInt32 unknownUint;

        public UnknownHeader_66()
        {
            headerType = (UInt32)HeaderType.Unknown_66;
        }

        public static UnknownHeader_66 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_66();

            header.unknownUint = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_68
    {
        public UInt32 headerType;
        public byte index;
        public byte unknownByte1;
        public byte unknownByte2;
        public byte unknownByte3;
        public UInt32 unknownUint;

        public UnknownHeader_68()
        {
            headerType = (UInt32)HeaderType.Unknown_68;
        }

        public static UnknownHeader_68 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_68();

            header.index = stageFile.GetByte();
            header.unknownByte1 = stageFile.GetByte();
            header.unknownByte2 = stageFile.GetByte();
            header.unknownByte3 = stageFile.GetByte();
            header.unknownUint = stageFile.GetUInt32();

            return header;
        }
    }

    public class BagItemHeader
    { 
        public UInt32 headerType;
        public byte index;
        public byte itemType;
        public UInt16 objectType;
        public string name;
        public UInt32 price;
        public UInt32 unknownUInt32;

        public BagItemHeader()
        {
            headerType = (UInt32)HeaderType.BagItem;
            name = string.Empty;
        }

        public static BagItemHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BagItemHeader();

            header.index = stageFile.GetByte();
            header.itemType = stageFile.GetByte();
            header.objectType = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class BagItemDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public BagItemDescriptionHeader()
        {
            headerType = (byte)HeaderType.BagItemDescription;
            description = new List<string>();
        }

        public static BagItemDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BagItemDescriptionHeader();
            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class UnknownHeader_6B
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_6B()
        {
            headerType = (byte)HeaderType.Unknown_6B;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_6B ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_6B();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class LocalItemHeader
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 objectType;
        public string name;
        public UInt32 price;
        public Int32 localItemValue;
        public byte spawnRate;
        public byte isCastleItem;
        public byte filler;
        public byte townCastleIndex;

        public LocalItemHeader()
        {
            headerType = (UInt32)HeaderType.LocalItem;
            name = string.Empty;
        }

        public static LocalItemHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new LocalItemHeader();

            header.index = stageFile.GetUInt16();
            header.objectType = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.localItemValue = stageFile.GetInt32();
            header.spawnRate = stageFile.GetByte();
            header.isCastleItem = stageFile.GetByte();
            header.filler = stageFile.GetByte();
            header.townCastleIndex = stageFile.GetByte();

            return header;
        }
    }

    public class TownCastleHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte continent;
        public UInt16 mapLocationID;
        public string name;
        public UInt32 unknownUint1;
        public UInt32 townValue;
        public UInt32 unknownUint2;

        public TownCastleHeader()
        {
            headerType = (UInt32)HeaderType.TownCastleName;
            name = string.Empty;
        }

        public static TownCastleHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new TownCastleHeader();

            header.index = stageFile.GetByte();
            header.continent = stageFile.GetByte();
            header.mapLocationID = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.unknownUint1 = stageFile.GetUInt32();
            header.townValue = stageFile.GetUInt32();
            header.unknownUint2 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_6E
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;
        public UInt32 unknownUint1;
        public UInt32 unknownUint2;

        public UnknownHeader_6E()
        {
            headerType = (UInt32)HeaderType.Unknown_6E;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_6E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_6E();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.unknownUint1 = stageFile.GetUInt32();
            header.unknownUint2 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownCastleInfo
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownCastleInfo()
        {
            headerType = (byte)HeaderType.CastleUnknownInfo;
            unknownBytes = new byte[3];
        }

        public static UnknownCastleInfo ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownCastleInfo();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class OffensiveMagicHeader
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 objectType;
        public string name;
        public UInt32 price;
        public UInt16 power; // multiplied by 100
        public byte magicType;
        public byte unknownIndex;
        public UInt16 effectType;
        public UInt16 filler;

        public OffensiveMagicHeader()
        {
            headerType = (UInt32)HeaderType.OffensiveMagic;
            name = string.Empty;
        }

        public static OffensiveMagicHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new OffensiveMagicHeader();

            header.index = stageFile.GetUInt16();
            header.objectType = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.power = stageFile.GetUInt16();
            header.magicType = stageFile.GetByte();
            header.unknownIndex = stageFile.GetByte();
            header.effectType = stageFile.GetUInt16();
            header.filler = stageFile.GetUInt16();

            return header;
        }
    }

    public class OffensiveMagicDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public OffensiveMagicDescriptionHeader()
        {
            headerType = (byte)HeaderType.OffensiveMagicDescription;
            description = new List<string>();
        }

        public static OffensiveMagicDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new OffensiveMagicDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class DefensiveMagicHeader
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 objectType;
        public string name;
        public UInt32 price;
        public UInt16 power; // multiplied by 100
        public byte magicType;
        public byte unknownIndex;
        public UInt16 effectType;
        public UInt16 filler;

        public DefensiveMagicHeader()
        {
            headerType = (UInt32)HeaderType.DefensiveMagic;
            name = string.Empty;
        }

        public static DefensiveMagicHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DefensiveMagicHeader();

            header.index = stageFile.GetUInt16();
            header.objectType = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.power = stageFile.GetUInt16();
            header.magicType = stageFile.GetByte();
            header.unknownIndex = stageFile.GetByte();
            header.effectType = stageFile.GetUInt16();
            header.filler = stageFile.GetUInt16();

            return header;
        }
    }

    public class DefensiveMagicDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public DefensiveMagicDescriptionHeader()
        {
            headerType = (byte)HeaderType.DefensiveMagicDescription;
            description = new List<string>();
        }

        public static DefensiveMagicDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DefensiveMagicDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class FieldMagicHeader
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 objectType;
        public string name;
        public UInt32 price;
        public UInt16 power; // multiplied by 100
        public byte magicType;
        public byte[] unknownBytes;
        public UInt16 effectType;

        public FieldMagicHeader()
        {
            headerType = (UInt32)HeaderType.FieldMagic;
            name = string.Empty;
            unknownBytes = new byte[3];
        }

        public static FieldMagicHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new FieldMagicHeader();

            header.index = stageFile.GetUInt16();
            header.objectType = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.price = stageFile.GetUInt32();
            header.power = stageFile.GetUInt16();
            header.magicType = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.effectType = stageFile.GetUInt16();

            return header;
        }
    }

    public class FieldMagicDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public FieldMagicDescriptionHeader()
        {
            headerType = (byte)HeaderType.FieldMagicDescription;
            description = new List<string>();
        }

        public static FieldMagicDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new FieldMagicDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class UnknownHeader_76
    {
        public UInt32 headerType;
        public UInt32 startOfList;
        public UInt32 unknownUint32;
        public UInt32 endOfList;
        public UInt32 filler;
        public List<byte> unknownBytes;

        public UnknownHeader_76()
        {
            headerType = (UInt32)HeaderType.Unknown_76;
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_76 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_76();

            header.startOfList = stageFile.GetUInt32();
            header.unknownUint32 = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();
            header.filler = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfList, header.endOfList);

            return header;
        }
    }

    public class UnknownHeader_77
    {
        public UInt32 headerType;
        public UInt32 startOfList;
        public UInt32 unknownUint32;
        public UInt32 endOfList;
        public UInt32 filler;
        public List<byte> unknownBytes;

        public UnknownHeader_77()
        {
            headerType = (UInt32)HeaderType.Unknown_77;
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_77 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_77();

            header.startOfList = stageFile.GetUInt32();
            header.unknownUint32 = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();
            header.filler = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfList, header.endOfList);

            return header;
        }
    }

    public class UnknownHeader_78
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 start;
        public List<UInt32> listPositions;
        public List<List<byte>> unknownBytes;

        public UnknownHeader_78()
        {
            headerType = (UInt32)HeaderType.Unknown_78;
            listPositions = new List<UInt32>();
            unknownBytes = new List<List<byte>>();
        }

        public static UnknownHeader_78 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_78();

            header.index = stageFile.GetUInt32();
            header.start = stageFile.GetUInt32();
            header.listPositions = stageFile.GetUInt32ListAtPosition(header.start);

            foreach (var position in header.listPositions)
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
    }

    public class BattleSkillHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte activationRate;
        public UInt16 unknownUInt16;
        public string name;

        public BattleSkillHeader()
        {
            headerType = (UInt32)HeaderType.BattleSkill;
            name = string.Empty;
        }

        public static BattleSkillHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BattleSkillHeader();

            header.index = stageFile.GetByte();
            header.activationRate = stageFile.GetByte();
            header.unknownUInt16 = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class JobSkillHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte activationRate;
        public UInt32 filler;
        public string name;

        public JobSkillHeader()
        {
            headerType = (UInt32)HeaderType.JobSkill;
            name = string.Empty;
        }

        public static JobSkillHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobSkillHeader();

            header.index = stageFile.GetByte();
            header.activationRate = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class MonsterDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public MonsterDescriptionHeader()
        {
            headerType = (byte)HeaderType.MonsterDescription;
            description = new List<string>();
        }

        public static MonsterDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MonsterDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class BattleSkillDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public BattleSkillDescriptionHeader()
        {
            headerType = (byte)HeaderType.BattleSkillDescription;
            description = new List<string>();
        }

        public static BattleSkillDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BattleSkillDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class JobSkillDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public JobSkillDescriptionHeader()
        {
            headerType = (byte)HeaderType.JobSkillDescription;
            description = new List<string>();
        }

        public static JobSkillDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobSkillDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class RandomLootHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 start;
        public UInt16 length;
        public UInt16 itemPickCount;
        public List<(byte index, byte type)> itemList;

        public RandomLootHeader()
        {
            headerType = (UInt32)HeaderType.RandomLoot;
            itemList = new List<(byte index, byte category)> ();
        }

        public static RandomLootHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new RandomLootHeader();
            header.index = stageFile.GetUInt32();
            header.start = stageFile.GetUInt32();

            var nextHeader = stageFile.Position();

            stageFile.SetPosition (header.start);
            header.length = stageFile.GetUInt16();
            header.itemPickCount = stageFile.GetUInt16();

            for (int i = 0; i < header.length; i++)
                header.itemList.Add((stageFile.GetByte(), stageFile.GetByte()));

            stageFile.SetPosition(nextHeader);

            return header;
        }
    }

    public class EffectNameHeader1
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 iconID;
        public string name;

        public EffectNameHeader1()
        {
            headerType = (UInt32)HeaderType.EffectName1;
            name = string.Empty;
        }

        public static EffectNameHeader1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EffectNameHeader1();

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class EffectNameHeader2
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 iconID;
        public byte minDuration;
        public byte maxDuration;
        public UInt16 filler;
        public string name;

        public EffectNameHeader2()
        {
            headerType = (UInt32)HeaderType.EffectName2;
            name = string.Empty;
        }

        public static EffectNameHeader2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EffectNameHeader2();

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.minDuration = stageFile.GetByte();
            header.maxDuration = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class EffectNameHeader3
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 iconID;
        public byte minDuration;
        public byte maxDuration;
        public UInt16 filler;
        public string name;

        public EffectNameHeader3()
        {
            headerType = (UInt32)HeaderType.EffectName3;
            name = string.Empty;
        }

        public static EffectNameHeader3 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new EffectNameHeader3();

            header.index = stageFile.GetUInt16();
            header.iconID = stageFile.GetUInt16();
            header.minDuration = stageFile.GetByte();
            header.maxDuration = stageFile.GetByte();
            header.filler = stageFile.GetUInt16();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class UnknownHeader_84
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_84()
        {
            headerType = (UInt32)HeaderType.Unknown_84;
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_84 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_84();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_85
    {
        public UInt32 headerType;
        public UInt32 startOfList;
        public UInt32 endOfList1;
        public UInt32 endOfList2;
        public List<byte> unknownBytes;

        public UnknownHeader_85()
        {
            headerType = (UInt32)HeaderType.Unknown_85;
            unknownBytes = new List<byte> { };
        }

        public static UnknownHeader_85 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_85();

            header.startOfList = stageFile.GetUInt32();
            header.endOfList1 = stageFile.GetUInt32();
            header.endOfList2 = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfList, header.endOfList2);

            return header;
        }
    }

    public class RandomEffectHeader
    {
        public UInt32 headerType;
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

        public RandomEffectHeader()
        {
            headerType = (UInt32)HeaderType.RandomEffect;
            effectName = string.Empty;
        }

        public static RandomEffectHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new RandomEffectHeader();

            header.effectType = stageFile.GetByte();
            header.effectTypeIndex = stageFile.GetByte();
            header.unknownByte1 = stageFile.GetByte();
            header.unknownByte2 = stageFile.GetByte();
            header.effectStatustype = stageFile.GetUInt32();
            header.effectQuantity = stageFile.GetUInt32();
            header.effectName = stageFile.GetString();

            return header;
        }
    }

    public class SpaceNameHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public SpaceNameHeader()
        {
            headerType = (UInt32)HeaderType.SpaceName;
            name = string.Empty;
        }

        public static SpaceNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new SpaceNameHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class SpaceDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public SpaceDescriptionHeader()
        {
            headerType = (byte)HeaderType.SpaceDescription;
            description = new List<string>();
        }

        public static SpaceDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new SpaceDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class BagItemTypeNameHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public BagItemTypeNameHeader()
        {
            headerType = (byte)HeaderType.BagItemTypeName;
            name = String.Empty;
        }

        public static BagItemTypeNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BagItemTypeNameHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class BattleMagicTypeNameHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public BattleMagicTypeNameHeader()
        {
            headerType = (byte)HeaderType.BattleMagicTypeName;
            name = String.Empty;
        }

        public static BattleMagicTypeNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new BattleMagicTypeNameHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class FieldMagicTypeNameHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public FieldMagicTypeNameHeader()
        {
            headerType = (byte)HeaderType.FieldMagicTypeName;
            name = String.Empty;
        }

        public static FieldMagicTypeNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new FieldMagicTypeNameHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class UnknownHeader_8C
    {
        public UInt32 headerType;
        public UInt32 endOfList;
        public List<UInt16> unknownUints;

        public UnknownHeader_8C()
        {
            headerType = (byte)HeaderType.Unknown_8C;
            unknownUints = new List<UInt16>();
        }

        public static UnknownHeader_8C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_8C();

            header.endOfList = stageFile.GetUInt32();
            while (stageFile.Position() < stageFile.fileOffset + header.endOfList)
                header.unknownUints.Add(stageFile.GetUInt16());

            return header;
        }
    }

    public class UnknownHeader_8E
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 unknownUInt32;


        public UnknownHeader_8E()
        {
            headerType = (byte)HeaderType.Unknown_8E;
        }

        public static UnknownHeader_8E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_8E();

            header.index = stageFile.GetUInt32();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_8F
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 startOfList;
        public List<UInt16> unknownList;

        public UnknownHeader_8F()
        {
            headerType = (byte)HeaderType.Unknown_8F;
            unknownList = new List<UInt16>();
        }

        public static UnknownHeader_8F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_8F();

            header.index = stageFile.GetUInt32();
            header.startOfList = stageFile.GetUInt32();
            header.unknownList = stageFile.GetUInt16ListAtPosition(header.startOfList);

            return header;
        }
    }

    public class UnknownHeader_93
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_93()
        {
            headerType = (UInt32)HeaderType.Unknown_93;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_93 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_93();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_94
    {
        public UInt32 headerType;
        public UInt32 startOfList;
        public UInt32 endOfList;
        public List<byte> unknownBytes;

        public UnknownHeader_94()
        {
            headerType = (byte)HeaderType.Unknown_94;
            unknownBytes = new List<byte> { };
        }

        public static UnknownHeader_94 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_94();

            header.startOfList = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfList, header.endOfList);

            return header;
        }
    }

    public class HairstyleDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public HairstyleDescriptionHeader()
        {
            headerType = (byte)HeaderType.HairstyleDescription;
            description = new List<string>();
        }

        public static HairstyleDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new HairstyleDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class HairstyleHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte nonClassIndex;
        public UInt16 objectType;
        public string name;
        public byte unknownByte;
        public byte descriptionID;
        public byte[] unknownBytes;
        public byte unknownHairType; // 0x01 = default unlocked???

        public HairstyleHeader()
        {
            headerType = (UInt32)HeaderType.Hairstyle;
            name = string.Empty;
            unknownBytes = new byte[5];
        }

        public static HairstyleHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new HairstyleHeader();

            header.index = stageFile.GetByte();
            header.nonClassIndex = stageFile.GetByte();
            header.objectType = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            header.unknownByte = stageFile.GetByte();
            header.descriptionID = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);
            header.unknownHairType = stageFile.GetByte();

            return header;
        }
    }

    public class UnknownHairstyleInfoHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public UnknownHairstyleInfoHeader()
        {
            headerType = (byte)HeaderType.HairstyleUnknownInfo;
            name = String.Empty;
        }

        public static UnknownHairstyleInfoHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHairstyleInfoHeader();

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();
            return header;
        }
    }

    public class UnknownHeader_9A
    {
        public UInt32 headerType;
        public byte firstIndex;
        public byte secondIndex;
        public byte[] unknownBytes;


        public UnknownHeader_9A()
        {
            headerType = (byte)HeaderType.Unknown_9A;
            unknownBytes = new byte[6];
        }

        public static UnknownHeader_9A ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9A();
  
            header.firstIndex = stageFile.GetByte();
            header.secondIndex = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_9B
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;


        public UnknownHeader_9B()
        {
            headerType = (byte)HeaderType.Unknown_9B;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_9B ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9B();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_9C
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;


        public UnknownHeader_9C()
        {
            headerType = (byte)HeaderType.Unknown_9C;
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_9C ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9C();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_9D
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;


        public UnknownHeader_9D()
        {
            headerType = (byte)HeaderType.Unknown_9D;
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_9D ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9D();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_9E
    {
        public UInt32 headerType;
        public UInt32 endOfList1;
        public UInt32 endOfList2;
        public List<byte> unknownBytes;

        public UnknownHeader_9E()
        {
            headerType = (byte)HeaderType.Unknown_9E;
            unknownBytes = new List<byte> { };
        }

        public static UnknownHeader_9E ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9E();

            header.endOfList1 = stageFile.GetUInt32();
            header.endOfList2 = stageFile.GetUInt32();

            while (stageFile.Position() < stageFile.fileOffset + header.endOfList2)
                header.unknownBytes.Add(stageFile.GetByte());

            return header;
        }
    }

    public class UnknownHeader_9F
    {
        public UInt32 headerType;
        public UInt32 unknownUInt32;

        public UnknownHeader_9F()
        {
            headerType = (byte)HeaderType.Unknown_9F;
        }

        public static UnknownHeader_9F ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_9F();

            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_A0
    {
        public UInt32 headerType;
        public UInt32 unknownUInt32;

        public UnknownHeader_A0()
        {
            headerType = (byte)HeaderType.Unknown_A0;
        }

        public static UnknownHeader_A0 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A0();

            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_A1
    {
        public UInt32 headerType;
        public byte[] unknownBytes;

        public UnknownHeader_A1()
        {
            headerType = (byte)HeaderType.Unknown_A1;
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_A1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A1();

            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_A2
    {
        public UInt32 headerType;
        public byte[] unknownBytes;

        public UnknownHeader_A2()
        {
            headerType = (byte)HeaderType.Unknown_A2;
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_A2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A2();

            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_A3
    {
        public UInt32 headerType;
        public UInt32 unknownUInt32;

        public UnknownHeader_A3()
        {
            headerType = (byte)HeaderType.Unknown_A3;
        }

        public static UnknownHeader_A3 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A3();

            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_A4
    {
        public UInt32 headerType;
        public UInt32 unknownUInt32;

        public UnknownHeader_A4()
        {
            headerType = (byte)HeaderType.Unknown_A4;
        }

        public static UnknownHeader_A4 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A4();

            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_A5
    {
        public UInt32 headerType;
        public byte[] unknownBytes;

        public UnknownHeader_A5()
        {
            headerType = (byte)HeaderType.Unknown_A5;
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_A5 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_A5();

            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class IGBListHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 listStart;
        public byte[] IGBUnknownHeader;
        public List<FileNameHeader> IGBFiles;

        public IGBListHeader()
        {
            headerType = (byte)HeaderType.IGBFileList;
            IGBUnknownHeader = new byte[32];
            IGBFiles = new List<FileNameHeader>();
        }

        public static IGBListHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new IGBListHeader();

            header.index = stageFile.GetUInt32();
            header.listStart = stageFile.GetUInt32();

            var nextHeader = stageFile.Position();
            if (stageFile.PositionAlreadyRead(header.listStart))
                return header;

            stageFile.SetPosition(header.listStart);

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
    }

    public class UnknownHeader_AD
    {
        public UInt32 headerType;
        public UInt32 startOfList;
        public UInt32 endOfList;
        public List<UInt32> unknownPointers;
        public List<byte> unknownBytes;

        public UnknownHeader_AD()
        {
            headerType = (byte)HeaderType.Unknown_AD;
            unknownPointers = new List<UInt32>();
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_AD ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_AD();

            header.startOfList = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();
            header.unknownPointers = stageFile.GetUInt32List();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfList, header.endOfList);

            return header;
        }
    }

    public class UnknownHeader_AE
    {
        public UInt32 headerType;
        public UInt32 startOfList;
        public UInt32 endOfList;
        public List<byte> unknownBytes;

        public UnknownHeader_AE()
        {
            headerType = (byte)HeaderType.Unknown_AE;
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_AE ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_AE();

            header.startOfList = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfList, header.endOfList);

            return header;
        }
    }

    public class UnknownHeader_AF
    {
        public UInt32 headerType;
        public UInt32 startOfList;
        public UInt32 endOfList;
        public List<byte> unknownBytes;

        public UnknownHeader_AF()
        {
            headerType = (byte)HeaderType.Unknown_AF;
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_AF ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_AF();

            header.startOfList = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();
            header.unknownBytes = stageFile.GetByteListAtSection(header.startOfList, header.endOfList);

            return header;
        }
    }

    public class UnknownHeader_B0
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;


        public UnknownHeader_B0()
        {
            headerType = (byte)HeaderType.Unknown_B0;
            unknownBytes = new byte[16];
        }

        public static UnknownHeader_B0 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B0();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_B1
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 unknownUInt32;


        public UnknownHeader_B1()
        {
            headerType = (byte)HeaderType.Unknown_B1;
        }

        public static UnknownHeader_B1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B1();

            header.index = stageFile.GetUInt32();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_B2
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;


        public UnknownHeader_B2()
        {
            headerType = (byte)HeaderType.Unknown_B2;
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_B2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B2();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_B3
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;


        public UnknownHeader_B3()
        {
            headerType = (byte)HeaderType.Unknown_B3;
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_B3 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B3();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_B4
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;


        public UnknownHeader_B4()
        {
            headerType = (byte)HeaderType.Unknown_B4;
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_B4 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B4();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_B5
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_B5()
        {
            headerType = (byte)HeaderType.Unknown_B5;
            unknownBytes = new byte[28];
        }

        public static UnknownHeader_B5 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B5();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_B6
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_B6()
        {
            headerType = (byte)HeaderType.Unknown_B6;
            unknownBytes = new byte[28];
        }

        public static UnknownHeader_B6 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_B6();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class HitFormulaHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public HitFormulaHeader()
        {
            headerType = (byte)HeaderType.HitFormula;
            formula = String.Empty;
        }

        public static HitFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new HitFormulaHeader();

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class AttackFormulaHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public AttackFormulaHeader()
        {
            headerType = (byte)HeaderType.AttackFormula;
            formula = String.Empty;
        }

        public static AttackFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new AttackFormulaHeader();

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class MagicFormulaHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public MagicFormulaHeader()
        {
            headerType = (byte)HeaderType.MagicFormula;
            formula = String.Empty;
        }

        public static MagicFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new MagicFormulaHeader();

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class StrikeFormulaHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public StrikeFormulaHeader()
        {
            headerType = (byte)HeaderType.StrikeFormula;
            formula = String.Empty;
        }

        public static StrikeFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new StrikeFormulaHeader();

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class CounterFormulaHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public CounterFormulaHeader()
        {
            headerType = (byte)HeaderType.CounterFormula;
            formula = String.Empty;
        }

        public static CounterFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new CounterFormulaHeader();

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class SelfAttackFormulaHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string formula;
        public UInt32 unknownUint32;

        public SelfAttackFormulaHeader()
        {
            headerType = (byte)HeaderType.SelfAttackFormula;
            formula = String.Empty;
        }

        public static SelfAttackFormulaHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new SelfAttackFormulaHeader();

            header.index = stageFile.GetUInt32();
            header.formula = stageFile.GetString();
            header.unknownUint32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_BD
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_BD()
        {
            headerType = (byte)HeaderType.Unknown_BD;
            unknownBytes = new byte[12];
        }

        public static UnknownHeader_BD ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_BD();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_BE
    {
        public UInt32 headerType;
        public UInt32 index;
        public UInt32 unknownUInt32;

        public UnknownHeader_BE()
        {
            headerType = (byte)HeaderType.Unknown_BE;
        }

        public static UnknownHeader_BE ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_BE();

            header.index = stageFile.GetUInt32();
            header.unknownUInt32 = stageFile.GetUInt32();

            return header;
        }
    }

    public class PrankNameHeader
    {
        public UInt32 headerType;
        public UInt32 index;
        public string name;

        public PrankNameHeader()
        {
            headerType = (byte)HeaderType.PrankName;
            name = String.Empty;
        }

        public static PrankNameHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new PrankNameHeader();
            byte[] wordBuffer = new byte[4];

            header.index = stageFile.GetUInt32();
            header.name = stageFile.GetString();

            return header;
        }
    }

    public class InstuctionListHeader
    {
        public UInt32 headerType;
        public UInt32 startOfList;
        public UInt32 endOfList;
        public List<UInt32> pointer;
        public List<string> instructions;

        public InstuctionListHeader()
        {
            headerType = (byte)HeaderType.InstructionsList;
            pointer = new List<UInt32>();
            instructions = new List<string>();
        }
        
        public static InstuctionListHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new InstuctionListHeader();

            header.startOfList = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();
            header.pointer = stageFile.GetUInt32ListAtPosition(header.startOfList);
            header.instructions = stageFile.GetStringListAtSection(header.startOfList + (uint)header.pointer.Count * 4, header.endOfList, 4, true);

            return header;
        }
    }

    public class UnknownHeader_D0
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_D0()
        {
            headerType = (byte)HeaderType.Unknown_D0;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_D0 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D0();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_D1
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_D1()
        {
            headerType = (byte)HeaderType.Unknown_D1;
            unknownBytes = new byte[7];
        }

        public static UnknownHeader_D1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D1();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_D2
    {
        public UInt32 headerType;
        public UInt32 index;

        public UnknownHeader_D2()
        {
            headerType = (UInt32)HeaderType.Unknown_D2;
        }

        public static UnknownHeader_D2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D2();

            header.index = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_D3
    {
        public UInt32 headerType;
        public UInt32 index;

        public UnknownHeader_D3()
        {
            headerType = (UInt32)HeaderType.Unknown_D3;
        }

        public static UnknownHeader_D3 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D3();

            header.index = stageFile.GetUInt32();

            return header;
        }
    }

    public class UnknownHeader_D4
    {
        public UInt32 headerType;
        public UInt32 unknownUInt32;
        public UInt32 endOfList;
        public List<byte> unknownBytes;

        public UnknownHeader_D4()
        {
            headerType = (byte)HeaderType.Unknown_D4;
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_D4 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D4();

            header.unknownUInt32 = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();

            while (stageFile.Position() < stageFile.fileOffset + header.endOfList)
                header.unknownBytes.Add(stageFile.GetByte());

            return header;
        }
    }

    public class JobRequirementHeader
    {
        public UInt32 headerType;
        public UInt32 jobIndex;
        public byte itemRequiredIndex;
        public byte[] jobRequirementIndexes;

        public JobRequirementHeader()
        {
            headerType = (UInt32)HeaderType.JobRequirement;
            jobRequirementIndexes = new byte[7];
        }

        public static JobRequirementHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new JobRequirementHeader();

            header.jobIndex = stageFile.GetUInt32();
            header.itemRequiredIndex = stageFile.GetByte();
            stageFile.Read(ref header.jobRequirementIndexes);

            return header;
        }
    }

    public class UnknownHeader_D5
    {
        public UInt32 headerType;
        public UInt32 unknownUInt32;
        public UInt32 endOfList;
        public List<byte> unknownBytes;

        public UnknownHeader_D5()
        {
            headerType = (byte)HeaderType.Unknown_D5;
            unknownBytes = new List<byte>();
        }

        public static UnknownHeader_D5 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D5();

            header.unknownUInt32 = stageFile.GetUInt32();
            header.endOfList = stageFile.GetUInt32();

            while (stageFile.Position() < stageFile.fileOffset + header.endOfList)
                header.unknownBytes.Add(stageFile.GetByte());

            return header;
        }
    }

    public class UnknownHeader_D7
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_D7()
        {
            headerType = (byte)HeaderType.Unknown_D7;
            unknownBytes = new byte[7];
        }

        public static UnknownHeader_D7 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_D7();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class DarkArtDescriptionHeader
    {
        public UInt32 headerType;
        public UInt32 descriptionStart;
        public UInt32 descriptionEnd;
        public List<string> description;

        public DarkArtDescriptionHeader()
        {
            headerType = (byte)HeaderType.DarkArtDescription;
            description = new List<string>();
        }

        public static DarkArtDescriptionHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DarkArtDescriptionHeader();

            header.descriptionStart = stageFile.GetUInt32();
            header.descriptionEnd = stageFile.GetUInt32();
            header.description = stageFile.GetStringListAtSection(header.descriptionStart, header.descriptionEnd);

            return header;
        }
    }

    public class DarkArtHeader
    {
        public UInt32 headerType;
        public byte index;
        public byte unknownByte;
        public UInt16 pointCost;
        public string name;

        public DarkArtHeader()
        {
            headerType = (UInt32)HeaderType.DarkArt;
            name = string.Empty;
        }

        public static DarkArtHeader ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new DarkArtHeader();

            header.index = stageFile.GetByte();
            header.unknownByte = stageFile.GetByte();
            header.pointCost = stageFile.GetUInt16();
            header.name = stageFile.GetString();
            return header;
        }
    }

    public class UnknownHeader_DB
    {
        public UInt32 headerType;
        public UInt32 unknownUint;
        public UInt32 endOfList1;
        public UInt32 endOfList2;
        public List<UInt16[]> unknownList;

        public UnknownHeader_DB()
        {
            headerType = (byte)HeaderType.Unknown_DB;
            unknownList = new List<UInt16[]>();
        }

        public static UnknownHeader_DB ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_DB();

            header.unknownUint = stageFile.GetUInt32();
            header.endOfList1 = stageFile.GetUInt32();
            header.endOfList2 = stageFile.GetUInt32();

            while (stageFile.Position() < header.endOfList1)
            {
                UInt16[] unknownShorts = new UInt16[8];

                for (int i = 0; i < 8; i++)
                    unknownShorts[i] = stageFile.GetUInt16();

                header.unknownList.Add(unknownShorts);
            }

            return header;
        }
    }

    public class UnknownHeader_DA
    {
        public UInt32 headerType;
        public UInt16 index;
        public UInt16 unknownShort;

        public UnknownHeader_DA()
        {
            headerType = (UInt32)HeaderType.Unknown_DA;
        }

        public static UnknownHeader_DA ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_DA();

            header.index = stageFile.GetUInt16();
            header.unknownShort = stageFile.GetUInt16();

            return header;
        }
    }

    public class UnknownHeader_DF
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;

        public UnknownHeader_DF()
        {
            headerType = (UInt32)HeaderType.Unknown_DF;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_DF ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_DF();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_E0
    {
        public UInt32 headerType;
        public UInt32 endOfList1;
        public UInt32 endOfList2;
        public List<byte> unknownList;

        public UnknownHeader_E0()
        {
            headerType = (byte)HeaderType.Unknown_E0;
            unknownList = new List<byte>();
        }

        public static UnknownHeader_E0 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_E0();

            header.endOfList1 = stageFile.GetUInt32();
            header.endOfList2 = stageFile.GetUInt32();

            while (stageFile.Position() < header.endOfList2)
                header.unknownList.Add(stageFile.GetByte());

            return header;
        }
    }

    public class UnknownHeader_E1
    {
        public UInt32 headerType;
        public UInt32 index;
        public byte[] unknownBytes;

        public UnknownHeader_E1()
        {
            headerType = (byte)HeaderType.Unknown_E1;
            unknownBytes = new byte[8];
        }

        public static UnknownHeader_E1 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_E1();

            header.index = stageFile.GetUInt32();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }

    public class UnknownHeader_E2
    {
        public UInt32 headerType;
        public byte index;
        public byte[] unknownBytes;


        public UnknownHeader_E2()
        {
            headerType = (byte)HeaderType.Unknown_E2;
            unknownBytes = new byte[3];
        }

        public static UnknownHeader_E2 ReadHeaderBlock(DokaponFileReader stageFile)
        {
            var header = new UnknownHeader_E2();

            header.index = stageFile.GetByte();
            stageFile.Read(ref header.unknownBytes);

            return header;
        }
    }
}
