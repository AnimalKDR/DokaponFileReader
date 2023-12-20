using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class FieldMagicData
    {
        public string name { get; set; }
        public uint price { get; set; }
        public float power { get; set; }
        public ushort iconID { get; set; }
        public string magicType { get; set; }
        public ushort effectType { get; set; }
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
                fieldMagicData.magicType = charFile.GetFieldMagicTypeName(fieldMagic.magicType);
                fieldMagicData.iconID = fieldMagic.iconID;
                fieldMagicData.effectType = fieldMagic.effectType;

                data.Add(fieldMagicData);
            }

            for (int i = 0; i < charFile.FieldMagicDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charFile.FieldMagicDescriptionHeader.description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<FieldMagicData> fieldMagicData, ref CharaFile charaFile)
        {
            for (int i = 0; i < fieldMagicData.Count && i < charaFile.FieldMagicHeaders.Count; i++)
            {
                charaFile.FieldMagicHeaders[i].name = fieldMagicData[i].name;
                charaFile.FieldMagicHeaders[i].price = fieldMagicData[i].price;
                charaFile.FieldMagicHeaders[i].power = (ushort)(100 * fieldMagicData[i].power);
                charaFile.FieldMagicHeaders[i].iconID = fieldMagicData[i].iconID;
                charaFile.FieldMagicHeaders[i].magicType = charaFile.GetFieldMagicTypeID(fieldMagicData[i].magicType);
                charaFile.FieldMagicHeaders[i].effectType = fieldMagicData[i].effectType;
            }

            for (int i = 0; i < fieldMagicData.Count && i < charaFile.FieldMagicDescriptionHeader.description.Count; i++)
            {
                charaFile.FieldMagicDescriptionHeader.description[i] = fieldMagicData[i].description;
            }
        }
    }
}
