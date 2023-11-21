using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class ShieldData
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

        public ShieldData(string name)
        {
            this.name = name;
            description = "None";
        }

        public static ObservableCollection<ShieldData> GetData(CharaFile charaFile)
        {
            ObservableCollection<ShieldData> data = new ObservableCollection<ShieldData>();
            foreach (var shield in charaFile.ShieldHeaders)
            {
                ShieldData shieldData = new ShieldData(shield.name);
                shieldData.price = shield.price;
                shieldData.attack = (int)shield.attack;
                shieldData.defense = (int)shield.defense;
                shieldData.magic = (int)shield.magic;
                shieldData.speed = (int)shield.speed;
                shieldData.hp = 10 * (int)shield.hp;

                shieldData.iconID = shield.objectType;
                shieldData.activationRate = shield.activationRate;

                data.Add(shieldData);
            }

            for (int i = 0; i < charaFile.ShieldDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.ShieldDescriptionHeaders[0].description[i];
            }

            return data;
        }
    }
}