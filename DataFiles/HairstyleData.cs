using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class HairstyleData
    {
        public string name { get; set; }
        public string sex { get; set; }
        public ushort iconID { get; set; }
        public byte hairTypeID { get; set; }
        public byte descriptionIndex { get; set; }
        public string description { get; set; }

        public HairstyleData(string name)
        {
            this.name = name;
            description = "None";
            sex = "None";
        }

        public static ObservableCollection<HairstyleData> GetData(CharaFile charaFile)
        {
            ObservableCollection<HairstyleData> data = new ObservableCollection<HairstyleData>();
            foreach (var hairstyle in charaFile.HairstyleHeaders)
            {
                HairstyleData hairstyleData = new HairstyleData(hairstyle.name);
                if (hairstyle.index % 2 == 1)
                    hairstyleData.sex = "Male";
                else
                    hairstyleData.sex = "Female";

                hairstyleData.hairTypeID = hairstyle.hairTypeID;
                hairstyleData.iconID = hairstyle.iconID;
                hairstyleData.descriptionIndex = hairstyle.descriptionIndex;

                if (hairstyleData.descriptionIndex != 0)
                    hairstyleData.description = charaFile.HairstyleDescriptionHeader.description[hairstyleData.descriptionIndex - 1];

                data.Add(hairstyleData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<HairstyleData> hairstyleData, ref CharaFile charaFile)
        {
            for (int i = 0; i < hairstyleData.Count && i < charaFile.HairstyleHeaders.Count; i++)
            {
                charaFile.HairstyleHeaders[i].name = hairstyleData[i].name;
                charaFile.HairstyleHeaders[i].hairTypeID = hairstyleData[i].hairTypeID;
                charaFile.HairstyleHeaders[i].iconID = hairstyleData[i].iconID;
                charaFile.HairstyleHeaders[i].descriptionIndex = hairstyleData[i].descriptionIndex;

                if (hairstyleData[i].descriptionIndex == 0)
                    continue;

                charaFile.HairstyleDescriptionHeader.description[hairstyleData[i].descriptionIndex - 1] = hairstyleData[i].description;
            }
        }
    }
}
