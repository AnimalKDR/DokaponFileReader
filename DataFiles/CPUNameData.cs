using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class CPUNameData
    {
        public int sex { get; set; }
        public string name { get; set; }


        public CPUNameData(string name)
        {
            this.name = name;
        }

        public static ObservableCollection<CPUNameData> GetData(CharaFile charaFile)
        {
            ObservableCollection<CPUNameData> data = new ObservableCollection<CPUNameData>();
            foreach (var header in charaFile.CPUNamesHeaders)
            {
                foreach (var name in header.names)
                {
                    CPUNameData nameData = new CPUNameData(name);
                    nameData.sex = (int)header.sex;

                    data.Add(nameData);
                }
            }

            return data;
        }

        public static void SetData(ObservableCollection<CPUNameData> cpuNameData, ref CharaFile charaFile)
        {
            int maleNames = 0;
            int femaleNames = 0;

            for (int i = 0; i < cpuNameData.Count; i++)
            {
                if (cpuNameData[i].sex == 0)
                    charaFile.CPUNamesHeaders[0].names[maleNames++] = cpuNameData[i].name;
                else
                    charaFile.CPUNamesHeaders[1].names[femaleNames++] = cpuNameData[i].name;
            }
        }
    }
}
