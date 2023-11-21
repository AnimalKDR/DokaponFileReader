using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class SpaceData
    {
        public string name { get; set; }
        public string description { get; set; }

        public SpaceData(string name)
        {
            this.name = name;
            this.description = String.Empty;
        }

        public static ObservableCollection<SpaceData> GetData(StageBaseFile stageBaseFile)
        {
            ObservableCollection<SpaceData> data = new ObservableCollection<SpaceData>();
            foreach (var header in stageBaseFile.SpaceNameHeaders)
            {
                SpaceData spaceData = new SpaceData(header.name);

                data.Add(spaceData);
            }

            for (int i = 0; i < stageBaseFile.SpaceDescriptionHeaders[0].description.Count; i++)
            {
                data[i].description = stageBaseFile.SpaceDescriptionHeaders[0].description[i];
            }

            return data;
        }
    }
}
