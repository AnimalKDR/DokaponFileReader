using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class RandomLootData
    {
        public List<DataEffectItem> randomItems;

        public RandomLootData()
        {
            randomItems = new List<DataEffectItem>();
        }

        public static ObservableCollection<RandomLootData> GetData(StageBaseFile stageBaseFile, ObservableCollection<EffectItemData> itemData)
        {
            ObservableCollection<RandomLootData> data = new ObservableCollection<RandomLootData>();

            for (int randomItemListIndex = 0; randomItemListIndex < stageBaseFile.RandomLootHeaders.Count; randomItemListIndex++)
            {
                RandomLootData randomLootData = new RandomLootData();

                foreach (var item in stageBaseFile.RandomLootHeaders[randomItemListIndex].itemList)
                {
                    DataEffectItem randomEffectItem = new DataEffectItem(EffectItemData.GetEffectItemFromIndex(itemData, (EffectItemType)item.type, item.index));
                    randomLootData.randomItems.Add(randomEffectItem);
                }

                data.Add(randomLootData);
            }
            return data;
        }

        public static void SetData(ObservableCollection<RandomLootData> randomLootData, ref StageBaseFile stageBaseFile)
        {
            for (int randomItemListIndex = 0; randomItemListIndex < stageBaseFile.RandomLootHeaders.Count && randomItemListIndex < randomLootData.Count; randomItemListIndex++)
            {
                for (int randomItemIndex = 0; randomItemIndex < stageBaseFile.RandomLootHeaders[randomItemListIndex].itemList.Count; randomItemIndex++)
                {
                    stageBaseFile.RandomLootHeaders[randomItemListIndex].itemList[randomItemIndex] = (randomLootData[randomItemListIndex].randomItems[randomItemIndex].item.index, (byte)randomLootData[randomItemListIndex].randomItems[randomItemIndex].item.itemType);
                }
            }
        }
    }
}
