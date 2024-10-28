using DokaponFileReader.DataFiles;
using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class EffectItemData 
    {
        public byte index { get; set; }
        public string name { get; set; }
        public EffectItemType itemType { get; set; }

        public EffectItemData(EffectItemType itemType = EffectItemType.None, byte index = 0, string name = "None")
        {
            this.name = name;
            this.index = index;
            this.itemType = itemType;
        }

        public static void AddWeaponData(ref ObservableCollection<EffectItemData> itemData, ObservableCollection<WeaponData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData(EffectItemType.Weapon, item.index, item.name));
            }
        }

        public static void AddShieldData(ref ObservableCollection<EffectItemData> itemData, ObservableCollection<ShieldData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData(EffectItemType.Shield, item.index, item.name));
            }
        }

        public static void AddAccessoryData(ref ObservableCollection<EffectItemData> itemData, ObservableCollection<AccessoryData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData(EffectItemType.Accessory, item.index, item.name));
            }
        }

        public static void AddOffensiveMagicData(ref ObservableCollection<EffectItemData> itemData, ObservableCollection<OffensiveMagicData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData(EffectItemType.OffensiveMagic, item.index, item.name));
            }
        }

        public static void AddDefensiveMagicData(ref ObservableCollection<EffectItemData> itemData, ObservableCollection<DefensiveMagicData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData(EffectItemType.DefensiveMagic, item.index, item.name));
            }
        }

        public static void AddBagItemData(ref ObservableCollection<EffectItemData> itemData, ObservableCollection<BagItemData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData(EffectItemType.BagItem, item.index, item.name));
            }
        }

        public static void AddLocalItemData(ref ObservableCollection<EffectItemData> itemData, ObservableCollection<LocalItemData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData(EffectItemType.BagItem, (byte)item.index, item.name));
            }
        }

        public static void AddFieldMagicData(ref ObservableCollection<EffectItemData> itemData, ObservableCollection<FieldMagicData> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData(EffectItemType.FieldMagic, item.index, item.name));
            }
        }
        public static void AddEffectData(ref ObservableCollection<EffectItemData> itemData, List<RandomEffectHeader> data)
        {
            foreach (var item in data)
            {
                itemData.Add(new EffectItemData((EffectItemType)item.effectType, item.effectTypeIndex, item.effectName));
            }
        }

        public static EffectItemData GetEffectItemFromIndex(ObservableCollection<EffectItemData> itemData, EffectItemType itemType, byte index)
        {
            foreach(var item in itemData)
            {
                if (item.itemType == itemType && item.index == index)
                    return item;
            }

            return new EffectItemData();
        }

        public static byte GetEffectItemIndexFromName(ObservableCollection<EffectItemData> itemData, EffectItemType itemType, string itemName)
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
