using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class RandomLootData
    {
        public string itemName { get; set; }

        public RandomLootData(string itemName)
        {
            this.itemName = itemName;
        }

        public static ObservableCollection<RandomLootData> GetData(CharaFile charaFile, StageBaseFile stageBaseFile, int index)
        {
            ObservableCollection<RandomLootData> data = new ObservableCollection<RandomLootData>();

            if (index >= stageBaseFile.RandomLootHeaders.Count)
                return data;

            foreach (var item in stageBaseFile.RandomLootHeaders[index].itemList)
            {
                string itemName;

                if (item.type < 0x80)
                    itemName = charaFile.GetItemName((ItemType)item.type, item.index);
                else
                    itemName = stageBaseFile.GetEffectName(item.type, item.index);

                data.Add(new RandomLootData(itemName));
            }

            return data;
        }

        public static void SetData(ObservableCollection<RandomLootData> randomLootData, ref CharaFile charaFile, ref StageBaseFile stageBaseFile, int index)
        {
            if (index >= stageBaseFile.RandomLootHeaders.Count)
                return;

            for (int i = 0; i < randomLootData.Count; i++)
            {
                (byte type, byte id) = charaFile.GetItemTypeAndID(randomLootData[i].itemName);

                if (type == (byte)ItemType.None)
                    (type, id) = stageBaseFile.GetEffectTypeAndID(randomLootData[i].itemName);

                stageBaseFile.RandomLootHeaders[index].itemList[i] = (id, type);
            }
        }
    }
}
