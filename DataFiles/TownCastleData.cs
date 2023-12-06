using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class TownCastleData
    {
        public string name { get; set; }
        public string continent { get; set; }
        public ushort mapLocationID { get; set; }
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
                townCastle.mapLocationID = header.mapLocationID;
                townCastle.townValue = header.townValue;
                townCastle.continent = stageBaseFile.GetLocationName(header.continent);

                data.Add(townCastle);
            }

            return data;
        }

        public static void SetData(ObservableCollection<TownCastleData> townCastleData, ref StageBaseFile stageBaseFile)
        {
            for (int i = 0; i < townCastleData.Count && i < stageBaseFile.TownCastleHeaders.Count; i++)
            {
                stageBaseFile.TownCastleHeaders[i].name = townCastleData[i].name;
                stageBaseFile.TownCastleHeaders[i].mapLocationID = townCastleData[i].mapLocationID;
                stageBaseFile.TownCastleHeaders[i].townValue = townCastleData[i].townValue;
                stageBaseFile.TownCastleHeaders[i].continent = stageBaseFile.GetLocationIndex(townCastleData[i].continent);
            }
        }
    }
}
