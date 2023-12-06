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

        public static void SetData(ObservableCollection<NPCData> npcData, ref CharaFile charaFile)
        {
            for (int i = 0; i < npcData.Count && i < charaFile.NPCNameHeaders.Count; i++)
            {
                charaFile.NPCNameHeaders[i].name = npcData[i].name;
            }
        }
    }
}
