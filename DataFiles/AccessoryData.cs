using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class AccessoryData
    {
        public byte index { get; set; }
        public string name { get; set; }
        public uint price { get; set; }
        public short attack { get; set; }
        public short defense { get; set; }
        public short magic { get; set; }
        public short speed { get; set; }
        public int hp { get; set; }
        public ushort iconID { get; set; }
        public byte activationRate { get; set; }
        public string description { get; set; }

        public AccessoryData(string name = "None", byte index = 0)
        {
            this.name = name;
            this.index = index;
            description = "None";
        }

        public static ObservableCollection<AccessoryData> GetData(CharaFile charaFile)
        {
            ObservableCollection<AccessoryData> data = new ObservableCollection<AccessoryData>();
            foreach (var accessory in charaFile.AccessoryHeaders)
            {
                AccessoryData accessoryData = new AccessoryData(accessory.name, (byte)accessory.index);
                accessoryData.price = accessory.price;
                accessoryData.attack = accessory.attack;
                accessoryData.defense = accessory.defense;
                accessoryData.magic = accessory.magic;
                accessoryData.speed = accessory.speed;
                accessoryData.hp = 10 * accessory.hp;

                accessoryData.iconID = accessory.iconID;
                accessoryData.activationRate = accessory.activationRate;

                data.Add(accessoryData);
            }

            for (int i = 0; i < charaFile.AccessoryDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.AccessoryDescriptionHeader.description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<AccessoryData> accesoryData, ref CharaFile charaFile)
        {
            for (int i = 0; i < accesoryData.Count && i < charaFile.AccessoryHeaders.Count; i++)
            {
                charaFile.AccessoryHeaders[i].index = accesoryData[i].index;
                charaFile.AccessoryHeaders[i].name = accesoryData[i].name;
                charaFile.AccessoryHeaders[i].price = accesoryData[i].price;
                charaFile.AccessoryHeaders[i].attack = accesoryData[i].attack;
                charaFile.AccessoryHeaders[i].defense = accesoryData[i].defense;
                charaFile.AccessoryHeaders[i].magic = accesoryData[i].magic;
                charaFile.AccessoryHeaders[i].speed = accesoryData[i].speed;
                charaFile.AccessoryHeaders[i].hp = (short)(accesoryData[i].hp / 10);
                charaFile.AccessoryHeaders[i].iconID = accesoryData[i].iconID;
                charaFile.AccessoryHeaders[i].activationRate = accesoryData[i].activationRate;
            }

            for (int i = 0; i < accesoryData.Count && i < charaFile.AccessoryDescriptionHeader.description.Count; i++)
            {
                charaFile.AccessoryDescriptionHeader.description[i] = accesoryData[i].description;
            }
        }
    }
}