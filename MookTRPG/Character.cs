using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MookTRPG
{
    public class Character
    {
        // 调查员信息
        public string Background { get; set; }
        public string Name { get; set; }
        public string Player { get; set; }
        public string Occupation { get; set; }
        public int OccupationID { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Hometown { get; set; }

        // 属性

        /// <summary>
        /// 力量
        /// </summary>
        public int STR { get; set; }
        /// <summary>
        /// 体质
        /// </summary>
        public int CON { get; set; }
        /// <summary>
        /// 体型
        /// </summary>
        public int SIZ { get; set; }
        /// <summary>
        /// 敏捷
        /// </summary>
        public int DEX { get; set; }
        /// <summary>
        /// 外貌
        /// </summary>
        public int APP { get; set; }
        /// <summary>
        /// 教育
        /// </summary>
        public int EDU { get; set; }
        /// <summary>
        /// 智力或灵感
        /// </summary>
        public int INT { get; set; }
        /// <summary>
        /// 意志
        /// </summary>
        public int POW { get; set; }
        public int Luck { get; set; }
        /// <summary>
        /// 移动
        /// </summary>
        public int MOV { get; set; }
        public int MOVAValue { get; set; }

        public string Head { get; set; }

        public int HitPoints { get; set; }
        public int HitPointsMax { get; set; }
        public int Sanity { get; set; }
        public int SanityMax { get; set; }
        public int MagicPoints { get; set; }
        public int MagicPointsMax { get; set; }

        /// <summary>
        /// 健康，昏迷，重伤，濒死
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 神志清醒，临时性疯狂，不定性疯狂，永久性疯狂
        /// </summary>
        public string SpecialState { get; set; }

        // 人物倾向权重
        public string PropensityWeight { get; set; }


        // 技能表

        public Dictionary<string, Skill> Skills { get; set; }


        /// <summary>
        /// 职业信用范围,最小值
        /// </summary>
        public int PCSMin { get; set; }
        /// <summary>
        /// 职业信用范围,最大值
        /// </summary>
        public int PCSMax { get; set; }
        /// <summary>
        /// 剩余职业点
        /// </summary>
        public int RemainingOccupationPoints { get; set; }
        /// <summary>
        /// 剩余兴趣点
        /// </summary>
        public int ResidualInterestPoints { get; set; }

        // 格斗

        public string DamageBonus { get; set; }
        public int Build { get; set; }
        public int Dodge { get; set; }

        public string[] WuQi { get; set; }
        public string[] WuQiGeneral { get; set; }
        public string[] WuQiHurt { get; set; }
        public string[] WuQiRange { get; set; }
        public string[] WuQiFrequency { get; set; }
        public string[] WuQiLoadingCapacity { get; set; }
        public string[] WuQiFaultValue { get; set; }

        // 背景故事

        public string XingXiangMiaoShu { get; set; }
        public string SiXiangYuXinNian { get; set; }
        public string ZhongYaoZhiRen { get; set; }
        public string YiYiFeiFanZhiDi { get; set; }
        public string BaoGuiZhiWu { get; set; }
        public string TeZhi { get; set; }
        public string ChuangSHangHeSHangBa { get; set; }
        public string GongJuZhengHeGuangZaoZHeng { get; set; }
        public string DianJiFaShuHeShenHuaZaoWu { get; set; }
        public string DiSanLeiJieShu { get; set; }
        public string ZhuangBeiHeWuPin { get; set; }

        public int XiaoFeiShuiPing { get; set; }
        public int XianJin { get; set; }
        public int ZiChan { get; set; }
        public int ZiChanXiangShu { get; set; }

        public string JingLiMoZu { get; set; }
        public string RenWuBianHuaMiaoShu { get; set; }


        public string[] TongBanJueSe { get; set; }
        public string[] TongBanWanJia { get; set; }
    }
}
