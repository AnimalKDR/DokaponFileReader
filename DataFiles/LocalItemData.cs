using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class LocalItemData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public int localItemValue { get; set; }
        public ushort iconID { get; set; }
        public byte spawnRate { get; set; }
        public string townName { get; set; }
        public string description { get; set; }

        public LocalItemData(string name)
        {
            this.name = name;
            description = "None";
            townName = "None";
        }

        public static ObservableCollection<LocalItemData> GetData(CharaFile charaFile, StageBaseFile stageBaseFile)
        {
            ObservableCollection<LocalItemData> data = new ObservableCollection<LocalItemData>();
            foreach (var item in charaFile.LocalItemHeaders)
            {
                LocalItemData itemData = new LocalItemData(item.name);
                itemData.price = item.price;
                itemData.iconID = item.iconID;
                itemData.spawnRate = item.spawnRate;
                itemData.localItemValue = item.localItemValue;
                itemData.townName = stageBaseFile.GetTownCastleName(item.townCastleIndex);
                itemData.description = charaFile.BagItemDescriptionHeaders[0].description[item.index - 1];

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
                charaFile.LocalItemHeaders[i].townCastleIndex = stageBaseFile.GetTownCastleIndex(localItemData[i].townName);
                charaFile.BagItemDescriptionHeaders[0].description[charaFile.LocalItemHeaders[i].index - 1] = localItemData[i].description;
            }
        }
    }
}
