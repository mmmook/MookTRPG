using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MookTRPG
{
    public class Skill
    {
        public string Name = "";
        public string Description = "";
        public int BasePoints = 0;
        public int GrowUpPoints = 0;
        public int Points = 0;
        public int InterestPoints = 0;
        public string Type = "";
        public bool HaveBranchSkill = false;
        public Dictionary<string, BranchingSkill> BranchSkill = new Dictionary<string, BranchingSkill>();
    }
}
