using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class ItemStoreData
    {
        private const int ItemStoreIndex = 1;

        public List<DataItem> storeItems;

        public ItemStoreData()
        {
            storeItems = new List<DataItem>();
        }

        public static ObservableCollection<ItemStoreData> GetData(StageBaseFile stageBaseFile, ObservableCollection<ItemData> itemData)
        {
            ObservableCollection<ItemStoreData> data = new ObservableCollection<ItemStoreData>();

            for (int storeIndex = 0; storeIndex < stageBaseFile.StoreDataHeaders[ItemStoreIndex].shopItemsList.Count; storeIndex++)
            {
                ItemStoreData store = new ItemStoreData();
                EffectItemType storeItemType = EffectItemType.BagItem;

                foreach (var storeItemIndex in stageBaseFile.StoreDataHeaders[ItemStoreIndex].shopItemsList[storeIndex])
                {
                    if (storeItemIndex == 0)
                        continue;

                    ItemData storeItem = ItemData.GetItemFromIndex(itemData, storeItemType, storeItemIndex);
                    store.storeItems.Add(new DataItem(storeItem));
                }

                data.Add(store);
            }
            
            return data;
        }

        public static void SetData(ObservableCollection<ItemStoreData> storeData, ObservableCollection<ItemData> itemData, ref StageBaseFile stageBaseFile)
        {
            for (int storeIndex = 0; storeIndex < storeData.Count && storeIndex < stageBaseFile.StoreDataHeaders[ItemStoreIndex].shopItemsList.Count; storeIndex++)
            {
                for (int storeItemIndex = 0; storeItemIndex < storeData[storeIndex].storeItems.Count && storeItemIndex < stageBaseFile.StoreDataHeaders[ItemStoreIndex].shopItemsList[storeIndex].Count; storeItemIndex++)
                {
                    stageBaseFile.StoreDataHeaders[ItemStoreIndex].shopItemsList[storeIndex][storeItemIndex] = storeData[storeIndex].storeItems[storeItemIndex].item.index;
                }
            }
        }
    }
}
