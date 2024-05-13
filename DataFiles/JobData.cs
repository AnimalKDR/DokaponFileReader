using DokaponFileReader.DataFiles;
using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class JobData
    {
        public JobNameData jobName { get; set; }
        public ushort startingAttack { get; set; }
        public ushort startingDefense { get; set; }
        public ushort startingMagic { get; set; }
        public ushort startingSpeed { get; set; }
        public int startingHP { get; set; }
        public ushort levelUpAttack { get; set; }
        public ushort levelUpDefense { get; set; }
        public ushort levelUpMagic { get; set; }
        public ushort levelUpSpeed { get; set; }
        public int levelUpHP { get; set; }
        public ushort masteryAttack { get; set; }
        public ushort masteryDefense { get; set; }
        public ushort masteryMagic { get; set; }
        public ushort masterySpeed { get; set; }
        public int masteryHP { get; set; }
        public byte bagItemSpace { get; set; }
        public byte fieldMagicSpace { get; set; }
        public BattleSkillData level4BattleSkill { get; set; }
        public BattleSkillData level6BattleSkill { get; set; }
        public JobSkillData passiveSkill { get; set; }
        public ItemData itemRequirement { get; set; }
        public uint startingSalary { get; set; }
        public ushort levelUpSalaryMultiplier { get; set; }
        public byte bonusRequirementCount { get; set; }
        public float bonusMultiplier { get; set; }
        public ushort battlesToLevel { get; set; }
        public JobNameData[] masteryRequirement { get; set; }
        public string jobDescription { get; set; }

        public JobData()
        {
            this.jobName = new JobNameData();
            masteryRequirement = new JobNameData[3] { new JobNameData(), new JobNameData(), new JobNameData() };
            itemRequirement = new ItemData();
            level4BattleSkill = new BattleSkillData();
            level6BattleSkill = new BattleSkillData();
            passiveSkill = new JobSkillData();
            jobDescription = String.Empty;
        }

        public static ObservableCollection<JobData> GetData(CharaFile charaFile, ObservableCollection<BattleSkillData> battleSkillData, ObservableCollection<JobSkillData> jobSkillData, ObservableCollection<ItemData> itemData, ObservableCollection<JobNameData> jobNameData)
        {
            ObservableCollection<JobData> data = new ObservableCollection<JobData>();

            foreach (var jobName in charaFile.JobNameHeaders)
            {
                JobData jobData = new JobData();
                jobData.jobName = JobNameData.GetJobNameDataByIndex(jobNameData, jobName.index);
                data.Add(jobData);
            }

            foreach (var jobItemSpace in charaFile.JobItemSpaceHeaders)
            {
                if (jobItemSpace.sex == 1)
                    continue;

                  data[jobItemSpace.index].bagItemSpace = jobItemSpace.bagItemSpace;
                  data[jobItemSpace.index].fieldMagicSpace = jobItemSpace.fieldMagicSpace;
            }

            foreach (var jobRequirement in charaFile.JobRequirementHeaders)
            {
                for (int i = 0; i < 3; i++)
                {
                    data[jobRequirement.jobIndex].masteryRequirement[i] = JobNameData.GetJobNameDataByIndex(jobNameData, jobRequirement.jobRequirementIndexes[i]);
                }

                data[jobRequirement.jobIndex].itemRequirement = ItemData.GetItemFromIndex(itemData, EffectItemType.BagItem, jobRequirement.itemRequiredIndex);
            }

            foreach (var jobSalary in charaFile.JobSalaryHeaders)
            {
                if (jobSalary.sex == 1)
                    continue;

                data[jobSalary.index].startingSalary = jobSalary.startingSalary;
                data[jobSalary.index].levelUpSalaryMultiplier = jobSalary.levelUpSalaryMultiplier;
                data[jobSalary.index].bonusRequirementCount = jobSalary.bonusRequirementCount;
                data[jobSalary.index].bonusMultiplier = (float)jobSalary.bonusMultiplier / 100;
            }

            foreach (var jobSkill in charaFile.JobSkillHeaders)
            {
                data[jobSkill.index - 1].passiveSkill = JobSkillData.GetJobSkillDataByIndex(jobSkillData, jobSkill.index);
            }

            foreach (var jobStartingStats in charaFile.JobStartingStatsHeaders)
            {
                if (jobStartingStats.sex == 1)
                    continue;

                data[jobStartingStats.index].startingAttack = jobStartingStats.attack;
                data[jobStartingStats.index].startingDefense = jobStartingStats.defense;
                data[jobStartingStats.index].startingMagic = jobStartingStats.magic;
                data[jobStartingStats.index].startingSpeed = jobStartingStats.speed;
                data[jobStartingStats.index].startingHP = 10 * jobStartingStats.hp;
            }

            foreach (var jobBattleSkill in charaFile.JobBattleSkillHeaders)
            {
                if (jobBattleSkill.sex == 1)
                    continue;

                data[jobBattleSkill.index].level4BattleSkill = BattleSkillData.GetBattleSkillDataByIndex(battleSkillData, jobBattleSkill.firstBattleSkillIndex);
                data[jobBattleSkill.index].level6BattleSkill = BattleSkillData.GetBattleSkillDataByIndex(battleSkillData, jobBattleSkill.secondBattleSkillIndex);
            }

            for (int i = 0; i < charaFile.JobDescriptionHeader.description.Count / 2; i++)
            {
                data[i].jobDescription = charaFile.JobDescriptionHeader.description[2 * i];
            }

            foreach (var levelUp in charaFile.JobLevelAndMasteryHeaders)
            {
                if (levelUp.sex == 1)
                    continue;

                data[levelUp.index].levelUpAttack = levelUp.levelUpAttack;
                data[levelUp.index].levelUpDefense = levelUp.levelUpDefense;
                data[levelUp.index].levelUpMagic = levelUp.levelUpMagic;
                data[levelUp.index].levelUpSpeed = levelUp.levelUpSpeed;
                data[levelUp.index].levelUpHP = 10 * (int)levelUp.levelUpHP;

                data[levelUp.index].masteryAttack = levelUp.masteryAttack;
                data[levelUp.index].masteryDefense = levelUp.masteryDefense;
                data[levelUp.index].masteryMagic = levelUp.masteryMagic;
                data[levelUp.index].masterySpeed = levelUp.masterySpeed;
                data[levelUp.index].masteryHP = 10 * (int)levelUp.masteryHP;
            }

            foreach (var levelUpRequirement in charaFile.JobLevelUpRequirementHeaders)
            {
                if (levelUpRequirement.sex == 1)
                    continue;

                data[levelUpRequirement.index].battlesToLevel = levelUpRequirement.battlesToLevel;
            }         

            return data;
        }

        public static void SetData(ObservableCollection<JobData> jobData, ref CharaFile charaFile)
        {
            for (int i = 0; i < jobData.Count; i++)
            {
                charaFile.JobNameHeaders[i].name = jobData[i].jobName.name;
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobItemSpaceHeaders.Count / 2;  i++)
            {
                charaFile.JobItemSpaceHeaders[(2 * i) + 0].bagItemSpace = jobData[i].bagItemSpace;
                charaFile.JobItemSpaceHeaders[(2 * i) + 0].fieldMagicSpace = jobData[i].fieldMagicSpace;
                charaFile.JobItemSpaceHeaders[(2 * i) + 1].bagItemSpace = jobData[i].bagItemSpace;
                charaFile.JobItemSpaceHeaders[(2 * i) + 1].fieldMagicSpace = jobData[i].fieldMagicSpace;
            }

            foreach (var jobRequirement in charaFile.JobRequirementHeaders)
            {
                for (int i = 0; i < 3; i++)
                {
                    jobRequirement.jobRequirementIndexes[i] = (byte)jobData[jobRequirement.jobIndex].masteryRequirement[i].index;
                }

                jobRequirement.itemRequiredIndex = jobData[jobRequirement.jobIndex].itemRequirement.index;
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobSalaryHeaders.Count / 2; i++)
            {
                charaFile.JobSalaryHeaders[(2 * i) + 0].startingSalary = jobData[i].startingSalary;
                charaFile.JobSalaryHeaders[(2 * i) + 0].levelUpSalaryMultiplier = jobData[i].levelUpSalaryMultiplier;
                charaFile.JobSalaryHeaders[(2 * i) + 0].bonusRequirementCount = jobData[i].bonusRequirementCount;
                charaFile.JobSalaryHeaders[(2 * i) + 0].bonusMultiplier = (ushort)(100 * jobData[i].bonusMultiplier + 0.5);

                charaFile.JobSalaryHeaders[(2 * i) + 1].startingSalary = jobData[i].startingSalary;
                charaFile.JobSalaryHeaders[(2 * i) + 1].levelUpSalaryMultiplier = jobData[i].levelUpSalaryMultiplier;
                charaFile.JobSalaryHeaders[(2 * i) + 1].bonusRequirementCount = jobData[i].bonusRequirementCount;
                charaFile.JobSalaryHeaders[(2 * i) + 1].bonusMultiplier = (ushort)(100 * jobData[i].bonusMultiplier + 0.5);
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobSkillHeaders.Count; i++)
            {
                charaFile.JobSkillHeaders[i].index = jobData[i].passiveSkill.index;
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobStartingStatsHeaders.Count / 2; i++)
            {
                charaFile.JobStartingStatsHeaders[(2 * i) + 0].attack = jobData[i].startingAttack;
                charaFile.JobStartingStatsHeaders[(2 * i) + 0].defense = jobData[i].startingDefense;
                charaFile.JobStartingStatsHeaders[(2 * i) + 0].magic = jobData[i].startingMagic;
                charaFile.JobStartingStatsHeaders[(2 * i) + 0].speed = jobData[i].startingSpeed;
                charaFile.JobStartingStatsHeaders[(2 * i) + 0].hp = (ushort)(jobData[i].startingHP / 10);

                charaFile.JobStartingStatsHeaders[(2 * i) + 1].attack = jobData[i].startingAttack;
                charaFile.JobStartingStatsHeaders[(2 * i) + 1].defense = jobData[i].startingDefense;
                charaFile.JobStartingStatsHeaders[(2 * i) + 1].magic = jobData[i].startingMagic;
                charaFile.JobStartingStatsHeaders[(2 * i) + 1].speed = jobData[i].startingSpeed;
                charaFile.JobStartingStatsHeaders[(2 * i) + 1].hp = (ushort)(jobData[i].startingHP / 10);
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobBattleSkillHeaders.Count / 2; i++)
            {
                charaFile.JobBattleSkillHeaders[(2 * i) + 0].firstBattleSkillIndex = jobData[i].level4BattleSkill.index;
                charaFile.JobBattleSkillHeaders[(2 * i) + 0].secondBattleSkillIndex = jobData[i].level6BattleSkill.index;

                charaFile.JobBattleSkillHeaders[(2 * i) + 1].firstBattleSkillIndex = jobData[i].level4BattleSkill.index;
                charaFile.JobBattleSkillHeaders[(2 * i) + 1].secondBattleSkillIndex = jobData[i].level6BattleSkill.index;
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobDescriptionHeader.description.Count / 2; i++)
            {
                charaFile.JobDescriptionHeader.description[(2 * i) + 0] = jobData[i].jobDescription;

                charaFile.JobDescriptionHeader.description[(2 * i) + 1] = jobData[i].jobDescription;
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobLevelAndMasteryHeaders.Count / 2; i++)
            {
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].levelUpAttack = jobData[i].levelUpAttack;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].levelUpDefense = jobData[i].levelUpDefense;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].levelUpMagic = jobData[i].levelUpMagic;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].levelUpSpeed = jobData[i].levelUpSpeed;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].levelUpHP = (ushort)(jobData[i].levelUpHP / 10);

                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].masteryAttack = jobData[i].masteryAttack;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].masteryDefense = jobData[i].masteryDefense;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].masteryMagic = jobData[i].masteryMagic;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].masterySpeed = jobData[i].masterySpeed;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 0].masteryHP = (ushort)(jobData[i].masteryHP / 10);

                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].levelUpAttack = jobData[i].levelUpAttack;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].levelUpDefense = jobData[i].levelUpDefense;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].levelUpMagic = jobData[i].levelUpMagic;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].levelUpSpeed = jobData[i].levelUpSpeed;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].levelUpHP = (ushort)(jobData[i].levelUpHP / 10);

                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].masteryAttack = jobData[i].masteryAttack;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].masteryDefense = jobData[i].masteryDefense;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].masteryMagic = jobData[i].masteryMagic;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].masterySpeed = jobData[i].masterySpeed;
                charaFile.JobLevelAndMasteryHeaders[(2 * i) + 1].masteryHP = (ushort)(jobData[i].masteryHP / 10);
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobLevelUpRequirementHeaders.Count / 2; i++)
            {
                charaFile.JobLevelUpRequirementHeaders[(2 * i) + 0].battlesToLevel = jobData[i].battlesToLevel;

                charaFile.JobLevelUpRequirementHeaders[(2 * i) + 1].battlesToLevel = jobData[i].battlesToLevel;
            }
        }
    }
}
