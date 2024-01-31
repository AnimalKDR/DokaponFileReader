﻿using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class MonsterData
    {

        public string name { get; set; }
        public string description { get; set; }
        public ushort level { get; set; }
        public float attack { get; set; }
        public float defense { get; set; }
        public float magic { get; set; }
        public float speed { get; set; }
        public float hp { get; set; }
        public byte voiceID { get; set; }
        public MonsterType monsterType { get; set; }
        public string offensiveMagic { get; set; }
        public string defensiveMagic { get; set; }
        public string battleSkill { get; set; }
        public ushort experience { get; set; }
        public short gold { get; set; }
        public bool dynamicGold { get; set; }
        public EffectItemType[] dropItemType { get; set; }
        public string [] dropItem { get; set; }
        public byte[] dropItemChance { get; set; }
        public byte aiIndex { get; set; }

        public SpecialStatType specialTypeAttack { get; set; }
        public SpecialStatType specialTypeDefense { get; set; }
        public SpecialStatType specialTypeMagic { get; set; }
        public SpecialStatType specialTypeSpeed { get; set; }
        public SpecialStatType specialTypeHP { get; set; }

        public enum AIType
        {
            Normal,
            NoMagic,
            LowMagic,
            HighMagicNoSkill,
            HighMagic,
            NoMagicOrDefense,
            NoMagicDefense,
            Bandit,

        }

        public MonsterData(string name)
        {
            this.name = name;
            dropItemType = new EffectItemType[2] {EffectItemType.None, EffectItemType.None };
            dropItem = new string[2] { "None", "None" };
            dropItemChance = new byte[2] { 0, 0 };
            description = String.Empty;
            monsterType = MonsterType.Special;
            offensiveMagic = "None";
            defensiveMagic = "None";
            battleSkill = "None";
        }

        public static (SpecialStatType, float) SetStatTypeAndValue(ushort stat)
        {
            if (stat >> 8 == (ushort)SpecialStatType.Clonus)
                return (SpecialStatType.Clonus, stat & 0xFF);

            if (stat >> 8 == (ushort)SpecialStatType.Average)
                return (SpecialStatType.Average, (stat & 0xFF) / (float)10.0 + 1);

            if (stat >> 8 == (ushort)SpecialStatType.Highest)
                return (SpecialStatType.Highest, (stat & 0xFF) / (float)10.0 + 1);

            if (stat >> 8 == (ushort)SpecialStatType.Lowest)
                return (SpecialStatType.Lowest, (stat & 0xFF) / (float)10.0 + 1);

            return (SpecialStatType.None, stat);
        }

        public static ushort GetStatWriteValue(SpecialStatType statType, float statValue)
        {
            if (statType == SpecialStatType.None)
                return (ushort)statValue;

            int value = (int)((statValue - 1) * 10 + 0.5);
            if (statType == SpecialStatType.Clonus)
                value = (int)statValue;

            int value2 = (int)(statType) << 8;
            int value3 = value + value2;
            return (ushort)value3;
        }

        public static ObservableCollection<MonsterData> GetData(CharaFile charaFile)
        {
            ObservableCollection<MonsterData> data = new ObservableCollection<MonsterData>();
            foreach (var monster in charaFile.MonsterHeaders)
            {
                MonsterData monsterData = new MonsterData(monster.name);
                monsterData.level = monster.level;

                (monsterData.specialTypeAttack, monsterData.attack) = SetStatTypeAndValue(monster.attack);
                (monsterData.specialTypeDefense, monsterData.defense) = SetStatTypeAndValue(monster.defense);
                (monsterData.specialTypeMagic, monsterData.magic) = SetStatTypeAndValue(monster.magic);
                (monsterData.specialTypeSpeed, monsterData.speed) = SetStatTypeAndValue(monster.speed);
                (monsterData.specialTypeHP, monsterData.hp) = SetStatTypeAndValue(monster.hp);

                monsterData.experience = monster.experience;
                monsterData.gold = Math.Abs(monster.gold);
                monsterData.dynamicGold = monster.gold < 0 ? true : false;
                monsterData.battleSkill = charaFile.GetItemName(EffectItemType.BattleSkill, monster.battleSkillID);
                monsterData.offensiveMagic = charaFile.GetItemName(EffectItemType.OffensiveMagic, monster.offensiveMagicID);
                monsterData.defensiveMagic = charaFile.GetItemName(EffectItemType.DefensiveMagic, monster.defensiveMagicID);

                data.Add(monsterData);
            }

            for (int i = 0; i < charaFile.MonsterDescriptionHeader.description.Count && i < data.Count; i++)
            {
                data[i].description = charaFile.MonsterDescriptionHeader.description[i];
            }

            foreach (var monsterDrop in charaFile.MonsterItemDropHeaders)
            {
                data[monsterDrop.index].dropItemType[0] = (EffectItemType)monsterDrop.categoryItem0;
                data[monsterDrop.index].dropItemType[1] = (EffectItemType)monsterDrop.categoryItem1;
                data[monsterDrop.index].dropItem[0] = charaFile.GetItemName((EffectItemType)monsterDrop.categoryItem0, monsterDrop.indexItem0);
                data[monsterDrop.index].dropItem[1] = charaFile.GetItemName((EffectItemType)monsterDrop.categoryItem1, monsterDrop.indexItem1);
                data[monsterDrop.index].dropItemChance[0] = monsterDrop.dropItemChance0;
                data[monsterDrop.index].dropItemChance[1] = monsterDrop.dropItemChance1;
            }

            foreach (var monsterType in charaFile.MonsterTypeHeaders)
            {
                data[monsterType.index].voiceID = monsterType.voiceID;
                data[monsterType.index].monsterType = (MonsterType)monsterType.monsterType;
                data[monsterType.index].aiIndex = monsterType.aiIndex;
            }

            return data;
        }

        public static void SetData(ObservableCollection<MonsterData> monsterData, ref CharaFile charaFile)
        {
            for (int i = 0; i < monsterData.Count && i < charaFile.MonsterHeaders.Count; i++)
            {
                charaFile.MonsterHeaders[i].name = monsterData[i].name;
                charaFile.MonsterHeaders[i].level = monsterData[i].level;
                charaFile.MonsterHeaders[i].attack = GetStatWriteValue(monsterData[i].specialTypeAttack, monsterData[i].attack);
                charaFile.MonsterHeaders[i].defense = GetStatWriteValue(monsterData[i].specialTypeDefense, monsterData[i].defense);
                charaFile.MonsterHeaders[i].magic = GetStatWriteValue(monsterData[i].specialTypeMagic, monsterData[i].magic);
                charaFile.MonsterHeaders[i].speed = GetStatWriteValue(monsterData[i].specialTypeSpeed, monsterData[i].speed);
                charaFile.MonsterHeaders[i].hp = GetStatWriteValue(monsterData[i].specialTypeHP, monsterData[i].hp);
                charaFile.MonsterHeaders[i].experience = monsterData[i].experience;
                charaFile.MonsterHeaders[i].gold = monsterData[i].dynamicGold ? (short)-monsterData[i].gold : monsterData[i].gold;
                charaFile.MonsterHeaders[i].battleSkillID = charaFile.GetItemID(EffectItemType.BattleSkill, monsterData[i].battleSkill);
                charaFile.MonsterHeaders[i].offensiveMagicID = charaFile.GetItemID(EffectItemType.OffensiveMagic, monsterData[i].offensiveMagic);
                charaFile.MonsterHeaders[i].defensiveMagicID = charaFile.GetItemID(EffectItemType.DefensiveMagic, monsterData[i].defensiveMagic);
            }

            for (int i = 0; i < monsterData.Count && i < charaFile.MonsterDescriptionHeader.description.Count; i++)
            {
                charaFile.MonsterDescriptionHeader.description[i] = monsterData[i].description;
            }

            for (int i = 0; i < monsterData.Count && i < charaFile.MonsterItemDropHeaders.Count; i++)
            {
                charaFile.MonsterItemDropHeaders[i].categoryItem0 = (byte)monsterData[i].dropItemType[0];
                charaFile.MonsterItemDropHeaders[i].categoryItem1 = (byte)monsterData[i].dropItemType[1];
                charaFile.MonsterItemDropHeaders[i].indexItem0 = charaFile.GetItemID(monsterData[i].dropItemType[0], monsterData[i].dropItem[0]);
                charaFile.MonsterItemDropHeaders[i].indexItem1 = charaFile.GetItemID(monsterData[i].dropItemType[1], monsterData[i].dropItem[1]);
                charaFile.MonsterItemDropHeaders[i].dropItemChance0 = monsterData[i].dropItemChance[0];
                charaFile.MonsterItemDropHeaders[i].dropItemChance1 = monsterData[i].dropItemChance[1];
            }

            for (int i = 0; i < monsterData.Count && i < charaFile.MonsterTypeHeaders.Count; i++)
            {
                charaFile.MonsterTypeHeaders[i].voiceID = monsterData[i].voiceID;
                charaFile.MonsterTypeHeaders[i].monsterType = (byte)monsterData[i].monsterType;
                charaFile.MonsterTypeHeaders[i].aiIndex = monsterData[i].aiIndex;
            }
        }
    }
}
