using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MookTRPG
{
    public class Occupation
    {
        /// <summary>
        /// 职业序号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 职业名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 信用范围
        /// </summary>
        public string CreditRating { get; set; }
        /// <summary>
        /// 本职技能点
        /// </summary>
        public string SkillPoints { get; set; }
        /// <summary>
        /// 本职技能
        /// </summary>
        public string ProfessionalSkills { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 推荐关系人
        /// </summary>
        public string RecommendRelatedPerson { get; set; }
    }
}
