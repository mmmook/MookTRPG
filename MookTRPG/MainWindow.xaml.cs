using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MookTRPG
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        int frequency = 1;
        int addedValue = 0;

        private string bgTime = "";
        private string gender = "";
        private string pWeight = "";
        public Dictionary<string, string> completedOccupation = new Dictionary<string, string>();
        private Occupation occupation = null;

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        #region 骰子

        private void FrequencyReduce_Click(object sender, RoutedEventArgs e)
        {
            frequency--;
            if (frequency < 1)
            {
                frequency = 1;
            }
            Frequency.Content = string.Format("{0}d", frequency);
        }

        private void FrequencyAdd_Click(object sender, RoutedEventArgs e)
        {
            frequency++;
            Frequency.Content = string.Format("{0}d", frequency);
        }

        private void AddedValueReduce_Click(object sender, RoutedEventArgs e)
        {
            addedValue--;
            if (addedValue < 0)
            {
                addedValue = 0;
            }
            AddedValue.Content = string.Format("+{0}", addedValue);
        }

        private void AddedValueAdd_Click(object sender, RoutedEventArgs e)
        {
            addedValue++;
            AddedValue.Content = string.Format("+{0}", addedValue);
        }

        private void D2_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 3);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d2+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d2";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        private void D3_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 4);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d3+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d3";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        private void D4_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 5);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d4+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d4";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        private void D6_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 7);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d6+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d6";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        private void D8_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 9);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d8+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d8";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        private void D10_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 11);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d10+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d10";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        private void D12_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 13);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d12+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d12";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        private void D20_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 21);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d20+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d20";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        private void D100_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            string numStr = "";

            for (int i = 0; i < frequency; i++)
            {
                int nn = Roll.random.Next(1, 101);
                num += nn;
                numStr += nn + ", ";
            }
            if (addedValue != 0)
            {
                dNum.Content = frequency + "d100+" + addedValue;
            }
            else
            {
                dNum.Content = frequency + "d100";
            }
            TotalValue.Content = num + addedValue;
            dNumPart.Content = numStr.Substring(0, numStr.Length - 1);
        }

        #endregion


        #region 创建人物卡

        private void Init()
        {
            if (!Directory.Exists(Environment.CurrentDirectory + "/Output"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "/Output");
            if (!File.Exists(Environment.CurrentDirectory + "/Output/COC7角色卡.xlsx"))
                Utility.CopyFile(Environment.CurrentDirectory + "/Template/Template.xlsx", Environment.CurrentDirectory + "/Output/COC7角色卡.xlsx");

            ExcelUtility.InitCharacterCard(Environment.CurrentDirectory + "/Output/COC7角色卡.xlsx");

            CompletedOccupation();
            // 
            InitOccupation();
            
            List<Skill> jineng = IOHelper.LoadListData<Skill>(Environment.CurrentDirectory + "/Template/Skills.json");
            foreach (Skill s in jineng)
            {
                CharacterManager.Skills.Add(s.Name, s);
            }
            List<BranchingSkill> jiyi = IOHelper.LoadListData<BranchingSkill>(Environment.CurrentDirectory + "/Template/ArtsAndCrafts.json");
            foreach (BranchingSkill bs in jiyi)
            {
                CharacterManager.JiYi.Add(bs.Name, bs);
            }
            List<BranchingSkill> kexue = IOHelper.LoadListData<BranchingSkill>(Environment.CurrentDirectory + "/Template/Science.json");
            foreach (BranchingSkill bs in kexue)
            {
                CharacterManager.KeXue.Add(bs.Name, bs);
            }
            List<BranchingSkill> gedou = IOHelper.LoadListData<BranchingSkill>(Environment.CurrentDirectory + "/Template/Combat.json");
            foreach (BranchingSkill bs in gedou)
            {
                CharacterManager.GeDou.Add(bs.Name, bs);
            }
            List<BranchingSkill> sheji = IOHelper.LoadListData<BranchingSkill>(Environment.CurrentDirectory + "/Template/Shooting.json");
            foreach (BranchingSkill bs in sheji)
            {
                CharacterManager.SheJi.Add(bs.Name, bs);
            }
            List<BranchingSkill> yuyan = IOHelper.LoadListData<BranchingSkill>(Environment.CurrentDirectory + "/Template/Language.json");
            foreach (BranchingSkill bs in yuyan)
            {
                CharacterManager.YuYan.Add(bs.Name, bs);
            }
            List<BranchingSkill> jiashi = IOHelper.LoadListData<BranchingSkill>(Environment.CurrentDirectory + "/Template/Pilot.json");
            foreach (BranchingSkill bs in jiashi)
            {
                CharacterManager.JiaShi.Add(bs.Name, bs);
            }
            List<BranchingSkill> xueshi = IOHelper.LoadListData<BranchingSkill>(Environment.CurrentDirectory + "/Template/Knowledge.json");
            foreach (BranchingSkill bs in xueshi)
            {
                CharacterManager.XueShi.Add(bs.Name, bs);
            }

            InitMotherTongue();
            InitWeapons();
        }

        private void CompletedOccupation()
        {
            completedOccupation.Add("事务所侦探、保安", "事务所侦探、保安");
            completedOccupation.Add("考古学家（原作向）", "考古学家（原作向）");
            completedOccupation.Add("医生（原作向）", "医生（原作向）");
            completedOccupation.Add("神秘学家", "神秘学家");
            completedOccupation.Add("警方(原作向)-警探", "警方(原作向)-警探");
            completedOccupation.Add("学生、实习生", "警方(原作向)-警探");
        }

        private void InitOccupation()
        {
            List<Occupation> occs = new List<Occupation>();
            for (int i = 0; i < 229; i++)
            {
                Occupation occ = new Occupation();
                occ.ID = Convert.ToInt32(ExcelUtility.GetValue(i + 3, 0, 2));
                occ.Name = ExcelUtility.GetValue(i + 3, 1, 2).ToString();
                occ.CreditRating = ExcelUtility.GetValue(i + 3, 3, 2).ToString();
                occ.SkillPoints = ExcelUtility.GetValue(i + 3, 4, 2).ToString();
                occ.ProfessionalSkills = ExcelUtility.GetValue(i + 3, 6, 2).ToString();
                if (completedOccupation.ContainsKey(occ.Name))
                {
                    occs.Add(occ);
                }
            }
            Occupation.ItemsSource = occs;
        }

        void InitMotherTongue()
        {
            List<General> lans = new List<General>();
            int i = 0;
            foreach (string bstr in CharacterManager.YuYan.Keys)
            {
                General g = new General();
                g.ID = i;
                g.Name = bstr;
                lans.Add(g);
                i++;
            }
            MotherTongue.ItemsSource = lans;
        }

        // 初始化武器
        void InitWeapons()
        {
            



        }

        // 性别
        private void Gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (sender as ComboBox).SelectedItem as ComboBoxItem;
            gender = cbi.Content.ToString();
            Console.WriteLine(cbi.Content);
        }

        // 时代背景
        private void Background_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (sender as ComboBox).SelectedItem as ComboBoxItem;
            bgTime = cbi.Content.ToString();
            Console.WriteLine(cbi.Content);
        }

        // 职业
        private void Occupation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Occupation occ = (sender as ComboBox).SelectedItem as Occupation;
            occupation = occ;
            ProfessionalSkills.Text = occ.ProfessionalSkills;
            CreditRating.Content = occ.CreditRating;
            SkillPoints.Content = occ.SkillPoints;
            InterestSkillPoints.Content = "智力×2";
        }

        // 分配兴趣点
        private void RandomInterestPoints_Checked(object sender, RoutedEventArgs e)
        {
            CharacterManager.randomInterestPoints = (bool)(sender as CheckBox).IsChecked;
            Console.WriteLine(CharacterManager.randomInterestPoints);
        }
        private void RandomInterestPoints_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterManager.randomInterestPoints = (bool)(sender as CheckBox).IsChecked;
            Console.WriteLine(CharacterManager.randomInterestPoints);
        }

        // 母语
        private void MotherTongue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            General my = (sender as ComboBox).SelectedItem as General;
            CharacterManager.motherTongue = my.Name;
            Console.WriteLine(my.Name);
        }

        // 人物倾向
        private void PropensityWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (sender as ComboBox).SelectedItem as ComboBoxItem;
            pWeight = cbi.Content.ToString();
            Console.WriteLine(cbi.Content);
        }

        // 快速创建
        private void QuickCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullName.Text.Trim()))
            {
                MessageBox.Show("姓名为空！");
                return;
            }

            InitInvestigatorInfo();
            // 
            ExcelUtility.InitCharacterCard(Environment.CurrentDirectory + "/Output/COC7角色卡.xlsx");
            // 定位到文件
            System.Diagnostics.Process.Start("Explorer", "/select," + Environment.CurrentDirectory + "\\Output\\" + CharacterManager.character.Name + ".xlsx");
            
        }

        /// <summary>
        /// 初始化调查员信息
        /// </summary>
        public void InitInvestigatorInfo()
        {
            CharacterManager.character = new Character();

            CharacterManager.character.Background = bgTime;
            CharacterManager.character.Name = FullName.Text.Trim();
            CharacterManager.character.Gender = gender;
            CharacterManager.character.Occupation = occupation.Name;
            CharacterManager.character.OccupationID = occupation.ID;

            CharacterManager.character.Age = 25;
            CharacterManager.character.Address = "中国";
            CharacterManager.character.Hometown = "中国";

            CharacterManager.character.PropensityWeight = pWeight;

            string[] pcs = occupation.CreditRating.Split('-');
            CharacterManager.character.PCSMin = Convert.ToInt32(pcs[0]);
            CharacterManager.character.PCSMax = Convert.ToInt32(pcs[1]);
            

            CharacterManager.InitAttribute();
            // 生成人物卡JSON文件
            GenerateCharacterCardJSON();
            GenerateCharacterCardExcel();
        }

        private void GenerateCharacterCardJSON()
        {
            IOHelper.SaveData(Environment.CurrentDirectory + "/Output/" + CharacterManager.character.Name + ".json", CharacterManager.character);
        }

        private void GenerateCharacterCardExcel()
        {
            // 调查员信息
            ExcelUtility.SetValue(CharacterManager.character.Name, 2, 4);
            ExcelUtility.SetValue(CharacterManager.character.Background, 3, 12);
            ExcelUtility.SetValue(CharacterManager.character.Occupation, 4, 4);
            ExcelUtility.SetValue(CharacterManager.character.OccupationID, 4, 12);
            ExcelUtility.SetValue(CharacterManager.character.Age, 5, 4);
            ExcelUtility.SetValue(CharacterManager.character.Gender, 5, 12);
            ExcelUtility.SetValue(CharacterManager.character.Address, 6, 4);
            ExcelUtility.SetValue(CharacterManager.character.Hometown, 6, 12);

            // 属性
            ExcelUtility.SetValue(CharacterManager.character.STR, 2, 20);
            ExcelUtility.SetValue(CharacterManager.character.CON, 4, 20);
            ExcelUtility.SetValue(CharacterManager.character.SIZ, 6, 20);
            ExcelUtility.SetValue(CharacterManager.character.DEX, 2, 26);
            ExcelUtility.SetValue(CharacterManager.character.APP, 4, 26);
            ExcelUtility.SetValue(CharacterManager.character.INT, 6, 26);
            ExcelUtility.SetValue(CharacterManager.character.POW, 2, 32);
            ExcelUtility.SetValue(CharacterManager.character.EDU, 4, 32);
            ExcelUtility.SetValue(CharacterManager.character.Luck, 6, 32);
            // 生命值
            ExcelUtility.SetValue(Convert.ToInt32(ExcelUtility.GetValue(9, 6)), 9, 4);
            // 理智
            ExcelUtility.SetValue(CharacterManager.character.POW, 9, 13);
            // 魔法值
            ExcelUtility.SetValue(Convert.ToInt32(ExcelUtility.GetValue(9, 24)), 9, 22);

            SetCharacterCardSkills();

            try
            {
                ExcelUtility.SaveCharacterCard(Environment.CurrentDirectory + "/Output/" + CharacterManager.character.Name + ".xlsx");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        /// <summary>
        /// 设置角色卡技能点
        /// </summary>
        public void SetCharacterCardSkills()
        {
            foreach (string str in CharacterManager.character.Skills.Keys)
            {
                switch (str)
                {
                    case "会计":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["会计"].Points, 15, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["会计"].InterestPoints, 15, 15);
                        break;
                    case "人类学":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["人类学"].Points, 16, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["人类学"].InterestPoints, 16, 15);
                        break;
                    case "估价":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["估价"].Points, 17, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["估价"].InterestPoints, 17, 15);
                        break;
                    case "考古学":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["考古学"].Points, 18, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["考古学"].InterestPoints, 18, 15);
                        break;
                    case "技艺":
                        int jynum = 0;
                        foreach (string bstr in CharacterManager.character.Skills["技艺"].BranchSkill.Keys)
                        {
                            ExcelUtility.SetValue(CharacterManager.character.Skills["技艺"].BranchSkill[bstr].Name, 19 + jynum, 7);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["技艺"].BranchSkill[bstr].Points, 19 + jynum, 13);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["技艺"].BranchSkill[bstr].InterestPoints, 19 + jynum, 15);
                            jynum++;
                        }
                        break;
                    case "取悦":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["取悦"].Points, 22, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["取悦"].InterestPoints, 22, 15);
                        break;
                    case "攀爬":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["攀爬"].Points, 23, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["攀爬"].InterestPoints, 23, 15);
                        break;
                    case "计算机使用":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["计算机使用"].Points, 24, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["计算机使用"].InterestPoints, 24, 15);
                        break;
                    case "信用评级":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["信用评级"].Points, 25, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["信用评级"].InterestPoints, 25, 15);
                        break;
                    case "克苏鲁神话":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["克苏鲁神话"].Points, 26, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["克苏鲁神话"].InterestPoints, 26, 15);
                        break;
                    case "乔装":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["乔装"].Points, 27, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["乔装"].InterestPoints, 27, 15);
                        break;
                    case "闪避":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["闪避"].Points, 28, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["闪避"].InterestPoints, 28, 15);
                        break;
                    case "汽车驾驶":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["汽车驾驶"].Points, 29, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["汽车驾驶"].InterestPoints, 29, 15);
                        break;
                    case "电气维修":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["电气维修"].Points, 30, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["电气维修"].InterestPoints, 30, 15);
                        break;
                    case "电子学":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["电子学"].Points, 31, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["电子学"].InterestPoints, 31, 15);
                        break;
                    case "话术":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["话术"].Points, 32, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["话术"].InterestPoints, 32, 15);
                        break;
                    case "格斗":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["格斗"].BranchSkill["斗殴"].Points, 33, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["格斗"].BranchSkill["斗殴"].InterestPoints, 33, 15);
                        int gdnum = 0;
                        foreach (string bstr in CharacterManager.character.Skills["格斗"].BranchSkill.Keys)
                        {
                            if(bstr != "斗殴")
                            {
                                ExcelUtility.SetValue(CharacterManager.character.Skills["格斗"].BranchSkill[bstr].Name, 34 + gdnum, 7);
                                ExcelUtility.SetValueNum(CharacterManager.character.Skills["格斗"].BranchSkill[bstr].Points, 34 + gdnum, 13);
                                ExcelUtility.SetValueNum(CharacterManager.character.Skills["格斗"].BranchSkill[bstr].InterestPoints, 34 + gdnum, 15);
                                gdnum++;
                            }
                        }
                        break;
                    case "射击":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["射击"].BranchSkill["手枪"].Points, 37, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["射击"].BranchSkill["手枪"].InterestPoints, 37, 15);
                        int sjnum = 0;
                        foreach (string bstr in CharacterManager.character.Skills["射击"].BranchSkill.Keys)
                        {
                            if (bstr != "手枪")
                            {
                                ExcelUtility.SetValue(CharacterManager.character.Skills["射击"].BranchSkill[bstr].Name, 38 + sjnum, 7);
                                ExcelUtility.SetValueNum(CharacterManager.character.Skills["射击"].BranchSkill[bstr].Points, 38 + sjnum, 13);
                                ExcelUtility.SetValueNum(CharacterManager.character.Skills["射击"].BranchSkill[bstr].InterestPoints, 38 + sjnum, 15);
                                sjnum++;
                            }
                        }
                        break;
                    case "急救":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["急救"].Points, 41, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["急救"].InterestPoints, 41, 15);
                        break;
                    case "历史":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["历史"].Points, 42, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["历史"].InterestPoints, 42, 15);
                        break;
                    case "恐吓":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["恐吓"].Points, 43, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["恐吓"].InterestPoints, 43, 15);
                        break;
                    case "跳跃":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["跳跃"].Points, 44, 13);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["跳跃"].InterestPoints, 44, 15);
                        break;
                    case "外语":
                        int wynum = 0;
                        foreach (string bstr in CharacterManager.character.Skills["外语"].BranchSkill.Keys)
                        {
                            ExcelUtility.SetValue(CharacterManager.character.Skills["外语"].BranchSkill[bstr].Name, 45 + wynum, 7);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["外语"].BranchSkill[bstr].Points, 45 + wynum, 13);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["外语"].BranchSkill[bstr].InterestPoints, 45 + wynum, 15);
                            wynum++;
                        }
                        break;
                    case "母语":
                        foreach (string bstr in CharacterManager.character.Skills["母语"].BranchSkill.Keys)
                        {
                            ExcelUtility.SetValue(CharacterManager.character.Skills["母语"].BranchSkill[bstr].Name, 48, 7);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["母语"].BranchSkill[bstr].Points, 48, 13);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["母语"].BranchSkill[bstr].InterestPoints, 48, 15);
                        }
                        break;
                    case "法律":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["法律"].Points, 15, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["法律"].InterestPoints, 15, 37);
                        break;
                    case "图书馆使用":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["图书馆使用"].Points, 16, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["图书馆使用"].InterestPoints, 16, 37);
                        break;
                    case "聆听":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["聆听"].Points, 17, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["聆听"].InterestPoints, 17, 37);
                        break;
                    case "锁匠":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["锁匠"].Points, 18, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["锁匠"].InterestPoints, 18, 37);
                        break;
                    case "机械维修":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["机械维修"].Points, 19, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["机械维修"].InterestPoints, 19, 37);
                        break;
                    case "医学":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["医学"].Points, 20, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["医学"].InterestPoints, 20, 37);
                        break;
                    case "博物学":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["博物学"].Points, 21, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["博物学"].InterestPoints, 21, 37);
                        break;
                    case "导航":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["导航"].Points, 22, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["导航"].InterestPoints, 22, 37);
                        break;
                    case "神秘学":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["神秘学"].Points, 23, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["神秘学"].InterestPoints, 23, 37);
                        break;
                    case "操作重型机械":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["操作重型机械"].Points, 24, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["操作重型机械"].InterestPoints, 24, 37);
                        break;
                    case "说服":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["说服"].Points, 25, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["说服"].InterestPoints, 25, 37);
                        break;
                    case "驾驶":
                        foreach (string bstr in CharacterManager.character.Skills["驾驶"].BranchSkill.Keys)
                        {
                            ExcelUtility.SetValue(CharacterManager.character.Skills["驾驶"].BranchSkill[bstr].Name, 26, 29);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["驾驶"].BranchSkill[bstr].Points, 26, 35);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["驾驶"].BranchSkill[bstr].InterestPoints, 26, 37);
                        }
                        break;
                    case "精神分析":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["精神分析"].Points, 27, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["精神分析"].InterestPoints, 27, 37);
                        break;
                    case "心理学":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["心理学"].Points, 28, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["心理学"].InterestPoints, 28, 37);
                        break;
                    case "骑术":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["骑术"].Points, 29, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["骑术"].InterestPoints, 29, 37);
                        break;
                    case "科学":
                        int kxnum = 0;
                        foreach (string bstr in CharacterManager.character.Skills["科学"].BranchSkill.Keys)
                        {
                            ExcelUtility.SetValue(CharacterManager.character.Skills["科学"].BranchSkill[bstr].Name, 30 + kxnum, 29);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["科学"].BranchSkill[bstr].Points, 30 + kxnum, 35);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["科学"].BranchSkill[bstr].InterestPoints, 30 + kxnum, 37);
                            kxnum++;
                        }
                        break;
                    case "妙手":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["妙手"].Points, 33, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["妙手"].InterestPoints, 33, 37);
                        break;
                    case "侦察":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["侦察"].Points, 34, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["侦察"].InterestPoints, 34, 37);
                        break;
                    case "潜行":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["潜行"].Points, 35, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["潜行"].InterestPoints, 35, 37);
                        break;
                    case "生存":
                        foreach (string bstr in CharacterManager.character.Skills["生存"].BranchSkill.Keys)
                        {
                            ExcelUtility.SetValue(CharacterManager.character.Skills["生存"].BranchSkill[bstr].Name, 36, 29);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["生存"].BranchSkill[bstr].Points, 36, 35);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["生存"].BranchSkill[bstr].InterestPoints, 36, 37);
                        }
                        break;
                    case "游泳":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["游泳"].Points, 37, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["游泳"].InterestPoints, 37, 37);
                        break;
                    case "投掷":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["投掷"].Points, 38, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["投掷"].InterestPoints, 38, 37);
                        break;
                    case "追踪":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["追踪"].Points, 39, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["追踪"].InterestPoints, 39, 37);
                        break;
                    case "驯兽":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["驯兽"].Points, 40, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["驯兽"].InterestPoints, 40, 37);
                        break;
                    case "潜水":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["潜水"].Points, 41, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["潜水"].InterestPoints, 41, 37);
                        break;
                    case "爆破":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["爆破"].Points, 42, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["爆破"].InterestPoints, 42, 37);
                        break;
                    case "读唇":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["读唇"].Points, 43, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["读唇"].InterestPoints, 43, 37);
                        break;
                    case "催眠":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["催眠"].Points, 44, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["催眠"].InterestPoints, 44, 37);
                        break;
                    case "炮术":
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["炮术"].Points, 45, 35);
                        ExcelUtility.SetValueNum(CharacterManager.character.Skills["炮术"].InterestPoints, 45, 37);
                        break;
                    case "学识":
                        foreach (string bstr in CharacterManager.character.Skills["学识"].BranchSkill.Keys)
                        {
                            ExcelUtility.SetValue(CharacterManager.character.Skills["学识"].BranchSkill[bstr].Name, 46, 29);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["学识"].BranchSkill[bstr].Points, 46, 35);
                            ExcelUtility.SetValueNum(CharacterManager.character.Skills["学识"].BranchSkill[bstr].InterestPoints, 46, 37);
                        }
                        break;
                }
            }
        }


        #endregion

        
    }
}
