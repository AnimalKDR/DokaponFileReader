using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class TownCastleData
    {
        public byte index { get; set; }
        public string name { get; set; }
        public string continent { get; set; }
        public ushort mapLocationID { get; set; }
        public uint townValue { get; set; }

        public TownCastleData(string name = "None", byte index = 0)
        {
            this.name = name;
            this.index = index;
            continent = String.Empty;
        }

        public static ObservableCollection<TownCastleData> GetData(StageBaseFile stageBaseFile)
        {
            ObservableCollection<TownCastleData> data = new ObservableCollection<TownCastleData>();
            foreach (var header in stageBaseFile.TownCastleHeaders)
            {
                TownCastleData townCastle = new TownCastleData(header.name, header.index);
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

        public static TownCastleData GetTownCastleDataByIndex(ObservableCollection<TownCastleData> townCastleData, byte index)
        {
            foreach (var townCastle in townCastleData)
            {
                if (townCastle.index == index)
                    return townCastle;
            }

            return new TownCastleData();
        }
    }
}
