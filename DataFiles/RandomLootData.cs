using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class RandomLootData
    {
        public string item { get; set; }

        public RandomLootData(string item)
        {
            this.item = item;
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
    }
}
