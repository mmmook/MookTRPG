using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MookTRPG
{
    public static class Utility
    {

        public static void CopyFile(string sourceFile, string destinationFile)
        {
            FileInfo file = new FileInfo(sourceFile);
            if (file.Exists)
            {
                // true is overwrite 
                file.CopyTo(destinationFile, true);
            }
        }


        public static T DeepCopyByReflect<T>(T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopyByReflect(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }

        public static Skill CopySkill(Skill skill)
        {
            Skill newSkill = new Skill();
            newSkill.Name = skill.Name;
            newSkill.Description = skill.Description;
            newSkill.BasePoints = skill.BasePoints;
            newSkill.Points = skill.Points;
            newSkill.InterestPoints = skill.InterestPoints;
            newSkill.Type = skill.Type;
            newSkill.HaveBranchSkill = skill.HaveBranchSkill;
            newSkill.BranchSkill = skill.BranchSkill;
            return newSkill;
        }

        public static BranchingSkill CopySkill(BranchingSkill bskill)
        {
            BranchingSkill newbskill = new BranchingSkill();
            newbskill.Name = bskill.Name;
            newbskill.Description = bskill.Description;
            newbskill.BasePoints = bskill.BasePoints;
            newbskill.Points = bskill.Points;
            newbskill.InterestPoints = bskill.InterestPoints;
            return newbskill;
        }

    }
}
