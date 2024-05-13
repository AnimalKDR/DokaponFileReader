using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class LocationData
    {
        public uint index { get; set; }
        public string name { get; set; }

        public LocationData(string name = "None", uint index = 0)
        {
            this.name = name;
            this.index = index;
        }

        public static ObservableCollection<LocationData> GetData(StageBaseFile stageBaseFile)
        {
            ObservableCollection<LocationData> data = new ObservableCollection<LocationData>();
            foreach (var header in stageBaseFile.LocationHeaders)
            {
                LocationData locationData = new LocationData(header.name, header.index);

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

        public static LocationData GetLocationDataByIndex(ObservableCollection<LocationData> locationData, uint index)
        {
            foreach (var location in locationData)
            {
                if (location.index == index)
                    return location;
            }

            return new LocationData();
        }
    }
}
