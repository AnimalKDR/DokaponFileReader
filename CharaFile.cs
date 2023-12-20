using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DokaponFileReader
{
    public class CharaFile
    {
        public string fileHeader;
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
        public DialogPointerListHeader DialogPointerListHeader;
        public InstuctionListHeader InstructionListHeader;

        public UnknownHeader_1D UnknownHeader_1D;
        public UnknownHeader_1E UnknownHeader_1E;
        public UnknownHeader_2C UnknownHeader_2C;
        public UnknownHeader_47 UnknownHeader_47;
        public UnknownHeader_4D UnknownHeader_4D;
        public UnknownHeader_4F UnknownHeader_4F;
        public UnknownHeader_76 UnknownHeader_76;
        public UnknownHeader_77 UnknownHeader_77;
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

        public List<EndOfFileHeader> EmptyHeaders;
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
        public List<DialogListHeader> DialogListHeaders;
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
            DialogPointerListHeader = new DialogPointerListHeader(4);
            InstructionListHeader = new InstuctionListHeader(4);

            UnknownHeader_1D = new UnknownHeader_1D(4);
            UnknownHeader_1E = new UnknownHeader_1E(4);
            UnknownHeader_2C = new UnknownHeader_2C(4);
            UnknownHeader_47 = new UnknownHeader_47(4);
            UnknownHeader_4D = new UnknownHeader_4D(4);
            UnknownHeader_4F = new UnknownHeader_4F(4);
            UnknownHeader_76 = new UnknownHeader_76(4);
            UnknownHeader_77 = new UnknownHeader_77(4);
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


            EmptyHeaders = new List<EndOfFileHeader>();
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
            DialogListHeaders = new List<DialogListHeader>();
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
                    case HeaderType.EndOfFile: EmptyHeaders.Add(EndOfFileHeader.ReadHeaderBlock(stageFile)); break;
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
                    case HeaderType.Unknown_76: UnknownHeader_76=UnknownHeader_76.ReadHeaderBlock(stageFile); break;
                    case HeaderType.Unknown_77: UnknownHeader_77=UnknownHeader_77.ReadHeaderBlock(stageFile); break;
                    case HeaderType.DialogList: DialogListHeaders.Add(DialogListHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_E2: UnknownHeaders_E2.Add(UnknownHeader_E2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DialogPointerList: DialogPointerListHeader = DialogPointerListHeader.ReadHeaderBlock(stageFile); break;
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
                    case HeaderType.InstructionsList: InstructionListHeader=InstuctionListHeader.ReadHeaderBlock(stageFile); break;
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
                    case HeaderType.AttackFormula: AttackFormulaHeaders.Add(AttackFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MagicFormula: MagicFormulaHeaders.Add(MagicFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.StrikeFormula: StrikeFormulaHeaders.Add(StrikeFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.CounterFormula: CounterFormulaHeaders.Add(CounterFormulaHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.SelfAttackFormula: SelfAttackFormulaHeaders.Add(SelfAttackFormulaHeader.ReadHeaderBlock(stageFile)); break;

                    default:
                        Console.WriteLine("Unknown Header!"); break;
                }
            }
        }

        public void WriteCharaFile(DokaponFileWriter stageFile)
        {
            stageFile.Write(Encoding.GetEncoding(932).GetBytes(fileHeader));
            stageFile.Write(fileSize);
            stageFile.Write(headerSize);
            stageFile.Write(filler);

            CharFileNameHeaders[0].WriteHeaderBlock(stageFile);

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

            ShieldDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in ShieldHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownShieldInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[1].WriteHeaderBlock(stageFile);
            ShieldDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[1].WriteEndDataBlock(stageFile);

            AccessoryDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in AccessoryHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[2].WriteHeaderBlock(stageFile);
            AccessoryDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[2].WriteEndDataBlock(stageFile);

            HairstyleDescriptionHeader.WriteHeaderBlock(stageFile);
            foreach (var header in HairstyleHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in UnknownHairstyleInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[3].WriteHeaderBlock(stageFile);
            HairstyleDescriptionHeader.WriteBlockData(stageFile);
            CharUnknownHeaders_03[3].WriteEndDataBlock(stageFile);

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

            CharFileNameHeaders[1].WriteHeaderBlockWithPosition(stageFile);

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

            foreach (var header in CPUNamesHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[7].WriteHeaderBlock(stageFile);
            foreach (var header in CPUNamesHeaders)
                header.WriteBlockData(stageFile);
            CharUnknownHeaders_03[7].WriteEndDataBlock(stageFile);

            foreach (var header in UnknownHeaders_17)
                header.WriteHeaderBlock(stageFile);

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

            foreach (var header in NPCNameHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in NPCUnknownInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            foreach (var header in NPCFileInfoHeaders)
                header.WriteHeaderBlock(stageFile);
            CharUnknownHeaders_03[9].WriteHeaderBlock(stageFile);
            WriteNPCFileInfoHeaders(stageFile);
            CharUnknownHeaders_03[9].WriteEndDataBlock(stageFile);

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