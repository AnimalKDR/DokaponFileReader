using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class MonsterEncounterData
    {
        public List<MonsterData> monster;

        public MonsterEncounterData()
        {
            monster = new List<MonsterData>();
        }

        public static ObservableCollection<MonsterEncounterData> GetData(CharaFile charaFile, ObservableCollection<MonsterData> monsterData)
        {
            ObservableCollection<MonsterEncounterData> data = new ObservableCollection<MonsterEncounterData>();

            for (int listIndex = 0; listIndex < charaFile.MonsterEncounterHeader.monsterEncounterList.Count; listIndex++)
            {
                MonsterEncounterData encounterData = new MonsterEncounterData();

                foreach (var monsterIndex in charaFile.MonsterEncounterHeader.monsterEncounterList[listIndex])
                {
                    if (monsterIndex == 0xFF || monsterIndex >= monsterData.Count)
                        continue;

                    encounterData.monster.Add(monsterData[monsterIndex]);
                }

                data.Add(encounterData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<MonsterEncounterData> monsterEncounterData, ObservableCollection<MonsterData> monsterData, ref CharaFile charaFile)
        {
            for (int encounterListIndex = 0; encounterListIndex < monsterEncounterData.Count && encounterListIndex < charaFile.MonsterEncounterHeader.monsterEncounterList.Count; encounterListIndex++)
            {
                for (int monsterIndex = 0; monsterIndex < monsterEncounterData[encounterListIndex].monster.Count && monsterIndex < charaFile.MonsterEncounterHeader.monsterEncounterList[encounterListIndex].Count; monsterIndex++)
                {
                    charaFile.MonsterEncounterHeader.monsterEncounterList[encounterListIndex][monsterIndex] = monsterEncounterData[encounterListIndex].monster[monsterIndex].index;
                }
            }
        }

        public static byte GetMonsterIndexFromName(string monsterName, ObservableCollection<MonsterData> monsterData)
        {
            for (byte index = 0; index < monsterData.Count; index++)
            {
                if (monsterData[index].name == monsterName)
                    return index;
            }

            return 0;
        }
    }
}
