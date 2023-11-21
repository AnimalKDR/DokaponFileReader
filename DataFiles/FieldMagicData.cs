using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class FieldMagicData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public float power { get; set; }
        public int iconID { get; set; }
        public string magicType { get; set; }
        public int effectType { get; set; }
        public string description { get; set; }

        public FieldMagicData(string name)
        {
            this.name = name;
            description = "None";
            magicType = "None";
        }

        public static ObservableCollection<FieldMagicData> GetData(CharaFile charFile)
        {
            ObservableCollection<FieldMagicData> data = new ObservableCollection<FieldMagicData>();
            foreach (var fieldMagic in charFile.FieldMagicHeaders)
            {
                FieldMagicData fieldMagicData = new FieldMagicData(fieldMagic.name);
                fieldMagicData.price = fieldMagic.price;
                fieldMagicData.power = (float)(fieldMagic.power / 100.0);
                if (fieldMagic.magicType != 0)
                    fieldMagicData.magicType = charFile.FieldMagicTypeNameHeaders[fieldMagic.magicType - 1].name;
                fieldMagicData.iconID = fieldMagic.objectType;
                fieldMagicData.effectType = fieldMagic.effectType;

                data.Add(fieldMagicData);
            }

            for (int i = 0; i < charFile.FieldMagicDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charFile.FieldMagicDescriptionHeaders[0].description[i];
            }

            return data;
        }
    }
}
