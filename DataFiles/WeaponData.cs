using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class WeaponData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public short attack { get; set; }
        public short defense { get; set; }
        public short magic { get; set; }
        public short speed { get; set; }
        public int hp { get; set; }
        public WeaponHeader.BonusClass bonusClass { get; set; }
        public ushort iconID { get; set; }
        public byte activationRate { get; set; }
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
                weaponData.attack = weapon.attack;
                weaponData.defense = weapon.defense;
                weaponData.magic = weapon.magic;
                weaponData.speed = weapon.speed;
                weaponData.hp = 10 * weapon.hp;
                weaponData.bonusClass = (WeaponHeader.BonusClass)weapon.bonusClass;
                weaponData.iconID = weapon.iconID;
                weaponData.activationRate = weapon.activationRate;
                weaponData.attackAnimation = (WeaponHeader.AnimationType)weapon.attackAnimation;

                data.Add(weaponData);
            }

            for (int i = 0; i < charaFile.WeaponDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.WeaponDescriptionHeaders[0].description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<WeaponData> weaponData, ref CharaFile charaFile)
        {
            for (int i = 0; i < weaponData.Count && i < charaFile.WeaponHeaders.Count; i++)
            {
                charaFile.WeaponHeaders[i].name = weaponData[i].name;
                charaFile.WeaponHeaders[i].price = weaponData[i].price;
                charaFile.WeaponHeaders[i].attack = weaponData[i].attack;
                charaFile.WeaponHeaders[i].defense = weaponData[i].defense;
                charaFile.WeaponHeaders[i].magic = weaponData[i].magic;
                charaFile.WeaponHeaders[i].speed = weaponData[i].speed;
                charaFile.WeaponHeaders[i].hp = (short)(weaponData[i].hp / 10);
                charaFile.WeaponHeaders[i].bonusClass = (byte)weaponData[i].bonusClass;
                charaFile.WeaponHeaders[i].iconID = weaponData[i].iconID;
                charaFile.WeaponHeaders[i].activationRate = weaponData[i].activationRate;
                charaFile.WeaponHeaders[i].attackAnimation = (byte)weaponData[i].attackAnimation;
            }

            for (int i = 0; i < weaponData.Count && i < charaFile.WeaponDescriptionHeaders.Count; i++)
            {
                charaFile.WeaponDescriptionHeaders[0].description[i] = weaponData[i].description;
            }
        }
    }
}
