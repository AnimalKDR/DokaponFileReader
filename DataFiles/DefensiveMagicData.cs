using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class DefensiveMagicData
    {

        public string name { get; set; }
        public uint price { get; set; }
        public float power { get; set; }
        public ushort iconID { get; set; }
        public string magicType { get; set; }
        public ushort effectType { get; set; }
        public byte sortIndex { get; set; }
        public string description { get; set; }

        public DefensiveMagicData(string name)
        {
            this.name = name;
            description = "None";
            magicType = "None";
        }

        public static ObservableCollection<DefensiveMagicData> GetData(CharaFile charaFile)
        {
            ObservableCollection<DefensiveMagicData> data = new ObservableCollection<DefensiveMagicData>();
            foreach (var defensiveMagic in charaFile.DefensiveMagicHeaders)
            {
                DefensiveMagicData defensiveMagicData = new DefensiveMagicData(defensiveMagic.name);
                defensiveMagicData.price = defensiveMagic.price;
                defensiveMagicData.power = (float)(defensiveMagic.power / 100.0);
                defensiveMagicData.magicType = charaFile.GetBattleMagicTypeName(defensiveMagic.magicType);
                defensiveMagicData.iconID = defensiveMagic.iconID;
                defensiveMagicData.effectType = defensiveMagic.effectType;
                defensiveMagicData.sortIndex = defensiveMagic.sortIndex;

                data.Add(defensiveMagicData);
            }

            for (int i = 0; i < charaFile.DefensiveMagicDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.DefensiveMagicDescriptionHeader.description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<DefensiveMagicData> defensiveMagicData, ref CharaFile charaFile)
        {
            for (int i = 0; i < defensiveMagicData.Count && i < charaFile.DefensiveMagicHeaders.Count; i++)
            {
                charaFile.DefensiveMagicHeaders[i].name = defensiveMagicData[i].name;
                charaFile.DefensiveMagicHeaders[i].price = defensiveMagicData[i].price;
                charaFile.DefensiveMagicHeaders[i].power = (ushort)(100 * defensiveMagicData[i].power);
                charaFile.DefensiveMagicHeaders[i].magicType = charaFile.GetBattleMagicTypeID(defensiveMagicData[i].magicType);
                charaFile.DefensiveMagicHeaders[i].iconID = defensiveMagicData[i].iconID;
                charaFile.DefensiveMagicHeaders[i].effectType = defensiveMagicData[i].effectType;
                charaFile.DefensiveMagicHeaders[i].sortIndex = defensiveMagicData[i].sortIndex;
            }

            for (int i = 0; i < defensiveMagicData.Count && i < charaFile.DefensiveMagicDescriptionHeader.description.Count; i++)
            {
                charaFile.DefensiveMagicDescriptionHeader.description[i] = defensiveMagicData[i].description;
            }
        }
    }
}
