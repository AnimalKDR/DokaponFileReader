using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class DefensiveMagicData
    {

        public string name { get; set; }
        public uint price { get; set; }
        public float power { get; set; }
        public int iconID { get; set; }
        public string magicType { get; set; }
        public int effectType { get; set; }
        public int sortIndex { get; set; }
        public string description { get; set; }

        public DefensiveMagicData(string name)
        {
            this.name = name;
            description = "None";
            magicType = "None";
        }

        public static ObservableCollection<DefensiveMagicData> GetData(CharaFile charFile)
        {
            ObservableCollection<DefensiveMagicData> data = new ObservableCollection<DefensiveMagicData>();
            foreach (var defensiveMagic in charFile.DefensiveMagicHeaders)
            {
                DefensiveMagicData defensiveMagicData = new DefensiveMagicData(defensiveMagic.name);
                defensiveMagicData.price = defensiveMagic.price;
                defensiveMagicData.power = (float)(defensiveMagic.power / 100.0);
                if (defensiveMagic.magicType != 0)
                    defensiveMagicData.magicType = charFile.BattleMagicTypeNameHeaders[defensiveMagic.magicType - 1].name;
                defensiveMagicData.iconID = defensiveMagic.objectType;
                defensiveMagicData.effectType = defensiveMagic.effectType;
                defensiveMagicData.sortIndex = defensiveMagic.unknownIndex;

                data.Add(defensiveMagicData);
            }

            for (int i = 0; i < charFile.DefensiveMagicDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charFile.DefensiveMagicDescriptionHeaders[0].description[i];
            }

            return data;
        }
    }
}
