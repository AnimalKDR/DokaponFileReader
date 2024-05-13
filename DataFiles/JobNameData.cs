using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class JobNameData
    {
        public byte index { get; set; }
        public string name { get; set; }

        public JobNameData(string name = "", byte index = 0xFF)
        {
            this.name = name;
            this.index = index;
        }

        public static ObservableCollection<JobNameData> GetData(CharaFile charFile)
        {
            ObservableCollection<JobNameData> data = new ObservableCollection<JobNameData>();
            foreach (var header in charFile.JobNameHeaders)
            {
                JobNameData jobData = new JobNameData(header.name, (byte)header.index);

                data.Add(jobData);
            }

            data.Add(new JobNameData());

            return data;
        }

        public static void SetData(ObservableCollection<JobNameData> jobNameData, ref CharaFile charFile)
        {
            for (int i = 0; i < jobNameData.Count - 1  && i < charFile.JobNameHeaders.Count; i++)
            {
                charFile.JobNameHeaders[i].name = jobNameData[i].name;
            }
        }

        public static JobNameData GetJobNameDataByIndex(ObservableCollection<JobNameData> jobNameData, uint index)
        {
            foreach (var jobName in jobNameData)
            {
                if (jobName.index == index)
                    return jobName;
            }

            return new JobNameData();
        }
    }
}
