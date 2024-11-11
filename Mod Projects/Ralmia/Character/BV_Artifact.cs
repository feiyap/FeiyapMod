using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ralmia
{
    class BV_Artifact
    {
        public int UseNum = 0;

        public static List<Skill> haveType = new List<Skill>
        {
        };

        public void checkNewType(Skill skillD)
        {
            bool isHave = false;
            foreach (Skill sk in haveType)
            {
                if (sk == skillD)
                {
                    isHave = true;
                }
            }

            if (!isHave)
            {
                haveType.Add(skillD);
                UseNum++;
            }
        }
    }
}
