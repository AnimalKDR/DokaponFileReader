using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class ShieldData
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

        public ShieldData(string name = "None", byte index = 0)
        {
            this.name = name;
            this.index = index;
            description = "None";
        }

        public static ObservableCollection<ShieldData> GetData(CharaFile charaFile)
        {
            ObservableCollection<ShieldData> data = new ObservableCollection<ShieldData>();
            foreach (var shield in charaFile.ShieldHeaders)
            {
                ShieldData shieldData = new ShieldData(shield.name, (byte)shield.index);
                shieldData.price = shield.price;
                shieldData.attack = shield.attack;
                shieldData.defense = shield.defense;
                shieldData.magic = shield.magic;
                shieldData.speed = shield.speed;
                shieldData.hp = 10 * shield.hp;

                shieldData.iconID = shield.iconID;
                shieldData.activationRate = shield.activationRate;

                data.Add(shieldData);
            }

            for (int i = 0; i < charaFile.ShieldDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.ShieldDescriptionHeader.description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<ShieldData> shieldData, ref CharaFile charaFile)
        {
            for (int i = 0; i < shieldData.Count && i < charaFile.ShieldHeaders.Count; i++)
            {
                charaFile.ShieldHeaders[i].index = shieldData[i].index;
                charaFile.ShieldHeaders[i].name = shieldData[i].name;
                charaFile.ShieldHeaders[i].price = shieldData[i].price;
                charaFile.ShieldHeaders[i].attack = shieldData[i].attack;
                charaFile.ShieldHeaders[i].defense = shieldData[i].defense;
                charaFile.ShieldHeaders[i].magic = shieldData[i].magic;
                charaFile.ShieldHeaders[i].speed = shieldData[i].speed;
                charaFile.ShieldHeaders[i].hp = (short)(shieldData[i].hp / 10);
                charaFile.ShieldHeaders[i].iconID = shieldData[i].iconID;
                charaFile.ShieldHeaders[i].activationRate = shieldData[i].activationRate;
            }

            for (int i = 0; i < shieldData.Count && i < charaFile.ShieldDescriptionHeader.description.Count; i++)
            {
                charaFile.ShieldDescriptionHeader.description[i] = shieldData[i].description;
            }
        }
    }
}