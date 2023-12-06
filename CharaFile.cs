﻿using System.Text;

namespace DokaponFileReader
{
    public class CharaFile
    {
        public string fileHeader;
        public UInt32 fileSize;
        public UInt32 headerSize;
        public byte[] filler;

        public List<EndOfFileHeader> EmptyHeaders;
        public List<FileNameHeader> CharFileNameHeaders;
        public List<UnknownHeader_03> CharUnknownHeaders_03;
        public List<WeaponHeader> WeaponHeaders;
        public List<WeaponUnknownInfoHeader> UnknownWeaponInfoHeaders;
        public List<WeaponDescriptionHeader> WeaponDescriptionHeaders;
        public List<ShieldHeader> ShieldHeaders;
        public List<ShieldUnknownInfoHeader> UnknownShieldInfoHeaders;
        public List<ShieldDescriptionHeader> ShieldDescriptionHeaders;
        public List<WeaponBonusDescriptionHeader> WeaponBonusDescriptionHeaders;
        public List<AccessoryHeader> AccessoryHeaders;
        public List<AccessoryDescriptionHeader> AccessoryDescriptionHeaders;
        public List<HairstyleHeader> HairstyleHeaders;
        public List<HairstyleDescriptionHeader> HairstyleDescriptionHeaders;
        public List<UnknownHairstyleInfoHeader> UnknownHairstyleInfoHeaders;
        public List<BagItemTypeNameHeader> BagItemTypeNameHeaders;
        public List<BagItemHeader> BagItemHeaders;
        public List<BagItemDescriptionHeader> BagItemDescriptionHeaders;
        public List<LocalItemHeader> LocalItemHeaders;
        public List<UnknownHeader_6B> UnknownHeaders_6B;
        public List<OffensiveMagicHeader> OffensiveMagicHeaders;
        public List<OffensiveMagicDescriptionHeader> OffensiveMagicDescriptionHeaders;
        public List<DefensiveMagicHeader> DefensiveMagicHeaders;
        public List<DefensiveMagicDescriptionHeader> DefensiveMagicDescriptionHeaders;
        public List<FieldMagicHeader> FieldMagicHeaders;
        public List<FieldMagicDescriptionHeader> FieldMagicDescriptionHeaders;
        public List<BattleMagicTypeNameHeader> BattleMagicTypeNameHeaders;
        public List<FieldMagicTypeNameHeader> FieldMagicTypeNameHeaders;
        public List<UnknownHeader_9F> UnknownHeaders_9F;
        public List<UnknownHeader_D0> UnknownHeaders_D0;
        public List<UnknownHeader_D1> UnknownHeaders_D1;
        public List<UnknownHeader_D4> UnknownHeaders_D4;
        public List<UnknownHeader_D5> UnknownHeaders_D5;
        public List<UnknownHeader_D7> UnknownHeaders_D7;
        public List<DarkArtDescriptionHeader> DarkArtDescritpionHeaders;
        public List<DarkArtHeader> DarkArtHeaders;
        public List<BattleSkillHeader> BattleSkillHeaders;
        public List<BattleSkillDescriptionHeader> BattleSkillDescriptionHeaders;
        public List<JobSkillHeader> JobSkillHeaders;
        public List<JobSkillDescriptionHeader> JobSkillDescriptionHeaders;
        public List<JobFileHeader2> JobFileHeaders2;
        public List<JobSalaryHeader> JobSalaryHeaders;
        public List<JobLevelAndMasteryHeader> JobLevelAndMasteryHeaders;
        public List<JobBattleSkillHeader> JobBattleSkillHeaders;
        public List<JobDescriptionHeader> JobDescriptionHeaders;
        public List<JobLevelUpRequirementHeader> JobLevelUpRequirementHeaders;
        public List<JobStartingStatsHeader> JobStartingStatsHeaders;
        public List<JobUnknownInfoHeader1> JobUnknownInfoHeaders1;
        public List<JobNameHeader> JobNameHeaders;
        public List<JobUnknownInfoHeader2> JobUnknownInfoHeaders2;
        public List<JobItemSpacesHeader> JobItemSpaceHeaders;
        public List<JobFileHeader1> JobFileHeaders1;
        public List<JobRequirementHeader> JobRequirementHeaders;
        public List<UnknownHeader_38> UnknownHeaders_38;
        public List<UnknownHeader_39> UnknownHeaders_39;
        public List<UnknownHeader_8F> UnknownHeaders_8F;
        public List<EffectNameHeader1> EffectNameHeaders1;
        public List<EffectNameHeader2> EffectNameHeaders2;
        public List<EffectNameHeader3> EffectNameHeaders3;
        public List<UnknownHeader_8C> UnknownHeaders_8C;
        public List<UnknownHeader_8E> UnknownHeaders_8E;
        public List<UnknownHeader_9A> UnknownHeaders_9A;
        public List<UnknownHeader_9B> UnknownHeaders_9B;
        public List<UnknownHeader_9E> UnknownHeaders_9E;
        public List<CPUNamesHeader> CPUNamesHeaders;
        public List<MonsterDescriptionHeader> MonsterDescriptionHeaders;
        public List<MonsterHeader> MonsterHeaders;
        public List<UnknownHeader_17> UnknownHeaders_17;
        public List<MonsterItemDropHeader> MonsterItemDropHeaders;
        public List<MonsterUnknownInfoHeader> MonsterUnknownInfoHeaders1;
        public List<MonsterFileInfoHeader> MonsterUnknownInfoHeaders2;
        public List<MonsterTypeHeader> MonsterTypeHeaders;
        public List<MonsterAITableHeader> MonsterAITableHeaders;
        public List<UnknownHeader_52> UnknownHeaders_52;
        public List<UnknownHeader_54> UnknownHeaders_54;
        public List<NPCNameHeader> NPCNameHeaders;
        public List<NPCUnknownInfoHeader> NPCUnknownInfoHeaders;
        public List<NPCFileInfoHeader> NPCFileInfoHeaders;
        public List<EtcFileNameHeader> EtcFileNameHeaders;
        public List<TextureFileNameHeader> TextureFileNameHeaders;
        public List<UnknownHeader_2C> UnknownHeaders_2C;
        public List<UnknownHeader_2D> UnknownHeaders_2D;
        public List<UnknownHeader_9D> UnknownHeaders_9D;
        public List<UnknownHeader_9C> UnknownHeaders_9C;
        public List<UnknownHeader_E1> UnknownHeaders_E1;
        public List<UnknownHeader_49> UnknownHeaders_49;
        public List<UnknownHeader_5C> UnknownHeaders_5C;
        public List<UnknownHeader_4D> UnknownHeaders_4D;
        public List<UnknownHeader_4E> UnknownHeaders_4E;
        public List<UnknownHeader_4F> UnknownHeaders_4F;
        public List<UnknownHeader_76> UnknownHeaders_76;
        public List<UnknownHeader_77> UnknownHeaders_77;
        public List<DialogListHeader> DialogListHeaders;
        public List<UnknownHeader_E2> UnknownHeaders_E2;
        public List<DialogPointerListHeader> DialogPointerListHeaders;
        public List<UnknownHeader_46> UnknownHeaders_46;
        public List<UnknownHeader_47> UnknownHeaders_47;
        public List<UnknownHeader_4C> UnknownHeaders_4C;
        public List<UnknownHeader_1C> UnknownHeaders_1C;
        public List<UnknownHeader_1D> UnknownHeaders_1D;
        public List<UnknownHeader_1E> UnknownHeaders_1E;
        public List<UnknownHeader_84> UnknownHeaders_84;
        public List<UnknownHeader_3F> UnknownHeaders_3F;
        public List<UnknownHeader_48> UnknownHeaders_48;
        public List<UnknownHeader_DF> UnknownHeaders_DF;
        public List<UnknownHeader_D3> UnknownHeaders_D3;
        public List<UnknownHeader_D2> UnknownHeaders_D2;
        public List<InstuctionListHeader> InstructionListHeaders;
        public List<PrankNameHeader> PrankNameHeaders;
        public List<UnknownHeader_A0> UnknownHeaders_A0;
        public List<UnknownHeader_A1> UnknownHeaders_A1;
        public List<UnknownHeader_A2> UnknownHeaders_A2;
        public List<UnknownHeader_A3> UnknownHeaders_A3;
        public List<UnknownHeader_A4> UnknownHeaders_A4;
        public List<UnknownHeader_A5> UnknownHeaders_A5;
        public List<UnknownHeader_AD> UnknownHeaders_AD;
        public List<UnknownHeader_AE> UnknownHeaders_AE;
        public List<UnknownHeader_AF> UnknownHeaders_AF;
        public List<UnknownHeader_B0> UnknownHeaders_B0;
        public List<UnknownHeader_B1> UnknownHeaders_B1;
        public List<UnknownHeader_B2> UnknownHeaders_B2;
        public List<UnknownHeader_B3> UnknownHeaders_B3;
        public List<UnknownHeader_B4> UnknownHeaders_B4;
        public List<UnknownHeader_B5> UnknownHeaders_B5;
        public List<UnknownHeader_B6> UnknownHeaders_B6;
        public List<UnknownHeader_BD> UnknownHeaders_BD;
        public List<UnknownHeader_BE> UnknownHeaders_BE;
        public List<HitFormulaHeader> HitFormulaHeaders;
        public List<AttackFormulaHeader> AttackFormulaHeaders;
        public List<MagicFormulaHeader> MagicFormulaHeaders;
        public List<StrikeFormulaHeader> StrikeFormulaHeaders;
        public List<CounterFormulaHeader> CounterFormulaHeaders;
        public List<SelfAttackFormulaHeader> SelfAttackFormulaHeaders;

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

            EmptyHeaders = new List<EndOfFileHeader>();
            CharFileNameHeaders = new List<FileNameHeader>();
            CharUnknownHeaders_03 = new List<UnknownHeader_03>();
            WeaponHeaders = new List<WeaponHeader>();
            UnknownWeaponInfoHeaders = new List<WeaponUnknownInfoHeader>();
            WeaponDescriptionHeaders = new List<WeaponDescriptionHeader>();
            ShieldHeaders = new List<ShieldHeader>();
            UnknownShieldInfoHeaders = new List<ShieldUnknownInfoHeader>();
            ShieldDescriptionHeaders = new List<ShieldDescriptionHeader>();
            WeaponBonusDescriptionHeaders = new List<WeaponBonusDescriptionHeader>();
            AccessoryHeaders = new List<AccessoryHeader>();
            AccessoryDescriptionHeaders = new List<AccessoryDescriptionHeader>();
            HairstyleHeaders = new List<HairstyleHeader>();
            HairstyleDescriptionHeaders = new List<HairstyleDescriptionHeader>();
            UnknownHairstyleInfoHeaders = new List<UnknownHairstyleInfoHeader>();
            BagItemTypeNameHeaders = new List<BagItemTypeNameHeader>();
            BagItemHeaders = new List<BagItemHeader>();
            BagItemDescriptionHeaders = new List<BagItemDescriptionHeader>();
            LocalItemHeaders = new List<LocalItemHeader>();
            UnknownHeaders_6B = new List<UnknownHeader_6B>();
            OffensiveMagicHeaders = new List<OffensiveMagicHeader>();
            OffensiveMagicDescriptionHeaders = new List<OffensiveMagicDescriptionHeader>();
            DefensiveMagicHeaders = new List<DefensiveMagicHeader>();
            DefensiveMagicDescriptionHeaders = new List<DefensiveMagicDescriptionHeader>();
            FieldMagicHeaders = new List<FieldMagicHeader>();
            FieldMagicDescriptionHeaders = new List<FieldMagicDescriptionHeader>();
            BattleMagicTypeNameHeaders = new List<BattleMagicTypeNameHeader>();
            FieldMagicTypeNameHeaders = new List<FieldMagicTypeNameHeader>();
            UnknownHeaders_9F = new List<UnknownHeader_9F>();
            UnknownHeaders_D0 = new List<UnknownHeader_D0>();
            UnknownHeaders_D1 = new List<UnknownHeader_D1>();
            UnknownHeaders_D4 = new List<UnknownHeader_D4>();
            UnknownHeaders_D5 = new List<UnknownHeader_D5>();
            UnknownHeaders_D7 = new List<UnknownHeader_D7>();
            DarkArtDescritpionHeaders = new List<DarkArtDescriptionHeader>();
            DarkArtHeaders = new List<DarkArtHeader>();
            BattleSkillHeaders = new List<BattleSkillHeader>();
            BattleSkillDescriptionHeaders = new List<BattleSkillDescriptionHeader>();
            JobSkillHeaders = new List<JobSkillHeader>();
            JobSkillDescriptionHeaders = new List<JobSkillDescriptionHeader>();
            JobFileHeaders2 = new List<JobFileHeader2>();
            JobSalaryHeaders = new List<JobSalaryHeader>();
            JobLevelAndMasteryHeaders = new List<JobLevelAndMasteryHeader>();
            JobBattleSkillHeaders = new List<JobBattleSkillHeader>();
            JobDescriptionHeaders = new List<JobDescriptionHeader>();
            JobLevelUpRequirementHeaders = new List<JobLevelUpRequirementHeader>();
            JobStartingStatsHeaders = new List<JobStartingStatsHeader>();
            JobUnknownInfoHeaders1 = new List<JobUnknownInfoHeader1>();
            JobNameHeaders = new List<JobNameHeader>();
            JobUnknownInfoHeaders2 = new List<JobUnknownInfoHeader2>();
            JobItemSpaceHeaders = new List<JobItemSpacesHeader>();
            JobFileHeaders1 = new List<JobFileHeader1>();
            JobRequirementHeaders = new List<JobRequirementHeader>();
            UnknownHeaders_38 = new List<UnknownHeader_38>();
            UnknownHeaders_39 = new List<UnknownHeader_39>();
            UnknownHeaders_8F = new List<UnknownHeader_8F>();
            EffectNameHeaders1 = new List<EffectNameHeader1>();
            EffectNameHeaders2 = new List<EffectNameHeader2>();
            EffectNameHeaders3 = new List<EffectNameHeader3>();
            UnknownHeaders_8C = new List<UnknownHeader_8C>();
            UnknownHeaders_8E = new List<UnknownHeader_8E>();
            UnknownHeaders_9A = new List<UnknownHeader_9A>();
            UnknownHeaders_9B = new List<UnknownHeader_9B>();
            UnknownHeaders_9E = new List<UnknownHeader_9E>();
            CPUNamesHeaders = new List<CPUNamesHeader>();
            MonsterDescriptionHeaders = new List<MonsterDescriptionHeader>();
            MonsterHeaders = new List<MonsterHeader>();
            UnknownHeaders_17 = new List<UnknownHeader_17>();
            MonsterItemDropHeaders = new List<MonsterItemDropHeader>();
            MonsterUnknownInfoHeaders1 = new List<MonsterUnknownInfoHeader>();
            MonsterUnknownInfoHeaders2 = new List<MonsterFileInfoHeader>();
            MonsterTypeHeaders = new List<MonsterTypeHeader>();
            MonsterAITableHeaders = new List<MonsterAITableHeader>();
            UnknownHeaders_52 = new List<UnknownHeader_52>();
            UnknownHeaders_54 = new List<UnknownHeader_54>();
            NPCNameHeaders = new List<NPCNameHeader>();
            NPCUnknownInfoHeaders = new List<NPCUnknownInfoHeader>();
            NPCFileInfoHeaders = new List<NPCFileInfoHeader>();
            EtcFileNameHeaders = new List<EtcFileNameHeader>();
            TextureFileNameHeaders = new List<TextureFileNameHeader>();
            UnknownHeaders_2C = new List<UnknownHeader_2C>();
            UnknownHeaders_2D = new List<UnknownHeader_2D>();
            UnknownHeaders_9D = new List<UnknownHeader_9D>();
            UnknownHeaders_9C = new List<UnknownHeader_9C>();
            UnknownHeaders_E1 = new List<UnknownHeader_E1>();
            UnknownHeaders_49 = new List<UnknownHeader_49>();
            UnknownHeaders_5C = new List<UnknownHeader_5C>();
            UnknownHeaders_4D = new List<UnknownHeader_4D>();
            UnknownHeaders_4E = new List<UnknownHeader_4E>();
            UnknownHeaders_4F = new List<UnknownHeader_4F>();
            UnknownHeaders_76 = new List<UnknownHeader_76>();
            UnknownHeaders_77 = new List<UnknownHeader_77>();
            DialogListHeaders = new List<DialogListHeader>();
            UnknownHeaders_E2 = new List<UnknownHeader_E2>();
            DialogPointerListHeaders = new List<DialogPointerListHeader>();
            UnknownHeaders_46 = new List<UnknownHeader_46>();
            UnknownHeaders_47 = new List<UnknownHeader_47>();
            UnknownHeaders_4C = new List<UnknownHeader_4C>();
            UnknownHeaders_1C = new List<UnknownHeader_1C>();
            UnknownHeaders_1D = new List<UnknownHeader_1D>();
            UnknownHeaders_1E = new List<UnknownHeader_1E>();
            UnknownHeaders_84 = new List<UnknownHeader_84>();
            UnknownHeaders_3F = new List<UnknownHeader_3F>();
            UnknownHeaders_48 = new List<UnknownHeader_48>();
            UnknownHeaders_DF = new List<UnknownHeader_DF>();
            UnknownHeaders_D3 = new List<UnknownHeader_D3>();
            UnknownHeaders_D2 = new List<UnknownHeader_D2>();
            InstructionListHeaders = new List<InstuctionListHeader>();
            PrankNameHeaders = new List<PrankNameHeader>();
            UnknownHeaders_A0 = new List<UnknownHeader_A0>();
            UnknownHeaders_A1 = new List<UnknownHeader_A1>();
            UnknownHeaders_A2 = new List<UnknownHeader_A2>();
            UnknownHeaders_A3 = new List<UnknownHeader_A3>();
            UnknownHeaders_A4 = new List<UnknownHeader_A4>();
            UnknownHeaders_A5 = new List<UnknownHeader_A5>();
            UnknownHeaders_AD = new List<UnknownHeader_AD>();
            UnknownHeaders_AE = new List<UnknownHeader_AE>();
            UnknownHeaders_AF = new List<UnknownHeader_AF>();
            UnknownHeaders_B0 = new List<UnknownHeader_B0>();
            UnknownHeaders_B1 = new List<UnknownHeader_B1>();
            UnknownHeaders_B2 = new List<UnknownHeader_B2>();
            UnknownHeaders_B3 = new List<UnknownHeader_B3>();
            UnknownHeaders_B4 = new List<UnknownHeader_B4>();
            UnknownHeaders_B5 = new List<UnknownHeader_B5>();
            UnknownHeaders_B6 = new List<UnknownHeader_B6>();
            UnknownHeaders_BD = new List<UnknownHeader_BD>();
            UnknownHeaders_BE = new List<UnknownHeader_BE>();
            HitFormulaHeaders = new List<HitFormulaHeader>();
            AttackFormulaHeaders = new List<AttackFormulaHeader>();
            MagicFormulaHeaders = new List<MagicFormulaHeader>();
            StrikeFormulaHeaders = new List<StrikeFormulaHeader>();
            CounterFormulaHeaders = new List<CounterFormulaHeader>();
            SelfAttackFormulaHeaders = new List<SelfAttackFormulaHeader>();
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

            while (stageFile.Position() < stageFile.fileOffset + fileSize && stageFile.Read(ref wordBuffer) > 0)
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
                    case HeaderType.WeaponDescription: WeaponDescriptionHeaders.Add(WeaponDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Shield: ShieldHeaders.Add(ShieldHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.ShieldUnknownInfo: UnknownShieldInfoHeaders.Add(ShieldUnknownInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.ShieldDescription: ShieldDescriptionHeaders.Add(ShieldDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.WeaponBonusDescription: WeaponBonusDescriptionHeaders.Add(WeaponBonusDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Accessory: AccessoryHeaders.Add(AccessoryHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.AccessoryDescription: AccessoryDescriptionHeaders.Add(AccessoryDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Hairstyle: HairstyleHeaders.Add(HairstyleHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.HairstyleDescription: HairstyleDescriptionHeaders.Add(HairstyleDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.HairstyleUnknownInfo: UnknownHairstyleInfoHeaders.Add(UnknownHairstyleInfoHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BagItemTypeName: BagItemTypeNameHeaders.Add(BagItemTypeNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BagItem: BagItemHeaders.Add(BagItemHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BagItemDescription: BagItemDescriptionHeaders.Add(BagItemDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.LocalItem: LocalItemHeaders.Add(LocalItemHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.OffensiveMagic: OffensiveMagicHeaders.Add(OffensiveMagicHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.OffensiveMagicDescription: OffensiveMagicDescriptionHeaders.Add(OffensiveMagicDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DefensiveMagic: DefensiveMagicHeaders.Add(DefensiveMagicHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DefensiveMagicDescription: DefensiveMagicDescriptionHeaders.Add(DefensiveMagicDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.FieldMagic: FieldMagicHeaders.Add(FieldMagicHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.FieldMagicDescription: FieldMagicDescriptionHeaders.Add(FieldMagicDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BattleMagicTypeName: BattleMagicTypeNameHeaders.Add(BattleMagicTypeNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.FieldMagicTypeName: FieldMagicTypeNameHeaders.Add(FieldMagicTypeNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_6B: UnknownHeaders_6B.Add(UnknownHeader_6B.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BattleSkill: BattleSkillHeaders.Add(BattleSkillHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.BattleSkillDescription: BattleSkillDescriptionHeaders.Add(BattleSkillDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobSkill: JobSkillHeaders.Add(JobSkillHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobSkillDescription: JobSkillDescriptionHeaders.Add(JobSkillDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9F: UnknownHeaders_9F.Add(UnknownHeader_9F.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D0: UnknownHeaders_D0.Add(UnknownHeader_D0.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D1: UnknownHeaders_D1.Add(UnknownHeader_D1.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D4: UnknownHeaders_D4.Add(UnknownHeader_D4.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D5: UnknownHeaders_D5.Add(UnknownHeader_D5.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D7: UnknownHeaders_D7.Add(UnknownHeader_D7.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DarkArtDescription: DarkArtDescritpionHeaders.Add(DarkArtDescriptionHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DarkArt: DarkArtHeaders.Add(DarkArtHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobFile2: JobFileHeaders2.Add(JobFileHeader2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobSalary: JobSalaryHeaders.Add(JobSalaryHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobLevelAndMastery: JobLevelAndMasteryHeaders.Add(JobLevelAndMasteryHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobBattleSkill: JobBattleSkillHeaders.Add(JobBattleSkillHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.JobDescription: JobDescriptionHeaders.Add(JobDescriptionHeader.ReadHeaderBlock(stageFile)); break;
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
                    case HeaderType.Unknown_8C: UnknownHeaders_8C.Add(UnknownHeader_8C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_8E: UnknownHeaders_8E.Add(UnknownHeader_8E.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9A: UnknownHeaders_9A.Add(UnknownHeader_9A.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9B: UnknownHeaders_9B.Add(UnknownHeader_9B.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9E: UnknownHeaders_9E.Add(UnknownHeader_9E.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.CPUNames: CPUNamesHeaders.Add(CPUNamesHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_17: UnknownHeaders_17.Add(UnknownHeader_17.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.MonsterDescription: MonsterDescriptionHeaders.Add(MonsterDescriptionHeader.ReadHeaderBlock(stageFile)); break;
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
                    case HeaderType.Unknown_2C: UnknownHeaders_2C.Add(UnknownHeader_2C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_2D: UnknownHeaders_2D.Add(UnknownHeader_2D.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9D: UnknownHeaders_9D.Add(UnknownHeader_9D.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_9C: UnknownHeaders_9C.Add(UnknownHeader_9C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_E1: UnknownHeaders_E1.Add(UnknownHeader_E1.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_49: UnknownHeaders_49.Add(UnknownHeader_49.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_5C: UnknownHeaders_5C.Add(UnknownHeader_5C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_4D: UnknownHeaders_4D.Add(UnknownHeader_4D.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_4E: UnknownHeaders_4E.Add(UnknownHeader_4E.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_4F: UnknownHeaders_4F.Add(UnknownHeader_4F.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_76: UnknownHeaders_76.Add(UnknownHeader_76.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_77: UnknownHeaders_77.Add(UnknownHeader_77.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DialogList: DialogListHeaders.Add(DialogListHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_E2: UnknownHeaders_E2.Add(UnknownHeader_E2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.DialogPointerList: DialogPointerListHeaders.Add(DialogPointerListHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_46: UnknownHeaders_46.Add(UnknownHeader_46.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_47: UnknownHeaders_47.Add(UnknownHeader_47.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_4C: UnknownHeaders_4C.Add(UnknownHeader_4C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_1C: UnknownHeaders_1C.Add(UnknownHeader_1C.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_1D: UnknownHeaders_1D.Add(UnknownHeader_1D.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_1E: UnknownHeaders_1E.Add(UnknownHeader_1E.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_84: UnknownHeaders_84.Add(UnknownHeader_84.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_3F: UnknownHeaders_3F.Add(UnknownHeader_3F.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_48: UnknownHeaders_48.Add(UnknownHeader_48.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_DF: UnknownHeaders_DF.Add(UnknownHeader_DF.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D3: UnknownHeaders_D3.Add(UnknownHeader_D3.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_D2: UnknownHeaders_D2.Add(UnknownHeader_D2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.InstructionsList: InstructionListHeaders.Add(InstuctionListHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.PrankName: PrankNameHeaders.Add(PrankNameHeader.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_A0: UnknownHeaders_A0.Add(UnknownHeader_A0.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_A1: UnknownHeaders_A1.Add(UnknownHeader_A1.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_A2: UnknownHeaders_A2.Add(UnknownHeader_A2.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_A3: UnknownHeaders_A3.Add(UnknownHeader_A3.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_A4: UnknownHeaders_A4.Add(UnknownHeader_A4.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_A5: UnknownHeaders_A5.Add(UnknownHeader_A5.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_AD: UnknownHeaders_AD.Add(UnknownHeader_AD.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_AE: UnknownHeaders_AE.Add(UnknownHeader_AE.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_AF: UnknownHeaders_AF.Add(UnknownHeader_AF.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_B0: UnknownHeaders_B0.Add(UnknownHeader_B0.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_B1: UnknownHeaders_B1.Add(UnknownHeader_B1.ReadHeaderBlock(stageFile)); break;
                    case HeaderType.Unknown_B2: UnknownHeaders_B2.Add(UnknownHeader_B2.ReadHeaderBlock(stageFile)); break;
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