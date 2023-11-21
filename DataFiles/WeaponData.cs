using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class WeaponData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int magic { get; set; }
        public int speed { get; set; }
        public int hp { get; set; }
        public WeaponHeader.BonusClass bonusClass { get; set; }
        public int iconID { get; set; }
        public int activationRate { get; set; }
        public WeaponHeader.AnimationType attackAnimation { get; set; }
        public string description { get; set; }

        public WeaponData(string name)
        {
            this.name = name;
            description = "None";
        }

        public static ObservableCollection<WeaponData> GetData(CharaFile charaFile)
        {
            ObservableCollection<WeaponData> data = new ObservableCollection<WeaponData>();
            foreach (var weapon in charaFile.WeaponHeaders)
            {
                WeaponData weaponData = new WeaponData(weapon.name);
                weaponData.price = weapon.price;
                weaponData.attack = (int)weapon.attack;
                weaponData.defense = (int)weapon.defense;
                weaponData.magic = (int)weapon.magic;
                weaponData.speed = (int)weapon.speed;
                weaponData.hp = 10 * (int)weapon.hp;
                weaponData.bonusClass = (WeaponHeader.BonusClass)weapon.bonusClass;
                weaponData.iconID = weapon.objectType;
                weaponData.activationRate = weapon.activationRate;
                weaponData.attackAnimation = (WeaponHeader.AnimationType)weapon.animationIndex;

                data.Add(weaponData);
            }

            for (int i = 0; i < charaFile.WeaponDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.WeaponDescriptionHeaders[0].description[i];
            }

            return data;
        }
    }
}
