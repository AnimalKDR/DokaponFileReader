using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class DarkArtData
    {
        public string name { get; set; }
        public ushort cost { get; set; }
        public string description { get; set; }

        public DarkArtData(string name)
        {
            this.name = name;
            description = "None";
        }

        public static ObservableCollection<DarkArtData> GetData(CharaFile charaFile)
        {
            ObservableCollection<DarkArtData> data = new ObservableCollection<DarkArtData>();
            foreach (var darkArt in charaFile.DarkArtHeaders)
            {
                DarkArtData darkArtData = new DarkArtData(darkArt.name);
                darkArtData.cost = darkArt.pointCost;

                data.Add(darkArtData);
            }

            for (int i = 0; i < charaFile.DarkArtDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.DarkArtDescriptionHeader.description[i];
            }

            return data;
        }

        public static void SetData(ObservableCollection<DarkArtData> darkArtData, ref CharaFile charaFile)
        {
            for (int i = 0; i < darkArtData.Count && i < charaFile.DarkArtHeaders.Count; i++)
            {
                charaFile.DarkArtHeaders[i].name = darkArtData[i].name;
                charaFile.DarkArtHeaders[i].pointCost = darkArtData[i].cost;
            }

            for (int i = 0; i < darkArtData.Count && i < charaFile.DarkArtDescriptionHeader.description.Count; i++)
            {
                charaFile.DarkArtDescriptionHeader.description[i] = darkArtData[i].description;
            }
        }
    }
}
