using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class EffectData
    {
        public string name { get; set; }
        public int minDuration { get; set; }
        public int maxDuration { get; set; }
        public int iconID { get; set; }

        public EffectData(string name)
        {
            this.name = name;
        }

        public static ObservableCollection<EffectData> GetDataFromHeader1(CharaFile charaFile)
        {
            ObservableCollection<EffectData> data = new ObservableCollection<EffectData>();
            foreach (var header in charaFile.EffectNameHeaders1)
            {
                EffectData effectData = new EffectData(header.name);
                effectData.iconID = header.iconID;

                data.Add(effectData);
            }

            return data;
        }

        public static ObservableCollection<EffectData> GetDataFromHeader2(CharaFile charaFile)
        {
            ObservableCollection<EffectData> data = new ObservableCollection<EffectData>();
            foreach (var header in charaFile.EffectNameHeaders2)
            {
                EffectData effectData = new EffectData(header.name);
                effectData.minDuration = header.minDuration;
                effectData.maxDuration = header.maxDuration;
                effectData.iconID = header.iconID;

                data.Add(effectData);
            }

            return data;
        }

        public static ObservableCollection<EffectData> GetDataFromHeader3(CharaFile charaFile)
        {
            ObservableCollection<EffectData> data = new ObservableCollection<EffectData>();
            foreach (var header in charaFile.EffectNameHeaders3)
            {
                EffectData effectData = new EffectData(header.name);
                effectData.minDuration = header.minDuration;
                effectData.maxDuration = header.maxDuration;
                effectData.iconID = header.iconID;

                data.Add(effectData);
            }

            return data;
        }
    }
}
