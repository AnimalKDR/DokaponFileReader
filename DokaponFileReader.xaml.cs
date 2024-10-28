using DokaponFileReader.DataFiles;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DokaponFileReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StageBaseFile stageBaseFile = new StageBaseFile();
        public CharaFile charaFile = new CharaFile();

        public ObservableCollection<ItemData> itemData = new ObservableCollection<ItemData>();
        public ObservableCollection<EffectItemData> effectItemData = new ObservableCollection<EffectItemData>();
        public ObservableCollection<JobNameData> jobNameData = new ObservableCollection<JobNameData>();
        public ObservableCollection<JobData> jobData = new ObservableCollection<JobData>();
        public ObservableCollection<MonsterData> monsterData = new ObservableCollection<MonsterData>();
        public ObservableCollection<MonsterAIData> monsterAIData = new ObservableCollection<MonsterAIData>();
        public ObservableCollection<WeaponData> weaponData = new ObservableCollection<WeaponData>();
        public ObservableCollection<ShieldData> shieldData = new ObservableCollection<ShieldData>();
        public ObservableCollection<AccessoryData> accessorydData = new ObservableCollection<AccessoryData>();
        public ObservableCollection<HairstyleData> hairstyleData = new ObservableCollection<HairstyleData>();
        public ObservableCollection<BagItemData> bagItemData = new ObservableCollection<BagItemData>();
        public ObservableCollection<LocalItemData> localItemData = new ObservableCollection<LocalItemData>();
        public ObservableCollection<OffensiveMagicData> offensiveMagicData = new ObservableCollection<OffensiveMagicData>();
        public ObservableCollection<DefensiveMagicData> defensiveMagicData = new ObservableCollection<DefensiveMagicData>();
        public ObservableCollection<FieldMagicData> fieldMagicData = new ObservableCollection<FieldMagicData>();
        public ObservableCollection<BattleSkillData> battleSkillData = new ObservableCollection<BattleSkillData>();
        public ObservableCollection<JobSkillData> jobSkillData = new ObservableCollection<JobSkillData>();
        public ObservableCollection<DarkArtData> darkArtData = new ObservableCollection<DarkArtData>();
        public ObservableCollection<CombatFormulaData> combatFormulaData = new ObservableCollection<CombatFormulaData>();
        public ObservableCollection<ExperienceData> experienceData = new ObservableCollection<ExperienceData>();
        public ObservableCollection<CPUNameData> cpuNameData = new ObservableCollection<CPUNameData>();
        public ObservableCollection<NPCData> npcData = new ObservableCollection<NPCData>();
        public ObservableCollection<DialogueData> dialogueData = new ObservableCollection<DialogueData>();
        public ObservableCollection<EffectData> effectData1 = new ObservableCollection<EffectData>();
        public ObservableCollection<EffectData> effectData2 = new ObservableCollection<EffectData>();
        public ObservableCollection<EffectData> effectData3 = new ObservableCollection<EffectData>();
        public ObservableCollection<InstructionData> instructionData = new ObservableCollection<InstructionData>();
        public ObservableCollection<PrankNameData> prankNameData = new ObservableCollection<PrankNameData>();
        public ObservableCollection<SpaceData> spaceData = new ObservableCollection<SpaceData>();
        public ObservableCollection<LocationData> locationData = new ObservableCollection<LocationData>();
        public ObservableCollection<TempleData> templeData = new ObservableCollection<TempleData>();
        public ObservableCollection<TownCastleData> townCastleData = new ObservableCollection<TownCastleData>();

        public ObservableCollection<RandomLootData> randomLootData = new ObservableCollection<RandomLootData>();
        public ObservableCollection<EffectItemType> itemTypeData = new ObservableCollection<EffectItemType>();

        public ObservableCollection<WeaponStoreData> weaponStoreData = new ObservableCollection<WeaponStoreData>();
        public ObservableCollection<ItemStoreData> itemStoreData = new ObservableCollection<ItemStoreData>();
        public ObservableCollection<MagicStoreData> magicStoreData = new ObservableCollection<MagicStoreData>();
        public ObservableCollection<MonsterEncounterData> monsterEncounterData = new ObservableCollection<MonsterEncounterData>();

        public MainWindow()
        {
            InitializeComponent();

            /*
                        string eng = "D:\\Users\\anima\\Source\\Repos\\CriPakTools\\CriPakTools\\bin\\Debug\\Data_eng\\dataSeq_EN\\STAGEBASE-EN-English.DAT";
                        string tst = "D:\\Users\\anima\\Source\\Repos\\DokaponFileReader\\stageBase_TEST.DAT";

                        var fileStreamEng = File.Open(eng, FileMode.Open);
                        var fileStreamTst = File.Open(tst, FileMode.Open);

                        fileStreamEng.Position = 0x4C9F0;
                        fileStreamTst.Position = 0x4C9F0;

                        List<UInt32> engList = new List<UInt32>();
                        List<UInt32> tstList = new List<UInt32>();

                        List<(int, int, UInt32)> differences = new List<(int, int, UInt32)>();

                        byte[] buffer = new byte[4];

                        while (fileStreamEng.Position < 0xB1BC0)
                        {
                            fileStreamEng.Read(buffer);
                            engList.Add(BitConverter.ToUInt32(buffer));
                        }

                        while (fileStreamTst.Position < 0xB1BC0)
                        {
                            fileStreamTst.Read(buffer);
                            tstList.Add(BitConverter.ToUInt32(buffer));
                        }

                        for (int i = 0; i < engList.Count; i++)
                        {
                            if (tstList[i] == engList[i])
                                continue;

                            var difference = tstList[i] - engList[i];

                            if (engList[i] < 0x4C9F0 - 0x8390  || engList[i] > 0xB1BC0 - 0x8390)
                                continue;

                            if (difference > 0xFFFFF520 || difference < 0xFFFFF470)
                                continue;

                            if (difference % 4 != 0)
                                continue;

                            if (i < 409)
                                continue;

                            var address = i - 409;

                            if (address >= 107) // UnknownHeader_AD.unknownUInt32s.RemoveAt(107);
                                address++;
                            if (address >= 583) // UnknownHeader_AD.unknownUInt32s.RemoveAt(583);
                                address++;
                            if (address >= 788) // UnknownHeader_AD.unknownUInt32s.RemoveAt(788);
                                address++;
                            if (address >= 2491) // UnknownHeader_AD.unknownUInt32s.Insert(2491, 0x00000E10);
                                address--;
                            if (address >= 7011) // UnknownHeader_AD.unknownUInt32s.RemoveRange(7011, 20);
                                address += 20;
                            if (address >= 8540) //  UnknownHeader_AD.unknownUInt32s.RemoveAt(8516);
                                address++;
                            if (address >= 18141) // UnknownHeader_AD.unknownUInt32s.Insert(18132, 0x01020509); UnknownHeader_AD.unknownUInt32s.Insert(18133, 0x000000FF); UnknownHeader_AD.unknownUInt32s.Insert(18134, 0x00056830);
                                address -= 3;
                            if (address >= 70990) // UnknownHeader_AD.unknownUInt32s.RemoveRange(70982, 6);
                                address += 6;
                            if (address >= 71010) // UnknownHeader_AD.unknownUInt32s.RemoveRange(70989, 2);
                                address += 2;
                            if (address >= 71019) // UnknownHeader_AD.unknownUInt32s.RemoveRange(71013, 6);
                                address += 6;
                            if (address >= 71194) // UnknownHeader_AD.unknownUInt32s.RemoveRange(71172, 6);
                                address += 6;
                            if (address >= 85684) // UnknownHeader_AD.unknownUInt32s.Insert(85674, 0x00000F10);
                                address--;
                            if (address >= 85690) // UnknownHeader_AD.unknownUInt32s.Insert(85690, 0x00020006); UnknownHeader_AD.unknownUInt32s.Insert(85691, 0x00000E10); UnknownHeader_AD.unknownUInt32s.Insert(85692, 0x00020006); UnknownHeader_AD.unknownUInt32s.Insert(85693, 0x00000C10);
                                address -= 4;

                           differences.Add((address, 4 * address + 0x4C46C, difference));
                        }

                        string res = "D:\\Users\\anima\\Source\\Repos\\DokaponFileReader\\pointerIndexes.bin";
                        var fileStreamRes = File.Create(res);

                        foreach (var item in differences)
                            fileStreamRes.Write(BitConverter.GetBytes(item.Item1));


                        string org = "D:\\Users\\anima\\Source\\Repos\\DokaponFileReader\\stageBase_EN.DAT";
                        var fileStreamOrg = File.Open(org, FileMode.Open);
                        fileStreamOrg.Position = 0x4BE08;

                        List<(int, int, UInt32)> newDiff = new List<(int, int, UInt32)>();

                        foreach(var item in differences)
                        {
                            fileStreamOrg.Position = item.Item2;
                            fileStreamOrg.Read(buffer);

                            var value = BitConverter.ToUInt32(buffer);

                            if (value >= 0x4BE08 - 0x8330 && value <= 0xB1080 - 0x8330)
                                continue;

                            newDiff.Add((item.Item1, item.Item2, value));
                        }

                        fileStreamOrg.Close();
                        fileStreamEng.Close();
                        fileStreamTst.Close();
                        fileStreamRes.Close();*/
        }

        ~MainWindow()
        {
            Close();
            MainProgram.exit = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            MainProgram.exit = true;
            base.OnClosed(e);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataContext = this;
        }

        private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open StageBase File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "DAT",
                Filter = "DAT files (*.DAT)|*.DAT",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenStageBaseFile(openFileDialog.FileName);
            }
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save StageBase File",

                CheckFileExists = false,
                CheckPathExists = true,

                DefaultExt = "DAT",
                Filter = "DAT files (*.DAT)|*.DAT",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveStageBaseFile(saveFileDialog.FileName);
            }
        }

        private void OpenStageBaseFile(string path)
        {
            DokaponFileReader fileReader = new DokaponFileReader(path);

            if (fileReader.fileStream.Name.Contains("stageBase"))
            {
                stageBaseFile.ReadStageBase(fileReader);

                while (fileReader.GetPosition() % 16 != 0)
                    fileReader.GetByte();

                fileReader.fileOffset = (UInt32)fileReader.GetPosition();
                charaFile.originalFileOffset = fileReader.fileOffset;

                charaFile.ReadCharaFile(fileReader);

                GetData();
            }

            fileReader.Close();
        }

        private void SaveStageBaseFile(string path)
        {
            DokaponFileWriter fileWriter = new DokaponFileWriter(path);

            SetData();

            stageBaseFile.WriteStageBase(fileWriter);

            fileWriter.fileOffset = (UInt32)fileWriter.GetPosition();

            charaFile.WriteCharaFile(fileWriter);

            fileWriter.Close();
        }

        private void GetData()
        {
            itemTypeData = new ObservableCollection<EffectItemType>();
            itemTypeData.Add(EffectItemType.None);
            itemTypeData.Add(EffectItemType.Weapon);
            itemTypeData.Add(EffectItemType.Shield);
            itemTypeData.Add(EffectItemType.Accessory);
            itemTypeData.Add(EffectItemType.OffensiveMagic);
            itemTypeData.Add(EffectItemType.DefensiveMagic);
            itemTypeData.Add(EffectItemType.BagItem);
            itemTypeData.Add(EffectItemType.FieldMagic);

            battleSkillData = BattleSkillData.GetData(charaFile);
            jobSkillData = JobSkillData.GetData(charaFile);
            weaponData = WeaponData.GetData(charaFile);
            shieldData = ShieldData.GetData(charaFile);
            accessorydData = AccessoryData.GetData(charaFile);
            offensiveMagicData = OffensiveMagicData.GetData(charaFile);
            defensiveMagicData = DefensiveMagicData.GetData(charaFile);
            bagItemData = BagItemData.GetData(charaFile);
            localItemData = LocalItemData.GetData(charaFile, stageBaseFile);
            fieldMagicData = FieldMagicData.GetData(charaFile);
            ItemData.AddWeaponData(ref itemData, weaponData);
            ItemData.AddShieldData(ref itemData, shieldData);
            ItemData.AddAccessoryData(ref itemData, accessorydData);
            ItemData.AddDefensiveMagicData(ref itemData, defensiveMagicData);
            ItemData.AddOffensiveMagicData(ref itemData, offensiveMagicData);
            ItemData.AddBagItemData(ref itemData, bagItemData);
            ItemData.AddLocalItemData(ref itemData, localItemData);
            ItemData.AddFieldMagicData(ref itemData, fieldMagicData);
            EffectItemData.AddWeaponData(ref effectItemData, weaponData);
            EffectItemData.AddShieldData(ref effectItemData, shieldData);
            EffectItemData.AddAccessoryData(ref effectItemData, accessorydData);
            EffectItemData.AddDefensiveMagicData(ref effectItemData, defensiveMagicData);
            EffectItemData.AddOffensiveMagicData(ref effectItemData, offensiveMagicData);
            EffectItemData.AddBagItemData(ref effectItemData, bagItemData);
            EffectItemData.AddLocalItemData(ref effectItemData, localItemData);
            EffectItemData.AddFieldMagicData(ref effectItemData, fieldMagicData);
            EffectItemData.AddEffectData(ref effectItemData, stageBaseFile.RandomEffectHeaders);

            jobNameData = JobNameData.GetData(charaFile);
            jobData = JobData.GetData(charaFile, battleSkillData, jobSkillData, itemData, jobNameData);
            monsterData = MonsterData.GetData(charaFile, battleSkillData, offensiveMagicData, defensiveMagicData, itemData);
            monsterAIData = MonsterAIData.GetData(charaFile);
            hairstyleData = HairstyleData.GetData(charaFile);
            darkArtData = DarkArtData.GetData(charaFile);
            combatFormulaData = CombatFormulaData.GetData(charaFile);
            cpuNameData = CPUNameData.GetData(charaFile);
            experienceData = ExperienceData.GetData(charaFile);
            npcData = NPCData.GetData(charaFile);
            dialogueData = DialogueData.GetData(charaFile);
            effectData1 = EffectData.GetDataFromHeader1(charaFile);
            effectData2 = EffectData.GetDataFromHeader2(charaFile);
            effectData3 = EffectData.GetDataFromHeader3(charaFile);
            instructionData = InstructionData.GetData(charaFile);
            prankNameData = PrankNameData.GetData(charaFile);
            spaceData = SpaceData.GetData(stageBaseFile);
            locationData = LocationData.GetData(stageBaseFile);
            templeData = TempleData.GetData(stageBaseFile);
            townCastleData = TownCastleData.GetData(stageBaseFile);
            weaponStoreData = WeaponStoreData.GetData(stageBaseFile, itemData);
            itemStoreData = ItemStoreData.GetData(stageBaseFile, itemData);
            magicStoreData = MagicStoreData.GetData(stageBaseFile, itemData);
            monsterEncounterData = MonsterEncounterData.GetData(charaFile, monsterData);
            randomLootData = RandomLootData.GetData(stageBaseFile, effectItemData);

            SetDataContext();
        }

        private void SetData()
        {
            JobNameData.SetData(jobNameData, ref charaFile);
            JobData.SetData(jobData, ref charaFile);
            MonsterData.SetData(monsterData, ref charaFile);
            MonsterAIData.SetData(monsterAIData, ref charaFile);
            WeaponData.SetData(weaponData, ref charaFile);
            ShieldData.SetData(shieldData, ref charaFile);
            AccessoryData.SetData(accessorydData, ref charaFile);
            HairstyleData.SetData(hairstyleData, ref charaFile);
            BagItemData.SetData(bagItemData, ref charaFile);
            LocalItemData.SetData(localItemData, ref charaFile, ref stageBaseFile);
            OffensiveMagicData.SetData(offensiveMagicData, ref charaFile);
            DefensiveMagicData.SetData(defensiveMagicData, ref charaFile);
            FieldMagicData.SetData(fieldMagicData, ref charaFile);
            BattleSkillData.SetData(battleSkillData, ref charaFile);
            JobSkillData.SetData(jobSkillData, ref charaFile);
            DarkArtData.SetData(darkArtData, ref charaFile);
            CombatFormulaData.SetData(combatFormulaData, ref charaFile);
            CPUNameData.SetData(cpuNameData, ref charaFile);
            ExperienceData.SetData(experienceData, ref charaFile);
            DialogueData.SetData(dialogueData, ref charaFile);
            EffectData.SetDataFromHeader1(effectData1, ref charaFile);
            EffectData.SetDataFromHeader2(effectData2, ref charaFile);
            EffectData.SetDataFromHeader3(effectData3, ref charaFile);
            InstructionData.SetData(instructionData, ref charaFile);
            PrankNameData.SetData(prankNameData, ref charaFile);
            SpaceData.SetData(spaceData, ref stageBaseFile);
            LocationData.SetData(locationData, ref stageBaseFile);
            TempleData.SetData(templeData, ref stageBaseFile);
            TownCastleData.SetData(townCastleData, ref stageBaseFile);
            WeaponStoreData.SetData(weaponStoreData, itemData, ref stageBaseFile);
            ItemStoreData.SetData(itemStoreData, itemData, ref stageBaseFile);
            MagicStoreData.SetData(magicStoreData, itemData, ref stageBaseFile);
            MonsterEncounterData.SetData(monsterEncounterData, monsterData, ref charaFile);
            RandomLootData.SetData(randomLootData, ref stageBaseFile);
        }

        private void SetDataContext()
        {
            JobDataTab.DataContext = jobData;
            MonsterDataTab.DataContext = monsterData;
            MonsterAIDataTab.DataContext = monsterAIData;
            WeaponDataTab.DataContext = weaponData;
            ShieldDataTab.DataContext = shieldData;
            AccessoryDataTab.DataContext = accessorydData;
            HairstyleDataTab.DataContext = hairstyleData;
            BagItemDataTab.DataContext = bagItemData;
            LocalItemDataTab.DataContext = localItemData;
            OffensiveMagicDataTab.DataContext = offensiveMagicData;
            DefensiveMagicDataTab.DataContext = defensiveMagicData;
            FieldMagicDataTab.DataContext = fieldMagicData;
            BattleSkillDataTab.DataContext = battleSkillData;
            PassiveSkillDataTab.DataContext = jobSkillData;
            DarkArtDataTab.DataContext = darkArtData;
            CombatFormulaDataTab.DataContext = combatFormulaData;
            ExperienceDataTab.DataContext = experienceData;
            CPUNameDataTab.DataContext = cpuNameData;
            NPCDataTab.DataContext = npcData;
            DialogueDataTab.DataContext = dialogueData;
            EffectDataTab1.DataContext = effectData1;
            EffectDataTab2.DataContext = effectData2;
            EffectDataTab3.DataContext = effectData3;
            InstructionDataTab.DataContext = instructionData;
            PrankNameDataTab.DataContext = prankNameData;
            SpaceDataTab.DataContext = spaceData;
            LocationDataTab.DataContext = locationData;
            TempleDataTab.DataContext = templeData;
            TownCastleDataTab.DataContext = townCastleData;

            int i = 0;
            foreach (TabItem tabItem in WeaponStoreControl.Items)
            {
                tabItem.DataContext = weaponStoreData[i++].storeItems;
                AddItemSourceToTab(tabItem);
            }

            i = 0;
            foreach (TabItem tabItem in MagicStoreControl.Items)
            {
                tabItem.DataContext = magicStoreData[i++].storeItems;
                AddItemSourceToTab(tabItem);
            }

            i = 0;
            foreach (TabItem tabItem in ItemStoreControl.Items)
            {
                tabItem.DataContext = itemStoreData[i++].storeItems;
                AddItemSourceToTab(tabItem);
            }

            i = 0;
            foreach (TabItem tabItem in RandomLootControl.Items)
            {
                tabItem.DataContext = randomLootData[i++].randomItems;
                AddEffectItemSourceToTab(tabItem);
            }

            i = 0;
            foreach (TabItem tabItem in RandomBattleControl.Items)
                tabItem.DataContext = monsterEncounterData[i++].monster;

            Level2BattleSkill.ItemsSource = battleSkillData;
            Level4BattleSkill.ItemsSource = battleSkillData;
            MonsterBattleSkill.ItemsSource = battleSkillData;
            PassiveSkill.ItemsSource = jobSkillData;
            MonsterOffensiveMagic.ItemsSource = offensiveMagicData;
            MonsterDefensiveMagic.ItemsSource = defensiveMagicData;
            DropItem1.ItemsSource = itemData;
            DropItem2.ItemsSource = itemData;
            ItemRequirement.ItemsSource = itemData;
            MasteryRequirement1.ItemsSource = jobNameData;
            MasteryRequirement2.ItemsSource = jobNameData;
            MasteryRequirement3.ItemsSource = jobNameData;
        }

        private void AddItemSourceToTab(TabItem tabItem)
        {
            var children = LogicalTreeHelper.GetChildren(tabItem);

            foreach (var child in children)
            {
                Grid? grid = child as Grid;
                if (grid == null)
                    continue;

                foreach (var gridChild in grid.Children)
                {
                    DataGrid? dataGrid = gridChild as DataGrid;
                    if (dataGrid == null)
                        continue;

                    DataGridComboBoxColumn? dataGridComboBox = dataGrid.Columns[1] as DataGridComboBoxColumn;

                    if (dataGridComboBox == null)
                        continue;

                    dataGridComboBox.ItemsSource = itemData;
                }
            }
        }

        private void AddEffectItemSourceToTab(TabItem tabItem)
        {
            var children = LogicalTreeHelper.GetChildren(tabItem);

            foreach (var child in children)
            {
                Grid? grid = child as Grid;
                if (grid == null)
                    continue;

                foreach (var gridChild in grid.Children)
                {
                    DataGrid? dataGrid = gridChild as DataGrid;
                    if (dataGrid == null)
                        continue;

                    DataGridComboBoxColumn? dataGridComboBox = dataGrid.Columns[1] as DataGridComboBoxColumn;

                    if (dataGridComboBox == null)
                        continue;

                    dataGridComboBox.ItemsSource = effectItemData;
                }
            }
        }
    }
}
