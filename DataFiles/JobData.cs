using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class JobData
    {
        public string jobName { get; set; }
        public int sex { get; set; }
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
        public string level4BattleSkill { get; set; }
        public string level6BattleSkill { get; set; }
        public uint startingSalary { get; set; }
        public ushort levelUpSalaryMultiplier { get; set; }
        public byte bonusRequirementCount { get; set; }
        public float bonusMultiplier { get; set; }
        public ushort battlesToLevel { get; set; }
        public string [] masteryRequirement { get; set; }
        public string itemRequirement { get; set; }
        public string jobPassiveName { get; set; }
        public byte jobPassiveActivationRate { get; set; }
        public string jobPassiveDescription { get; set; }
        public string jobDescription { get; set; }

        public JobData(string jobName)
        {
            this.jobName = jobName;
            masteryRequirement = new string[3]
            {
                "None", "None", "None" 
            };
            itemRequirement = "None";
            level4BattleSkill = "None";
            level6BattleSkill = "None";
            jobPassiveName = String.Empty;
            jobPassiveDescription = String.Empty;
            jobDescription = String.Empty;
        }

        public static ObservableCollection<JobData> GetData(CharaFile charaFile)
        {
            ObservableCollection<JobData> data = new ObservableCollection<JobData>();

            foreach (var jobName in charaFile.JobNameHeaders)
            {
                JobData jobData = new JobData(jobName.name);
                jobData.sex = 0;
                data.Add(jobData);

                jobData = new JobData(jobName.name);
                jobData.sex = 1;
                data.Add(jobData);
            }

            foreach (var jobItemSpace in charaFile.JobItemSpaceHeaders)
            {
                data[2 * jobItemSpace.index + jobItemSpace.sex].bagItemSpace = jobItemSpace.bagItemSpace;
                data[2 * jobItemSpace.index + jobItemSpace.sex].fieldMagicSpace = jobItemSpace.fieldMagicSpace;
            }

            foreach (var jobRequirement in charaFile.JobRequirementHeaders)
            {
                for (int i = 0; i < 3; i++)
                {
                    data[(int)(2 * jobRequirement.jobIndex)].masteryRequirement[i] = charaFile.GetJobName(jobRequirement.jobRequirementIndexes[i]);
                    data[(int)(2 * jobRequirement.jobIndex) + 1].masteryRequirement[i] = charaFile.GetJobName(jobRequirement.jobRequirementIndexes[i]);
                }

                data[(int)(2 * jobRequirement.jobIndex)].itemRequirement = charaFile.GetItemName(EffectItemType.BagItem, jobRequirement.itemRequiredIndex);
                data[(int)(2 * jobRequirement.jobIndex) + 1].itemRequirement = charaFile.GetItemName(EffectItemType.BagItem, jobRequirement.itemRequiredIndex);
            }

            foreach (var jobSalary in charaFile.JobSalaryHeaders)
            {
                data[2 * jobSalary.index + jobSalary.sex].startingSalary = jobSalary.startingSalary;
                data[2 * jobSalary.index + jobSalary.sex].levelUpSalaryMultiplier = jobSalary.levelUpSalaryMultiplier;
                data[2 * jobSalary.index + jobSalary.sex].bonusRequirementCount = jobSalary.bonusRequirementCount;
                data[2 * jobSalary.index + jobSalary.sex].bonusMultiplier = (float)jobSalary.bonusMultiplier / 100;
            }

            foreach (var jobSkill in charaFile.JobSkillHeaders)
            {
                var index = jobSkill.index - 1;

                data[(int)(2 * index)].jobPassiveName = jobSkill.name;
                data[(int)(2 * index)].jobPassiveActivationRate = jobSkill.activationRate;
                data[(int)(2 * index)].jobPassiveDescription = charaFile.JobSkillDescriptionHeader.description[index];

                data[(int)(2 * index) + 1].jobPassiveName = jobSkill.name;
                data[(int)(2 * index) + 1].jobPassiveActivationRate = jobSkill.activationRate;
                data[(int)(2 * index) + 1].jobPassiveDescription = charaFile.JobSkillDescriptionHeader.description[index];
            }

            foreach (var jobStartingStats in charaFile.JobStartingStatsHeaders)
            {
                data[2 * jobStartingStats.index + jobStartingStats.sex].startingAttack = jobStartingStats.attack;
                data[2 * jobStartingStats.index + jobStartingStats.sex].startingDefense = jobStartingStats.defense;
                data[2 * jobStartingStats.index + jobStartingStats.sex].startingMagic = jobStartingStats.magic;
                data[2 * jobStartingStats.index + jobStartingStats.sex].startingSpeed = jobStartingStats.speed;
                data[2 * jobStartingStats.index + jobStartingStats.sex].startingHP = 10 * jobStartingStats.hp;
            }

            foreach (var jobBattleSkill in charaFile.JobBattleSkillHeaders)
            {
                data[2 * jobBattleSkill.index + jobBattleSkill.sex].level4BattleSkill = charaFile.GetItemName(EffectItemType.BattleSkill, jobBattleSkill.firstBattleSkillIndex);
                data[2 * jobBattleSkill.index + jobBattleSkill.sex].level6BattleSkill = charaFile.GetItemName(EffectItemType.BattleSkill, jobBattleSkill.secondBattleSkillIndex);
            }

            for (int i = 0; i < charaFile.JobDescriptionHeader.description.Count; i++)
            {
                data[i].jobDescription = charaFile.JobDescriptionHeader.description[i];
            }

            foreach (var levelUp in charaFile.JobLevelAndMasteryHeaders)
            {
                data[2 * levelUp.index + levelUp.sex].levelUpAttack = levelUp.levelUpAttack;
                data[2 * levelUp.index + levelUp.sex].levelUpDefense = levelUp.levelUpDefense;
                data[2 * levelUp.index + levelUp.sex].levelUpMagic = levelUp.levelUpMagic;
                data[2 * levelUp.index + levelUp.sex].levelUpSpeed = levelUp.levelUpSpeed;
                data[2 * levelUp.index + levelUp.sex].levelUpHP = 10 * (int)levelUp.levelUpHP;

                data[2 * levelUp.index + levelUp.sex].masteryAttack = levelUp.masteryAttack;
                data[2 * levelUp.index + levelUp.sex].masteryDefense = levelUp.masteryDefense;
                data[2 * levelUp.index + levelUp.sex].masteryMagic = levelUp.masteryMagic;
                data[2 * levelUp.index + levelUp.sex].masterySpeed = levelUp.masterySpeed;
                data[2 * levelUp.index + levelUp.sex].masteryHP = 10 * (int)levelUp.masteryHP;
            }

            foreach (var levelUpRequirement in charaFile.JobLevelUpRequirementHeaders)
            {
                data[2 * levelUpRequirement.index + levelUpRequirement.sex].battlesToLevel = levelUpRequirement.battlesToLevel;
            }         

            return data;
        }

        public static void SetData(ObservableCollection<JobData> jobData, ref CharaFile charaFile)
        {
            for (int i = 0; i < jobData.Count / 2 && i < charaFile.JobNameHeaders.Count; i++)
            {
                charaFile.JobNameHeaders[i].name = jobData[2 * i].jobName;
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobItemSpaceHeaders.Count; i++)
            {
                charaFile.JobItemSpaceHeaders[i].bagItemSpace = jobData[i].bagItemSpace;
                charaFile.JobItemSpaceHeaders[i].fieldMagicSpace = jobData[i].fieldMagicSpace;
            }

            foreach (var jobRequirement in charaFile.JobRequirementHeaders)
            {
                for (int i = 0; i < 3; i++)
                {
                    jobRequirement.jobRequirementIndexes[i] = charaFile.GetJobIndex(jobData[2 * jobRequirement.jobIndex].masteryRequirement[i]);
                }

                jobRequirement.itemRequiredIndex = charaFile.GetItemID(EffectItemType.BagItem, jobData[2 * jobRequirement.jobIndex].itemRequirement);
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobSalaryHeaders.Count; i++)
            {
                charaFile.JobSalaryHeaders[i].startingSalary = jobData[i].startingSalary;
                charaFile.JobSalaryHeaders[i].levelUpSalaryMultiplier = jobData[i].levelUpSalaryMultiplier;
                charaFile.JobSalaryHeaders[i].bonusRequirementCount = jobData[i].bonusRequirementCount;
                charaFile.JobSalaryHeaders[i].bonusMultiplier = (ushort)(100 * jobData[i].bonusMultiplier + 0.5);
            }

            for (int i = 0; i < jobData.Count / 2 && i < charaFile.JobSkillHeaders.Count; i++)
            {
                charaFile.JobSkillHeaders[i].name = jobData[2 * i].jobPassiveName;
                charaFile.JobSkillHeaders[i].activationRate = jobData[2 * i].jobPassiveActivationRate;
                charaFile.JobSkillDescriptionHeader.description[i] = jobData[2 * i].jobPassiveDescription;
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobStartingStatsHeaders.Count; i++)
            {
                charaFile.JobStartingStatsHeaders[i].attack = jobData[i].startingAttack;
                charaFile.JobStartingStatsHeaders[i].defense = jobData[i].startingDefense;
                charaFile.JobStartingStatsHeaders[i].magic = jobData[i].startingMagic;
                charaFile.JobStartingStatsHeaders[i].speed = jobData[i].startingSpeed;
                charaFile.JobStartingStatsHeaders[i].hp = (ushort)(jobData[i].startingHP / 10);
            }

            for (int i = 0; i < jobData.Count; i++)
            {
                charaFile.JobBattleSkillHeaders[i].firstBattleSkillIndex = charaFile.GetItemID(EffectItemType.BattleSkill, jobData[i].level4BattleSkill);
                charaFile.JobBattleSkillHeaders[i].secondBattleSkillIndex = charaFile.GetItemID(EffectItemType.BattleSkill, jobData[i].level6BattleSkill);
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobBattleSkillHeaders.Count; i++)
            {
                charaFile.JobDescriptionHeader.description[i] = jobData[i].jobDescription;
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobLevelAndMasteryHeaders.Count; i++)
            {
                charaFile.JobLevelAndMasteryHeaders[i].levelUpAttack = jobData[i].levelUpAttack;
                charaFile.JobLevelAndMasteryHeaders[i].levelUpDefense = jobData[i].levelUpDefense;
                charaFile.JobLevelAndMasteryHeaders[i].levelUpMagic = jobData[i].levelUpMagic;
                charaFile.JobLevelAndMasteryHeaders[i].levelUpSpeed = jobData[i].levelUpSpeed;
                charaFile.JobLevelAndMasteryHeaders[i].levelUpHP = (ushort)(jobData[i].levelUpHP / 10);

                charaFile.JobLevelAndMasteryHeaders[i].masteryAttack = jobData[i].masteryAttack;
                charaFile.JobLevelAndMasteryHeaders[i].masteryDefense = jobData[i].masteryDefense;
                charaFile.JobLevelAndMasteryHeaders[i].masteryMagic = jobData[i].masteryMagic;
                charaFile.JobLevelAndMasteryHeaders[i].masterySpeed = jobData[i].masterySpeed;
                charaFile.JobLevelAndMasteryHeaders[i].masteryHP = (ushort)(jobData[i].masteryHP / 10);
            }

            for (int i = 0; i < jobData.Count && i < charaFile.JobLevelUpRequirementHeaders.Count; i++)
            {
                charaFile.JobLevelUpRequirementHeaders[i].battlesToLevel = jobData[i].battlesToLevel;
            }
        }
    }
}
