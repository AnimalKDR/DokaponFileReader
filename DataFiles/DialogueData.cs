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

            foreach (var dialogue in charaFile.DialogListHeader.dialog)
            {
                DialogueData dialogueData = new DialogueData(dialogue);

                data.Add(dialogueData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<DialogueData> dialogueData, ref CharaFile charaFile)
        {
            for (int i = 0; i < charaFile.DialogListHeader.dialog.Count && i < dialogueData.Count; i++)
            {
                charaFile.DialogListHeader.dialog[i] = dialogueData[i].dialogue;
            }
        }
    }
}
