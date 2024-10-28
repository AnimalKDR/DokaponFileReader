using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class MagicStoreData
    {
        private const int MagicStoreIndex = 2;

        public List<DataItem> storeItems;

        public MagicStoreData()
        {
            storeItems = new List<DataItem>();
        }

        public static ObservableCollection<MagicStoreData> GetData(StageBaseFile stageBaseFile, ObservableCollection<ItemData> itemData)
        {
            ObservableCollection<MagicStoreData> data = new ObservableCollection<MagicStoreData>();

            for (int storeIndex = 0; storeIndex < stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList.Count; storeIndex++)
            {
                MagicStoreData store = new MagicStoreData();
                EffectItemType storeItemType = EffectItemType.FieldMagic;

                foreach (var storeItemIndex in stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList[storeIndex])
                {
                    if (storeItemIndex == 0)
                    {
                        if (storeItemType == EffectItemType.FieldMagic)
                            storeItemType = EffectItemType.OffensiveMagic;
                        else
                            storeItemType = EffectItemType.DefensiveMagic;
                        continue;
                    }

                    ItemData storeItem;
                    if (storeItemType == EffectItemType.FieldMagic)
                        storeItem = ItemData.GetItemFromIndex(itemData, storeItemType, (byte)(storeItemIndex - 0x37));
                    else if (storeItemType == EffectItemType.DefensiveMagic)
                        storeItem = ItemData.GetItemFromIndex(itemData, storeItemType, (byte)(storeItemIndex - 0x1e));
                    else
                        storeItem = ItemData.GetItemFromIndex(itemData, storeItemType, (byte)(storeItemIndex));
                    store.storeItems.Add(new DataItem(storeItem));
                }

                data.Add(store);
            }
            
            return data;
        }

        public static void SetData(ObservableCollection<MagicStoreData> storeData, ObservableCollection<ItemData> itemData, ref StageBaseFile stageBaseFile)
        {
            bool doOnce1 = true;
            bool doOnce2 = true;

            for (int storeIndex = 0; storeIndex < storeData.Count && storeIndex < stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList.Count; storeIndex++)
            {
                for (int storeItemIndex = 0; storeItemIndex < storeData[storeIndex].storeItems.Count && storeItemIndex < stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList[storeIndex].Count; storeItemIndex++)
                {
                    if (storeData[storeIndex].storeItems[storeItemIndex].item.itemType == EffectItemType.FieldMagic)
                    {
                        stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList[storeIndex][storeItemIndex] = (byte)(storeData[storeIndex].storeItems[storeItemIndex].item.index + 0x37);
                    }
                    else if (storeData[storeIndex].storeItems[storeItemIndex].item.itemType == EffectItemType.OffensiveMagic)
                    {
                        if (doOnce1)
                        {
                            stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList[storeIndex][storeItemIndex] = 0;
                            doOnce1 = false;
                        }

                        stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList[storeIndex][storeItemIndex + 1] = storeData[storeIndex].storeItems[storeItemIndex].item.index;
                    }
                    else
                    {
                        if (doOnce2)
                        {
                            stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList[storeIndex][storeItemIndex + 1] = 0;
                            doOnce2 = false;
                        }

                        stageBaseFile.StoreDataHeaders[MagicStoreIndex].shopItemsList[storeIndex][storeItemIndex + 2] = (byte)(storeData[storeIndex].storeItems[storeItemIndex].item.index + 0x1E);
                    }
                }
            }
        }
    }
}
