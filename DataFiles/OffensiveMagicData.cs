using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class OffensiveMagicData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public float power { get; set; }
        public int iconID { get; set; }
        public string magicType { get; set; }
        public int effectType { get; set; }
        public int sortIndex { get; set; }
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
                offensiveMagicData.iconID = offensiveMagic.objectType;
                offensiveMagicData.effectType = offensiveMagic.effectType;
                offensiveMagicData.sortIndex = offensiveMagic.unknownIndex;

                data.Add(offensiveMagicData);
            }

            for (int i = 0; i < charFile.OffensiveMagicDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charFile.OffensiveMagicDescriptionHeaders[0].description[i];
            }

            return data;
        }
    }
}
