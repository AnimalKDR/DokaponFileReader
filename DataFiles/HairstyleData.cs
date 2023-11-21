using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class HairstyleData
    {
        public string name { get; set; }
        public string sex { get; set; }

        public int iconID { get; set; }

        public int hairTypeID { get; set; }

        public int descriptionIndex { get; set; }
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

                hairstyleData.hairTypeID = hairstyle.unknownHairType;
                hairstyleData.iconID = hairstyle.objectType;
                hairstyleData.descriptionIndex = hairstyle.nonClassIndex;

                if (hairstyle.unknownHairType != 0)
                    hairstyleData.description = charaFile.HairstyleDescriptionHeaders[0].description[hairstyle.descriptionID];

                data.Add(hairstyleData);
            }

            return data;
        }
    }
}
