using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class TownCastleData
    {
        public string name { get; set; }
        public string continent { get; set; }
        public int locationID { get; set; }
        public uint townValue { get; set; }

        public TownCastleData(string name)
        {
            this.name = name;
            continent = String.Empty;
        }

        public static ObservableCollection<TownCastleData> GetData(StageBaseFile stageBaseFile)
        {
            ObservableCollection<TownCastleData> data = new ObservableCollection<TownCastleData>();
            foreach (var header in stageBaseFile.TownCastleHeaders)
            {
                TownCastleData townCastle = new TownCastleData(header.name);
                townCastle.locationID = header.mapLocationID;
                townCastle.townValue = header.townValue;

                foreach (var location in stageBaseFile.LocationHeaders)
                {
                    if (header.continent != location.index)
                        continue;

                    townCastle.continent = location.name;
                    break;
                }

                data.Add(townCastle);
            }

            return data;
        }
    }
}
