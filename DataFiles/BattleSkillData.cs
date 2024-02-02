using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class BattleSkillData
    {
        public byte index { get; set; }
        public string name { get; set; }
        public int activationRate { get; set; }
        public string description { get; set; }

        public BattleSkillData(string name = "None", byte index = 0x00, int activationRate = 0, string description = "None")
        {
            this.index = index;
            this.name = name;
            this.activationRate = activationRate;
            this.description = description;
        }

        public static ObservableCollection<BattleSkillData> GetData(CharaFile charaFile)
        {
            ObservableCollection<BattleSkillData> data = new ObservableCollection<BattleSkillData>();

            foreach (var skill in charaFile.BattleSkillHeaders)
            {
                BattleSkillData battleSkillData = new BattleSkillData(skill.name, skill.index, skill.activationRate);
                data.Add(battleSkillData);
            }

            for (int i = 0; i < charaFile.BattleSkillDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.BattleSkillDescriptionHeader.description[i];
            }

            data.Add(new BattleSkillData("Clonus", 0x80, 100, "Clonus"));
            data.Add(new BattleSkillData());

            return data;
        }

        public static void SetData(ObservableCollection<BattleSkillData> battleSkillData, ref CharaFile charaFile)
        {
            for (int i = 0; i < battleSkillData.Count - 2 && i < charaFile.BattleSkillHeaders.Count; i++)
            {
                charaFile.BattleSkillHeaders[i].name = battleSkillData[i].name;
                charaFile.BattleSkillHeaders[i].activationRate = (byte)battleSkillData[i].activationRate;
            }

            for (int i = 0; i < battleSkillData.Count - 2 && i < charaFile.BattleSkillDescriptionHeader.description.Count; i++)
            {
                charaFile.BattleSkillDescriptionHeader.description[i] = battleSkillData[i].description;
            }
        }

        public static BattleSkillData GetBattleSkillDataByIndex(ObservableCollection<BattleSkillData> battleSkillData, byte index)
        { 
            foreach (var battleSkill in battleSkillData)
            {
                if (battleSkill.index == index)
                    return battleSkill;
            }

            return new BattleSkillData();
        }
    }
}
