using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace YasakaKanano
{
    public class BV_Kanano_P
    {
        public List<string> yuzhu = new List<string> { };

        public int getYuzhuLevel(BattleChar bc)
        {
            if (bc.BuffFind("B_Kanano_4"))
            {
                return bc.BuffReturn("B_Kanano_4").StackNum + 1;
            }
            return 1;
        }

        public void addYuzhuBuff(string buffid, BattleChar bc)
        {
            if (bc.BuffFind("B_Kanano_Rare_1"))
            {
                if (yuzhu.Count >= 2)
                {
                    bc.BuffReturn(yuzhu[0])?.SelfDestroy();
                    yuzhu.RemoveAt(0);
                    bc.BuffAdd(buffid, bc);
                    yuzhu.Add(buffid);
                }
                else
                {
                    bc.BuffAdd(buffid, bc);
                    yuzhu.Add(buffid);
                }
            }
            else
            {
                if (!bc.BuffFind(buffid))
                {
                    if (yuzhu.Count >= 1)
                    {
                        bc.BuffReturn(yuzhu[0])?.SelfDestroy();
                        yuzhu.RemoveAt(0);
                        bc.BuffAdd(buffid, bc);
                        yuzhu.Add(buffid);
                    }
                    else
                    {
                        bc.BuffAdd(buffid, bc);
                        yuzhu.Add(buffid);
                    }
                }
            }
        }
    }
}
