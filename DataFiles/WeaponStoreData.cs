using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class WeaponStoreData
    {
        private const int WeaponStoreIndex = 0;

        public List<DataItem> storeItems;

        public WeaponStoreData()
        {
            storeItems = new List<DataItem>();
        }

        public static ObservableCollection<WeaponStoreData> GetData(StageBaseFile stageBaseFile, ObservableCollection<ItemData> itemData)
        {
            ObservableCollection<WeaponStoreData> data = new ObservableCollection<WeaponStoreData>();

            for (int storeIndex = 0; storeIndex < stageBaseFile.StoreDataHeaders[WeaponStoreIndex].shopItemsList.Count; storeIndex++)
            {
                WeaponStoreData store = new WeaponStoreData();
                EffectItemType storeItemType = EffectItemType.Weapon;

                foreach (var storeItemIndex in stageBaseFile.StoreDataHeaders[WeaponStoreIndex].shopItemsList[storeIndex])
                {
                    if (storeItemIndex == 0)
                    {
                        storeItemType = EffectItemType.Shield;
                        continue;
                    }

                    ItemData storeItem = ItemData.GetItemFromIndex(itemData, storeItemType, storeItemIndex);
                    store.storeItems.Add(new DataItem(storeItem));
                }

                data.Add(store);
            }
            
            return data;
        }

        public static void SetData(ObservableCollection<WeaponStoreData> storeData, ObservableCollection<ItemData> itemData, ref StageBaseFile stageBaseFile)
        {
            bool doOnce = true;

            for (int storeIndex = 0; storeIndex < storeData.Count && storeIndex < stageBaseFile.StoreDataHeaders[0].shopItemsList.Count; storeIndex++)
            {
                for (int storeItemIndex = 0; storeItemIndex < storeData[storeIndex].storeItems.Count && storeItemIndex < stageBaseFile.StoreDataHeaders[WeaponStoreIndex].shopItemsList[storeIndex].Count; storeItemIndex++)
                {
                    if (storeData[storeIndex].storeItems[storeItemIndex].item.itemType == EffectItemType.Weapon)
                    {
                        stageBaseFile.StoreDataHeaders[WeaponStoreIndex].shopItemsList[storeIndex][storeItemIndex] = storeData[storeIndex].storeItems[storeItemIndex].item.index;
                    }
                    else
                    {
                        if (doOnce)
                        {
                            stageBaseFile.StoreDataHeaders[WeaponStoreIndex].shopItemsList[storeIndex][storeItemIndex] = 0;
                            doOnce = false;
                        }

                        stageBaseFile.StoreDataHeaders[WeaponStoreIndex].shopItemsList[storeIndex][storeItemIndex + 1] = storeData[storeIndex].storeItems[storeItemIndex].item.index;
                    }
                }
            }
        }
    }
}
