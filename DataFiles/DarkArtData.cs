using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class DarkArtData
    {
        public string name { get; set; }
        public int cost { get; set; }
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

            for (int i = 0; i < charaFile.DarkArtDescritpionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.DarkArtDescritpionHeaders[0].description[i];
            }

            return data;
        }
    }
}
