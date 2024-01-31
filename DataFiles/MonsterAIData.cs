using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class MonsterAIData
    {
        public byte index { get; set; }
        public byte attackRate { get; set; }
        public byte magicRate { get; set; }
        public byte skillRate { get; set; }
        public byte strikeRate { get; set; }
        public byte defendRate { get; set; }
        public byte magicDefendRate { get; set; }
        public byte counterRate { get; set; }

        public MonsterAIData()
        {
        }

        public static ObservableCollection<MonsterAIData> GetData(CharaFile charaFile)
        {
            ObservableCollection<MonsterAIData> data = new ObservableCollection<MonsterAIData>();
            foreach (var monsterAI in charaFile.MonsterAITableHeaders)
            {
                MonsterAIData monsterAIData = new MonsterAIData();
                monsterAIData.index = monsterAI.index;

                monsterAIData.attackRate = monsterAI.attackRate;
                monsterAIData.magicRate = monsterAI.magicRate;
                monsterAIData.skillRate = monsterAI.skillRate;
                monsterAIData.strikeRate = monsterAI.strikeRate;
                monsterAIData.defendRate = monsterAI.defendRate;
                monsterAIData.magicDefendRate = monsterAI.magicDefendRate;
                monsterAIData.counterRate = monsterAI.counterRate;

                data.Add(monsterAIData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<MonsterAIData> monsterAIData, ref CharaFile charaFile)
        {
            for (int i = 0; i < monsterAIData.Count && i < charaFile.MonsterAITableHeaders.Count; i++)
            {
                charaFile.MonsterAITableHeaders[i].attackRate = monsterAIData[i].attackRate;
                charaFile.MonsterAITableHeaders[i].magicRate = monsterAIData[i].magicRate;
                charaFile.MonsterAITableHeaders[i].skillRate = monsterAIData[i].skillRate;
                charaFile.MonsterAITableHeaders[i].strikeRate = monsterAIData[i].strikeRate;
                charaFile.MonsterAITableHeaders[i].defendRate = monsterAIData[i].defendRate;
                charaFile.MonsterAITableHeaders[i].magicDefendRate = monsterAIData[i].magicDefendRate;
                charaFile.MonsterAITableHeaders[i].counterRate = monsterAIData[i].counterRate;
            }
        }
    }
}
