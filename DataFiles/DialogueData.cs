using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class DialogueData
    {
        public string dialogue { get; set; }

        public DialogueData(string dialogue)
        {
            this.dialogue = dialogue;
        }

        public static ObservableCollection<DialogueData> GetData(CharaFile charaFile)
        {
            ObservableCollection<DialogueData> data = new ObservableCollection<DialogueData>();
            foreach (var header in charaFile.DialogListHeaders)
            {
                foreach (var dialogue in header.dialog)
                {
                    DialogueData dialogueData = new DialogueData(dialogue);

                    data.Add(dialogueData);
                }
            }

            return data;
        }
    }
}
