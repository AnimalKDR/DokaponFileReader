using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class DefensiveMagicData
    {
        public byte index { get; set; }
        public string name { get; set; }
        public uint price { get; set; }
        public float power { get; set; }
        public ushort iconID { get; set; }
        public string magicType { get; set; }
        public ushort effectType { get; set; }
        public byte sortIndex { get; set; }
        public string description { get; set; }

        public DefensiveMagicData(string name = "None", byte index = 0)
        {
            this.name = name;
            this.index = index;
            description = "None";
            magicType = "None";
        }

        public static ObservableCollection<DefensiveMagicData> GetData(CharaFile charaFile)
        {
            ObservableCollection<DefensiveMagicData> data = new ObservableCollection<DefensiveMagicData>();
            foreach (var defensiveMagic in charaFile.DefensiveMagicHeaders)
            {
                DefensiveMagicData defensiveMagicData = new DefensiveMagicData(defensiveMagic.name, (byte)defensiveMagic.index);
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

            data.Add(new DefensiveMagicData("Clonus 1", 0x80));
            data.Add(new DefensiveMagicData("Clonus 2", 0x81));
            data.Add(new DefensiveMagicData("Clonus 3", 0x82));
            data.Add(new DefensiveMagicData("Clonus 4", 0x83));
            data.Add(new DefensiveMagicData());

            return data;
        }

        public static void SetData(ObservableCollection<DefensiveMagicData> defensiveMagicData, ref CharaFile charaFile)
        {
            for (int i = 0; i < defensiveMagicData.Count - 5 && i < charaFile.DefensiveMagicHeaders.Count; i++)
            {
                charaFile.DefensiveMagicHeaders[i].index = defensiveMagicData[i].index;
                charaFile.DefensiveMagicHeaders[i].name = defensiveMagicData[i].name;
                charaFile.DefensiveMagicHeaders[i].price = defensiveMagicData[i].price;
                charaFile.DefensiveMagicHeaders[i].power = (ushort)(100 * defensiveMagicData[i].power + 0.5);
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

        public static DefensiveMagicData GetDefensiveMagicDataByIndex(ObservableCollection<DefensiveMagicData> defensiveMagicData, byte index)
        {
            foreach (var defensiveMagic in defensiveMagicData)
            {
                if (defensiveMagic.index == index)
                    return defensiveMagic;
            }

            return new DefensiveMagicData();
        }
    }
}
