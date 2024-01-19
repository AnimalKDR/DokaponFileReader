using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DokaponFileReader
{
    public class CharaFile
    {
        public string fileHeader;
        public UInt32 originalFileOffset;
        public UInt32 fileSize;
        public UInt32 headerSize;
        public byte[] filler;

        public WeaponDescriptionHeader WeaponDescriptionHeader;
        public ShieldDescriptionHeader ShieldDescriptionHeader;
        public WeaponBonusDescriptionHeader WeaponBonusDescriptionHeader;
        public AccessoryDescriptionHeader AccessoryDescriptionHeader;
        public HairstyleDescriptionHeader HairstyleDescriptionHeader;
        public BagItemDescriptionHeader BagItemDescriptionHeader;
        public OffensiveMagicDescriptionHeader OffensiveMagicDescriptionHeader;
        public DefensiveMagicDescriptionHeader DefensiveMagicDescriptionHeader;
        public FieldMagicDescriptionHeader FieldMagicDescriptionHeader;
        public DarkArtDescriptionHeader DarkArtDescriptionHeader;
        public BattleSkillDescriptionHeader BattleSkillDescriptionHeader;
        public JobSkillDescriptionHeader JobSkillDescriptionHeader;
        public JobDescriptionHeader JobDescriptionHeader;
        public MonsterDescriptionHeader MonsterDescriptionHeader;
        public DialogListHeader DialogListHeader;
        public InstructionListHeader InstructionListHeader;
        public EndOfFileHeader EndOfFileHeader;

        public UnknownHeader_1D UnknownHeader_1D;
        public UnknownHeader_1E UnknownHeader_1E;
        public UnknownHeader_2C UnknownHeader_2C;
        public UnknownHeader_47 UnknownHeader_47;
        public UnknownHeader_4D UnknownHeader_4D;
        public UnknownHeader_4F UnknownHeader_4F;
        public ExperienceRequirementHeader ExperienceRequirementHeader;
        public CPULevelUpHeader CPULevelUpHeader;
        public UnknownHeader_8C UnknownHeader_8C;
        public UnknownHeader_9C UnknownHeader_9C;
        public UnknownHeader_9D UnknownHeader_9D;
        public UnknownHeader_9E UnknownHeader_9E;
        public UnknownHeader_9F UnknownHeader_9F;
        public UnknownHeader_A0 UnknownHeader_A0;
        public UnknownHeader_A1 UnknownHeader_A1;
        public UnknownHeader_A2 UnknownHeader_A2;
        public UnknownHeader_A3 UnknownHeader_A3;
        public UnknownHeader_A4 UnknownHeader_A4;
        public UnknownHeader_A5 UnknownHeader_A5;
        public UnknownHeader_AD UnknownHeader_AD;
        public UnknownHeader_AE UnknownHeader_AE;
        public UnknownHeader_AF UnknownHeader_AF;
        public UnknownHeader_B1 UnknownHeader_B1;
        public UnknownHeader_B2 UnknownHeader_B2;
        public UnknownHeader_E1 UnknownHeader_E1;
        public UnknownHeader_D4 UnknownHeader_D4;
        public UnknownHeader_D5 UnknownHeader_D5;
        public UnknownHeader_79 UnknownHeader_79;

        public List<FileNameHeader> CharFileNameHeaders;
        public List<UnknownHeader_03> CharUnknownHeaders_03;
        public List<WeaponHeader> WeaponHeaders;
        public List<WeaponUnknownInfoHeader> UnknownWeaponInfoHeaders;
        public List<ShieldHeader> ShieldHeaders;
        public List<ShieldUnknownInfoHeader> UnknownShieldInfoHeaders;
        public List<AccessoryHeader> AccessoryHeaders;
        public List<HairstyleHeader> HairstyleHeaders;
        public List<UnknownHairstyleInfoHeader> UnknownHairstyleInfoHeaders;
        public List<BagItemTypeNameHeader> BagItemTypeNameHeaders;
        public List<BagItemHeader> BagItemHeaders;
        public List<LocalItemHeader> LocalItemHeaders;
        public List<OffensiveMagicHeader> OffensiveMagicHeaders;
        public List<DefensiveMagicHeader> DefensiveMagicHeaders;
        public List<FieldMagicHeader> FieldMagicHeaders;
        public List<BattleMagicTypeNameHeader> BattleMagicTypeNameHeaders;
        public List<FieldMagicTypeNameHeader> FieldMagicTypeNameHeaders;
        public List<DarkArtHeader> DarkArtHeaders;
        public List<BattleSkillHeader> BattleSkillHeaders;
        public List<JobSkillHeader> JobSkillHeaders;
        public List<JobFileHeader2> JobFileHeaders2;
        public List<JobSalaryHeader> JobSalaryHeaders;
        public List<JobLevelAndMasteryHeader> JobLevelAndMasteryHeaders;
        public List<JobBattleSkillHeader> JobBattleSkillHeaders;
        public List<JobLevelUpRequirementHeader> JobLevelUpRequirementHeaders;
        public List<JobStartingStatsHeader> JobStartingStatsHeaders;
        public List<JobUnknownInfoHeader1> JobUnknownInfoHeaders1;
        public List<JobNameHeader> JobNameHeaders;
        public List<JobUnknownInfoHeader2> JobUnknownInfoHeaders2;
        public List<JobItemSpacesHeader> JobItemSpaceHeaders;
        public List<JobFileHeader1> JobFileHeaders1;
        public List<JobRequirementHeader> JobRequirementHeaders;
        public List<EffectNameHeader1> EffectNameHeaders1;
        public List<EffectNameHeader2> EffectNameHeaders2;
        public List<EffectNameHeader3> EffectNameHeaders3;
        public List<CPUNamesHeader> CPUNamesHeaders;
        public List<MonsterHeader> MonsterHeaders;
        public List<MonsterItemDropHeader> MonsterItemDropHeaders;
        public List<MonsterUnknownInfoHeader> MonsterUnknownInfoHeaders1;
        public List<MonsterFileInfoHeader> MonsterUnknownInfoHeaders2;
        public List<MonsterTypeHeader> MonsterTypeHeaders;
        public List<MonsterAITableHeader> MonsterAITableHeaders;
        public List<NPCNameHeader> NPCNameHeaders;
        public List<NPCUnknownInfoHeader> NPCUnknownInfoHeaders;
        public List<NPCFileInfoHeader> NPCFileInfoHeaders;
        public List<EtcFileNameHeader> EtcFileNameHeaders;
        public List<TextureFileNameHeader> TextureFileNameHeaders;
        public List<DialogPointerListHeader> DialogPointerListHeaders;
        public List<PrankNameHeader> PrankNameHeaders;
        public List<HitFormulaHeader> HitFormulaHeaders;
        public List<AttackFormulaHeader> AttackFormulaHeaders;
        public List<MagicFormulaHeader> MagicFormulaHeaders;
        public List<StrikeFormulaHeader> StrikeFormulaHeaders;
        public List<CounterFormulaHeader> CounterFormulaHeaders;
        public List<SelfAttackFormulaHeader> SelfAttackFormulaHeaders;

        public List<UnknownHeader_17> UnknownHeaders_17;
        public List<UnknownHeader_1C> UnknownHeaders_1C;
        public List<UnknownHeader_2D> UnknownHeaders_2D;
        public List<UnknownHeader_38> UnknownHeaders_38;
        public List<UnknownHeader_39> UnknownHeaders_39;
        public List<UnknownHeader_3F> UnknownHeaders_3F;
        public List<UnknownHeader_46> UnknownHeaders_46;
        public List<UnknownHeader_49> UnknownHeaders_49;
        public List<UnknownHeader_48> UnknownHeaders_48;
        public List<UnknownHeader_4E> UnknownHeaders_4E;
        public List<UnknownHeader_4C> UnknownHeaders_4C;
        public List<UnknownHeader_52> UnknownHeaders_52;
        public List<UnknownHeader_54> UnknownHeaders_54;
        public List<UnknownHeader_5C> UnknownHeaders_5C;
        public List<UnknownHeader_6B> UnknownHeaders_6B;
        public List<UnknownHeader_84> UnknownHeaders_84;
        public List<UnknownHeader_8E> UnknownHeaders_8E;
        public List<UnknownHeader_8F> UnknownHeaders_8F;
        public List<UnknownHeader_9A> UnknownHeaders_9A;
        public List<UnknownHeader_9B> UnknownHeaders_9B;
        public List<UnknownHeader_B0> UnknownHeaders_B0;
        public List<UnknownHeader_B3> UnknownHeaders_B3;
        public List<UnknownHeader_B4> UnknownHeaders_B4;
        public List<UnknownHeader_B5> UnknownHeaders_B5;
        public List<UnknownHeader_B6> UnknownHeaders_B6;
        public List<UnknownHeader_BD> UnknownHeaders_BD;
        public List<UnknownHeader_BE> UnknownHeaders_BE;
        public List<UnknownHeader_D0> UnknownHeaders_D0;
        public List<UnknownHeader_D1> UnknownHeaders_D1;
        public List<UnknownHeader_D2> UnknownHeaders_D2;
        public List<UnknownHeader_D3> UnknownHeaders_D3;
        public List<UnknownHeader_D7> UnknownHeaders_D7;
        public List<UnknownHeader_DF> UnknownHeaders_DF;
        public List<UnknownHeader_E2> UnknownHeaders_E2;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CharaFile()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeHeaders();
        }

        private void InitializeHeaders()
        {
            fileHeader = String.Empty;
            filler = new byte[36];

            WeaponDescriptionHeader = new WeaponDescriptionHeader(4);
            ShieldDescriptionHeader = new ShieldDescriptionHeader(4);
            WeaponBonusDescriptionHeader = new WeaponBonusDescriptionHeader(4);
            AccessoryDescriptionHeader = new AccessoryDescriptionHeader(4);
            HairstyleDescriptionHeader = new HairstyleDescriptionHeader(4);
            BagItemDescriptionHeader = new BagItemDescriptionHeader(4);
            OffensiveMagicDescriptionHeader = new OffensiveMagicDescriptionHeader(4);
            DefensiveMagicDescriptionHeader = new DefensiveMagicDescriptionHeader(4);
            FieldMagicDescriptionHeader = new FieldMagicDescriptionHeader(4);
            DarkArtDescriptionHeader = new DarkArtDescriptionHeader(4);
            BattleSkillDescriptionHeader = new BattleSkillDescriptionHeader(4);
            JobSkillDescriptionHeader = new JobSkillDescriptionHeader(4);
            JobDescriptionHeader = new JobDescriptionHeader(4);
            MonsterDescriptionHeader = new MonsterDescriptionHeader(4);
            DialogListHeader = new DialogListHeader(4);
            InstructionListHeader = new InstructionListHeader(4);

            UnknownHeader_1D = new UnknownHeader_1D(4);
            UnknownHeader_1E = new UnknownHeader_1E(4);
            UnknownHeader_2C = new UnknownHeader_2C(4);
            UnknownHeader_47 = new UnknownHeader_47(4);
            UnknownHeader_4D = new UnknownHeader_4D(4);
            UnknownHeader_4F = new UnknownHeader_4F(4);
            ExperienceRequirementHeader = new ExperienceRequirementHeader(4);
            CPULevelUpHeader = new CPULevelUpHeader(4);
            UnknownHeader_8C = new UnknownHeader_8C(4);
            UnknownHeader_9C = new UnknownHeader_9C(4);
            UnknownHeader_9D = new UnknownHeader_9D(4);
            UnknownHeader_9E = new UnknownHeader_9E(4);
            UnknownHeader_9F = new UnknownHeader_9F(4);
            UnknownHeader_A0 = new UnknownHeader_A0(4);
            UnknownHeader_A1 = new UnknownHeader_A1(4);
            UnknownHeader_A2 = new UnknownHeader_A2(4);
            UnknownHeader_A3 = new UnknownHeader_A3(4);
            UnknownHeader_A4 = new UnknownHeader_A4(4);
            UnknownHeader_A5 = new UnknownHeader_A5(4);
            UnknownHeader_AD = new UnknownHeader_AD(4);
            UnknownHeader_AE = new UnknownHeader_AE(4);
            UnknownHeader_AF = new UnknownHeader_AF(4);
            UnknownHeader_B1 = new UnknownHeader_B1(4);
            UnknownHeader_B2 = new UnknownHeader_B2(4);
            UnknownHeader_E1 = new UnknownHeader_E1(4);
            UnknownHeader_D4 = new UnknownHeader_D4(4);
            UnknownHeader_D5 = new UnknownHeader_D5(4);
            UnknownHeader_79 = new UnknownHeader_79(4);


            CharFileNameHeaders = new List<FileNameHeader>();
            CharUnknownHeaders_03 = new List<UnknownHeader_03>();
            WeaponHeaders = new List<WeaponHeader>();
            UnknownWeaponInfoHeaders = new List<WeaponUnknownInfoHeader>();
            ShieldHeaders = new List<ShieldHeader>();
            UnknownShieldInfoHeaders = new List<ShieldUnknownInfoHeader>();
            AccessoryHeaders = new List<AccessoryHeader>();
            HairstyleHeaders = new List<HairstyleHeader>();
            UnknownHairstyleInfoHeaders = new List<UnknownHairstyleInfoHeader>();
            BagItemTypeNameHeaders = new List<BagItemTypeNameHeader>();
            BagItemHeaders = new List<BagItemHeader>();
            LocalItemHeaders = new List<LocalItemHeader>();
            OffensiveMagicHeaders = new List<OffensiveMagicHeader>();
            DefensiveMagicHeaders = new List<DefensiveMagicHeader>();
            FieldMagicHeaders = new List<FieldMagicHeader>();
            BattleMagicTypeNameHeaders = new List<BattleMagicTypeNameHeader>();
            FieldMagicTypeNameHeaders = new List<FieldMagicTypeNameHeader>();
            DarkArtHeaders = new List<DarkArtHeader>();
            BattleSkillHeaders = new List<BattleSkillHeader>();
            JobSkillHeaders = new List<JobSkillHeader>();
            JobFileHeaders2 = new List<JobFileHeader2>();
            JobSalaryHeaders = new List<JobSalaryHeader>();
            JobLevelAndMasteryHeaders = new List<JobLevelAndMasteryHeader>();
            JobBattleSkillHeaders = new List<JobBattleSkillHeader>();
            JobLevelUpRequirementHeaders = new List<JobLevelUpRequirementHeader>();
            JobStartingStatsHeaders = new List<JobStartingStatsHeader>();
            JobUnknownInfoHeaders1 = new List<JobUnknownInfoHeader1>();
            JobNameHeaders = new List<JobNameHeader>();
            JobUnknownInfoHeaders2 = new List<JobUnknownInfoHeader2>();
            JobItemSpaceHeaders = new List<JobItemSpacesHeader>();
            JobFileHeaders1 = new List<JobFileHeader1>();
            JobRequirementHeaders = new List<JobRequirementHeader>();
            EffectNameHeaders1 = new List<EffectNameHeader1>();
            EffectNameHeaders2 = new List<EffectNameHeader2>();
            EffectNameHeaders3 = new List<EffectNameHeader3>();
            CPUNamesHeaders = new List<CPUNamesHeader>();
            MonsterHeaders = new List<MonsterHeader>();
            MonsterItemDropHeaders = new List<MonsterItemDropHeader>();
            MonsterUnknownInfoHeaders1 = new List<MonsterUnknownInfoHeader>();
            MonsterUnknownInfoHeaders2 = new List<MonsterFileInfoHeader>();
            MonsterTypeHeaders = new List<MonsterTypeHeader>();
            MonsterAITableHeaders = new List<MonsterAITableHeader>();
            NPCNameHeaders = new List<NPCNameHeader>();
            NPCUnknownInfoHeaders = new List<NPCUnknownInfoHeader>();
            NPCFileInfoHeaders = new List<NPCFileInfoHeader>();
            EtcFileNameHeaders = new List<EtcFileNameHeader>();
            TextureFileNameHeaders = new List<TextureFileNameHeader>();
            DialogPointerListHeaders = new List<DialogPointerListHeader>();
            PrankNameHeaders = new List<PrankNameHeader>();
            HitFormulaHeaders = new List<HitFormulaHeader>();
            AttackFormulaHeaders = new List<AttackFormulaHeader>();
            MagicFormulaHeaders = new List<MagicFormulaHeader>();
            StrikeFormulaHeaders = new List<StrikeFormulaHeader>();
            CounterFormulaHeaders = new List<CounterFormulaHeader>();
            SelfAttackFormulaHeaders = new List<SelfAttackFormulaHeader>();

            UnknownHeaders_17 = new List<UnknownHeader_17>();
            UnknownHeaders_1C = new List<UnknownHeader_1C>();
            UnknownHeaders_2D = new List<UnknownHeader_2D>();
            UnknownHeaders_38 = new List<UnknownHeader_38>();
            UnknownHeaders_39 = new List<UnknownHeader_39>();
            UnknownHeaders_3F = new List<UnknownHeader_3F>();
            UnknownHeaders_46 = new List<UnknownHeader_46>();
            UnknownHeaders_48 = new List<UnknownHeader_48>();
            UnknownHeaders_4C = new List<UnknownHeader_4C>();
            UnknownHeaders_49 = new List<UnknownHeader_49>();
            UnknownHeaders_4E = new List<UnknownHeader_4E>();
            UnknownHeaders_52 = new List<UnknownHeader_52>();
            UnknownHeaders_54 = new List<UnknownHeader_54>();
            UnknownHeaders_5C = new List<UnknownHeader_5C>();
            UnknownHeaders_6B = new List<UnknownHeader_6B>();
            UnknownHeaders_84 = new List<UnknownHeader_84>();
            UnknownHeaders_8E = new List<UnknownHeader_8E>();
            UnknownHeaders_8F = new List<UnknownHeader_8F>();
            UnknownHeaders_9A = new List<UnknownHeader_9A>();
            UnknownHeaders_9B = new List<UnknownHeader_9B>();
            UnknownHeaders_B0 = new List<UnknownHeader_B0>();
            UnknownHeaders_B3 = new List<UnknownHeader_B3>();
            UnknownHeaders_B4 = new List<UnknownHeader_B4>();
            UnknownHeaders_B5 = new List<UnknownHeader_B5>();
            UnknownHeaders_B6 = new List<UnknownHeader_B6>();
            UnknownHeaders_BD = new List<UnknownHeader_BD>();
            UnknownHeaders_BE = new List<UnknownHeader_BE>();
            UnknownHeaders_D0 = new List<UnknownHeader_D0>();
            UnknownHeaders_D1 = new List<UnknownHeader_D1>();
            UnknownHeaders_D2 = new List<UnknownHeader_D2>();
            UnknownHeaders_D3 = new List<UnknownHeader_D3>();
            UnknownHeaders_D7 = new List<UnknownHeader_D7>();
            UnknownHeaders_DF = new List<UnknownHeader_DF>();
            UnknownHeaders_E2 = new List<UnknownHeader_E2>();
        }

        public void ReadCharaFile(DokaponFileReader stageFile)
        {
            InitializeHeaders();

            byte[] wordBuffer = new byte[4];

            stageFile.Read(ref wordBuffer);
            fileHeader = Encoding.GetEncoding(932).GetString(wordBuffer);
            fileSize = stageFile.GetUInt32();
            headerSize = stageFile.GetUInt32();
            stageFile.Read(ref filler);

            while (stageFile.GetRelativePosition() < fileSize && stageFile.Read(ref wordBuffer) > 0)
            {
                var header = BitConverter.ToUInt32(wordBuffer);

                switch ((HeaderType)header)
                {
                    case 0x00: break;
                    case HeaderType.FileName: CharFileNameHeaders.Add(FileNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_03: CharUnknownHeaders_03.Add(UnknownHeader_03.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.EndOfFile: EndOfFileHeader = EndOfFileHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Weapon: WeaponHeaders.Add(WeaponHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.WeaponUnknownInfo: UnknownWeaponInfoHeaders.Add(WeaponUnknownInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.WeaponDescription: WeaponDescriptionHeader = WeaponDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Shield: ShieldHeaders.Add(ShieldHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.ShieldUnknownInfo: UnknownShieldInfoHeaders.Add(ShieldUnknownInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.ShieldDescription: ShieldDescriptionHeader = ShieldDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.WeaponBonusDescription: WeaponBonusDescriptionHeader = WeaponBonusDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Accessory: AccessoryHeaders.Add(AccessoryHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.AccessoryDescription: AccessoryDescriptionHeader = AccessoryDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Hairstyle: HairstyleHeaders.Add(HairstyleHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.HairstyleDescription: HairstyleDescriptionHeader = HairstyleDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.HairstyleUnknownInfo: UnknownHairstyleInfoHeaders.Add(UnknownHairstyleInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BagItemTypeName: BagItemTypeNameHeaders.Add(BagItemTypeNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BagItem: BagItemHeaders.Add(BagItemHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BagItemDescription: BagItemDescriptionHeader = BagItemDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.LocalItem: LocalItemHeaders.Add(LocalItemHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.OffensiveMagic: OffensiveMagicHeaders.Add(OffensiveMagicHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.OffensiveMagicDescription: OffensiveMagicDescriptionHeader = OffensiveMagicDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.DefensiveMagic: DefensiveMagicHeaders.Add(DefensiveMagicHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DefensiveMagicDescription: DefensiveMagicDescriptionHeader = DefensiveMagicDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.FieldMagic: FieldMagicHeaders.Add(FieldMagicHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.FieldMagicDescription: FieldMagicDescriptionHeader = FieldMagicDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.BattleMagicTypeName: BattleMagicTypeNameHeaders.Add(BattleMagicTypeNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.FieldMagicTypeName: FieldMagicTypeNameHeaders.Add(FieldMagicTypeNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_6B: UnknownHeaders_6B.Add(UnknownHeader_6B.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BattleSkill: BattleSkillHeaders.Add(BattleSkillHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BattleSkillDescription: BattleSkillDescriptionHeader = BattleSkillDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.JobSkill: JobSkillHeaders.Add(JobSkillHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobSkillDescription: JobSkillDescriptionHeader = JobSkillDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_9F: UnknownHeader_9F = UnknownHeader_9F.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_D0: UnknownHeaders_D0.Add(UnknownHeader_D0.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D1: UnknownHeaders_D1.Add(UnknownHeader_D1.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D4: UnknownHeader_D4 = UnknownHeader_D4.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_D5: UnknownHeader_D5 = UnknownHeader_D5.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_D7: UnknownHeaders_D7.Add(UnknownHeader_D7.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DarkArtDescription: DarkArtDescriptionHeader = DarkArtDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.DarkArt: DarkArtHeaders.Add(DarkArtHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobFile2: JobFileHeaders2.Add(JobFileHeader2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobSalary: JobSalaryHeaders.Add(JobSalaryHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobLevelAndMastery: JobLevelAndMasteryHeaders.Add(JobLevelAndMasteryHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobBattleSkill: JobBattleSkillHeaders.Add(JobBattleSkillHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobDescription: JobDescriptionHeader = JobDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.JobLevelUpRequirement: JobLevelUpRequirementHeaders.Add(JobLevelUpRequirementHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobStartingStats: JobStartingStatsHeaders.Add(JobStartingStatsHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobUnknownInfo1: JobUnknownInfoHeaders1.Add(JobUnknownInfoHeader1.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobName: JobNameHeaders.Add(JobNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobUnknownInfo2: JobUnknownInfoHeaders2.Add(JobUnknownInfoHeader2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobItemSpace: JobItemSpaceHeaders.Add(JobItemSpacesHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobFile1: JobFileHeaders1.Add(JobFileHeader1.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobRequirement: JobRequirementHeaders.Add(JobRequirementHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_38: UnknownHeaders_38.Add(UnknownHeader_38.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_39: UnknownHeaders_39.Add(UnknownHeader_39.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_8F: UnknownHeaders_8F.Add(UnknownHeader_8F.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.EffectName1: EffectNameHeaders1.Add(EffectNameHeader1.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.EffectName2: EffectNameHeaders2.Add(EffectNameHeader2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.EffectName3: EffectNameHeaders3.Add(EffectNameHeader3.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_8C: UnknownHeader_8C = UnknownHeader_8C.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_8E: UnknownHeaders_8E.Add(UnknownHeader_8E.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9A: UnknownHeaders_9A.Add(UnknownHeader_9A.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9B: UnknownHeaders_9B.Add(UnknownHeader_9B.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9E: UnknownHeader_9E = UnknownHeader_9E.ReadHeaderBlock(stageFile); break;
                    case HeaderType.CPUNames: CPUNamesHeaders.Add(CPUNamesHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_17: UnknownHeaders_17.Add(UnknownHeader_17.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MonsterDescription: MonsterDescriptionHeader = MonsterDescriptionHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Monster: MonsterHeaders.Add(MonsterHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MonsterItemDrop: MonsterItemDropHeaders.Add(MonsterItemDropHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MonsterUnknownInfo: MonsterUnknownInfoHeaders1.Add(MonsterUnknownInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MonsterFileInfo: MonsterUnknownInfoHeaders2.Add(MonsterFileInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MonsterType: MonsterTypeHeaders.Add(MonsterTypeHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MonsterAITable: MonsterAITableHeaders.Add(MonsterAITableHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_52: UnknownHeaders_52.Add(UnknownHeader_52.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_54: UnknownHeaders_54.Add(UnknownHeader_54.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.NPCName: NPCNameHeaders.Add(NPCNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.NPCUnknownInfo: NPCUnknownInfoHeaders.Add(NPCUnknownInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.NPCFileInfo: NPCFileInfoHeaders.Add(NPCFileInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.EtcFileName: EtcFileNameHeaders.Add(EtcFileNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.TextureFileName: TextureFileNameHeaders.Add(TextureFileNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_2C: UnknownHeader_2C = UnknownHeader_2C.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_2D: UnknownHeaders_2D.Add(UnknownHeader_2D.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9D: UnknownHeader_9D = UnknownHeader_9D.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_9C: UnknownHeader_9C = UnknownHeader_9C.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_E1: UnknownHeader_E1 = UnknownHeader_E1.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_49: UnknownHeaders_49.Add(UnknownHeader_49.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_5C: UnknownHeaders_5C.Add(UnknownHeader_5C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_4D: UnknownHeader_4D=UnknownHeader_4D.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_4E: UnknownHeaders_4E.Add(UnknownHeader_4E.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_4F: UnknownHeader_4F=UnknownHeader_4F.ReadHeaderBlock(stageFile); break;
                    case HeaderType.ExperienceRequirement: ExperienceRequirementHeader = ExperienceRequirementHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.CPULevelUp: CPULevelUpHeader = CPULevelUpHeader.ReadHeaderBlock(stageFile);  break;
                    case HeaderType.DialogList: DialogListHeader = DialogListHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_E2: UnknownHeaders_E2.Add(UnknownHeader_E2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DialogPointerList: DialogPointerListHeaders.Add(DialogPointerListHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_46: UnknownHeaders_46.Add(UnknownHeader_46.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_47: UnknownHeader_47 = UnknownHeader_47.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_4C: UnknownHeaders_4C.Add(UnknownHeader_4C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_1C: UnknownHeaders_1C.Add(UnknownHeader_1C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_1D: UnknownHeader_1D = UnknownHeader_1D.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_1E: UnknownHeader_1E = UnknownHeader_1E.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_84: UnknownHeaders_84.Add(UnknownHeader_84.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_3F: UnknownHeaders_3F.Add(UnknownHeader_3F.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_48: UnknownHeaders_48.Add(UnknownHeader_48.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_DF: UnknownHeaders_DF.Add(UnknownHeader_DF.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D3: UnknownHeaders_D3.Add(UnknownHeader_D3.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D2: UnknownHeaders_D2.Add(UnknownHeader_D2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.InstructionsList: InstructionListHeader=InstructionListHeader.ReadHeaderBlock(stageFile); break;
                    case HeaderType.PrankName: PrankNameHeaders.Add(PrankNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_A0: UnknownHeader_A0=UnknownHeader_A0.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_A1: UnknownHeader_A1=UnknownHeader_A1.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_A2: UnknownHeader_A2= UnknownHeader_A2.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_A3: UnknownHeader_A3=UnknownHeader_A3.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_A4: UnknownHeader_A4=UnknownHeader_A4.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_A5: UnknownHeader_A5=UnknownHeader_A5.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_AD: UnknownHeader_AD=UnknownHeader_AD.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_AE: UnknownHeader_AE=UnknownHeader_AE.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_AF: UnknownHeader_AF=UnknownHeader_AF.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_B0: UnknownHeaders_B0.Add(UnknownHeader_B0.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_B1: UnknownHeader_B1=UnknownHeader_B1.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_B2: UnknownHeader_B2=UnknownHeader_B2.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_B3: UnknownHeaders_B3.Add(UnknownHeader_B3.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_B4: UnknownHeaders_B4.Add(UnknownHeader_B4.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_B5: UnknownHeaders_B5.Add(UnknownHeader_B5.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_B6: UnknownHeaders_B6.Add(UnknownHeader_B6.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_BD: UnknownHeaders_BD.Add(UnknownHeader_BD.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_BE: UnknownHeaders_BE.Add(UnknownHeader_BE.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.HitFormula: HitFormulaHeaders.Add(HitFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_79: UnknownHeader_79 = UnknownHeader_79.ReadHeaderBlock(stageFile); break;
                    case HeaderType.AttackFormula: AttackFormulaHeaders.Add(AttackFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MagicFormula: MagicFormulaHeaders.Add(MagicFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.StrikeFormula: StrikeFormulaHeaders.Add(StrikeFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.CounterFormula: CounterFormulaHeaders.Add(CounterFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.SelfAttackFormula: SelfAttackFormulaHeaders.Add(SelfAttackFormulaHeader.ReadHeaderBlock(stageFile)); break;

                    default:
                        Console.WriteLine("Unknown Header!"); break;
                }
            }
            /*
            ShieldDescriptionHeader.description[37] = "This shield sucks the essence \\nout of the user's soul.\0";
            AccessoryDescriptionHeader.description[13] = "A ring blessed by an angel.\\nIt can block negative \\n{c3}space effects.{c-}\0";
            AccessoryDescriptionHeader.description[16] = "A mysterious bracelet that\\nhalves damage from\\n{c3}lightning field magic{c-}.\0\0";
            AccessoryDescriptionHeader.description[28] = "This badge proves you're a\\ngood person. Its wearer's \\ncrimes are soon forgiven.\0\0\0";
            HairstyleDescriptionHeader.description[16] = "A cute little elephant hat. Don't ask\\nabout the pink elephant.\0";
            BagItemTypeNameHeaders[8].name = "Local Items\0";
            BagItemHeaders[71].name = "Rhine Dog\0\0\0";
            BagItemHeaders[72].name = "Yukon Dog\0\0\0";
            BagItemHeaders[73].name = "Cusco Dog\0\0\0";
            BagItemHeaders[74].name = "Strom Dog\0\0\0";
            BagItemHeaders[75].name = "Kalar Dog\0\0\0";
            BagItemDescriptionHeader.description[47] = "A stone tablet, filled with ancient\\nknowledge to create 'a body of steel.'\\nMaster {c2}Alchemist{c-} and {c2}Monk{c-} first. \0\0";
            BagItemDescriptionHeader.description[79] = "Stinky, gooey fermented soybeans. {c1}Not \\na favorite of our bearded King{c-}.\0";
            BagItemDescriptionHeader.description[81] = "Soup made from a shark's fin. {c1}The King{c-}\\n{c1}views it as a delicacy{c-}.\0";
            BagItemDescriptionHeader.description[107] = "A creamy-tasting shellfish. \0\0\0\0";
            BagItemDescriptionHeader.description[108] = "The patty is 3-inches thick! This is\\ntruly the king of burgers.\0\0\0\0";
            BagItemDescriptionHeader.description[142] = "Crunchy on the outside, empty on the\\ninside!? {c1}Naturally, the King hates this.{c-}\0\0";
            BagItemDescriptionHeader.description[145] = "Giant, rock-shaped souvenir candy. \0";
            BagItemDescriptionHeader.description[157] = "Awful smelling dried fish. Some people\\nlove it. {c1}The King is not one of them.{c-}\\nDeliver this item to {c2}{v36}.{c-}\0\0";
            BagItemDescriptionHeader.description[159] = "Stinky, gooey fermented soybeans. {c1}Not \\na favorite of our bearded King{c-}.\\nDeliver this item to {c2}{v36}.{c-}\0\0\0\0";
            BagItemDescriptionHeader.description[163] = "Veggies, rice, beef and a raw egg served\\nin a hot stone bowl. Cooks as you eat it!\\nDeliver this item to {c2}{v36}.{c-}\0\0\0\0";
            BagItemDescriptionHeader.description[166] = "A stong-smelling, pulpy drink made from\\npotatoes. {c1}The King dislikes it.{c-}\\nDeliver this item to {c2}{v36}.{c-}\0\0\0";
            BagItemDescriptionHeader.description[179] = "Strong smelling cheese with blue mold\\nthat the {c1}King really hates{c-}.\\nDeliver this item to {c2}{v36}.{c-}\0";
            BagItemDescriptionHeader.description[187] = "A creamy-tasting shellfish. \\nDeliver this item to {c2}{v36}.{c-}\0\0\0";
            BagItemDescriptionHeader.description[193] = "Carefully cut so that it weighs exactly\\n777 grams. (pre-cooked weight)\\nDeliver this item to {c2}{v36}.{c-}\0\0\0";
            BagItemDescriptionHeader.description[195] = "Served with seasoned meat inside a soft\\nor fried tortilla. A fiesta of flavor!\\nDeliver this item to {c2}{v36}.{c-}\0\0\0\0";
            BagItemDescriptionHeader.description[196] = "A yellow banana. Monkeys find it\\nirresistable!\\nDeliver this item to {c2}{v36}.{c-}\0\0\0\0";
            BagItemDescriptionHeader.description[200] = "Boring old beans. {c1}King would rather eat\\nhis own eyebrows than eat these.{c-}\\nDeliver this item to {c2}{v36}.{c-}\0\0";
            BagItemDescriptionHeader.description[202] = "Unfermented juice from maize morado.\\nSweetened and choc-full of antioxidants.\\nDeliver this item to {c2}{v36}.{c-}\0";
            BagItemDescriptionHeader.description[210] = "Don't be nervous; it's just shaped\\nlike a penguin. (Or is it?)\\nDeliver this item to {c2}{v36}.{c-}\0\0\0";
            BagItemDescriptionHeader.description[223] = "Juice made from sweet sweet fruits.\\nDeliver this item to {c2}{v36}.{c-}\0\0\0\0";
            OffensiveMagicDescriptionHeader.description[5] = "Summons a thunderstorm\\nto assault your foe with \\npowerful lightning bolts.\0\0\0\0";
            OffensiveMagicDescriptionHeader.description[12] = "Creates a mirror image of\\nyourself to attack your\\nopponent.\0";
            OffensiveMagicDescriptionHeader.description[13] = "Lets you quickly appear close \\nto your foe and attack!\0";
            OffensiveMagicDescriptionHeader.description[19] = "Steals your opponent's HP\\nand uses it for yourself.\0\0\0\0";
            FieldMagicDescriptionHeader.description[34] = "Causes a chosen player to lose \\na few {c2}items{c-} or {c2}field magic.{c-}\0\0\0\0";
            BattleSkillDescriptionHeader.description[0] = "Increases {c3}AT{c-} by {c3}50%{c-}.\0\0\0\0";
            BattleSkillDescriptionHeader.description[1] = "Increases {c3}AT and DF{c-} \\nby {c3}50%{c-}.\0\0\0";
            BattleSkillDescriptionHeader.description[2] = "Increases {c3}AT{c-} by {c3}200%{c-},\\nbut if it fails, {c3}AT{c-} is\\n{c3}halved{c-}.\0\0";
            BattleSkillDescriptionHeader.description[6] = "Increases {c3}AT and MG{c-}\\nby {c3}50%{c-}.\0\0\0\0";
            BattleSkillDescriptionHeader.description[7] = "Increases {c3}AT{c-} by {c3}50%{c-} \\nevery battle turn.\0\0\0\0";
            BattleSkillDescriptionHeader.description[8] = "Increases {c3}all stats{c-} \\nby {c3}50%{c-}, but your {c1}HP will\\nbe halved{c-} after battle.\0";
            BattleSkillDescriptionHeader.description[9] = "Increases random stats\\nby {c3}50%{c-}.\0";
            BattleSkillDescriptionHeader.description[12] = "Seals a random battle \\ncommand.\0\0\0\0";
            BattleSkillDescriptionHeader.description[17] = "Seals the opponent's\\n{c1}Give Up{c-} and \\n{c1}Counter{c-} commands.\0\0\0";
            BattleSkillDescriptionHeader.description[23] = "Recovers half your {c3}HP{c-}\\nand cures certain \\n{c3}status ailments.{c-}\0";
            BattleSkillDescriptionHeader.description[25] = "Creates {c3}money{c-}\\nfrom {c2}damage{c-} taken \\nby anyone in battle.\0";
            BattleSkillDescriptionHeader.description[31] = "{c2}Nullifies magic attacks{c-}\\nfor a few turns, but \\nsometimes fails.\0\0\0\0";
            BattleSkillDescriptionHeader.description[33] = "Copies the opponent's\\nstats if they are \\n{c2}higher than yours.{c-}\0\0\0";
            BattleSkillDescriptionHeader.description[45] = "Destroys an opponent's\\n{c1}equipment{c-} with a \\n50％ success rate.\0\0\0";
            JobDescriptionHeader.description[6] = "Helps others with holy powers. \\nTheir gift comes from faith.\0\0\0";
            JobDescriptionHeader.description[7] = "Helps others with holy powers. \\nTheir gift comes from faith.\0\0\0";
            EffectNameHeaders1[0].name = "poison\0\0";
            EffectNameHeaders1[4].name = "curse\0\0\0";
            EffectNameHeaders1[9].name = "Z Plague\0\0\0\0";
            EffectNameHeaders2[0].name = "sleep\0\0\0";
            EffectNameHeaders2[4].name = "squeeze\0";
            EffectNameHeaders2[5].name = "shock\0\0\0";
            EffectNameHeaders2[6].name = "charmed\0";
            EffectNameHeaders2[7].name = "oetrified\0\0\0";
            EffectNameHeaders2[8].name = "confused\0\0\0\0";
            EffectNameHeaders2[9].name = "blinded\0";
            EffectNameHeaders3[5].name = "footsore\0\0\0\0";
            EffectNameHeaders3[6].name = "paralysis\0\0\0";
            EffectNameHeaders3[7].name = "fear\0\0\0\0";
            EffectNameHeaders3[8].name = "seal\0\0\0\0";
            EffectNameHeaders3[9].name = "quake\0\0\0";
            UnknownHeaders_17[7].unknownBytes[0] = 0xE0;
            UnknownHeaders_17[7].unknownBytes[1] = 0xE0;
            UnknownHeaders_17[7].unknownBytes[2] = 0xE0;
            MonsterDescriptionHeader.description[55] = "Wind spirits that like playing tricks.\\nThey're said to cause the slicing\\nwinds of the kamaitachi.\0";
            MonsterDescriptionHeader.description[57] = "Wind spirits that like playing tricks.\\nThey're said to cause the winds that\\nallow kamaitachi to move so quickly.\0\0";
            MonsterDescriptionHeader.description[109] = "A snake-haired woman who can turn people\\nto stone with her eyes. She feeds her\\nvictims to the snakes on her head.\0";
            MonsterDescriptionHeader.description[128] = "They're very cute, but they carry\\nZ Plague! If they attack you with their\\nteeth or claws, you'll be infected.\0";
            MonsterDescriptionHeader.description[133] = "Hard-working earth spirits. They're\\nweaponsmiths who are quite good with\\ntheir hands, despite their appearances.\0\0";
            MonsterDescriptionHeader.description[134] = "A squid that lives a lazy life under the\\nsea: sleeping, reading magazines, and\\neating anything that comes close enough.\0\0\0";

            UnknownHeaders_E2[0].unknownBytes[1] = 0x14;
            UnknownHeaders_E2[1].unknownBytes[1] = 0x14;
            UnknownHeaders_E2[12].unknownBytes[1] = 0x14;
            UnknownHeaders_E2[13].unknownBytes[0] = 0x46;
            UnknownHeaders_E2[13].unknownBytes[1] = 0x1E;
            UnknownHeaders_E2[13].unknownBytes[2] = 0x00;
            UnknownHeaders_E2[14].unknownBytes[0] = 0x46;
            UnknownHeaders_E2[14].unknownBytes[1] = 0x1E;
            UnknownHeaders_E2[14].unknownBytes[2] = 0x00;
            UnknownHeaders_E2[15].unknownBytes[0] = 0x46;
            UnknownHeaders_E2[15].unknownBytes[1] = 0x1E;
            UnknownHeaders_E2[15].unknownBytes[2] = 0x00;
            UnknownHeaders_E2[16].unknownBytes[0] = 0x46;
            UnknownHeaders_E2[16].unknownBytes[1] = 0x1E;
            UnknownHeaders_E2[16].unknownBytes[2] = 0x00;

            DialogListHeader.dialog[86] = "This is the secret location where we\\nintroduce the Sting and Atlus USA staff\\nthat participated in making Dokapon Kingdom.\\k\0\0";
            DialogListHeader.dialog[87] = "We hope you're enjoying the game.\\nThanks for playing!\\nSee you!\\k\0";
            DialogListHeader.dialog[88] = "{K14,28}{Y10}{c2}～　Sting Staff　～{c-}\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Character Design{C255,104,0}{k26}★{c-}\\n{K13,26}{Y10}Eiko Tameshige\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Sound{C255,104,0}{k26}★{c-}\\n{K13,26}{Y10}Shigeki Hayashi\0\0\0";
            DialogListHeader.dialog[89] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Programming{C255,104,0}{k26}★{c-}\\n\\n{K13,26}{Y10}Noboru Fujisawa\\n{Y10}Hiroaki Katagiri\\n{Y10}Umeki Matsuhashi\0";
            DialogListHeader.dialog[90] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Characters{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Akito Kuroda\\n{Y8}Yasuhito Kuwayama\\n{Y8}Hideharu　Ishii\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Effects{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Yoshirou Hayashi\\n\0";
            DialogListHeader.dialog[91] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Map{C255,104,0}{k26}★{c-}\\n{K13,26}{Y10}Yousuke　Tachibana\\n{Y10}Miyuki Yamada\\n{Y10}Miyuki Makimura\0\0";
            DialogListHeader.dialog[92] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Manager{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Daisuke Murakami\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Planning{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Shigeto Yasuda\\n{Y10}Masahiro Kobayashi\0\0";
            DialogListHeader.dialog[93] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Marketing{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Yoshihisa Tomita\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Web Design{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Kaori Hijiya\\n\0\0\0";
            DialogListHeader.dialog[94] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Special Thanks{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Everyone who helped development\\n{Y10}Everyone at Sting\\n\0\0";
            DialogListHeader.dialog[95] = "\\n\\n\\n{k30}{C255,104,0}★{c-}{K15,30}The King of Dokapon{C255,104,0}{k30}★{c-}\\n\\n{K13,26}Takeshi Santo\\n\0\0";
            DialogListHeader.dialog[96] = "\\n\\n{k26}{C255,104,0}★{c-}{K13,26}US Localization{C255,104,0}{k26}★{c-}\\n\\n{K13,26}Atlus USA\\n\0\0\0\0";
            DialogListHeader.dialog[97] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Executive Producer{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Shinichi Suzuki\\n\\n{k26}{C255,104,0}★{c-}{K13,26}General Manager{C255,104,0}{k26}★{c-}\\n{K13,26}{Y10}Mitsuhiro Tanaka\0\0\0\0";
            DialogListHeader.dialog[98] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Director of Production{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Bill Alexander\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Project Lead{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Samuel Mullen\\n\0";
            DialogListHeader.dialog[99] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Project Coordinators{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Hiroyuki Tanaka\\n{Y10}Yu Namba\\n\0";
            DialogListHeader.dialog[100] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Translators{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Madoka Ueno\\n{Y10}Alex Britton\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Editors{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Mike Meeker\\n{Y10}Clayton S. Chan\\n\0";
            DialogListHeader.dialog[101] = "\\n{k26}{C255,104,0}★{c-}{K13,26}QA Manager{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Carl Chen\\n\\n{k26}{C255,104,0}★{c-}{K13,26}QA Leads{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Richard Rodrigues\\n{Y10}Victor Gonzalez\\n\0\0\0\0";
            DialogListHeader.dialog[102] = "\\n{k26}{C255,104,0}★{c-}{K13,26}QA Testers{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Christian Baptiste\\n{Y8}Cynthia Ungson\\n{Y8}Joel Ellis\\n{Y8}Meriel Regodon\\n{Y8}Scott Williams\\n\0\0\0";
            DialogListHeader.dialog[103] = "\\n{k26}{C255,104,0}★{c-}{K13,26}V.P. Sales & Marketing{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Tim Pivnicny\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Creative Designers{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Jeremy Cail\\n{Y10}Michiko Shiikuma\\n\0\0\0\0";
            DialogListHeader.dialog[104] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Web Designer{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Amanda Dalgleish\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Media Assistant{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Hans Christian L. Pena\\n\0";
            DialogListHeader.dialog[105] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Public Relations{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Aram Jabbari\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Marketing{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Robyn Mukai\\n\0";
            DialogListHeader.dialog[106] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Sales Admin. Manager{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Sally Ortiz\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Sales Administrator{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Monica Lee\\n\\n{k26}{C255,104,0}★{c-}{K13,26}Voice Recording{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}PCB Productions\\n\0";
            DialogListHeader.dialog[107] = "\\n{k26}{C255,104,0}★{c-}{K13,26}Special Thanks{C255,104,0}{k26}★{c-}\\n{K13,26}{Y15}Everyone at Atlus USA\\n\0\0\0\0";
            DialogListHeader.dialog[108] = "\\n\\n\\n{K15,30}And...\\nYOU\\nThe Player!\\nThank you so much!\\n\0";
            DialogListHeader.dialog[109] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[110] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[111] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[112] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[113] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[114] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[115] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[116] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[117] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[118] = DialogListHeader.dialog[120];
            DialogListHeader.dialog[119] = DialogListHeader.dialog[120];
            var temp = DialogListHeader.dialog[131];
            DialogListHeader.dialog[131] = DialogListHeader.dialog[133];
            DialogListHeader.dialog[133] = temp;
            temp = DialogListHeader.dialog[144];
            DialogListHeader.dialog[144] = DialogListHeader.dialog[146];
            DialogListHeader.dialog[146] = temp;
            DialogListHeader.dialog[190] = "Stats have decreased: {c1}AT{c-} {c1}-1{c-}, {c1}DF{c-} {c1}-1{c-}、\\n{c1}MG{c-} {c1}-1{c-}, {c1}SP{c-} {c1}-1{c-}!\\n{c1}All stats{c-} have decreased by {c1}1{c-}!\\k\0";
            DialogListHeader.dialog[197] = "{c2}{v10}{c-} has received\\n{c1}{v11}{c-}!\\k\0";
            DialogListHeader.dialog[221] = "{W480}My initial analysis shows that there are other \\ncarbon-based lifeforms harassing you.\\k\0";
            DialogListHeader.dialog[259] = "{c2}{v0}{c-}{c2}{v1}{c-}\\nlost all money!\\k\0";
            DialogListHeader.dialog[303] = "Selecting the battle order...\\nPress {k24}{I94}{K12,24} when ready.\0";
            DialogListHeader.dialog[336] = "{c2}{v2}{c-}...\\n{W315}That sure looks... Uh... Interesting.\\k\0";
            DialogListHeader.dialog[413] = "{W476}Please, play again another time.\\nWell then, if you will excuse me...\\k\0";
            DialogListHeader.dialog[464] = "{W0}I can't buy that \\nitem, sorry.\0";
            DialogListHeader.dialog[465] = "{W0}You don't have any thing to sell!\0";
            DialogListHeader.dialog[471] = "{W0}Okay chump. Bring it on!\\k\0";
            DialogListHeader.dialog[485] = "{W0}Hmm, a {c2}{v0}{c-}, meow.\\nAfter trading in your {c2}{v5}{c-} \\nit'll be {c2}{v6}{c-}G, meow. Okay?\0";
            DialogListHeader.dialog[605] = "Press {k24}{i94}{K12,24} to start.\\k\0";
            DialogListHeader.dialog[657] = "There are no taxes.\\nYou do not have enough cash.\\k\0";
            DialogListHeader.dialog[686] = "Whoever collects the most money\\nin the time specified will be the winner!\\nPress {k24}{I94}{K11,24} to change the time limit.\0";
            DialogListHeader.dialog[873] = "{W516}Ohhh?@You donft have\\nany equipment, {c2}{v0}{c-}!\\nIt's so sad... I'm getting all weepy...\\k\0";
            DialogListHeader.dialog[893] = "{W197}Oh, Penny......\\nYou are such a loyal daughter...\\k\0";
            DialogListHeader.dialog[1207] = "Bring me pictures of the puppies\\nfrom {c2}{v7}{c-}{c2}{v8}{c-}.\\k\0";
            DialogListHeader.dialog[1210] = "Bring me pictures of the puppies\\nfrom {c2}{v7}{c-}{c2}{v8}{c-}.\\k\0";
            DialogListHeader.dialog[1254] = "I want to give her the very valuable\\n{c2}Monroe Flower{c-}, which only blooms\\non the {c2}Daunting Mountain{c-}. \\k\0";
            DialogListHeader.dialog[1297] = "{c2}{v6}{c-}\\n{c2}{v7}{c-}got {c3}{v2}{c-}G!\\k\0";
            DialogListHeader.dialog[1350] = "Start the spinner with the {k24}{I94}{K12,24} button!\0";
            DialogListHeader.dialog[1351] = "Use {c2}Skeleton Key{c-} with {k24}{I97}{K12,24}.\0";
            DialogListHeader.dialog[1361] = "{c2}{v0}{c-} dropped a\\n{c1}{v4}{c-}{c1}{v5}{c-}!\\k\0";
            DialogListHeader.dialog[1628] = "We'll decide what order to draw cards in.\\nPush {k24}{I94}{K12,24} at any time.\0";
            DialogListHeader.dialog[1641] = "Enter the amount to invest. Press left or right\\nto move the cursor. Press up or down to change\\nthe amount. Confirm with {k24}{i94}{K12,24}\0";
            DialogListHeader.dialog[1642] = "Press the {k24}{I94}{K12,24} button to start.\\k\0";
            DialogListHeader.dialog[1661] = "{c2}{v17}{c-} threw the\\n{c1}{v11}{c-} away.\\k\0";
            DialogListHeader.dialog[1666] = "{c2}{v30}{c-} now has\\n{c1}Z Plague{c-}!\0";
            DialogListHeader.dialog[1677] = "The {c1}Reaper{c-} has visited {c2}{v30}{c-}!\\n{c1}{v1}{c-} turns until death...\0";
            DialogListHeader.dialog[1686] = DialogListHeader.dialog[1687];
            DialogListHeader.dialog[1687] = "{c2}{v30}{c-}'s {c1}Battle Magic{c-}\\nhas been {c1}sealed{c-}!\\k\0";
            DialogListHeader.dialog[1706] = "{c2}{v30}{c-} was cured\\nof {c1}Z Plague{c-}!\0";
            DialogListHeader.dialog[1710] = "{c2}{v30}{c-} can now use\\n{c2}{v31}{c-}. \\k\0";
            DialogListHeader.dialog[1736] = "{c2}{v30}{c-} took damage\\nfrom {c1}Z Plague{c-}!\0";
            DialogListHeader.dialog[1755] = "Take an accessory!\0";
            DialogListHeader.dialog[1766] = "Throw away all their cash!({c1}{v12}{c-}G)!\0";
            DialogListHeader.dialog[1773] = "Your bag is full.\\nPlease choose {c1}{v30}{c-} {v31} to throw away.\0";
            DialogListHeader.dialog[1832] = "The {c1}Reaper{c-} draws close, {c2}{v30}{c-}! \\nThe only way to call him off is\\nto defeat {c1}{v31}{c-}!\\k\0";
            DialogListHeader.dialog[1835] = "{c2}{v30}{c-}'s\\n{c1}{v31}{c-}\\n{c1}{v32}{c-} disappeared!\\k\0";
            DialogListHeader.dialog[1853] = "{c2}{v31}{c-}\\n{c2}{v32}{c-}\\nswitched places!\\k\0";
            DialogListHeader.dialog[1854] = "{c2}{v31}{c-}\\n{c2}{v32}{c-}'s\\n{c2}{v33}{c-} got switched!\\k\0";
            DialogListHeader.dialog[1893] = "Lost {c1}{v12}{c-}G!\\k\0";
            DialogListHeader.dialog[1908] = "{c2}{v30}{c-} has been forced to\\naccept {c2}bad items{c-}!\\k\0";
            DialogListHeader.dialog[1927] = "{c2}{v30}{c-}'s {c1}{v31}{c-},\\n{c1}{v32}{c-}, and {c1}{v33}{c-}\\ndisappeared!\\k\0";


            DialogListHeader.dialog.RemoveRange(1232, 5);
            DialogListHeader.dialogPointer.RemoveRange(1232, 5);

            DialogPointerListHeaders[68].dialogPointer.RemoveRange(36, 5);

            InstructionListHeader.instructions[1] = "{z26}Dokapon Knowledge\\n\\nIn Dokapon Kingdom, the player who ends\\nthe game with the most {k22}{i112}{X2}{K11,22}{z26}{c2}money{c-}\\n{c1}is the winner!{c-}\\n\\nThe other adventurers are your rivals!\\nDon't let them take the thrill of\\nvictory from you!\\n\\n{c1}Show no mercy!{c-} You must break them!\\n{c2}That is the Dokapon way!{c-}\0";
            InstructionListHeader.instructions[3] = "{z26}{c2}Empty Spaces{c-}\\nMost will send you into battle with\\n{k22}{i121}{X2}{K11,22}{z26}monsters. Sometimes, you'll trigger\\nan encounter with a colorful character.\\n\\n{c2}Loot Spaces{c-}\\nYou can get some primo loot on these\\nspaces! Score {k22}{i1}{X2}{K11,22}{z26}items, {k22}{i2}{X2}{K11,22}{z26}field magic,\\n{k22}{i74}{X2}{K11,22}{z26}equipment, and even {k22}{i112}{X2}{K11,22}{z26}money!\\nWith so many types of treasure, make\\nsure you use some strategy and grab\\nthe loot that's right for you!\0";
            InstructionListHeader.instructions[5] = "{z26}{c2}Dokapon Castle Space{c-}\\nYou can switch jobs, change your hairdo,\\nand give gifts to the King here.\\n{c2}Castle Spaces{c-}\\nYou can spend the night here. If you\\nown the castle, you can invest in it.\\n{c2}Town Spaces{c-}\\nYou can collect taxes and Local Items.\\n{c2}Shop Spaces{c-}\\nYou can buy many useful things here,\\nsuch as items and equipment.\\n\0";
            InstructionListHeader.instructions[7] = "{z26}{c2}Temple Spaces{c-}\\nYou can get status ailments treated\\nhere. You can also send the King gifts.\\nIf you visit a temple, you will be\\nrevived at that temple when you die.\0";
            InstructionListHeader.instructions[9] = "{z26}You can {k22}{i111}{X2}{K11,22}{z26}{c2}switch jobs{c-} at {c2}Dokapon Castle{c-}.\\nSome things change when you switch jobs:\\n{k22}{i92}{X2}{K11,22}{z26}Field Skills\\n{k22}{i93}{X2}{K11,22}{z26}Battle Skills\\n{k22}{i1}{X2}{K11,22}{z26}Item and {k22}{i2}{X2}{K11,22}{z26}field magic capacity\\n{k22}{i112}{X2}{K11,22}{z26}Salary\\nYour {k22}{i105}{X2}{K11,22}{z26}Level Up stat increases\\n\\n{c2}Make sure to keep an eye on your stats!{c-}\\nKeep your stats balanced!\0";
            InstructionListHeader.instructions[11] = "{k22}{i1}{X2}{K11,22}{z26}{c2}Items{c-} have a variety of effects.\\nYou can restore HP, increase attack...\\nBasically, all kinds of good things.\\n{k22}{i5}{X2}{K11,22}{z26}{c2}Spinners{c-} increase the number\\nof spinners you spin and {k22}{i3}{X2}{K11,22}{z26}{c2}crystals{c-}\\nset the number of spaces you move.\\n\\nIn Dokapon, it's important to get\\nto your destination quickly! {k22}{i5}{X2}{K11,22}{z26}{c2}Spinners{c-}\\nand {k22}{i3}{X2}{K11,22}{z26}{c2}crystals{c-} are essential {k22}{i1}{X2}{K11,22}{z26}{c2}items{c-}\\nfor good Dokapon strategy. Proper usage\\nwill allow you to optimize your moves!\0";
            InstructionListHeader.instructions[13] = "{k22}{i2}{X2}{K11,22}{z26}Field magic{c-} can inflict damage on\\nyour opponents or give them status\\nailments. Sometimes, they'll have\\ncompletely random effects.\\n\\n{k22}{i2}{X2}{K11,22}{z26}{c2}Field magic{c-} spells are most\\neffective when someone with high \\n{k22}{i108}{X2}{K11,22}{z26}{c2}MG{c-} is casting them.\\n\\nBut it's hard to hit a target who has a\\nhigher {k22}{i109}{X2}{K11,22}{z26}{c2}SP{c-} than you, so watch out!\0";
            InstructionListHeader.instructions[15] = "{z26}Try and predict your opponent's defense!\\n\\n{k22}{i224}{X2}{K11,22}{z26}{c2}Attack{c-} is weak against {k22}{i224}{X2}{K11,22}{z26}{c1}Defend{c-}!\\nYou will be able to safely inflict damage!\\n{k22}{i223}{X2}{K11,22}{z26}{c2}Strike{c-} is weak against {k22}{i223}{X2}{K11,22}{z26}{c1}Counter{c-}!\\nYou can do tremendous damage, but if you\\nget countered, you'll be in trouble!\\n{k22}{i221}{X2}{K11,22}{z26}{c1}Off. Magic{c-} is weak against {k22}{i221}{X2}{K11,22}{z26}{c2}Def. Magic{c-}!\\nUse your {k22}{i91}{X2}{K11,22}{z26}Offensive Magic wisely!\\n{k22}{i222}{X2}{K11,22}{z26}{c2}Skills{c-}\\nUse your {k22}{i93}{X2}{K11,22}{z26}Battle Skills!\0";
            InstructionListHeader.instructions[16] = "{z26}Try and predict your opponent's defense!\\n\\n{k22}{i97}{X2}{K11,22}{z26}{c2}Attack{c-} is weak against {k22}{i97}{X2}{K11,22}{z26}{c1}Defend{c-}!\\nYou will be able to safely inflict damage!\\n{k22}{i95}{X2}{K11,22}{z26}{c2}Strike{c-} is weak against {k22}{i95}{X2}{K11,22}{z26}{c1}Counter{c-}!\\nYou can do tremendous damage, but if you\\nget countered, you'll be in trouble!\\n{k22}{i96}{X2}{K11,22}{z26}{c1}Off. Magic{c-} is weak against {k22}{i96}{X2}{K11,22}{z26}{c2}Def. Magic{c-}!\\nUse your {k22}{i91}{X2}{K11,22}{z26}Offensive Magic wisely!\\n{k22}{i94}{X2}{K11,22}{z26}{c2}Skills{c-}\\nUse your {k22}{i93}{X2}{K11,22}{z26}Battle Skills!\0";
            InstructionListHeader.instructions[17] = "{z26}Try and predict your opponent's defense!\\n\\n{k22}{i94}{X2}{K11,22}{z26}{c2}Attack{c-} is weak against {k22}{i94}{X2}{K11,22}{z26}{c1}Defend{c-}!\\nYou will be able to safely inflict damage!\\n{k22}{i97}{X2}{K11,22}{z26}{c2}Strike{c-} is weak against {k22}{i97}{X2}{K11,22}{z26}{c1}Counter{c-}!\\nYou can do tremendous damage, but if you\\nget countered, you'll be in trouble!\\n{k22}{i96}{X2}{K11,22}{z26}{c1}Off. Magic{c-} is weak against {k22}{i96}{X2}{K11,22}{z26}{c2}Def. Magic{c-}!\\nUse your {k22}{i91}{X2}{K11,22}{z26}Offensive Magic wisely!\\n{k22}{i95}{X2}{K11,22}{z26}{c2}Skills{c-}\\nUse your {k22}{i93}{X2}{K11,22}{z26}Battle Skills!\0";
            InstructionListHeader.instructions[19] = "{z26}Try and predict your enemy's attack!\\n\\n{k22}{i224}{X2}{K11,22}{z26}{c2}Defend{c-} is strong against {k22}{i224}{X2}{K11,22}{z26}{c3}Attack{c-}!\\nYou can reduce the damage taken!\\n{k22}{i223}{X2}{K11,22}{z26}{c2}Counter{c-} is strong against {k22}{i223}{X2}{K11,22}{z26}{c3}Strike{c-}!\\nEvade {c2}Strike{c-} and bust out a Counter!\\n{k22}{i221}{X2}{K11,22}{z26}{c2}Off. Magic{c-} is weak against {k22}{i221}{X2}{K11,22}{z26}{c3}Def. Magic{c-}!\\n{c2}Defend against magic with Def. Magic!\\n{k22}{i222}{X2}{K11,22}{z26}{c2}Give Up{c-}\\nScared to fight? You can give up. Wimp.\0";
            InstructionListHeader.instructions[20] = "{z26}Try and predict your enemy's attack!\\n\\n{k22}{i97}{X2}{K11,22}{z26}{c2}Defend{c-} is strong against {k22}{i97}{X2}{K11,22}{z26}{c3}Attack{c-}!\\nYou can reduce the damage taken!\\n{k22}{i95}{X2}{K11,22}{z26}{c2}Counter{c-} is strong against {k22}{i95}{X2}{K11,22}{z26}{c3}Strike{c-}!\\nEvade {c2}Strike{c-} and bust out a Counter!\\n{k22}{i96}{X2}{K11,22}{z26}{c2}Off. Magic{c-} is weak against {k22}{i96}{X2}{K11,22}{z26}{c3}Def. Magic{c-}!\\n{c2}Defend against magic with Def. Magic!\\n{k22}{i94}{X2}{K11,22}{z26}{c2}Give Up{c-}\\nScared to fight? You can give up. Wimp.\0";
            InstructionListHeader.instructions[21] = "{z26}Try and predict your enemy's attack!\\n\\n{k22}{i94}{X2}{K11,22}{z26}{c2}Defend{c-} is strong against {k22}{i94}{X2}{K11,22}{z26}{c3}Attack{c-}!\\nYou can reduce the damage taken!\\n{k22}{i97}{X2}{K11,22}{z26}{c2}Counter{c-} is strong against {k22}{i97}{X2}{K11,22}{z26}{c3}Strike{c-}!\\nEvade {c2}Strike{c-} and bust out a Counter!\\n{k22}{i96}{X2}{K11,22}{z26}{c2}Off. Magic{c-} is weak against {k22}{i96}{X2}{K11,22}{z26}{c3}Def. Magic{c-}!\\n{c2}Defend against magic with Def. Magic!\\n{k22}{i95}{X2}{K11,22}{z26}{c2}Give Up{c-}\\nScared to fight? You can give up. Wimp.\0";
            InstructionListHeader.instructions[23] = "{k22}{i93}{X2}{K11,22}{z26}{c2}Battle skills{c-} are skills you can use \\nin battle that have a special effect.\\nDifferent {k22}{i111}{X2}{K11,22}{z26}{c2}jobs{c-} gain different skills.\\n\\nSome {k22}{i93}{X2}{K11,22}{z26}{c2}battle skills{c-} work\\n{c3}all the time{c-} and some don't.\\n\\nDepending how you use them,\\nthey can affect the outcome of battle,\\nso use them wisely!\0";
            InstructionListHeader.instructions[25] = "{z26}When you earn enough experience from\\nwinning battles, you will {k22}{i105}{X2}{K11,22}{z26}{c2}Level Up!{c-} \\nWhen you {k22}{i105}{X2}{K11,22}{z26}{c2}Level Up{c-}, your HP \\n{c2}fully recovers{c-} and your {c2}stats{c-} increase.\\n\\nSome stats will increase automatically.\\n{c2}You can allocate points to increase{c-}\\n{c2}others.{c-} Remember to stay balanced.\\nStat increases vary by your {k22}{i111}{X2}{K11,22}{z26}{c2}job \\nand jobs you have {c2}mastered{c-}.\\nTry your hand at many {k22}{i111}{X2}{K11,22}{z26}jobs!\0";
            InstructionListHeader.instructions[27] = "{z26}If you continue winning battles and keep\\nthe same job, your {c2}Job Level{c-} goes up.  \\nThere are {c2}6 levels{c-} for each {c2}Job{c-}.\\nYour pay and the jobs you can switch to\\ndepend on what Job Level you are!\\nEven after you switch, the {c2}Job Level{c-}\\nyou earned won't decrease!\\n\\nBy {k22}{i127}{X2}{K11,22}{z26}{c2}mastering{c-} a job, \\nyou will earn {c3}Bonus Points{c-} for your\\nstats every time you {k22}{i105}{X2}{K11,22}{z26}Level Up! \\nSo, be sure to {k22}{i127}{X2}{K11,22}{z26}{c2}master{c-} your job!\0";
            InstructionListHeader.instructions[29] = "Battle Help functions\\n\\n{k22}{i219}{X2}{K11,22}{z26}{c2}Information{c-}\\nGain intel on the enemy's {k22}{i91}{X2}{K11,22}{z26}Off. Magic,\\n{k22}{i93}{X2}{K11,22}{z26}Battle Skills, or their {k22}{i92}{X2}{K11,22}{z26}Def. Magic.\\n\\n{k22}{i220}{X2}{K11,22}{z26}{c2}Predictions{c-}\\nProvides you with an estimate of the\\nresults you'll get for each command.\\nYou can't use this on {c2}monsters you're{c-}\\n{c2}battling for the first time{c-}.\0";
            InstructionListHeader.instructions[30] = "Battle Help functions\\n\\n{k22}{i240}{X2}{K11,22}{z26}{c2}Information{c-}\\nGain intel on the enemy's {k22}{i91}{X2}{K11,22}{z26}Off. Magic,\\n{k22}{i93}{X2}{K11,22}{z26}Battle Skills, or their {k22}{i92}{X2}{K11,22}{z26}Def. Magic.\\n\\n{k22}{i241}{X2}{K11,22}{z26}{c2}Predictions{c-}\\nProvides you with an estimate of the\\nresults you'll get for each command.\\nYou can't use this on {c2}monsters you're{c-}\\n{c2}battling for the first time{c-}.\0";
            InstructionListHeader.instructions[31] = "Battle Help functions\\n\\n{k22}{i98}{X2}{K11,22}{z26}{c2}Information{c-}\\nGain intel on the enemy's {k22}{i91}{X2}{K11,22}{z26}Off. Magic,\\n{k22}{i93}{X2}{K11,22}{z26}Battle Skills, or their {k22}{i92}{X2}{K11,22}{z26}Def. Magic.\\n\\n{k22}{i99}{X2}{K11,22}{z26}{c2}Predictions{c-}\\nProvides you with an estimate of the\\nresults you'll get for each command.\\nYou can't use this on {c2}monsters you're{c-}\\n{c2}battling for the first time{c-}.\0";
            InstructionListHeader.instructions[33] = "{z26}{c2}Total Assets{c-} are made up of three parts.\\n\\n{c2}Cash{c-}\\nThe money you currently have on-hand.\\n{c2}Local Items{c-}\\nThe King will add the worth of all the\\ngifts you give him to your total assets.\\n{c2}Town Worth{c-}\\nThe value of all your towns and castles.\0";
            InstructionListHeader.instructions[35] = "{z26}{c3}Local Items{c-} can be obtained at\\ntowns you own and through events.\\nYou can sell them, but if you send them\\nto the King, he'll add the value to your\\ntotal assets... If he likes the gift.\\n\\nIt's better to send {c3}Local Items{c-}\\nto the King rather than sell them.\\nIf you send the King a Local Item he\\n{c1}hates{c-}, he will {c1}subtract money from\\n{c1}your total assets{c-}, so be careful!\\nSend those under {c2}someone else's name{c-}!\0";
            InstructionListHeader.instructions[37] = "{k22}{i53}{X2}{K11,22}{z26}{c1}Footsore{c-}\\n  You can only move one space.\\n{k22}{i55}{X2}{K11,22}{z26}{c1}Paralysis{c-}\\n  You can't move for a few turns.\\n{k22}{i56}{X2}{K11,22}{z26}{c1}Fear{c-}\\n  You can't initiate combat.\\n{k22}{i57}{X2}{K11,22}{z26}{c1}Seal{c-}\\n  You can't use items.\\n{k22}{i58}{X2}{K11,22}{z26}{c1}Doom{c-}\\n  You'll die after a set number of turns\\n  unless you kill whoever doomed you.\\n\0";
            InstructionListHeader.instructions[39] = "{k22}{i63}{X2}{K11,22}{z26}{c1}Wanted{c-}\\n  You will be unable to enter buildings.\\n{k22}{i51}{X2}{K11,22}{z26}{c1}Poison{c-}\\n  Your HP will decrease each turn.\\n{k22}{i52}{X2}{K11,22}{z26}{c1}Z Plague{c-}\\n  A deadly, contagious virus.\0";
            InstructionListHeader.instructions[41] = "{k22}{i60}{X2}{K11,22}{z26}{c1}Confusion{c-}\\n  Your battle commands are randomized.\\n{k22}{i61}{X2}{K11,22}{z26}{c1}Curse{c-}\\n  You may attack yourself.\\n{k22}{i62}{X2}{K11,22}{z26}{c1}Blindness{c-}\\n  Your hit rate drops dramatically.\\n{k22}{i59}{X2}{K11,22}{z26}{c1}Seal{c-}\\n  Some commands may be locked.\\n{k22}{i59}{X2}{K11,22}{z26}{c1}Charm{c-}\\n  You can't use attack or counter.\0";
            InstructionListHeader.instructions[43] = "{k22}{i59}{X2}{K11,22}{z26}{c1}Attack Magic Seal{c-}\\n  You can't use {c2}Offensive Magic{c-}.\\n{k22}{i59}{X2}{K11,22}{z26}{c1}Battle Magic Seal{c-}\\n  {c2}Offensive & Defensive Magic{c-} are locked.\\n{k22}{i59}{X2}{K11,22}{z26}{c1}Bound{c-}\\n  {c2}Give up and Counter{c-} are locked.\\n{k22}{i59}{X2}{K11,22}{z26}{c1}Squeeze{c-}\\n  You're stuck fast and unable to move.\\n{k22}{i59}{X2}{K11,22}{z26}{c1}Petrification{c-}\\n  You can't do anything!\0";
            InstructionListHeader.instructions[45] = "{k22}{i64}{X2}{K11,22}{z26}{c1}AT DOWN{c-}\\n  Your {k22}{i106}{X2}{K11,22}{z26}{c2}AT{c-} will go down.\\n{k22}{i65}{X2}{K11,22}{z26}{c1}DF DOWN{c-}\\n  Your {k22}{i107}{X2}{K11,22}{z26}{c2}DF{c-} will go down.\\n{k22}{i66}{X2}{K11,22}{z26}{c1}MG DOWN{c-}\\n  Your {k22}{i108}{X2}{K11,22}{z26}{c2}MG{c-} will go down.\\n{k22}{i67}{X2}{K11,22}{z26}{c1}SP DOWN{c-}\\n  Your {k22}{i109}{X2}{K11,22}{z26}{c2}SP{c-} will go down.\\n{k22}{i68}{X2}{K11,22}{z26}{c1}ALL DOWN{c-}\\n  {c2}All of the above{c-} + {k22}{i110}{X2}{K11,22}{z26}{c2}HP{c-} will go down.\\n{k22}{i54}{X2}{K11,22}{z26}{c1}Sleep{c-}\\n  You are unable to do anything.\\n\0";

            InstructionListHeader.dataPointers[40] = 0x41834;
            InstructionListHeader.dataPointers.Add(0x41ADC);
            InstructionListHeader.dataPointers.Add(0x41FE4);
            InstructionListHeader.dataPointers.Add(0x42244);
            InstructionListHeader.dataPointers.Add(0x41834);
            InstructionListHeader.dataPointers.Add(0x41D60);
            InstructionListHeader.dataPointers.Add(0x41FE4);
            InstructionListHeader.dataPointers.Add(0x42480);
            InstructionListHeader.dataPointers.Add(0x42CA8);
            InstructionListHeader.dataPointers.Add(0x42E80);
            InstructionListHeader.dataPointers.Add(0x42CA8);
            InstructionListHeader.dataPointers.Add(0x4303C);
            InstructionListHeader.dataPointers.Add(0x00000);

            UnknownHeader_AD.unknownUInt32s.RemoveAt(107);
            UnknownHeader_AD.unknownUInt32s.RemoveAt(583);
            UnknownHeader_AD.unknownUInt32s.RemoveAt(788);
            UnknownHeader_AD.unknownUInt32s.Insert(2491, 0x00000E10);
            UnknownHeader_AD.unknownUInt32s.RemoveRange(7011, 20);
            UnknownHeader_AD.unknownUInt32s.RemoveAt(8506);
            UnknownHeader_AD.unknownUInt32s.Insert(18132, 0x01020509);
            UnknownHeader_AD.unknownUInt32s.Insert(18133, 0x000000FF);
            UnknownHeader_AD.unknownUInt32s.Insert(18134, 0x00056830);
            UnknownHeader_AD.unknownUInt32s.RemoveRange(70982, 6);
            UnknownHeader_AD.unknownUInt32s.RemoveRange(70989, 2);
            UnknownHeader_AD.unknownUInt32s.RemoveRange(71013, 6);
            UnknownHeader_AD.unknownUInt32s.RemoveRange(71172, 6);
            UnknownHeader_AD.unknownUInt32s.Insert(85674, 0x00000F10);
            UnknownHeader_AD.unknownUInt32s.Insert(85690, 0x00020006);
            UnknownHeader_AD.unknownUInt32s.Insert(85691, 0x00000E10);
            UnknownHeader_AD.unknownUInt32s.Insert(85692, 0x00020006);
            UnknownHeader_AD.unknownUInt32s.Insert(85693, 0x00000C10);

            
            

            UnknownHeader_79.headerStart = 0x10000;
            UnknownHeader_79.unknownUint32 = 0x63;*/
        }

        public void WriteCharaFile(DokaponFileWriter stageFile)
        {
            stageFile.Write(Encoding.GetEncoding(932).GetBytes(fileHeader));
            stageFile.Write(fileSize);
            stageFile.Write(headerSize);
            stageFile.Write(filler);

            // Start Configuration
            CharFileNameHeaders[0].WriteHeaderBlock(stageFile);

            // Weapon Data
            WeaponDescriptionHeader.WriteHeaderBlock(stageFile);
            WeaponBonusDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in WeaponHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownWeaponInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[0].WriteHeaderBlock(stageFile);
            WeaponBonusDescriptionHeader.WriteBlockData(stageFile);
            WeaponDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[0].WriteEndDataBlock(stageFile);

            // Shield Data
            ShieldDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in ShieldHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownShieldInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[1].WriteHeaderBlock(stageFile);
            ShieldDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[1].WriteEndDataBlock(stageFile);

            // Accessory Data
            AccessoryDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in AccessoryHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[2].WriteHeaderBlock(stageFile);
            AccessoryDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[2].WriteEndDataBlock(stageFile);

            // Hairstyle Data
            HairstyleDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in HairstyleHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHairstyleInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[3].WriteHeaderBlock(stageFile);
            HairstyleDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[3].WriteEndDataBlock(stageFile);

            // Bag Item Data
            BagItemDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in BagItemTypeNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in BagItemHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in LocalItemHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_D7)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_D0)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_6B)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[4].WriteHeaderBlock(stageFile);
            BagItemDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[4].WriteEndDataBlock(stageFile);

            // Magic / Skill Data
            OffensiveMagicDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in BattleMagicTypeNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in FieldMagicTypeNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in OffensiveMagicHeaders)
                header.WriteHeaderBlock(stageFile);
            DefensiveMagicDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in DefensiveMagicHeaders)
                header.WriteHeaderBlock(stageFile);
            FieldMagicDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in FieldMagicHeaders)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_9F.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_D1)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_D4.WriteHeaderBlock(stageFile);
            UnknownHeader_D5.WriteHeaderBlock(stageFile);
            DarkArtDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in DarkArtHeaders)
                header.WriteHeaderBlock(stageFile);
            JobSkillDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in JobSkillHeaders)
                header.WriteHeaderBlock(stageFile);
            BattleSkillDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in BattleSkillHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[5].WriteHeaderBlock(stageFile);
            DarkArtDescriptionHeader.WriteBlockData(stageFile);
            OffensiveMagicDescriptionHeader.WriteBlockData(stageFile);
            DefensiveMagicDescriptionHeader.WriteBlockData(stageFile);
            FieldMagicDescriptionHeader.WriteBlockData(stageFile);
            JobSkillDescriptionHeader.WriteBlockData(stageFile);
            BattleSkillDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[5].WriteEndDataBlock(stageFile);

            // Job Data
            JobDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in JobNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobBattleSkillHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobStartingStatsHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobLevelAndMasteryHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobItemSpaceHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobLevelUpRequirementHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobSalaryHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobRequirementHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobUnknownInfoHeaders1)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobFileHeaders1)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobFileHeaders2)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in JobUnknownInfoHeaders2)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_38)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_39)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_8F)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[6].WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_39)
                header.WriteBlockData(stageFile);
            foreach (var header in UnknownHeaders_8F)
                header.WriteBlockData(stageFile);
            JobDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[6].WriteEndDataBlock(stageFile);
            // End Class Data
            CharFileNameHeaders[1].WriteHeaderBlockWithPosition(stageFile);

            // Effect Data
            foreach (var header in EffectNameHeaders1)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in EffectNameHeaders2)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in EffectNameHeaders3)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_8E)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_9A)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_9B)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_9E.WriteHeaderBlock(stageFile);
            UnknownHeader_9E.WriteBlockData(stageFile);
            UnknownHeader_8C.WriteHeaderBlock(stageFile);

            // CPU Name Data
            foreach (var header in CPUNamesHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[7].WriteHeaderBlock(stageFile);
            foreach (var header in CPUNamesHeaders)
                header.WriteBlockData(stageFile);
            CharUnknownHeaders_03[7].WriteEndDataBlock(stageFile);

            foreach (var header in UnknownHeaders_17)
                header.WriteHeaderBlock(stageFile);

            // Monster Data
            MonsterDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in MonsterHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in MonsterItemDropHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in MonsterUnknownInfoHeaders1)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in MonsterUnknownInfoHeaders2)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in MonsterTypeHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in MonsterAITableHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_52)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_54)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[8].WriteHeaderBlock(stageFile);
            foreach (var header in MonsterUnknownInfoHeaders2)
                header.WriteBlockData(stageFile);
            MonsterDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[8].WriteEndDataBlock(stageFile);

            // NPC Data
            foreach (var header in NPCNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in NPCUnknownInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in NPCFileInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[9].WriteHeaderBlock(stageFile);
            WriteNPCFileInfoHeaders(stageFile);
            CharUnknownHeaders_03[9].WriteEndDataBlock(stageFile);

            // External File Data???
            foreach (var header in EtcFileNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in TextureFileNameHeaders)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_2C.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_2D)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_9D.WriteHeaderBlock(stageFile);
            UnknownHeader_9C.WriteHeaderBlock(stageFile);
            UnknownHeader_E1.WriteHeaderBlock(stageFile);
            UnknownHeader_4F.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_4E)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_4D.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[10].WriteHeaderBlock(stageFile);
            UnknownHeader_4D.WritePointerData(stageFile);
            UnknownHeader_4D.WriteBlockData(stageFile);
            UnknownHeader_4F.WritePointerData(stageFile);
            UnknownHeader_4F.WriteBlockData(stageFile);
            CharUnknownHeaders_03[10].WriteEndDataBlock(stageFile);

            // Experience Data
            ExperienceRequirementHeader.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[11].WriteHeaderBlock(stageFile);
            ExperienceRequirementHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[11].WriteEndDataBlock(stageFile);

            // CPU Level Up Data
            CPULevelUpHeader.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[12].WriteHeaderBlock(stageFile);
            CPULevelUpHeader.WritePointerData(stageFile);
            CPULevelUpHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[12].WriteEndDataBlock(stageFile);

            foreach (var header in UnknownHeaders_E2)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_49)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_5C)
                header.WriteHeaderBlock(stageFile);

            // Dialog Data
            DialogListHeader.WriteHeaderBlock(stageFile);
            foreach (var header in DialogPointerListHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[13].WriteHeaderBlock(stageFile);
            WriteDialogHeaders(stageFile);
            CharUnknownHeaders_03[13].WriteEndDataBlock(stageFile);

            UnknownHeader_47.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_84)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_1C)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_1D.WriteHeaderBlock(stageFile);
            UnknownHeader_1E.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_46)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_4C)
                header.WriteHeaderBlock(stageFile);
            for (int i = 0; i < 6; i++)
                UnknownHeaders_48[i].WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_3F)
                header.WriteHeaderBlock(stageFile);
            for (int i = 6; i < UnknownHeaders_48.Count; i++)
                UnknownHeaders_48[i].WriteHeaderBlock(stageFile);
            // End Event List
            CharFileNameHeaders[2].WriteHeaderBlockWithPosition(stageFile);

            foreach (var header in UnknownHeaders_DF)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_D2)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_D3)
                header.WriteHeaderBlock(stageFile);

            // Instuctions Data
            InstructionListHeader.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[14].WriteHeaderBlock(stageFile);
            InstructionListHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[14].WriteEndDataBlock(stageFile);

            foreach (var header in PrankNameHeaders)
                header.WriteHeaderBlock(stageFile);

            // Start Combat Settings
            CharFileNameHeaders[3].fileName = "######## 戦闘系設定を開始 <chara.txt> ########\0\0";
            CharFileNameHeaders[3].WriteHeaderBlockWithPosition(stageFile);

            UnknownHeader_AE.WriteHeaderBlock(stageFile);
            UnknownHeader_AF.WriteHeaderBlock(stageFile);
            UnknownHeader_A1.WriteHeaderBlock(stageFile);
            UnknownHeader_A0.WriteHeaderBlock(stageFile);
            UnknownHeader_A2.WriteHeaderBlock(stageFile);
            UnknownHeader_A3.WriteHeaderBlock(stageFile);
            UnknownHeader_A4.WriteHeaderBlock(stageFile);
            UnknownHeader_A5.WriteHeaderBlock(stageFile);
            UnknownHeader_AD.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[15].WriteHeaderBlock(stageFile);
            UnknownHeader_AE.WriteBlockData(stageFile);
            UnknownHeader_AF.WriteBlockData(stageFile);
            UnknownHeader_AD.WriteBlockData(stageFile, originalFileOffset);
            CharUnknownHeaders_03[15].WriteEndDataBlock(stageFile);

            foreach (var header in UnknownHeaders_B0)
                header.WriteHeaderBlock(stageFile);
            UnknownHeader_B1.WriteHeaderBlock(stageFile);
            UnknownHeader_B2.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_B3)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_B4)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_B5)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_B6)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in HitFormulaHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in AttackFormulaHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in MagicFormulaHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in StrikeFormulaHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in CounterFormulaHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in SelfAttackFormulaHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_BD)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHeaders_BE)
                header.WriteHeaderBlock(stageFile);

            // Settings Complete
            CharFileNameHeaders[4].WriteHeaderBlockWithPosition(stageFile);

            // Static Data Group Settings Complete
            CharFileNameHeaders[5].fileName = "(静的データ群設定の完了) \0\0\0";
            CharFileNameHeaders[5].WriteHeaderBlockWithPosition(stageFile);

            if (UnknownHeader_79.headerStart > 0)
                UnknownHeader_79.WriteHeaderBlock(stageFile);

            EndOfFileHeader.WriteHeaderBlock(stageFile);

            while (stageFile.GetPosition() % 8 != 0)
                stageFile.Write((byte)0);

            var currentPosition = stageFile.GetPosition();
            fileSize = stageFile.GetRelativePosition();
            stageFile.SetPosition(stageFile.fileOffset + 4);
            stageFile.Write(fileSize);
            stageFile.SetPosition(currentPosition);

            while (stageFile.GetPosition() % 16 != 0)
                stageFile.Write((byte)0);
        }

        public void WriteDialogHeaders(DokaponFileWriter stageFile)
        {
            DialogListHeader.startOfData = stageFile.GetRelativePosition();

            for (int i = 0; i < DialogListHeader.dialog.Count; i++)
            {
                for (int j = 0; j < DialogPointerListHeaders.Count; j++)
                {
                    for (int k = 0; k < DialogPointerListHeaders[j].dialogPointer.Count; k++)
                    {
                        if (DialogPointerListHeaders[j].dialogPointerAdjusted[k])
                            continue;

                        if (DialogPointerListHeaders[j].dialogPointer[k] == DialogListHeader.dialogPointer[i])
                        {
                            DialogPointerListHeaders[j].dialogPointerAdjusted[k] = true;
                            DialogPointerListHeaders[j].dialogPointer[k] = stageFile.GetRelativePosition();
                        }
                    }
                }

                DialogListHeader.dialogPointer[i] = stageFile.GetRelativePosition();
                stageFile.WriteString(DialogListHeader.dialog[i]);
            }

            DialogListHeader.endOfData = stageFile.GetRelativePosition();
            var currentPosition = stageFile.GetPosition();
            stageFile.SetPosition(DialogListHeader.headerStart);
            DialogListHeader.WriteHeaderBlock(stageFile);

            foreach (var header in DialogPointerListHeaders)
                header.WriteHeaderBlock(stageFile);

            stageFile.SetPosition(currentPosition);
        }

        public void WriteNPCFileInfoHeaders(DokaponFileWriter stageFile)
        {
            for (int header = 0; header < NPCFileInfoHeaders.Count; header++)
            {
                for (int pointer1 = 0; pointer1 < NPCFileInfoHeaders[header].unknownPointers1.Count; pointer1++)
                {
                    // skip previous duplicates
                    if (NPCFileInfoHeaders[header].duplicatePointers1[pointer1])
                        continue;

                    // search second set of pointers for duplicates
                    for (int pointer2 = 0; pointer2 < NPCFileInfoHeaders[header].unknownPointers2.Count; pointer2++)
                    {
                        // skip previous duplicates
                        if (NPCFileInfoHeaders[header].duplicatePointers2[pointer2])
                            continue;

                        if (NPCFileInfoHeaders[header].unknownPointers2[pointer2].pointer == NPCFileInfoHeaders[header].unknownPointers1[pointer1].pointer)
                        {
                            NPCFileInfoHeaders[header].unknownPointers2[pointer2].pointer = stageFile.GetRelativePosition();
                            NPCFileInfoHeaders[header].duplicatePointers2[pointer2] = true;
                        }
                    }

                    // check for duplicates in all additional headers
                    for (int nextHeader = header + 1; nextHeader < NPCFileInfoHeaders.Count; nextHeader++)
                    {
                        // check first pointer set
                        for (int nextPointer1 = 0; nextPointer1 < NPCFileInfoHeaders[nextHeader].unknownPointers1.Count; nextPointer1++)
                        {
                            // skip previous duplicates
                            if (NPCFileInfoHeaders[nextHeader].duplicatePointers1[nextPointer1])
                                continue;

                            if (NPCFileInfoHeaders[nextHeader].unknownPointers1[nextPointer1].pointer == NPCFileInfoHeaders[header].unknownPointers1[pointer1].pointer)
                            {
                                NPCFileInfoHeaders[nextHeader].unknownPointers1[nextPointer1].pointer = stageFile.GetRelativePosition();
                                NPCFileInfoHeaders[nextHeader].duplicatePointers1[nextPointer1] = true;
                            }
                        }

                        // check second pointer set
                        for (int nextPointer2 = 0; nextPointer2 < NPCFileInfoHeaders[nextHeader].unknownPointers2.Count; nextPointer2++)
                        {
                            // skip previous duplicates
                            if (NPCFileInfoHeaders[nextHeader].duplicatePointers2[nextPointer2])
                                continue;

                            if (NPCFileInfoHeaders[nextHeader].unknownPointers2[nextPointer2].pointer == NPCFileInfoHeaders[header].unknownPointers1[pointer1].pointer)
                            {
                                NPCFileInfoHeaders[nextHeader].unknownPointers2[nextPointer2].pointer = stageFile.GetRelativePosition();
                                NPCFileInfoHeaders[nextHeader].duplicatePointers2[nextPointer2] = true;
                            }
                        }
                    }

                    NPCFileInfoHeaders[header].unknownPointers1[pointer1].pointer = stageFile.GetRelativePosition();
                    foreach (var v in NPCFileInfoHeaders[header].unknownUInt16s1[pointer1])
                        stageFile.Write(v);
                }

                for (int pointer2 = 0; pointer2 < NPCFileInfoHeaders[header].unknownPointers2.Count; pointer2++)
                {
                    // skip previous duplicates
                    if (NPCFileInfoHeaders[header].duplicatePointers2[pointer2])
                        continue;

                    // check for duplicates in all additional headers
                    for (int nextHeader = header + 1; nextHeader < NPCFileInfoHeaders.Count; nextHeader++)
                    {
                        // check first pointer set
                        for (int nextPointer1 = 0; nextPointer1 < NPCFileInfoHeaders[nextHeader].unknownPointers1.Count; nextPointer1++)
                        {
                            // skip previous duplicates
                            if (NPCFileInfoHeaders[nextHeader].duplicatePointers1[nextPointer1])
                                continue;

                            if (NPCFileInfoHeaders[nextHeader].unknownPointers1[nextPointer1].pointer == NPCFileInfoHeaders[header].unknownPointers2[pointer2].pointer)
                            {
                                NPCFileInfoHeaders[nextHeader].unknownPointers1[nextPointer1].pointer = stageFile.GetRelativePosition();
                                NPCFileInfoHeaders[nextHeader].duplicatePointers1[nextPointer1] = true;
                            }
                        }

                        // check second pointer set
                        for (int nextPointer2 = 0; nextPointer2 < NPCFileInfoHeaders[nextHeader].unknownPointers2.Count; nextPointer2++)
                        {
                            // skip previous duplicates
                            if (NPCFileInfoHeaders[nextHeader].duplicatePointers2[nextPointer2])
                                continue;

                            if (NPCFileInfoHeaders[nextHeader].unknownPointers2[nextPointer2].pointer == NPCFileInfoHeaders[header].unknownPointers2[pointer2].pointer)
                            {
                                NPCFileInfoHeaders[nextHeader].unknownPointers2[nextPointer2].pointer = stageFile.GetRelativePosition();
                                NPCFileInfoHeaders[nextHeader].duplicatePointers2[nextPointer2] = true;
                            }
                        }
                    }

                    NPCFileInfoHeaders[header].unknownPointers2[pointer2].pointer = stageFile.GetRelativePosition();
                    foreach (var v in NPCFileInfoHeaders[header].unknownUInt16s2[pointer2])
                        stageFile.Write(v);
                }

                var currentPosition = stageFile.GetPosition();
                stageFile.SetPosition(NPCFileInfoHeaders[header].headerStart);
                NPCFileInfoHeaders[header].WriteHeaderBlock(stageFile);
                stageFile.SetPosition(currentPosition);
            }
        }

        public string GetJobName(int jobIndex)
        {
            if (jobIndex >= JobNameHeaders.Count)
                return "None";

            return JobNameHeaders[jobIndex].name;
        }

        public byte GetJobIndex(string jobName)
        { 
            foreach (var header in JobNameHeaders)
            {
                if (header.name == jobName)
                    return (byte)header.index;
            }

            return 0xFF;
        }

        public string GetItemName(ItemType type, int id)
        {
            if (id == 0)
                return ("None");
            if (id == 0x80)
                return ("Clonus 1");
            if (id == 0x81)
                return ("Clonus 2");
            if (id == 0x82)
                return ("Clonus 3");
            if (id == 0x83)
                return ("Clonus 4");
//            if (type == ItemType.BagItem && id == 0x9d)
 //               return ("Black Diamond");

            switch (type)
            {
                case ItemType.Weapon: return (WeaponHeaders[id - 1].name);
                case ItemType.Shield: return (ShieldHeaders[id - 1].name);
                case ItemType.Accessory: return (AccessoryHeaders[id - 1].name);
                case ItemType.Hairstyle: return (HairstyleHeaders[id - 1].name);
                case ItemType.BagItem: 
                    if (id - 1 >= BagItemHeaders.Count)
                        return (LocalItemHeaders[id - BagItemHeaders.Count - 1].name);
                    return (BagItemHeaders[id - 1].name);
                case ItemType.OffensiveMagic: return (OffensiveMagicHeaders[id - 1].name);
                case ItemType.DefensiveMagic: return (DefensiveMagicHeaders[id - 1].name);
                case ItemType.FieldMagic: return (FieldMagicHeaders[id - 1].name);
                case ItemType.BattleSkill: return (BattleSkillHeaders[id - 1].name);
                default: return "None";
            }
        }

        public (byte, byte) GetItemTypeAndID(string itemName)
        {
            if (itemName == "Clonus 1")
                return ((byte)ItemType.BattleSkill, 0x80);
            if (itemName == "Clonus 2")
                return ((byte)ItemType.BattleSkill, 0x81);
            if (itemName == "Clonus 3")
                return ((byte)ItemType.BattleSkill, 0x82);
            if (itemName == "Clonus 4")
                return ((byte)ItemType.BattleSkill, 0x83);

            foreach (var header in WeaponHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.Weapon, (byte)(header.index + 1));
            }

            foreach (var header in ShieldHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.Shield, (byte)(header.index + 1));
            }

            foreach (var header in AccessoryHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.Accessory, (byte)(header.index + 1));
            }

            foreach (var header in HairstyleHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.Hairstyle, (byte)(header.index + 1));
            }

            foreach (var header in BagItemHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.BagItem, (byte)(header.index + 1));
            }

            foreach (var header in LocalItemHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.BagItem, (byte)(header.index + BagItemHeaders.Count + 1));
            }

            foreach (var header in OffensiveMagicHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.OffensiveMagic, (byte)(header.index + 1));
            }

            foreach (var header in DefensiveMagicHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.DefensiveMagic, (byte)(header.index + 1));
            }

            foreach (var header in FieldMagicHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.FieldMagic, (byte)(header.index + 1));
            }

            foreach (var header in BattleSkillHeaders)
            {
                if (header.name == itemName)
                    return ((byte)ItemType.BattleSkill, (byte)(header.index + 1));
            }

            return ((byte)ItemType.None, 0);
        }

        public string GetBattleMagicTypeName(byte index)
        {
            foreach (var header in BattleMagicTypeNameHeaders)
            {
                if ((byte)header.index == index)
                    return header.name;
            }

            return "None";
        }

        public byte GetBattleMagicTypeID(string itemType)
        {
            foreach (var header in BattleMagicTypeNameHeaders)
            {
                if (header.name == itemType)
                    return (byte)header.index;
            }

            return 0;
        }

        public string GetFieldMagicTypeName(byte index)
        {
            foreach (var header in FieldMagicTypeNameHeaders)
            {
                if ((byte)header.index == index)
                    return header.name;
            }

            return "None";
        }

        public byte GetFieldMagicTypeID(string itemType)
        {
            foreach (var header in FieldMagicTypeNameHeaders)
            {
                if (header.name == itemType)
                    return (byte)header.index;
            }

            return 0;
        }

        public string GetBagItemTypeName(byte index)
        {
            foreach (var header in BagItemTypeNameHeaders)
            {
                if ((byte)header.index == index)
                    return header.name;
            }

            return "None";
        }

        public byte GetBagItemTypeID(string itemType)
        {
            foreach (var header in BagItemTypeNameHeaders)
            {
                if (header.name == itemType)
                    return (byte)header.index;
            }

            return 0;
        }
    }
}