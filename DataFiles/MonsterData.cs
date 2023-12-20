using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class MonsterData
    {

        public string name { get; set; }
        public string description { get; set; }
        public ushort level { get; set; }
        public ushort attack { get; set; }
        public ushort defense { get; set; }
        public ushort magic { get; set; }
        public ushort speed { get; set; }
        public ushort hp { get; set; }
        public byte voiceID { get; set; }
        public string monsterType { get; set; }
        public string offensiveMagic { get; set; }
        public string defensiveMagic { get; set; }
        public string battleSkill { get; set; }
        public ushort experience { get; set; }
        public short gold { get; set; }
        public bool dynamicGold { get; set; }
        public string [] dropItem { get; set; }
        public byte[] dropItemChance { get; set; }
        public byte aiIndex { get; set; }
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
            dropItemChance = new byte[2] { 0, 0 };
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
                monsterData.attack = monster.attack;
                monsterData.defense = monster.defense;
                monsterData.magic = monster.magic;
                monsterData.speed = monster.speed;
                monsterData.hp = monster.hp;
                monsterData.experience = monster.experience;
                monsterData.gold = Math.Abs(monster.gold);
                monsterData.dynamicGold = monster.gold < 0 ? true : false;
                monsterData.battleSkill = charaFile.GetItemName(ItemType.BattleSkill, monster.battleSkillID);
                monsterData.offensiveMagic = charaFile.GetItemName(ItemType.OffensiveMagic, monster.offensiveMagicID);
                monsterData.defensiveMagic = charaFile.GetItemName(ItemType.DefensiveMagic, monster.defensiveMagicID);

                data.Add(monsterData);
            }

            for (int i = 0; i < charaFile.MonsterDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.MonsterDescriptionHeader.description[i];
            }

            foreach (var monsterDrop in charaFile.MonsterItemDropHeaders)
            {
                data[monsterDrop.index].dropItem[0] = charaFile.GetItemName((ItemType)monsterDrop.categoryItem0, monsterDrop.indexItem0);
                data[monsterDrop.index].dropItem[1] = charaFile.GetItemName((ItemType)monsterDrop.categoryItem1, monsterDrop.indexItem1);
                data[monsterDrop.index].dropItemChance[0] = monsterDrop.dropItemChance0;
                data[monsterDrop.index].dropItemChance[1] = monsterDrop.dropItemChance1;
            }

            foreach (var monsterType in charaFile.MonsterTypeHeaders)
            {
                data[monsterType.index].voiceID = monsterType.voiceID;
                data[monsterType.index].monsterType = MonsterTypeHeader.GetMonsterType((MonsterTypeHeader.MonsterType)monsterType.monsterType);
                data[monsterType.index].aiIndex = monsterType.aiIndex;
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

        public static void SetData(ObservableCollection<MonsterData> monsterData, ref CharaFile charaFile)
        {
            for (int i = 0; i < monsterData.Count && i < charaFile.MonsterHeaders.Count; i++)
            {
                charaFile.MonsterHeaders[i].name = monsterData[i].name;
                charaFile.MonsterHeaders[i].level = monsterData[i].level;
                charaFile.MonsterHeaders[i].attack = monsterData[i].attack;
                charaFile.MonsterHeaders[i].defense = monsterData[i].defense;
                charaFile.MonsterHeaders[i].magic = monsterData[i].magic;
                charaFile.MonsterHeaders[i].speed = monsterData[i].speed;
                charaFile.MonsterHeaders[i].hp = monsterData[i].hp;
                charaFile.MonsterHeaders[i].experience = monsterData[i].experience;
                charaFile.MonsterHeaders[i].gold = monsterData[i].dynamicGold ? (short)-monsterData[i].gold : monsterData[i].gold;
                (_, charaFile.MonsterHeaders[i].battleSkillID) = charaFile.GetItemTypeAndID(monsterData[i].battleSkill);
                (_, charaFile.MonsterHeaders[i].offensiveMagicID) = charaFile.GetItemTypeAndID(monsterData[i].offensiveMagic);
                (_, charaFile.MonsterHeaders[i].defensiveMagicID) = charaFile.GetItemTypeAndID(monsterData[i].defensiveMagic);
            }

            for (int i = 0; i < monsterData.Count && i < charaFile.MonsterDescriptionHeader.description.Count; i++)
            {
                charaFile.MonsterDescriptionHeader.description[i] = monsterData[i].description;
            }

            for (int i = 0; i < monsterData.Count && i < charaFile.MonsterItemDropHeaders.Count; i++)
            {
                (charaFile.MonsterItemDropHeaders[i].categoryItem0, charaFile.MonsterItemDropHeaders[i].indexItem0) = charaFile.GetItemTypeAndID(monsterData[i].dropItem[0]);
                (charaFile.MonsterItemDropHeaders[i].categoryItem1, charaFile.MonsterItemDropHeaders[i].indexItem1) = charaFile.GetItemTypeAndID(monsterData[i].dropItem[1]);
                charaFile.MonsterItemDropHeaders[i].dropItemChance0 = monsterData[i].dropItemChance[0];
                charaFile.MonsterItemDropHeaders[i].dropItemChance1 = monsterData[i].dropItemChance[1];
            }

            for (int i = 0; i < monsterData.Count && i < charaFile.MonsterTypeHeaders.Count; i++)
            {
                charaFile.MonsterTypeHeaders[i].voiceID = monsterData[i].voiceID;
                charaFile.MonsterTypeHeaders[i].monsterType = MonsterTypeHeader.GetMonsterID(monsterData[i].monsterType);
                charaFile.MonsterTypeHeaders[i].aiIndex = monsterData[i].aiIndex;
            }
        }
    }
}
