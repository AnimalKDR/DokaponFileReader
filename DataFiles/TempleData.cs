using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class TempleData
    {
        public string name { get; set; }
        public string continent { get; set; }
        public ushort mapLocationID { get; set; }

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
                templeData.mapLocationID = header.mapLocationID;
                templeData.continent = stageBaseFile.GetLocationName(header.continent);

                data.Add(templeData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<TempleData> templeData, ref StageBaseFile stageBaseFile)
        {
            for (int i = 0; i < templeData.Count && i < stageBaseFile.TempleNameHeaders.Count; i++)
            {
                stageBaseFile.TownCastleHeaders[i].name = templeData[i].name;
                stageBaseFile.TownCastleHeaders[i].mapLocationID = templeData[i].mapLocationID;
                stageBaseFile.TownCastleHeaders[i].continent = stageBaseFile.GetLocationIndex(templeData[i].continent);
            }
        }
    }
}
