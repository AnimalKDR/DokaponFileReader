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

        public static void SetData(ObservableCollection<DialogueData> dialogueData, ref CharaFile charaFile)
        {
            int k = 0;

            for (int i = 0; i < charaFile.DialogListHeaders.Count; i++)
            {
                for (int j = 0; j< charaFile.DialogListHeaders[i].dialog.Count; j++)
                {
                    charaFile.DialogListHeaders[i].dialog[j] = dialogueData[k++].dialogue;
                }
            }
        }
    }
}
