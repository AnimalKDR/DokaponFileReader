using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class RandomLootData
    {
        public string itemName { get; set; }
        public EffectItemType itemType { get; set; }

        public RandomLootData(EffectItemType itemType, string itemName)
        {
            this.itemType = itemType;
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
                    itemName = charaFile.GetItemName((EffectItemType)item.type, item.index);
                else
                    itemName = stageBaseFile.GetEffectName(item.type, item.index);

                data.Add(new RandomLootData((EffectItemType)item.type, itemName));
            }

            return data;
        }

        public static void SetData(ObservableCollection<RandomLootData> randomLootData, ref CharaFile charaFile, ref StageBaseFile stageBaseFile, int index)
        {
            if (index >= stageBaseFile.RandomLootHeaders.Count)
                return;

            for (int i = 0; i < randomLootData.Count; i++)
            {
                if (randomLootData[i].itemType >= EffectItemType.GainGold)
                {
                    stageBaseFile.RandomLootHeaders[index].itemList[i] = (stageBaseFile.GetEffectTypeIndex(randomLootData[i].itemName), (byte)randomLootData[i].itemType);
                }
                else
                {
                    stageBaseFile.RandomLootHeaders[index].itemList[i] = (charaFile.GetItemID(randomLootData[i].itemType, randomLootData[i].itemName), (byte)randomLootData[i].itemType);
                }
            }
        }
    }
}
