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

            for (int i = 0; i < stageBaseFile.SpaceDescriptionHeader.description.Count; i++)
            {
                data[i].description = stageBaseFile.SpaceDescriptionHeader.description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<SpaceData> spaceData, ref StageBaseFile stageBaseFile)
        {
            for (int i = 0; i < spaceData.Count && i < stageBaseFile.SpaceNameHeaders.Count; i++)
            {
                stageBaseFile.SpaceNameHeaders[i].name = spaceData[i].name;
            }

            for (int i = 0; i < spaceData.Count && i < stageBaseFile.SpaceDescriptionHeader.description.Count; i++)
            {
                stageBaseFile.SpaceDescriptionHeader.description[i] = spaceData[i].description;
            }
        }
    }
}
