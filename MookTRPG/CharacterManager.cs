using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MookTRPG
{
    public static class CharacterManager
    {
        /// <summary>
        /// 角色
        /// </summary>
        public static Character character = new Character();

        public static Dictionary<string, Skill> Skills = new Dictionary<string, Skill>();
        public static Dictionary<string, BranchingSkill> JiYi = new Dictionary<string, BranchingSkill>();
        public static Dictionary<string, BranchingSkill> KeXue = new Dictionary<string, BranchingSkill>();
        public static Dictionary<string, BranchingSkill> GeDou = new Dictionary<string, BranchingSkill>();
        public static Dictionary<string, BranchingSkill> SheJi = new Dictionary<string, BranchingSkill>();
        public static Dictionary<string, BranchingSkill> YuYan = new Dictionary<string, BranchingSkill>();
        public static Dictionary<string, BranchingSkill> JiaShi = new Dictionary<string, BranchingSkill>();
        public static Dictionary<string, BranchingSkill> XueShi = new Dictionary<string, BranchingSkill>();
        public static Dictionary<string, Weapons> Weapons = new Dictionary<string, Weapons>();

        public static string motherTongue = "";
        public static bool randomInterestPoints = false;

        /// <summary>
        /// 初始化技能点最大值
        /// </summary>
        public const int INITSKILLSPOINTSMAX = 80;


        /// <summary>
        /// 初始化属性
        /// </summary>
        public static void InitAttribute()
        {
            character.STR = RollSTR();
            character.CON = RollCON();
            character.SIZ = RollSIZ();
            character.DEX = RollDEX();
            character.APP = RollAPP();
            character.INT = RollINT();
            character.POW = RollPOW();
            character.EDU = RollEDU();
            character.Luck = RollLuck();

            character.MOVAValue = 0;
            
            if (character.Age >= 15 && character.Age <= 19)
            {
                Random ran = new Random();
                int num = ran.Next(1, 6);
                character.STR -= num;
                character.SIZ -= (5 - num);
                character.EDU -= 5;

                int luc = RollLuck();
                if (luc > character.Luck)
                {
                    character.Luck = luc;
                }

            }
            else if (character.Age >= 20 && character.Age <= 39)
            {
                int ver = Roll.D100();
                if (ver > character.EDU)
                {
                    int val = Roll.D10();
                    AddEDU(val);
                }
            }
            else if (character.Age >= 40 && character.Age <= 49)
            {
                for (int i = 0; i < 2; i++)
                {
                    int ver = Roll.D100();
                    if (ver > character.EDU)
                    {
                        int val = Roll.D10();
                        AddEDU(val);
                    }
                }
                character.APP -= 5;
                character.STR -= 1;
                character.CON -= 2;
                character.DEX -= 2;
                character.MOVAValue -= 1;
            }
            else if (character.Age >= 50 && character.Age <= 59)
            {
                for (int i = 0; i < 3; i++)
                {
                    int ver = Roll.D100();
                    if (ver > character.EDU)
                    {
                        int val = Roll.D10();
                        AddEDU(val);
                    }
                }
                character.APP -= 10;
                character.STR -= 3;
                character.CON -= 3;
                character.DEX -= 4;
                character.MOVAValue -= 2;
            }
            else if (character.Age >= 60 && character.Age <= 69)
            {
                for (int i = 0; i < 4; i++)
                {
                    int ver = Roll.D100();
                    if (ver > character.EDU)
                    {
                        int val = Roll.D10();
                        AddEDU(val);
                    }
                }
                character.APP -= 15;
                character.STR -= 6;
                character.CON -= 6;
                character.DEX -= 8;
                character.MOVAValue -= 3;
            }
            else if (character.Age >= 70 && character.Age <= 79)
            {
                for (int i = 0; i < 4; i++)
                {
                    int ver = Roll.D100();
                    if (ver > character.EDU)
                    {
                        int val = Roll.D10();
                        AddEDU(val);
                    }
                }
                character.APP -= 20;
                character.STR -= 12;
                character.CON -= 12;
                character.DEX -= 16;
                character.MOVAValue -= 4;
            }
            else if (character.Age >= 80 && character.Age <= 89)
            {
                for (int i = 0; i < 4; i++)
                {
                    int ver = Roll.D100();
                    if (ver > character.EDU)
                    {
                        int val = Roll.D10();
                        AddEDU(val);
                    }
                }
                character.APP -= 25;
                character.STR -= 24;
                character.CON -= 24;
                character.DEX -= 32;
                character.MOVAValue -= 5;
            }

            character.HitPointsMax = HPMax();
            character.HitPoints = character.HitPointsMax;
            character.SanityMax = 99;
            character.Sanity = character.POW;
            character.MagicPointsMax = MPMax();
            character.MagicPoints = character.MagicPointsMax;

            character.State = "健康";
            character.SpecialState = "神志清醒";

            if (character.STR < character.SIZ && character.DEX < character.SIZ)
            {
                character.MOVAValue -= 1;
            }
            if (character.STR > character.SIZ && character.DEX > character.SIZ)
            {
                character.MOVAValue += 1;
            }
            character.MOV = 8 + character.MOVAValue;

            InitSkills();
        }

        /// <summary>
        /// Roll 力量 3D6×5
        /// </summary>
        /// <returns></returns>
        public static int RollSTR()
        {
            int num = Roll.D6(3) * 5;
            Console.WriteLine("力量：" + num);
            return num;
        }

        /// <summary>
        /// Roll 体质 3D6×5
        /// </summary>
        /// <returns></returns>
        public static int RollCON()
        {
            int num = Roll.D6(3) * 5;
            Console.WriteLine("体质：" + num);
            return num;
        }

        /// <summary>
        /// Roll 体型 (2D6+6)×5
        /// </summary>
        /// <returns></returns>
        public static int RollSIZ()
        {
            int num = (Roll.D6(2) + 6) * 5;
            Console.WriteLine("体型：" + num);
            return num;
        }

        /// <summary>
        /// Roll 敏捷 3D6×5
        /// </summary>
        /// <returns></returns>
        public static int RollDEX()
        {
            int num = Roll.D6(3) * 5;
            Console.WriteLine("敏捷：" + num);
            return num;
        }

        /// <summary>
        /// Roll 外貌 3D6×5
        /// </summary>
        /// <returns></returns>
        public static int RollAPP()
        {
            int num = Roll.D6(3) * 5;
            Console.WriteLine("外貌：" + num);
            return num;
        }

        /// <summary>
        /// Roll 智力 3D6×5
        /// </summary>
        /// <returns></returns>
        public static int RollINT()
        {
            int num = (Roll.D6(2) + 6) * 5;
            Console.WriteLine("智力：" + num);
            return num;
        }

        /// <summary>
        /// Roll 意志 3D6×5
        /// </summary>
        /// <returns></returns>
        public static int RollPOW()
        {
            int num = Roll.D6(3) * 5;
            Console.WriteLine("意志：" + num);
            return num;
        }

        /// <summary>
        /// Roll 教育 3D6×5
        /// </summary>
        /// <returns></returns>
        public static int RollEDU()
        {
            int num = (Roll.D6(2) + 6) * 5;
            Console.WriteLine("教育：" + num);
            return num;
        }

        /// <summary>
        /// Roll 幸运 3D6×5
        /// </summary>
        /// <returns></returns>
        public static int RollLuck()
        {
            int num = Roll.D6(3) * 5;
            Console.WriteLine("幸运：" + num);
            return num;
        }



        public static void InitSkills()
        {
            // 兴趣点
            character.ResidualInterestPoints = character.INT * 2;

            character.Skills = new Dictionary<string, Skill>();

            character.Skills.Add("信用评级", Skills["信用评级"]);
            character.Skills.Add("克苏鲁神话", Skills["克苏鲁神话"]);
            
            character.Skills.Add("母语", Skills["母语"]);
            character.Skills["母语"].BranchSkill = new Dictionary<string, BranchingSkill>();
            BranchingSkill my = new BranchingSkill();
            my.Name = motherTongue;
            my.BasePoints = character.EDU;
            character.Skills["母语"].BranchSkill.Add(my.Name, my);

            switch (character.Occupation)
            {
                case "事务所侦探、保安":
                    事务所侦探();
                    break;
                case "考古学家（原作向）":
                    考古学家();
                    break;
                case "医生（原作向）":
                    医生();
                    break;
                case "神秘学家":
                    神秘学家();
                    break;
                case "警方(原作向)-警探":
                    警探();
                    break;
                case "学生、实习生":
                    学生();
                    break;
            }

            InitAssignSkillPoints();

            if (!character.Skills.ContainsKey("闪避"))
            {
                character.Skills.Add("闪避", Skills["闪避"]);
                character.Skills["闪避"].BasePoints = character.DEX / 2;
            }

            if (!character.Skills.ContainsKey("格斗"))
            {
                character.Skills.Add("格斗", Utility.CopySkill(Skills["格斗"]));
                character.Skills["格斗"].BranchSkill = new Dictionary<string, BranchingSkill>();
                character.Skills["格斗"].BranchSkill.Add("斗殴", Utility.CopySkill(GeDou["斗殴"]));
            }
            else
            {
                if (!character.Skills["格斗"].BranchSkill.ContainsKey("斗殴"))
                {
                    character.Skills["格斗"].BranchSkill = new Dictionary<string, BranchingSkill>();
                    character.Skills["格斗"].BranchSkill.Add("斗殴", Utility.CopySkill(GeDou["斗殴"]));
                }
            }

            if (!character.Skills.ContainsKey("射击"))
            {
                character.Skills.Add("射击", Utility.CopySkill(Skills["射击"]));
                character.Skills["射击"].BranchSkill = new Dictionary<string, BranchingSkill>();
                character.Skills["射击"].BranchSkill.Add("手枪", Utility.CopySkill(SheJi["手枪"]));
            }
            else
            {
                if (!character.Skills["射击"].BranchSkill.ContainsKey("手枪"))
                {
                    character.Skills["射击"].BranchSkill = new Dictionary<string, BranchingSkill>();
                    character.Skills["射击"].BranchSkill.Add("手枪", Utility.CopySkill(SheJi["手枪"]));
                }
            }

            // 分配兴趣点
            if (randomInterestPoints)
            {
                InitAssignInterestSkillPoints();
            }

            InitFighting();

        }

        /// <summary>
        /// 初始化分配技能点
        /// </summary>
        private static void InitAssignSkillPoints()
        {
            character.Skills["信用评级"].Points = character.PCSMax / 2;
            character.RemainingOccupationPoints -= character.Skills["信用评级"].Points;
            while (character.RemainingOccupationPoints > 0)
            {
                SkillWeight();
            }
            /*new Thread(() => {
                while (character.RemainingOccupationPoints > 0)
                {
                    SkillWeight();
                }
            }).Start();*/
        }

        /// <summary>
        /// 初始化兴趣技能点
        /// </summary>
        private static void InitAssignInterestSkillPoints()
        {
            List<string> skillNames = new List<string>(Skills.Keys);
            while (character.ResidualInterestPoints > 0)
            {
                int sjNum = Roll.random.Next(0, skillNames.Count);
                if (skillNames[sjNum] == "信用评级" || skillNames[sjNum] == "克苏鲁神话" || skillNames[sjNum] == "母语")
                    continue;

                if (Skills[skillNames[sjNum]].HaveBranchSkill == false)
                {
                    if (character.Skills.ContainsKey(skillNames[sjNum]))
                    {
                        if (character.Skills[skillNames[sjNum]].Points <= 40 && character.Skills[skillNames[sjNum]].InterestPoints <= 30)
                        {
                            AssignInterestSkillPoints(skillNames[sjNum], 1);
                        }
                    }
                    else
                    {
                        character.Skills.Add(skillNames[sjNum], Utility.CopySkill(Skills[skillNames[sjNum]]));
                        AssignInterestSkillPoints(skillNames[sjNum], 1);
                    }
                }
                
            }
        }

        /// <summary>
        /// 技能权重
        /// </summary>
        public static void SkillWeight()
        {
            foreach (string str in character.Skills.Keys)
            {
                if (str == "信用评级" || str == "克苏鲁神话" || str == "母语")
                    continue;

                if (character.PropensityWeight == "均衡")
                {
                    AssignSkillPoints(str, 1);
                }
                else
                {
                    if (character.Skills[str].Type == character.PropensityWeight)
                    {
                        AssignSkillPoints(str, 2);
                    }
                    else
                    {
                        AssignSkillPoints(str, 1);
                    }
                }

                
            }
        }

        /// <summary>
        /// 分配技能点
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dNum"></param>
        private static void AssignSkillPoints(string str, int dNum)
        {
            if (character.Skills[str].HaveBranchSkill)
            {
                foreach (string bkstr in character.Skills[str].BranchSkill.Keys)
                {
                    int num = Roll.D6(dNum) * 5;
                    // 足够剩余点
                    if (character.RemainingOccupationPoints >= num)
                    {
                        int tv = GetTotalValue(str, bkstr);
                        if ((tv + num) < INITSKILLSPOINTSMAX)
                        {
                            character.Skills[str].BranchSkill[bkstr].Points += num;
                            character.RemainingOccupationPoints -= num;
                        }
                        else
                        {
                            if ((INITSKILLSPOINTSMAX - tv) > 0)
                            {
                                character.Skills[str].BranchSkill[bkstr].Points += (INITSKILLSPOINTSMAX - tv);
                                character.RemainingOccupationPoints -= (INITSKILLSPOINTSMAX - tv);
                            }
                        }
                    }
                    else if (character.RemainingOccupationPoints > 0)
                    {
                        int tv = GetTotalValue(str, bkstr);
                        if ((tv + character.RemainingOccupationPoints) < INITSKILLSPOINTSMAX)
                        {
                            character.Skills[str].BranchSkill[bkstr].Points += character.RemainingOccupationPoints;
                            character.RemainingOccupationPoints -= character.RemainingOccupationPoints;
                        }
                        else
                        {
                            if ((INITSKILLSPOINTSMAX - tv) > 0)
                            {
                                character.Skills[str].BranchSkill[bkstr].Points += (INITSKILLSPOINTSMAX - tv);
                                character.RemainingOccupationPoints -= (INITSKILLSPOINTSMAX - tv);
                            }
                        }

                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                int num = Roll.D6(dNum) * 5;
                if (character.RemainingOccupationPoints >= num)
                {
                    int tv = GetTotalValue(str);
                    if ((tv + num) < INITSKILLSPOINTSMAX)
                    {
                        character.Skills[str].Points += num;
                        character.RemainingOccupationPoints -= num;
                    }
                    else
                    {
                        if ((INITSKILLSPOINTSMAX - tv) > 0)
                        {
                            character.Skills[str].Points += (INITSKILLSPOINTSMAX - tv);
                            character.RemainingOccupationPoints -= (INITSKILLSPOINTSMAX - tv);
                        }
                    }
                }
                else if(character.RemainingOccupationPoints > 0)
                {
                    int tv = GetTotalValue(str);
                    if ((tv + character.RemainingOccupationPoints) < INITSKILLSPOINTSMAX)
                    {
                        character.Skills[str].Points += character.RemainingOccupationPoints;
                        character.RemainingOccupationPoints -= character.RemainingOccupationPoints;
                    }
                    else
                    {
                        if ((INITSKILLSPOINTSMAX - tv) > 0)
                        {
                            character.Skills[str].Points += (INITSKILLSPOINTSMAX - tv);
                            character.RemainingOccupationPoints -= (INITSKILLSPOINTSMAX - tv);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 分配兴趣点
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dNum"></param>
        private static void AssignInterestSkillPoints(string str, int dNum)
        {
            if (character.Skills[str].HaveBranchSkill)
            {
                foreach (string bkstr in character.Skills[str].BranchSkill.Keys)
                {
                    if (character.ResidualInterestPoints <= 0)
                    {
                        break;
                    }
                    int num = Roll.D6(dNum) * 5;
                    // 足够剩余点
                    if (character.ResidualInterestPoints >= num)
                    {
                        int tv = GetTotalValue(str, bkstr);
                        if ((tv + num) < INITSKILLSPOINTSMAX)
                        {
                            character.Skills[str].BranchSkill[bkstr].InterestPoints += num;
                            character.ResidualInterestPoints -= num;
                        }
                        else
                        {
                            if ((INITSKILLSPOINTSMAX - tv) > 0)
                            {
                                character.Skills[str].BranchSkill[bkstr].InterestPoints += (INITSKILLSPOINTSMAX - tv);
                                character.ResidualInterestPoints -= (INITSKILLSPOINTSMAX - tv);
                            }
                        }
                    }
                    else if (character.ResidualInterestPoints > 0)
                    {
                        int tv = GetTotalValue(str, bkstr);
                        if ((tv + character.ResidualInterestPoints) < INITSKILLSPOINTSMAX)
                        {
                            character.Skills[str].BranchSkill[bkstr].InterestPoints += character.ResidualInterestPoints;
                            character.ResidualInterestPoints -= character.ResidualInterestPoints;
                        }
                        else
                        {
                            if ((INITSKILLSPOINTSMAX - tv) > 0)
                            {
                                character.Skills[str].BranchSkill[bkstr].InterestPoints += (INITSKILLSPOINTSMAX - tv);
                                character.ResidualInterestPoints -= (INITSKILLSPOINTSMAX - tv);
                            }
                        }

                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                if (character.ResidualInterestPoints <= 0)
                {
                    return ;
                }
                int num = Roll.D6(dNum) * 5;
                if (character.ResidualInterestPoints >= num)
                {
                    int tv = GetTotalValue(str);
                    if ((tv + num) < INITSKILLSPOINTSMAX)
                    {
                        character.Skills[str].InterestPoints += num;
                        character.ResidualInterestPoints -= num;
                    }
                    else
                    {
                        if ((INITSKILLSPOINTSMAX - tv) > 0)
                        {
                            character.Skills[str].InterestPoints += (INITSKILLSPOINTSMAX - tv);
                            character.ResidualInterestPoints -= (INITSKILLSPOINTSMAX - tv);
                        }
                    }
                }
                else if (character.ResidualInterestPoints > 0)
                {
                    int tv = GetTotalValue(str);
                    if ((tv + character.ResidualInterestPoints) < INITSKILLSPOINTSMAX)
                    {
                        character.Skills[str].InterestPoints += character.ResidualInterestPoints;
                        character.ResidualInterestPoints -= character.ResidualInterestPoints;
                    }
                    else
                    {
                        if ((INITSKILLSPOINTSMAX - tv) > 0)
                        {
                            character.Skills[str].InterestPoints += (INITSKILLSPOINTSMAX - tv);
                            character.ResidualInterestPoints -= (INITSKILLSPOINTSMAX - tv);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 初始战斗属性
        /// </summary>
        private static void InitFighting()
        {
            character.Dodge = GetTotalValue("闪避");

            int sc = character.STR + character.SIZ;
            if (sc >= 2 && sc <= 64)
            {
                character.DamageBonus = "-2";
                character.Build = -2;
            }
            else if (sc >= 65 && sc <= 84)
            {
                character.DamageBonus = "-1";
                character.Build = -1;
            }
            else if (sc >= 85 && sc <= 124)
            {
                character.DamageBonus = "0";
                character.Build = 0;
            }
            else if (sc >= 125 && sc <= 164)
            {
                character.DamageBonus = "+1d4";
                character.Build = 1;
            }
            else if (sc >= 165 && sc <= 204)
            {
                character.DamageBonus = "+1d6";
                character.Build = 2;
            }
            else if (sc >= 205 && sc <= 284)
            {
                character.DamageBonus = "+2d6";
                character.Build = 3;
            }
            else if (sc >= 285 && sc <= 364)
            {
                character.DamageBonus = "+3d6";
                character.Build = 4;
            }
            else if (sc >= 365 && sc <= 444)
            {
                character.DamageBonus = "+4d6";
                character.Build = 5;
            }
            else if (sc >= 445 && sc <= 524)
            {
                character.DamageBonus = "+5d6";
                character.Build = 6;
            }
        }



        /// <summary>
        /// 添加信用评级
        /// </summary>
        public static void AddCreditRating()
        {

        }

        /// <summary>
        /// 力量成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddSTR(int value)
        {
            character.STR += value;
            if (character.STR > 99)
            {
                character.STR = 99;
            }
        }

        /// <summary>
        /// 体质成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddCON(int value)
        {
            character.CON += value;
            if (character.CON > 99)
            {
                character.CON = 99;
            }
        }

        /// <summary>
        /// 体型成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddSIZ(int value)
        {
            character.SIZ += value;
            if (character.SIZ > 99)
            {
                character.SIZ = 99;
            }
        }

        /// <summary>
        /// 敏捷成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddDEX(int value)
        {
            character.DEX += value;
            if (character.DEX > 99)
            {
                character.DEX = 99;
            }
        }

        /// <summary>
        /// 外貌成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddAPP(int value)
        {
            character.APP += value;
            if (character.APP > 99)
            {
                character.APP = 99;
            }
        }

        /// <summary>
        /// 智力成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddINT(int value)
        {
            character.INT += value;
            if (character.INT > 99)
            {
                character.INT = 99;
            }
        }

        /// <summary>
        /// 意志成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddPOW(int value)
        {
            character.POW += value;
            if (character.POW > 99)
            {
                character.POW = 99;
            }
        }

        /// <summary>
        /// 教育成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddEDU(int value)
        {
            character.EDU += value;
            if (character.EDU > 99)
            {
                character.EDU = 99;
            }
        }

        /// <summary>
        /// 幸运成长
        /// </summary>
        /// <param name="value"></param>
        public static void AddLuck(int value)
        {
            character.Luck += value;
            if (character.Luck > 99)
            {
                character.Luck = 99;
            }
        }

        /// <summary>
        /// 恢复生命值
        /// </summary>
        /// <param name="value"></param>
        public static void AddHP(int value)
        {
            character.HitPoints += value;
            if (character.HitPoints > HPMax())
            {
                character.HitPoints = HPMax();
            }
        }

        /// <summary>
        /// 恢复理智
        /// </summary>
        /// <param name="value"></param>
        public static void AddSanity(int value)
        {
            character.Sanity += value;
            if (character.Sanity > SanityMax())
            {
                character.Sanity = SanityMax();
            }
        }

        /// <summary>
        /// 生命值上限
        /// </summary>
        /// <returns></returns>
        public static int HPMax()
        {
            return (character.CON + character.SIZ) / 10;
        }

        /// <summary>
        /// 魔法值上限
        /// </summary>
        /// <returns></returns>
        public static int MPMax()
        {
            return character.POW / 5;
        }

        /// <summary>
        /// 理智上限
        /// </summary>
        /// <returns></returns>
        public static int SanityMax()
        {
            return 99 - GetTotalValue("克苏鲁神话");
        }

        /// <summary>
        /// 获取技能总值
        /// </summary>
        /// <param name="valName"></param>
        /// <param name="branchName"></param>
        /// <returns></returns>
        public static int GetTotalValue(string valName, string branchName = "")
        {
            Skill skill = character.Skills[valName];
            if (skill == null)
            {
                return 0;
            }
            if (skill.HaveBranchSkill)
            {
                BranchingSkill bs = skill.BranchSkill[branchName];
                if (bs == null)
                {
                    return 0;
                }
                return bs.BasePoints + bs.GrowUpPoints + bs.Points + bs.InterestPoints;
            }

            return skill.BasePoints + skill.GrowUpPoints + skill.Points + skill.InterestPoints;
        }



        // 6
        private static void 事务所侦探()
        {
            int num1 = character.EDU * 2;
            int num2 = 0;
            if (character.STR >= character.DEX)
            {
                num2 = character.STR * 2;
            }
            else
            {
                num2 = character.DEX * 2;
            }
            // 剩余职业点
            character.RemainingOccupationPoints = num1 + num2;


            // 一项社交技能（取悦、话术、恐吓、说服）
            int sjnum = Roll.D4();
            switch (sjnum)
            {
                case 1:
                    character.Skills.Add("取悦", Utility.CopySkill(Skills["取悦"]));
                    break;
                case 2:
                    character.Skills.Add("话术", Utility.CopySkill(Skills["话术"]));
                    break;
                case 3:
                    character.Skills.Add("恐吓", Utility.CopySkill(Skills["恐吓"]));
                    break;
                case 4:
                    character.Skills.Add("说服", Utility.CopySkill(Skills["说服"]));
                    break;
            }
            // 格斗（斗殴）
            character.Skills.Add("格斗", Utility.CopySkill(Skills["格斗"]));
            character.Skills["格斗"].BranchSkill = new Dictionary<string, BranchingSkill>();
            character.Skills["格斗"].BranchSkill.Add("斗殴", Utility.CopySkill(GeDou["斗殴"]));
            // 射击
            character.Skills.Add("射击", Utility.CopySkill(Skills["射击"]));
            character.Skills["射击"].BranchSkill = new Dictionary<string, BranchingSkill>();
            character.Skills["射击"].BranchSkill.Add("手枪", Utility.CopySkill(SheJi["手枪"]));

            character.Skills.Add("法律", Utility.CopySkill(Skills["法律"]));
            character.Skills.Add("图书馆使用", Utility.CopySkill(Skills["图书馆使用"]));
            character.Skills.Add("心理学", Utility.CopySkill(Skills["心理学"]));
            character.Skills.Add("潜行", Utility.CopySkill(Skills["潜行"]));
            character.Skills.Add("追踪", Utility.CopySkill(Skills["追踪"]));
        }

        // 11
        static void 考古学家()
        {
            int num1 = character.EDU * 4;
            // 剩余职业点
            character.RemainingOccupationPoints = num1;

            character.Skills.Add("估价", Utility.CopySkill(Skills["估价"]));
            character.Skills.Add("考古学", Utility.CopySkill(Skills["考古学"]));
            character.Skills.Add("历史", Utility.CopySkill(Skills["历史"]));

            // 外语
            character.Skills.Add("外语", Utility.CopySkill(Skills["外语"]));
            character.Skills["外语"].BranchSkill = new Dictionary<string, BranchingSkill>();
            List<string> skillNames = YuYan.Keys.ToList();
            while (true)
            {
                int sjNum = Roll.random.Next(0, skillNames.Count);
                if (character.Skills["母语"].BranchSkill.ContainsKey(skillNames[sjNum]))
                    continue;

                character.Skills["外语"].BranchSkill.Add(skillNames[sjNum], Utility.CopySkill(YuYan[skillNames[sjNum]]));
                break;
            }

            character.Skills.Add("图书馆使用", Utility.CopySkill(Skills["图书馆使用"]));
            character.Skills.Add("侦察", Utility.CopySkill(Skills["侦察"]));
            character.Skills.Add("机械维修", Utility.CopySkill(Skills["机械维修"]));

            // 导航或科学
            int dkqznum = Roll.D2();
            if (dkqznum == 1)
            {
                character.Skills.Add("导航", Utility.CopySkill(Skills["导航"]));
            }
            else if (dkqznum == 2)
            {

                // 科学
                character.Skills.Add("科学", Utility.CopySkill(Skills["科学"]));
                character.Skills["科学"].BranchSkill = new Dictionary<string, BranchingSkill>();
                skillNames = KeXue.Keys.ToList();
                while (true)
                {
                    int sjNum = Roll.random.Next(0, skillNames.Count);
                    if (character.Skills["科学"].BranchSkill.ContainsKey(skillNames[sjNum]))
                        continue;

                    character.Skills["科学"].BranchSkill.Add(skillNames[sjNum], Utility.CopySkill(KeXue[skillNames[sjNum]]));
                    break;
                }
            }

        }

        // 44
        static void 医生()
        {
            int num1 = character.EDU * 4;
            // 剩余职业点
            character.RemainingOccupationPoints = num1;

            character.Skills.Add("急救", Utility.CopySkill(Skills["急救"]));
            character.Skills.Add("医学", Utility.CopySkill(Skills["医学"]));

            // 外语（拉丁文）
            character.Skills.Add("外语", Utility.CopySkill(Skills["外语"]));
            character.Skills["外语"].BranchSkill = new Dictionary<string, BranchingSkill>();
            character.Skills["外语"].BranchSkill.Add("拉丁语", Utility.CopySkill(YuYan["拉丁语"]));

            character.Skills.Add("心理学", Utility.CopySkill(Skills["心理学"]));

            // 科学（生物学、药学）
            character.Skills.Add("科学", Utility.CopySkill(Skills["科学"]));
            character.Skills["科学"].BranchSkill = new Dictionary<string, BranchingSkill>();
            character.Skills["科学"].BranchSkill.Add("生物学", Utility.CopySkill(KeXue["生物学"]));
            character.Skills["科学"].BranchSkill.Add("药学", Utility.CopySkill(KeXue["药学"]));

            // 任两种其他学术或个人特长
            List<string> skillNames = Skills.Keys.ToList();
            for (int i = 0; i < 2; i++)
            {
                while (true)
                {
                    int sjNum = Roll.random.Next(0, skillNames.Count);
                    if (skillNames[sjNum] == "信用评级" || skillNames[sjNum] == "克苏鲁神话" || skillNames[sjNum] == "母语")
                        continue;

                    if (Skills[skillNames[sjNum]].HaveBranchSkill == false)
                    {
                        if (!character.Skills.ContainsKey(skillNames[sjNum]))
                        {
                            character.Skills.Add(skillNames[sjNum], Utility.CopySkill(Skills[skillNames[sjNum]]));
                            break;
                        }
                    }
                }
            }
        }

        //81
        static void 神秘学家()
        {
            int num1 = character.EDU * 4;
            // 剩余职业点
            character.RemainingOccupationPoints = num1;

            character.Skills.Add("人类学", Utility.CopySkill(Skills["人类学"]));
            character.Skills.Add("历史", Utility.CopySkill(Skills["历史"]));
            character.Skills.Add("图书馆使用", Utility.CopySkill(Skills["图书馆使用"]));

            // 一项社交技能（取悦、话术、恐吓、说服）
            int sjnum = Roll.D4();
            switch (sjnum)
            {
                case 1:
                    character.Skills.Add("取悦", Utility.CopySkill(Skills["取悦"]));
                    break;
                case 2:
                    character.Skills.Add("话术", Utility.CopySkill(Skills["话术"]));
                    break;
                case 3:
                    character.Skills.Add("恐吓", Utility.CopySkill(Skills["恐吓"]));
                    break;
                case 4:
                    character.Skills.Add("说服", Utility.CopySkill(Skills["说服"]));
                    break;
            }

            character.Skills.Add("神秘学", Utility.CopySkill(Skills["神秘学"]));

            // 外语
            character.Skills.Add("外语", Utility.CopySkill(Skills["外语"]));
            character.Skills["外语"].BranchSkill = new Dictionary<string, BranchingSkill>();
            List<string> skillNames = YuYan.Keys.ToList();
            while (true)
            {
                int sjNum = Roll.random.Next(0, skillNames.Count);
                if (character.Skills["母语"].BranchSkill.ContainsKey(skillNames[sjNum]))
                    continue;

                character.Skills["外语"].BranchSkill.Add(skillNames[sjNum], Utility.CopySkill(YuYan[skillNames[sjNum]]));
                break;
            }

            // 科学（天文学）
            character.Skills.Add("科学", Utility.CopySkill(Skills["科学"]));
            character.Skills["科学"].BranchSkill = new Dictionary<string, BranchingSkill>();
            character.Skills["科学"].BranchSkill.Add("天文学", Utility.CopySkill(KeXue["天文学"]));

            // 任意一项项其他个人或时代特长
            skillNames = Skills.Keys.ToList();
            while (true)
            {
                int sjNum = Roll.random.Next(0, skillNames.Count);
                if (skillNames[sjNum] == "信用评级" || skillNames[sjNum] == "克苏鲁神话" || skillNames[sjNum] == "母语")
                    continue;

                if (Skills[skillNames[sjNum]].HaveBranchSkill == false)
                {
                    if (!character.Skills.ContainsKey(skillNames[sjNum]))
                    {
                        character.Skills.Add(skillNames[sjNum], Utility.CopySkill(Skills[skillNames[sjNum]]));
                        break;
                    }
                }
            }
        }

        // 89
        private static void 警探()
        {
            int num1 = character.EDU * 2;
            int num2 = 0;
            if (character.STR >= character.DEX)
            {
                num2 = character.STR * 2;
            }
            else
            {
                num2 = character.DEX * 2;
            }
            // 剩余职业点
            character.RemainingOccupationPoints = num1 + num2;

            // 二选一
            int jyqznum = Roll.D2();
            if (jyqznum == 1)
            {
                // 技艺（表演）
                character.Skills.Add("技艺", Utility.CopySkill(Skills["技艺"]));
                character.Skills["技艺"].BranchSkill = new Dictionary<string, BranchingSkill>();
                character.Skills["技艺"].BranchSkill.Add("表演", Utility.CopySkill(JiYi["表演"]));
            }
            else if (jyqznum == 2)
            {
                character.Skills.Add("乔装", Utility.CopySkill(Skills["乔装"]));
            }
            // 射击（手枪）
            character.Skills.Add("射击", Utility.CopySkill(Skills["射击"]));
            character.Skills["射击"].BranchSkill = new Dictionary<string, BranchingSkill>();
            character.Skills["射击"].BranchSkill.Add("手枪", Utility.CopySkill(SheJi["手枪"]));

            character.Skills.Add("法律", Utility.CopySkill(Skills["法律"]));
            character.Skills.Add("聆听", Utility.CopySkill(Skills["聆听"]));

            // 一项社交技能（取悦、话术、恐吓、说服）
            int sjnum = Roll.D4();
            switch (sjnum)
            {
                case 1:
                    character.Skills.Add("取悦", Utility.CopySkill(Skills["取悦"]));
                    break;
                case 2:
                    character.Skills.Add("话术", Utility.CopySkill(Skills["话术"]));
                    break;
                case 3:
                    character.Skills.Add("恐吓", Utility.CopySkill(Skills["恐吓"]));
                    break;
                case 4:
                    character.Skills.Add("说服", Utility.CopySkill(Skills["说服"]));
                    break;
            }

            character.Skills.Add("心理学", Utility.CopySkill(Skills["心理学"]));
            character.Skills.Add("侦察", Utility.CopySkill(Skills["侦察"]));

            // 一项其他技能
            List<string> skillNames = new List<string>(Skills.Keys);
            while (true)
            {
                int sjNum = Roll.random.Next(0, skillNames.Count);
                if (skillNames[sjNum] == "信用评级" || skillNames[sjNum] == "克苏鲁神话" || skillNames[sjNum] == "母语")
                    continue;

                if (Skills[skillNames[sjNum]].HaveBranchSkill == false)
                {
                    if (!character.Skills.ContainsKey(skillNames[sjNum]))
                    {
                        character.Skills.Add(skillNames[sjNum], Utility.CopySkill(Skills[skillNames[sjNum]]));
                        break;
                    }
                }
            }
        }

        // 106
        static void 学生()
        {
            int num1 = character.EDU * 4;
            // 剩余职业点
            character.RemainingOccupationPoints = num1;

            // 外语
            character.Skills.Add("外语", Utility.CopySkill(Skills["外语"]));
            character.Skills["外语"].BranchSkill = new Dictionary<string, BranchingSkill>();
            List<string> skillNames = YuYan.Keys.ToList();
            while (true)
            {
                int sjNum = Roll.random.Next(0, skillNames.Count);
                if (character.Skills["母语"].BranchSkill.ContainsKey(skillNames[sjNum]))
                    continue;

                character.Skills["外语"].BranchSkill.Add(skillNames[sjNum], Utility.CopySkill(YuYan[skillNames[sjNum]]));
                break;
            }
            character.Skills.Add("图书馆使用", Utility.CopySkill(Skills["图书馆使用"]));
            character.Skills.Add("聆听", Utility.CopySkill(Skills["聆听"]));

            // 三个学习的专业
            character.Skills.Add("科学", Utility.CopySkill(Skills["科学"]));
            character.Skills["科学"].BranchSkill = new Dictionary<string, BranchingSkill>();
            skillNames = KeXue.Keys.ToList();
            while (true)
            {
                int sjNum = Roll.random.Next(0, skillNames.Count);
                if (character.Skills["科学"].BranchSkill.ContainsKey(skillNames[sjNum]))
                    continue;

                character.Skills["科学"].BranchSkill.Add(skillNames[sjNum], Utility.CopySkill(KeXue[skillNames[sjNum]]));

                if (character.Skills["科学"].BranchSkill.Count >= 3)
                    break;
            }

            // 任意两项其他个人或时代特长
            skillNames = Skills.Keys.ToList();
            for (int i = 0; i < 2; i++)
            {
                while (true)
                {
                    int sjNum = Roll.random.Next(0, skillNames.Count);
                    if (skillNames[sjNum] == "信用评级" || skillNames[sjNum] == "克苏鲁神话" || skillNames[sjNum] == "母语")
                        continue;

                    if (Skills[skillNames[sjNum]].HaveBranchSkill == false)
                    {
                        if (!character.Skills.ContainsKey(skillNames[sjNum]))
                        {
                            character.Skills.Add(skillNames[sjNum], Utility.CopySkill(Skills[skillNames[sjNum]]));
                            break;
                        }
                    }
                }
            }
        }
    }
}
