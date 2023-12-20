using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class OffensiveMagicData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public float power { get; set; }
        public ushort iconID { get; set; }
        public string magicType { get; set; }
        public ushort effectType { get; set; }
        public byte sortIndex { get; set; }
        public string description { get; set; }

        public OffensiveMagicData(string name)
        {
            this.name = name;
            description = "None";
            magicType = "None";
        }

        public static ObservableCollection<OffensiveMagicData> GetData(CharaFile charFile)
        {
            ObservableCollection<OffensiveMagicData> data = new ObservableCollection<OffensiveMagicData>();
            foreach (var offensiveMagic in charFile.OffensiveMagicHeaders)
            {
                OffensiveMagicData offensiveMagicData = new OffensiveMagicData(offensiveMagic.name);
                offensiveMagicData.price = offensiveMagic.price;
                offensiveMagicData.power = (float)(offensiveMagic.power / 100.0);
                if (offensiveMagic.magicType != 0)
                    offensiveMagicData.magicType = charFile.BattleMagicTypeNameHeaders[offensiveMagic.magicType - 1].name;
                offensiveMagicData.iconID = offensiveMagic.iconID;
                offensiveMagicData.effectType = offensiveMagic.effectType;
                offensiveMagicData.sortIndex = offensiveMagic.sortIndex;

                data.Add(offensiveMagicData);
            }

            for (int i = 0; i < charFile.OffensiveMagicDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charFile.OffensiveMagicDescriptionHeader.description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<OffensiveMagicData> offensiveMagicData, ref CharaFile charaFile)
        {
            for (int i = 0; i < offensiveMagicData.Count && i < charaFile.OffensiveMagicHeaders.Count; i++)
            {
                charaFile.OffensiveMagicHeaders[i].name = offensiveMagicData[i].name;
                charaFile.OffensiveMagicHeaders[i].price = offensiveMagicData[i].price;
                charaFile.OffensiveMagicHeaders[i].power = (ushort)(100 * offensiveMagicData[i].power);
                charaFile.OffensiveMagicHeaders[i].magicType = charaFile.GetBattleMagicTypeID(offensiveMagicData[i].magicType);
                charaFile.OffensiveMagicHeaders[i].iconID = offensiveMagicData[i].iconID;
                charaFile.OffensiveMagicHeaders[i].effectType = offensiveMagicData[i].effectType;
                charaFile.OffensiveMagicHeaders[i].sortIndex = offensiveMagicData[i].sortIndex;
            }

            for (int i = 0; i < offensiveMagicData.Count && i < charaFile.OffensiveMagicDescriptionHeader.description.Count; i++)
            {
                charaFile.OffensiveMagicDescriptionHeader.description[i] = offensiveMagicData[i].description;
            }
        }
    }
}
