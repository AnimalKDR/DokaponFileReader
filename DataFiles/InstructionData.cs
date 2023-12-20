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

            foreach (var instruction in charaFile.InstructionListHeader.instructions)
            {
                InstructionData instructionData = new InstructionData(instruction);

                data.Add(instructionData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<InstructionData> instructionData, ref CharaFile charaFile)
        {
            for (int i = 0; i < charaFile.InstructionListHeader.instructions.Count && i < instructionData.Count; i++)
            {
                charaFile.InstructionListHeader.instructions[i] = instructionData[i].instruction;
            }
        }
    }
}
