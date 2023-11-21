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
    }
}
