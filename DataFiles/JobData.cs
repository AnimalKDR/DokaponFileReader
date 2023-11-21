using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class JobData
    {
        public string jobName { get; set; }
        public int sex { get; set; }
        public int startingAttack { get; set; }
        public int startingDefense { get; set; }
        public int startingMagic { get; set; }
        public int startingSpeed { get; set; }
        public int startingHP { get; set; }
        public int levelUpAttack { get; set; }
        public int levelUpDefense { get; set; }
        public int levelUpMagic { get; set; }
        public int levelUpSpeed { get; set; }
        public int levelUpHP { get; set; }
        public int masteryAttack { get; set; }
        public int masteryDefense { get; set; }
        public int masteryMagic { get; set; }
        public int masterySpeed { get; set; }
        public int masteryHP { get; set; }
        public int bagItemSpace { get; set; }
        public int fieldMagicSpace { get; set; }
        public string level4BattleSkill { get; set; }
        public string level6BattleSkill { get; set; }
        public int startingSalary { get; set; }
        public int levelUpSalaryMultiplier { get; set; }
        public int bonusRequirementCount { get; set; }
        public float bonusMultiplier { get; set; }
        public int battlesToLevel { get; set; }
        public string [] masteryRequirement { get; set; }
        public string itemRequirement { get; set; }
        public string jobPassiveName { get; set; }
        public int jobPassiveActivationRate { get; set; }
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
                    if (jobRequirement.jobRequirementIndexes[i] != 0xFF)
                    {
                        data[(int)(2 * jobRequirement.jobIndex)].masteryRequirement[i] = charaFile.JobNameHeaders[jobRequirement.jobRequirementIndexes[i]].name;
                        data[(int)(2 * jobRequirement.jobIndex) + 1].masteryRequirement[i] = charaFile.JobNameHeaders[jobRequirement.jobRequirementIndexes[i]].name;
                    }
                    else
                    {
                        data[(int)(2 * jobRequirement.jobIndex)].masteryRequirement[i] = "None";
                        data[(int)(2 * jobRequirement.jobIndex) + 1].masteryRequirement[i] = "None";
                    }


                    data[(int)(2 * jobRequirement.jobIndex)].itemRequirement = charaFile.GetItemName(ItemType.BagItem, jobRequirement.itemRequiredIndex);
                    data[(int)(2 * jobRequirement.jobIndex) + 1].itemRequirement = charaFile.GetItemName(ItemType.BagItem, jobRequirement.itemRequiredIndex);
                }
            }

            foreach (var jobSalary in charaFile.JobSalaryHeaders)
            {
                data[2 * jobSalary.index + jobSalary.sex].startingSalary = (int)jobSalary.startingSalary;
                data[2 * jobSalary.index + jobSalary.sex].levelUpSalaryMultiplier = (int)jobSalary.salaryMultiplier;
                data[2 * jobSalary.index + jobSalary.sex].bonusRequirementCount = (int)jobSalary.bonusRequirementCount;
                data[2 * jobSalary.index + jobSalary.sex].bonusMultiplier = (float)jobSalary.bonusMultiplier / 100;
            }

            foreach (var jobSkill in charaFile.JobSkillHeaders)
            {
                var index = jobSkill.index - 1;

                data[(int)(2 * index)].jobPassiveName = jobSkill.name;
                data[(int)(2 * index)].jobPassiveActivationRate = jobSkill.activationRate;
                data[(int)(2 * index)].jobPassiveDescription = charaFile.JobSkillDescriptionHeaders[0].description[index];

                data[(int)(2 * index) + 1].jobPassiveName = jobSkill.name;
                data[(int)(2 * index) + 1].jobPassiveActivationRate = jobSkill.activationRate;
                data[(int)(2 * index) + 1].jobPassiveDescription = charaFile.JobSkillDescriptionHeaders[0].description[index];
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
                data[(int)(2 * jobBattleSkill.index)].level4BattleSkill = charaFile.GetItemName(ItemType.BattleSkill, jobBattleSkill.firstBattleSkillIndex);
                data[(int)(2 * jobBattleSkill.index) + 1].level4BattleSkill = charaFile.GetItemName(ItemType.BattleSkill, jobBattleSkill.firstBattleSkillIndex);

                data[(int)(2 * jobBattleSkill.index)].level6BattleSkill = charaFile.GetItemName(ItemType.BattleSkill, jobBattleSkill.secondBattleSkillIndex);
                data[(int)(2 * jobBattleSkill.index) + 1].level6BattleSkill = charaFile.GetItemName(ItemType.BattleSkill, jobBattleSkill.secondBattleSkillIndex);

                for (int i = 0; i < charaFile.JobDescriptionHeaders[0].description.Count; i++)
                {
                    data[i].jobDescription = charaFile.JobDescriptionHeaders[0].description[i];
                }

                foreach (var levelUp in charaFile.JobLevelAndMasteryHeaders)
                {
                    data[2 * levelUp.index + levelUp.sex].levelUpAttack = (int)levelUp.attackLevelUp;
                    data[2 * levelUp.index + levelUp.sex].levelUpDefense = (int)levelUp.defenseLevelUp;
                    data[2 * levelUp.index + levelUp.sex].levelUpMagic = (int)levelUp.magicLevelUp;
                    data[2 * levelUp.index + levelUp.sex].levelUpSpeed = (int)levelUp.speedLevelUp;
                    data[2 * levelUp.index + levelUp.sex].levelUpHP = 10 * (int)levelUp.hpLevelUp;

                    data[2 * levelUp.index + levelUp.sex].masteryAttack = (int)levelUp.attackMastery;
                    data[2 * levelUp.index + levelUp.sex].masteryDefense = (int)levelUp.defenseMastery;
                    data[2 * levelUp.index + levelUp.sex].masteryMagic = (int)levelUp.magicMastery;
                    data[2 * levelUp.index + levelUp.sex].masterySpeed = (int)levelUp.speedMastery;
                    data[2 * levelUp.index + levelUp.sex].masteryHP = 10 * (int)levelUp.hpMastery;
                }

                foreach (var levelUpRequirement in charaFile.JobLevelUpRequirementHeaders)
                {
                    data[2 * levelUpRequirement.index + levelUpRequirement.sex].battlesToLevel = (int)levelUpRequirement.battlesToLevel;
                }
            }

            return data;
        }
    }
}
