using DokaponFileReader.DataFiles;
using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class ItemData 
    {
        public byte index { get; set; }
        public string name { get; set; }
        public EffectItemType itemType { get; set; }

        public ItemData(EffectItemType itemType = EffectItemType.None, byte index = 0, string name = "None")
        {
            this.name = name;
            this.index = index;
            this.itemType = itemType;
        }

        public static void AddWeaponData(ref ObservableCollection<ItemData> itemData, ObservableCollection<WeaponData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new ItemData(EffectItemType.Weapon, item.index, item.name));
            }
        }

        public static void AddShieldData(ref ObservableCollection<ItemData> itemData, ObservableCollection<ShieldData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new ItemData(EffectItemType.Shield, item.index, item.name));
            }
        }

        public static void AddAccessoryData(ref ObservableCollection<ItemData> itemData, ObservableCollection<AccessoryData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new ItemData(EffectItemType.Accessory, item.index, item.name));
            }
        }

        public static void AddOffensiveMagicData(ref ObservableCollection<ItemData> itemData, ObservableCollection<OffensiveMagicData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new ItemData(EffectItemType.OffensiveMagic, item.index, item.name));
            }
        }

        public static void AddDefensiveMagicData(ref ObservableCollection<ItemData> itemData, ObservableCollection<DefensiveMagicData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new ItemData(EffectItemType.DefensiveMagic, item.index, item.name));
            }
        }

        public static void AddBagItemData(ref ObservableCollection<ItemData> itemData, ObservableCollection<BagItemData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new ItemData(EffectItemType.BagItem, item.index, item.name));
            }
        }

        public static void AddLocalItemData(ref ObservableCollection<ItemData> itemData, ObservableCollection<LocalItemData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new ItemData(EffectItemType.BagItem, (byte)item.index, item.name));
            }
        }

        public static void AddFieldMagicData(ref ObservableCollection<ItemData> itemData, ObservableCollection<FieldMagicData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new ItemData(EffectItemType.FieldMagic, item.index, item.name));
            }
        }

        public static ItemData GetItemFromIndex(ObservableCollection<ItemData> itemData, EffectItemType itemType, byte index)
        {
            foreach(var item in itemData)
            {
                if (item.itemType == itemType && item.index == index)
                    return item;
            }

            return new ItemData();
        }

        public static byte GetItemIndexFromName(ObservableCollection<ItemData> itemData, EffectItemType itemType, string itemName)
        {
            foreach (var item in itemData)
            {
                if (item.itemType == itemType && item.name == itemName)
                    return item.index;
            }

            return 0;
        }
    }
}
