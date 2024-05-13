using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class LocalItemData
    {
        public ushort index { get; set; }
        public string name { get; set; }
        public uint price { get; set; }
        public int localItemValue { get; set; }
        public ushort iconID { get; set; }
        public byte spawnRate { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string deliverDescription { get; set; }

        public LocalItemData(string name = "None", ushort index = 0)
        {
            this.name = name;
            this.index = index;
            description = "None";
            deliverDescription = "None";
            location = "None";
        }

        public static ObservableCollection<LocalItemData> GetData(CharaFile charaFile, StageBaseFile stageBaseFile)
        {
            ObservableCollection<LocalItemData> data = new ObservableCollection<LocalItemData>();
            foreach (var item in charaFile.LocalItemHeaders)
            {
                LocalItemData itemData = new LocalItemData(item.name, item.index);
                itemData.price = item.price;
                itemData.iconID = item.iconID;
                itemData.spawnRate = item.spawnRate;
                itemData.localItemValue = item.localItemValue;
                itemData.location = stageBaseFile.GetTownCastleName(item.townCastleIndex);
                itemData.description = charaFile.BagItemDescriptionHeader.description[item.index - 1];
                itemData.deliverDescription = charaFile.BagItemDescriptionHeader.description[item.index - 1 + charaFile.LocalItemHeaders.Count];

                data.Add(itemData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<LocalItemData> localItemData, ref CharaFile charaFile, ref StageBaseFile stageBaseFile)
        {
            for (int i = 0; i < localItemData.Count && i < charaFile.LocalItemHeaders.Count; i++)
            {
                charaFile.LocalItemHeaders[i].name = localItemData[i].name;
                charaFile.LocalItemHeaders[i].price = localItemData[i].price;
                charaFile.LocalItemHeaders[i].iconID = localItemData[i].iconID;
                charaFile.LocalItemHeaders[i].spawnRate = localItemData[i].spawnRate;
                charaFile.LocalItemHeaders[i].localItemValue = localItemData[i].localItemValue;
                charaFile.LocalItemHeaders[i].townCastleIndex = stageBaseFile.GetTownCastleIndex(localItemData[i].location);
                charaFile.BagItemDescriptionHeader.description[charaFile.LocalItemHeaders[i].index - 1] = localItemData[i].description;
                charaFile.BagItemDescriptionHeader.description[charaFile.LocalItemHeaders[i].index - 1 + charaFile.LocalItemHeaders.Count] = localItemData[i].deliverDescription;
            }
        }

        public static LocalItemData GetLocalItemDataByIndex(ObservableCollection<LocalItemData> localItemData, ushort index)
        {
            foreach (var localItem in localItemData)
            {
                if (localItem.index == index)
                    return localItem;
            }

            return new LocalItemData();
        }
    }
}
