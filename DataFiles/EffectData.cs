using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class EffectData
    {
        public string name { get; set; }
        public byte minDuration { get; set; }
        public byte maxDuration { get; set; }
        public ushort iconID { get; set; }

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

        public static void SetDataFromHeader1(ObservableCollection<EffectData> effectData, ref CharaFile charaFile)
        {
            for (int i = 0; i < effectData.Count && i < charaFile.EffectNameHeaders1.Count; i++)
            {
                charaFile.EffectNameHeaders1[i].name = effectData[i].name;
                charaFile.EffectNameHeaders1[i].iconID = effectData[i].iconID;
            }
        }

        public static void SetDataFromHeader2(ObservableCollection<EffectData> effectData, ref CharaFile charaFile)
        {
            for (int i = 0; i < effectData.Count && i < charaFile.EffectNameHeaders2.Count; i++)
            {
                charaFile.EffectNameHeaders2[i].name = effectData[i].name;
                charaFile.EffectNameHeaders2[i].minDuration = effectData[i].minDuration;
                charaFile.EffectNameHeaders2[i].maxDuration = effectData[i].maxDuration;
                charaFile.EffectNameHeaders2[i].iconID = effectData[i].iconID;
            }
        }

        public static void SetDataFromHeader3(ObservableCollection<EffectData> effectData, ref CharaFile charaFile)
        {
            for (int i = 0; i < effectData.Count && i < charaFile.EffectNameHeaders3.Count; i++)
            {
                charaFile.EffectNameHeaders3[i].name = effectData[i].name;
                charaFile.EffectNameHeaders3[i].minDuration = effectData[i].minDuration;
                charaFile.EffectNameHeaders3[i].maxDuration = effectData[i].maxDuration;
                charaFile.EffectNameHeaders3[i].iconID = effectData[i].iconID;
            }
        }
    }
}
