using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class BagItemData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public int iconID { get; set; }
        public string itemType { get; set; }
        public string description { get; set; }

        public BagItemData(string name)
        {
            this.name = name;
            description = "None";
            itemType = "None";
        }

        public static ObservableCollection<BagItemData> GetData(CharaFile charaFile)
        {
            ObservableCollection<BagItemData> data = new ObservableCollection<BagItemData>();
            foreach (var bagItem in charaFile.BagItemHeaders)
            {
                BagItemData bagItemData = new BagItemData(bagItem.name);
                bagItemData.price = bagItem.price;
                if (bagItem.itemType != 0)
                    bagItemData.itemType = charaFile.BagItemTypeNameHeaders[bagItem.itemType - 1].name;
                bagItemData.iconID = bagItem.objectType;

                data.Add(bagItemData);
            }

            for (int i = 0; i < charaFile.BagItemDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.BagItemDescriptionHeaders[0].description[i];
            }

            return data;
        }
    }
}
