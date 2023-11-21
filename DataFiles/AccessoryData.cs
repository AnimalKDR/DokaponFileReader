using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class AccessoryData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int magic { get; set; }
        public int speed { get; set; }
        public int hp { get; set; }
        public int iconID { get; set; }
        public int activationRate { get; set; }
        public string description { get; set; }

        public AccessoryData(string name)
        {
            this.name = name;
            description = "None";
        }

        public static ObservableCollection<AccessoryData> GetData(CharaFile charaFile)
        {
            ObservableCollection<AccessoryData> data = new ObservableCollection<AccessoryData>();
            foreach (var accessory in charaFile.AccessoryHeaders)
            {
                AccessoryData accessoryData = new AccessoryData(accessory.name);
                accessoryData.price = accessory.price;
                accessoryData.attack = (int)accessory.attack;
                accessoryData.defense = (int)accessory.defense;
                accessoryData.magic = (int)accessory.magic;
                accessoryData.speed = (int)accessory.speed;
                accessoryData.hp = 10 * (int)accessory.hp;

                accessoryData.iconID = accessory.objectType;
                accessoryData.activationRate = accessory.activationRate;

                data.Add(accessoryData);
            }

            for (int i = 0; i < charaFile.AccessoryDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.AccessoryDescriptionHeaders[0].description[i];
            }

            return data;
        }
    }
}