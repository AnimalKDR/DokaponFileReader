using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class MonsterData
    {

        public string name { get; set; }
        public string description { get; set; }
        public int level { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int magic { get; set; }
        public int speed { get; set; }
        public int hp { get; set; }
        public int modelID { get; set; }
        public string monsterType { get; set; }
        public string offensiveMagic { get; set; }
        public string defensiveMagic { get; set; }
        public string battleSkill { get; set; }
        public int xp { get; set; }
        public int gold { get; set; }
        public bool dynamicGold { get; set; }
        public string [] dropItem { get; set; }
        public int[] dropItemChance { get; set; }
        public int attackRate { get; set; }
        public int magicRate { get; set; }
        public int skillRate { get; set; }
        public int strikeRate { get; set; }
        public int defendRate { get; set; }
        public int magicGuardRate { get; set; }
        public int counterRate { get; set; }



        public MonsterData(string name)
        {
            this.name = name;
            dropItem = new string[2] { "None", "None" };
            dropItemChance = new int[2] { 0, 0 };
            description = String.Empty;
            monsterType = String.Empty;
            offensiveMagic = "None";
            defensiveMagic = "None";
            battleSkill = "None";
        }

        public static ObservableCollection<MonsterData> GetData(CharaFile charaFile)
        {
            ObservableCollection<MonsterData> data = new ObservableCollection<MonsterData>();
            foreach (var monster in charaFile.MonsterHeaders)
            {
                MonsterData monsterData = new MonsterData(monster.name);
                monsterData.level = monster.level;
                monsterData.attack = (int)monster.attack;
                monsterData.defense = (int)monster.defense;
                monsterData.magic = (int)monster.magic;
                monsterData.speed = (int)monster.speed;
                monsterData.hp = (int)monster.hp;
                monsterData.xp = monster.experience;
                monsterData.gold = Math.Abs(monster.gold);
                monsterData.dynamicGold = monster.gold < 0 ? true : false;
                monsterData.battleSkill = charaFile.GetItemName(ItemType.BattleSkill, monster.battleSkillID);
                monsterData.offensiveMagic = charaFile.GetItemName(ItemType.OffensiveMagic, monster.offensiveMagicID);
                monsterData.defensiveMagic = charaFile.GetItemName(ItemType.DefensiveMagic, monster.defensiveMagicID);

                data.Add(monsterData);
            }

            for (int i = 0; i < charaFile.MonsterDescriptionHeaders[0].description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.MonsterDescriptionHeaders[0].description[i];
            }

            foreach (var monsterDrop in charaFile.MonsterItemDropHeaders)
            {
                data[monsterDrop.index].dropItem[0] = charaFile.GetItemName((ItemType)monsterDrop.categoryItem1, monsterDrop.indexItem1);
                data[monsterDrop.index].dropItem[1] = charaFile.GetItemName((ItemType)monsterDrop.categoryItem2, monsterDrop.indexItem2);
                data[monsterDrop.index].dropItemChance[0] = monsterDrop.dropRateItem1;
                data[monsterDrop.index].dropItemChance[1] = monsterDrop.dropRateItem2;
            }

            foreach (var monsterType in charaFile.MonsterTypeHeaders)
            {
                data[monsterType.index].modelID = monsterType.modelID;
                data[monsterType.index].monsterType = MonsterTypeHeader.GetMonsterType((MonsterTypeHeader.MonsterType)monsterType.monsterType);
                data[monsterType.index].attackRate = charaFile.MonsterAITableHeaders[monsterType.aiIndex].attackRate;
                data[monsterType.index].magicRate = charaFile.MonsterAITableHeaders[monsterType.aiIndex].magicRate;
                data[monsterType.index].skillRate = charaFile.MonsterAITableHeaders[monsterType.aiIndex].skillRate;
                data[monsterType.index].strikeRate = charaFile.MonsterAITableHeaders[monsterType.aiIndex].strikeRate;
                data[monsterType.index].defendRate = charaFile.MonsterAITableHeaders[monsterType.aiIndex].defendRate;
                data[monsterType.index].magicGuardRate = charaFile.MonsterAITableHeaders[monsterType.aiIndex].magicDefendRate;
                data[monsterType.index].counterRate = charaFile.MonsterAITableHeaders[monsterType.aiIndex].counterRate;
            }

            return data;
        }
    }
}
