using System.Collections.ObjectModel;

namespace DokaponFileReader.DataFiles
{
    public class CombatFormulaData
    {
        public string name { get; set; }
        public int index { get; set; }
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
                formulaData.index = (int)header.index;

                data.Add(formulaData);
            }

            foreach (AttackFormulaHeader header in charaFile.AttackFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Attack");
                formulaData.formula = header.formula;
                formulaData.index = (int)header.index;

                data.Add(formulaData);
            }

            foreach (MagicFormulaHeader header in charaFile.MagicFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Magic");
                formulaData.formula = header.formula;
                formulaData.index = (int)header.index;

                data.Add(formulaData);
            }

            foreach (StrikeFormulaHeader header in charaFile.StrikeFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Strike");
                formulaData.formula = header.formula;
                formulaData.index = (int)header.index;

                data.Add(formulaData);
            }

            foreach (CounterFormulaHeader header in charaFile.CounterFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Counter");
                formulaData.formula = header.formula;
                formulaData.index = (int)header.index;

                data.Add(formulaData);
            }

            foreach (SelfAttackFormulaHeader header in charaFile.SelfAttackFormulaHeaders)
            {
                CombatFormulaData formulaData = new CombatFormulaData("Self-Attack");
                formulaData.formula = header.formula;
                formulaData.index = (int)header.index;

                data.Add(formulaData);
            }

            return data;
        }
    }
}
