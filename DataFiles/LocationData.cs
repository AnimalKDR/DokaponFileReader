using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class LocationData
    {
        public string name { get; set; }

        public LocationData(string name)
        {
            this.name = name;
        }

        public static ObservableCollection<LocationData> GetData(StageBaseFile stageBaseFile)
        {
            ObservableCollection<LocationData> data = new ObservableCollection<LocationData>();
            foreach (var header in stageBaseFile.LocationHeaders)
            {
                LocationData locationData = new LocationData(header.name);

                data.Add(locationData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<LocationData> locationData, ref StageBaseFile stageBaseFile)
        {
            for (int i = 0; i < locationData.Count && i < stageBaseFile.LocationHeaders.Count; i++)
            {
                stageBaseFile.LocationHeaders[i].name = locationData[i].name;
            }
        }
    }
}
