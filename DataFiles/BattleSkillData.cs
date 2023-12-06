using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class BattleSkillData
    {
        public string name { get; set; }
        public int activationRate { get; set; }
        public string description { get; set; }

        public BattleSkillData(string name)
        {
            this.name = name;
            description = "None";
        }

        public static ObservableCollection<BattleSkillData> GetData(CharaFile charaFile)
        {
            ObservableCollection<BattleSkillData> data = new ObservableCollection<BattleSkillData>();
            foreach (var skill in charaFile.BattleSkillHeaders)
            {
                BattleSkillData battlerSkillData = new BattleSkillData(skill.name);
                battlerSkillData.activationRate = skill.activationRate;

                data.Add(battlerSkillData);
            }

            for (int i = 0; i < charaFile.BattleSkillDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.BattleSkillDescriptionHeaders[0].description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<BattleSkillData> battleSkillData, ref CharaFile charaFile)
        {
            for (int i = 0; i < battleSkillData.Count && i < charaFile.BattleSkillHeaders.Count; i++)
            {
                charaFile.BattleSkillHeaders[i].name = battleSkillData[i].name;
                charaFile.BattleSkillHeaders[i].activationRate = (byte)battleSkillData[i].activationRate;
            }

            for (int i = 0; i < battleSkillData.Count && i < charaFile.BattleSkillDescriptionHeaders.Count; i++)
            {
                charaFile.BattleSkillDescriptionHeaders[0].description[i] = battleSkillData[i].description;
            }
        }
    }
}
