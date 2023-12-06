using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class CombatFormulaData
    {
        public string name { get; set; }
        public uint index { get; set; }
        public string formula { get; set; }

        public CombatFormulaData(string name)
        {
            this.name = name;
            formula = "None";
        }

        public static ObservableCollection<CombatFormulaData> GetData(CharaFile charaFile)
        {
            ObservableCollection<CombatFormulaData> data = new ObservableCollection<CombatFormulaData>();

            foreach (HitFormulaHeader header in charaFile.HitFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Hit");
                formulaData.formula = header.formula;
                formulaData.index = header.index;

                data.Add(formulaData);
            }

            foreach (AttackFormulaHeader header in charaFile.AttackFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Attack");
                formulaData.formula = header.formula;
                formulaData.index = header.index;

                data.Add(formulaData);
            }

            foreach (MagicFormulaHeader header in charaFile.MagicFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Magic");
                formulaData.formula = header.formula;
                formulaData.index = header.index;

                data.Add(formulaData);
            }

            foreach (StrikeFormulaHeader header in charaFile.StrikeFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Strike");
                formulaData.formula = header.formula;
                formulaData.index = header.index;

                data.Add(formulaData);
            }

            foreach (CounterFormulaHeader header in charaFile.CounterFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Counter");
                formulaData.formula = header.formula;
                formulaData.index = header.index;

                data.Add(formulaData);
            }

            foreach (SelfAttackFormulaHeader header in charaFile.SelfAttackFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Self-Attack");
                formulaData.formula = header.formula;
                formulaData.index = header.index;

                data.Add(formulaData);
            }

            return data;
        }

        public static void SetData(ObservableCollection<CombatFormulaData> combatFormulaData, ref CharaFile charaFile)
        {
            int j = 0;
            for (int i = 0; j < combatFormulaData.Count && i < charaFile.HitFormulaHeaders.Count; i++)
            {
                charaFile.HitFormulaHeaders[i].formula = combatFormulaData[j].formula;
                charaFile.HitFormulaHeaders[i].index = combatFormulaData[j].index;
                j++;
            }

            for (int i = 0;  j < combatFormulaData.Count && i < charaFile.AttackFormulaHeaders.Count; i++)
            {
                charaFile.AttackFormulaHeaders[i].formula = combatFormulaData[j].formula;
                charaFile.AttackFormulaHeaders[i].index = combatFormulaData[j].index;
                j++;
            }

            for (int i = 0; j < combatFormulaData.Count && i < charaFile.MagicFormulaHeaders.Count; i++)
            {
                charaFile.MagicFormulaHeaders[i].formula = combatFormulaData[j].formula;
                charaFile.MagicFormulaHeaders[i].index = combatFormulaData[j].index;
                j++;
            }

            for (int i = 0; j < combatFormulaData.Count && i < charaFile.StrikeFormulaHeaders.Count; i++)
            {
                charaFile.StrikeFormulaHeaders[i].formula = combatFormulaData[j].formula;
                charaFile.StrikeFormulaHeaders[i].index = combatFormulaData[j].index;
                j++;
            }

            for (int i = 0; j < combatFormulaData.Count && i < charaFile.CounterFormulaHeaders.Count; i++)
            {
                charaFile.CounterFormulaHeaders[i].formula = combatFormulaData[j].formula;
                charaFile.CounterFormulaHeaders[i].index = combatFormulaData[j].index;
                j++;
            }

            for (int i = 0; j < combatFormulaData.Count && i < charaFile.SelfAttackFormulaHeaders.Count; i++)
            {
                charaFile.SelfAttackFormulaHeaders[i].formula = combatFormulaData[j].formula;
                charaFile.SelfAttackFormulaHeaders[i].index = combatFormulaData[j].index;
                j++;
            }
        }
    }
}
