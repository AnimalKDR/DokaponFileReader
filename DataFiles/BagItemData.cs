using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class BagItemData
    {
        public byte index { get; set; }
        public string name { get; set; }
        public uint price { get; set; }
        public ushort iconID { get; set; }
        public string itemType { get; set; }
        public string description { get; set; }

        public BagItemData(string name = "None", byte index = 0)
        {
            this.name = name;
            this.index = index;
            description = "None";
            itemType = "None";
        }

        public static ObservableCollection<BagItemData> GetData(CharaFile charaFile)
        {
            ObservableCollection<BagItemData> data = new ObservableCollection<BagItemData>();
            foreach (var bagItem in charaFile.BagItemHeaders)
            {
                BagItemData bagItemData = new BagItemData(bagItem.name, bagItem.index);
                bagItemData.price = bagItem.price;
                bagItemData.itemType = charaFile.GetBagItemTypeName(bagItem.itemType);
                bagItemData.iconID = bagItem.iconID;

                data.Add(bagItemData);
            }

            for (int i = 0; i < charaFile.BagItemDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.BagItemDescriptionHeader.description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<BagItemData> bagItemData, ref CharaFile charaFile)
        {
            for (int i = 0; i < bagItemData.Count && i < charaFile.BagItemHeaders.Count; i++)
            {
                charaFile.BagItemHeaders[i].index = bagItemData[i].index;
                charaFile.BagItemHeaders[i].name = bagItemData[i].name;
                charaFile.BagItemHeaders[i].price = bagItemData[i].price;
                charaFile.BagItemHeaders[i].iconID = bagItemData[i].iconID;
                charaFile.BagItemHeaders[i].itemType = charaFile.GetBagItemTypeID(bagItemData[i].itemType); 
            }

            for (int i = 0; i < bagItemData.Count && i < charaFile.BagItemDescriptionHeader.description.Count; i++)
            {
                charaFile.BagItemDescriptionHeader.description[i] = bagItemData[i].description;
            }
        }
    }
}
