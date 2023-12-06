using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class PrankNameData
    {
        public string name { get; set; }


        public PrankNameData(string name)
        {
            this.name = name;
        }

        public static ObservableCollection<PrankNameData> GetData(CharaFile charaFile)
        {
            ObservableCollection<PrankNameData> data = new ObservableCollection<PrankNameData>();
            foreach (var header in charaFile.PrankNameHeaders)
            {
                PrankNameData nameData = new PrankNameData(header.name);

                data.Add(nameData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<PrankNameData> prankNameData, ref CharaFile charaFile)
        {
            for (int i = 0; i < prankNameData.Count && i < charaFile.PrankNameHeaders.Count; i++)
            {
                charaFile.PrankNameHeaders[i].name = prankNameData[i].name;
            }
        }
    }
}
