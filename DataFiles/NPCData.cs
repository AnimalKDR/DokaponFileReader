using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class NPCData
    {
        public string name { get; set; }

        public NPCData(string name)
        {
            this.name = name;
        }

        public static ObservableCollection<NPCData> GetData(CharaFile charaFile)
        {
            ObservableCollection<NPCData> data = new ObservableCollection<NPCData>();
            foreach (var header in charaFile.NPCNameHeaders)
            {
                NPCData nameData = new NPCData(header.name);

                data.Add(nameData);
            }

            return data;
        }
    }
}
