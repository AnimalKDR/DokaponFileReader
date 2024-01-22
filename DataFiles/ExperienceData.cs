using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class ExperienceData
    {
        public int level { get; set; }
        public uint experience { get; set; }

        public ExperienceData(int level, uint experience)
        {
            this.level = level;
            this.experience = experience;
        }

        public static ObservableCollection<ExperienceData> GetData(CharaFile charaFile)
        {
            ObservableCollection<ExperienceData> data = new ObservableCollection<ExperienceData>();

            for(int i = 0; i < charaFile.ExperienceRequirementHeader.experienceRequired.Count; i++)
            {
                data.Add(new ExperienceData(i + 1, charaFile.ExperienceRequirementHeader.experienceRequired[i]));
            }

            return data;
        }

        public static void SetData(ObservableCollection<ExperienceData> experienceData, ref CharaFile charaFile)
        {
            for (int i = 0; i < charaFile.ExperienceRequirementHeader.experienceRequired.Count; i++)
            {
                charaFile.ExperienceRequirementHeader.experienceRequired[i] = experienceData[i].experience;
            }
        }
    }
}
