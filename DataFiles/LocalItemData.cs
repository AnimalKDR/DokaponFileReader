using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class LocalItemData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public int giftValue { get; set; }
        public int iconID { get; set; }
        public int spawnRate { get; set; }
        public string location { get; set; }
        public string description { get; set; }

        public LocalItemData(string name)
        {
            this.name = name;
            description = "None";
            location = "None";
        }

        public static ObservableCollection<LocalItemData> GetData(CharaFile charaFile, StageBaseFile stageBaseFile)
        {
            ObservableCollection<LocalItemData> data = new ObservableCollection<LocalItemData>();
            foreach (var item in charaFile.LocalItemHeaders)
            {
                LocalItemData itemData = new LocalItemData(item.name);
                itemData.price = item.price;
                itemData.iconID = item.objectType;
                itemData.spawnRate = item.spawnRate;
                itemData.giftValue = item.localItemValue;

                foreach (var townCastleName in stageBaseFile.TownCastleHeaders)
                {
                    if (item.townCastleIndex != townCastleName.index)
                        continue;

                    itemData.location = townCastleName.name;
                    break;
                }

                itemData.description = charaFile.BagItemDescriptionHeaders[0].description[item.index - 1];

                data.Add(itemData);
            }

            return data;
        }
    }
}
