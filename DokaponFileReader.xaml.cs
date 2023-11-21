﻿using DokaponFileReader.DataFiles;
using System.Collections.ObjectModel;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        ~MainWindow()
        {
            MainProgram.exit = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            MainProgram.exit = true;
            base.OnClosed(e);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void OpenStageBaseFile(string path)
        {
            DokaponFileReader fileReader = new DokaponFileReader(path);

            if (fileReader.fileStream.Name.Contains("stageBase"))
            {
                stageBaseFile.ReadStageBase(fileReader);

                while (fileReader.Position() % 16 != 0)
                    fileReader.GetByte();

                fileReader.fileOffset = (UInt32)fileReader.Position();

                charaFile.ReadCharaFile(fileReader);

                ObservableCollection<JobData> jobData = JobData.GetData(charaFile);
                ObservableCollection<MonsterData> monsterData = MonsterData.GetData(charaFile);
                ObservableCollection<WeaponData> weaponData = WeaponData.GetData(charaFile);
                ObservableCollection<ShieldData> shieldData = ShieldData.GetData(charaFile);
                ObservableCollection<AccessoryData> accessorydData = AccessoryData.GetData(charaFile);
                ObservableCollection<HairstyleData> hairstyleData = HairstyleData.GetData(charaFile);
                ObservableCollection<BagItemData> bagItemData = BagItemData.GetData(charaFile);
                ObservableCollection<LocalItemData> localItemData = LocalItemData.GetData(charaFile, stageBaseFile);
                ObservableCollection<OffensiveMagicData> offensiveMagicData = OffensiveMagicData.GetData(charaFile);
                ObservableCollection<DefensiveMagicData> defensiveMagicData = DefensiveMagicData.GetData(charaFile);
                ObservableCollection<FieldMagicData> fieldMagicData = FieldMagicData.GetData(charaFile);
                ObservableCollection<BattleSkillData> battleSkillData = BattleSkillData.GetData(charaFile);
                ObservableCollection<DarkArtData> darkArtData = DarkArtData.GetData(charaFile);
                ObservableCollection<CombatFormulaData> combatFormulaData = CombatFormulaData.GetData(charaFile);
                ObservableCollection<CPUNameData> cpuNameData = CPUNameData.GetData(charaFile);
                ObservableCollection<NPCData> npcData = NPCData.GetData(charaFile);
                ObservableCollection<DialogueData> dialogueData = DialogueData.GetData(charaFile);
                ObservableCollection<EffectData> effectData1 = EffectData.GetDataFromHeader1(charaFile);
                ObservableCollection<EffectData> effectData2 = EffectData.GetDataFromHeader2(charaFile);
                ObservableCollection<EffectData> effectData3 = EffectData.GetDataFromHeader3(charaFile);
                ObservableCollection<InstructionData> instructionData = InstructionData.GetData(charaFile);
                ObservableCollection<PrankNameData> prankNameData = PrankNameData.GetData(charaFile);
                ObservableCollection<SpaceData> spaceData = SpaceData.GetData(stageBaseFile);
                ObservableCollection<LocationData> locationData = LocationData.GetData(stageBaseFile);
                ObservableCollection<TempleData> templeData = TempleData.GetData(stageBaseFile);
                ObservableCollection<TownCastleData> townCastleData = TownCastleData.GetData(stageBaseFile);

                List<ObservableCollection<RandomLootData>> randomLootData = new List<ObservableCollection<RandomLootData>>();
                for (int i = 0; i < 69; i++)
                {
                    randomLootData.Add(RandomLootData.GetData(charaFile, stageBaseFile, i));
                }

                JobDataTab.DataContext = jobData;
                MonsterDataTab.DataContext = monsterData;
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
                DarkArtDataTab.DataContext = darkArtData;
                CombatFormulaDataTab.DataContext = combatFormulaData;
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

                // I'm sure there's a cleaner way to do this
                TableData0.DataContext = randomLootData[0];
                TableData1.DataContext = randomLootData[1];
                TableData2.DataContext = randomLootData[2];
                TableData3.DataContext = randomLootData[3];
                TableData4.DataContext = randomLootData[4];
                TableData5.DataContext = randomLootData[5];
                TableData6.DataContext = randomLootData[6];
                TableData7.DataContext = randomLootData[7];
                TableData8.DataContext = randomLootData[8];
                TableData9.DataContext = randomLootData[9];
                TableData10.DataContext = randomLootData[10];
                TableData11.DataContext = randomLootData[11];
                TableData12.DataContext = randomLootData[12];
                TableData13.DataContext = randomLootData[13];
                TableData14.DataContext = randomLootData[14];
                TableData15.DataContext = randomLootData[15];
                TableData16.DataContext = randomLootData[16];
                TableData17.DataContext = randomLootData[17];
                TableData18.DataContext = randomLootData[18];
                TableData19.DataContext = randomLootData[19];
                TableData20.DataContext = randomLootData[20];
                TableData21.DataContext = randomLootData[21];
                TableData22.DataContext = randomLootData[22];
                TableData23.DataContext = randomLootData[23];
                TableData24.DataContext = randomLootData[24];
                TableData25.DataContext = randomLootData[25];
                TableData26.DataContext = randomLootData[26];
                TableData27.DataContext = randomLootData[27];
                TableData28.DataContext = randomLootData[28];
                TableData29.DataContext = randomLootData[29];
                TableData30.DataContext = randomLootData[30];
                TableData31.DataContext = randomLootData[31];
                TableData32.DataContext = randomLootData[32];
                TableData33.DataContext = randomLootData[33];
                TableData34.DataContext = randomLootData[34];
                TableData35.DataContext = randomLootData[35];
                TableData36.DataContext = randomLootData[36];
                TableData37.DataContext = randomLootData[37];
                TableData38.DataContext = randomLootData[38];
                TableData39.DataContext = randomLootData[39];
                TableData40.DataContext = randomLootData[40];
                TableData41.DataContext = randomLootData[41];
                TableData42.DataContext = randomLootData[42];
                TableData43.DataContext = randomLootData[43];
                TableData44.DataContext = randomLootData[44];
                TableData45.DataContext = randomLootData[45];
                TableData46.DataContext = randomLootData[46];
                TableData47.DataContext = randomLootData[47];
                TableData48.DataContext = randomLootData[48];
                TableData49.DataContext = randomLootData[49];
                TableData50.DataContext = randomLootData[50];
                TableData51.DataContext = randomLootData[51];
                TableData52.DataContext = randomLootData[52];
                TableData53.DataContext = randomLootData[53];
                TableData54.DataContext = randomLootData[54];
                TableData55.DataContext = randomLootData[55];
                TableData56.DataContext = randomLootData[56];
                TableData57.DataContext = randomLootData[57];
                TableData58.DataContext = randomLootData[58];
                TableData59.DataContext = randomLootData[59];
                TableData60.DataContext = randomLootData[60];
                TableData61.DataContext = randomLootData[61];
                TableData62.DataContext = randomLootData[62];
                TableData63.DataContext = randomLootData[63];
                TableData64.DataContext = randomLootData[64];
                TableData65.DataContext = randomLootData[65];
                TableData66.DataContext = randomLootData[66];
                TableData67.DataContext = randomLootData[67];
                TableData68.DataContext = randomLootData[68];
            }

            fileReader.Close();
        }
    }
}
