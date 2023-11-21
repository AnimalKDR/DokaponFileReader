using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class TempleData
    {
        public string name { get; set; }
        public string continent { get; set; }
        public int locationID { get; set; }

        public TempleData(string name)
        {
            this.name = name;
            continent = String.Empty;
        }

        public static ObservableCollection<TempleData> GetData(StageBaseFile stageBaseFile)
        {
            ObservableCollection<TempleData> data = new ObservableCollection<TempleData>();
            foreach (var header in stageBaseFile.TempleNameHeaders)
            {
                TempleData templeData = new TempleData(header.name);
                templeData.locationID = header.mapLocationID;

                foreach (var location in stageBaseFile.LocationHeaders)
                {
                    if (header.continent != location.index)
                        continue;
                    
                    templeData.continent = location.name;
                    break;
                }

                data.Add(templeData);
            }

            return data;
        }
    }
}
