using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class InstructionData
    {
        public string instruction { get; set; }

        public InstructionData(string instruction)
        {
            this.instruction = instruction;
        }

        public static ObservableCollection<InstructionData> GetData(CharaFile charaFile)
        {
            ObservableCollection<InstructionData> data = new ObservableCollection<InstructionData>();
            foreach (var header in charaFile.InstructionListHeaders)
            {
                foreach (var instruction in header.instructions)
                {
                    InstructionData instructionData = new InstructionData(instruction);

                    data.Add(instructionData);
                }
            }

            return data;
        }
    }
}
