using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class JobSkillData
    {
        public byte index { get; set; }
        public string name { get; set; }
        public int activationRate { get; set; }
        public string description { get; set; }

        public JobSkillData(string name = "None", byte index = 0x00, int activationRate = 0, string description = "None")
        {
            this.index = index;
            this.name = name;
            this.activationRate = activationRate;
            this.description = description;
        }

        public static ObservableCollection<JobSkillData> GetData(CharaFile charaFile)
        {
            ObservableCollection<JobSkillData> data = new ObservableCollection<JobSkillData>();

            foreach (var skill in charaFile.JobSkillHeaders)
            {
                JobSkillData jobSkillData = new JobSkillData(skill.name, skill.index, skill.activationRate);
                data.Add(jobSkillData);
            }

            for (int i = 0; i < charaFile.JobSkillDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.JobSkillDescriptionHeader.description[i];
            }

            data.Add(new JobSkillData());

            return data;
        }

        public static void SetData(ObservableCollection<JobSkillData> jobSkillData, ref CharaFile charaFile)
        {
            for (int i = 0; i < jobSkillData.Count - 2 && i < charaFile.JobSkillHeaders.Count; i++)
            {
                charaFile.JobSkillHeaders[i].name = jobSkillData[i].name;
                charaFile.JobSkillHeaders[i].activationRate = (byte)jobSkillData[i].activationRate;
            }

            for (int i = 0; i < jobSkillData.Count - 1 && i < charaFile.JobSkillDescriptionHeader.description.Count; i++)
            {
                charaFile.JobSkillDescriptionHeader.description[i] = jobSkillData[i].description;
            }
        }

        public static JobSkillData GetJobSkillDataByIndex(ObservableCollection<JobSkillData> jobSkillData, byte index)
        { 
            foreach (var jobSkill in jobSkillData)
            {
                if (jobSkill.index == index)
                    return jobSkill;
            }

            return new JobSkillData();
        }
    }
}
